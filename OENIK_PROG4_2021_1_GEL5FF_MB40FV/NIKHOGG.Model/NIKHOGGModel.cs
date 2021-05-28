// <copyright file="NIKHOGGModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using NIKHOGG.Elements;

    /// <summary>
    /// Model status enumerator.
    /// </summary>
    public enum ModelStatus
    {
        /// <summary>
        /// Main menu.
        /// </summary>
        MainMenu,

        /// <summary>
        /// Start menu.
        /// </summary>
        StartMenu,

        /// <summary>
        /// Save menu.
        /// </summary>
        SavesMenu,

        /// <summary>
        /// Top list.
        /// </summary>
        TopList,

        /// <summary>
        /// Game play.
        /// </summary>
        GamePlay,

        /// <summary>
        /// Paused.
        /// </summary>
        Paused,

        /// <summary>
        /// Loading.
        /// </summary>
        Loading,
    }

    /// <summary>
    /// Implementation of model.
    /// </summary>
    public class NIKHOGGModel : IModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NIKHOGGModel"/> class.
        /// </summary>
        /// <param name="levelWidth">Level width.</param>
        /// <param name="levelHeight">Level height.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public NIKHOGGModel(double levelWidth, double levelHeight, double width, double height)
        {
            this.Status = ModelStatus.GamePlay;
            this.LevelWidth = levelWidth;
            this.LevelHeight = levelHeight;
            this.WindowWidth = width;
            this.WindowHeight = height;
            this.ActualPlayer = 0;
            this.CameraPos = Config.StartingCameraPos;
            this.TimeInTenthsOfSec = 0;
            this.LevelIndicator = new List<Rect>()
            {
                new Rect((this.WindowWidth / 2) - (Config.LevelIndicatorWidth * 3.5) - (Config.LevelIndicatorDistance * 3), Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
                new Rect((this.WindowWidth / 2) - (Config.LevelIndicatorWidth * 2.5) - (Config.LevelIndicatorDistance * 2), Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
                new Rect((this.WindowWidth / 2) - (Config.LevelIndicatorWidth * 1.5) - Config.LevelIndicatorDistance, Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
                new Rect((this.WindowWidth / 2) - (Config.LevelIndicatorWidth * 0.5), Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
                new Rect((this.WindowWidth / 2) + (Config.LevelIndicatorWidth * 0.5) + Config.LevelIndicatorDistance, Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
                new Rect((this.WindowWidth / 2) + (Config.LevelIndicatorWidth * 1.5) + (Config.LevelIndicatorDistance * 2), Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
                new Rect((this.WindowWidth / 2) + (Config.LevelIndicatorWidth * 2.5) + (Config.LevelIndicatorDistance * 3), Config.LevelIndicatorY, Config.LevelIndicatorWidth, Config.LevelIndicatorHeight),
            };
            this.Map = new List<MapPart>();
            this.DeadlyMapParts = new List<MapPart>();
            this.ThrowedWeapons = new List<IWeapon>();
            this.DroppedWeapons = new List<IWeapon>();
            this.WeaponsOnFloor = new List<IWeapon>();
            this.Arrows = new List<Arrow>();
            this.StaticArrows = new List<Arrow>();
            this.Toplist = new List<TopListItem>();

            this.PlayerOne = new Player(1, Config.SpawDistanceAtStart, this.WindowHeight - (Config.RowSize * Config.PlayerHeight), Config.RowSize * Config.PlayerWidth, Config.RowSize * Config.PlayerHeight, Brushes.White);
            this.PlayerTwo = new Player(2, this.WindowWidth - Config.SpawDistanceAtStart - Config.RowSize, this.WindowHeight - (Config.RowSize * Config.PlayerHeight), Config.RowSize * Config.PlayerWidth, Config.RowSize * Config.PlayerHeight, Brushes.Black);
        }

        /// <summary>
        /// Gets or sets the status of the model.
        /// </summary>
        public ModelStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the player one.
        /// </summary>
        public Player PlayerOne { get; set; }

        /// <summary>
        /// Gets or sets player two.
        /// </summary>
        public Player PlayerTwo { get; set; }

        /// <summary>
        /// Gets or sets the current level.
        /// </summary>
        public int CurrentLevel { get; set; }

        /// <summary>
        /// Gets or sets level width.
        /// </summary>
        public double LevelWidth { get; set; }

        /// <summary>
        /// Gets or sets level height.
        /// </summary>
        public double LevelHeight { get; set; }

        /// <summary>
        /// Gets or sets window width.
        /// </summary>
        public double WindowWidth { get; set; } // Pixel size

        /// <summary>
        /// Gets or sets window height.
        /// </summary>
        public double WindowHeight { get; set; } // Pixel size

        /// <summary>
        /// Gets or sets actual player.
        /// </summary>
        public int ActualPlayer { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or sets swapped players.
        /// </summary>
        public bool SwappedPlayers
        {
            get { return !(this.PlayerOne.Left < this.PlayerTwo.Left); }
        }

        /// <summary>
        /// Gets or sets cameraposition.
        /// </summary>
        public double CameraPos { get; set; }

        /// <summary>
        /// Gets or sets time in second.
        /// </summary>
        public int TimeInTenthsOfSec { get; set; }

        /// <summary>
        /// Gets or sets level indicator.
        /// </summary>
        public List<Rect> LevelIndicator { get; set; }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        public List<MapPart> Map { get; set; }

        /// <summary>
        /// Gets or sets the deadly mapparts.
        /// </summary>
        public List<MapPart> DeadlyMapParts { get; set; }

        /// <summary>
        /// Gets throwed weapons.
        /// </summary>
        public List<IWeapon> ThrowedWeapons { get; private set; }

        /// <summary>
        /// Gets dropped weapons.
        /// </summary>
        public List<IWeapon> DroppedWeapons { get; private set; }

        /// <summary>
        /// Gets weapons on floor.
        /// </summary>
        public List<IWeapon> WeaponsOnFloor { get; private set; }

        /// <summary>
        /// Gets arrow.
        /// </summary>
        public List<Arrow> Arrows { get; private set; }

        /// <summary>
        /// Gets static arrows.
        /// </summary>
        public List<Arrow> StaticArrows { get; private set; }

        /// <summary>
        /// Gets or sets toplist.
        /// </summary>
        public List<TopListItem> Toplist { get; set; }

        /// <summary>
        /// Gets or sets Finish area.
        /// </summary>
        public Finish Finish { get; set; }
    }
}