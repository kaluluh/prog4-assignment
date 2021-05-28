// <copyright file="IModel.cs" company="PlaceholderCompany">
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
    using NIKHOGG.Elements;

    /// <summary>
    /// Model interface.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        public ModelStatus Status { get; set; }

        /// <summary>
        /// Gets or sets player one.
        /// </summary>
        public Player PlayerOne { get; set; }

        /// <summary>
        /// Gets or sets player two.
        /// </summary>
        public Player PlayerTwo { get; set; }

        /// <summary>
        /// Gets or sets current level.
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
        public bool SwappedPlayers { get; }

        /// <summary>
        /// Gets or sets cameraposition.
        /// </summary>
        public double CameraPos { get; set; }

        /// <summary>
        /// Gets or sets time.
        /// </summary>
        public int TimeInTenthsOfSec { get; set; }

        /// <summary>
        /// Gets or sets level indicator.
        /// </summary>
        public List<Rect> LevelIndicator { get; set; }

        /// <summary>
        /// Gets or sets map.
        /// </summary>
        public List<MapPart> Map { get; set; }

        /// <summary>
        /// Gets or sets deadly map parts.
        /// </summary>
        public List<MapPart> DeadlyMapParts { get; set; }

        /// <summary>
        /// Gets throwed weapons.
        /// </summary>
        public List<IWeapon> ThrowedWeapons { get; }

        /// <summary>
        /// Gets the dropped weapons.
        /// </summary>
        public List<IWeapon> DroppedWeapons { get; }

        /// <summary>
        /// Gets the weaopens on florr.
        /// </summary>
        public List<IWeapon> WeaponsOnFloor { get; }

        /// <summary>
        /// Gets the arrows.
        /// </summary>
        public List<Arrow> Arrows { get; }

        /// <summary>
        /// Gets the static arrows.
        /// </summary>
        public List<Arrow> StaticArrows { get; }

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
