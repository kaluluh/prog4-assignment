// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Display
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using NIKHOGG.Elements;
    using NIKHOGG.Logic;
    using NIKHOGG.Model;
    using NIKHOGG.Renderer;

    /// <summary>
    /// The game control class implementation.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        private IModel model;
        private ILogic logic;
        private IRenderer renderer;
        private DispatcherTimer tickTimer;
        private Stopwatch stopwatch;
        private int loadGame;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.NIKHOGGControl_Loaded;
        }

        /// <summary>
        /// Loading saved game.
        /// </summary>
        public void LoadGame()
        {
            this.loadGame = 1;
        }

        /// <summary>
        /// OnRender method.
        /// </summary>
        /// <param name="drawingContext">Drawing context.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDrawing(drawingContext);
            }
        }

        private void NIKHOGGControl_Loaded(object sender, RoutedEventArgs e)
        {
            Config.Scale = this.ActualHeight / Config.LevelHeight;
            Config.RowSize = this.ActualHeight / Config.Rows;
            Config.StartingCameraPos = -(((Config.LevelWidth * Config.Scale) - this.ActualWidth) / 2);
            Config.MaxCameraPos = this.ActualWidth - (Config.LevelWidth * Config.Scale);
            this.model = new NIKHOGGModel(Config.LevelWidth * Config.Scale, this.ActualHeight, this.ActualWidth, this.ActualHeight);
            this.logic = new NIKHOGGLogic(this.model);
            this.renderer = new NIKHOGGRenderer(this.model);

            if (this.loadGame > 0)
            {
                if (!this.logic.LoadGame(this.loadGame))
                {
                    this.logic.InitModel(4, 0);
                }
            }

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.stopwatch = new Stopwatch();
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(Config.TickTime);
                this.tickTimer.Tick += this.TickTimer_Tick;
                this.tickTimer.Start();
                this.stopwatch.Start();

                win.KeyDown += this.Win_KeyDown;
                win.KeyUp += this.Win_KeyUp;

                this.logic.RefreshScreen += (obj, args) => this.InvalidateVisual();
                this.logic.Finished += (obj, args) => this.EndScreen();
            }
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            this.logic.GenerateNextFrame();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.model.Status == ModelStatus.GamePlay)
            {
                switch (e.Key)
                {
                    case Key.W: this.logic.WeaponUp(this.model.PlayerOne); break;
                    case Key.S: this.logic.WeaponDown(this.model.PlayerOne); break;
                    case Key.A: this.logic.ChangeAx(this.model.PlayerOne, Direction.Left, true); break;
                    case Key.D: this.logic.ChangeAx(this.model.PlayerOne, Direction.Right, true); break;
                    case Key.F: this.logic.Attack(this.model.PlayerOne); break;
                    case Key.G: this.logic.Jump(this.model.PlayerOne); break;
                    case Key.Up: this.logic.WeaponUp(this.model.PlayerTwo); break;
                    case Key.Down: this.logic.WeaponDown(this.model.PlayerTwo); break;
                    case Key.Left: this.logic.ChangeAx(this.model.PlayerTwo, Direction.Left, true); break;
                    case Key.Right: this.logic.ChangeAx(this.model.PlayerTwo, Direction.Right, true); break;
                    case Key.N: this.logic.Attack(this.model.PlayerTwo); break;
                    case Key.M: this.logic.Jump(this.model.PlayerTwo); break;
                }

                if (e.Key == Key.Escape)
                {
                    if (this.model.Status == ModelStatus.Paused)
                    {
                        this.model.Status = ModelStatus.GamePlay;
                        this.tickTimer.Start();
                    }
                    else
                    {
                        this.model.Status = ModelStatus.Paused;
                        this.stopwatch.Stop();
                        this.tickTimer.Stop();
                        PauseMenuWindow pauseMenuWindow = new PauseMenuWindow();
                        if (pauseMenuWindow.ShowDialog() == false)
                        {
                            if (pauseMenuWindow.Continue)
                            {
                                pauseMenuWindow.Close();
                                this.model.Status = ModelStatus.GamePlay;
                                this.tickTimer.Start();
                                this.stopwatch.Start();
                            }
                            else if (pauseMenuWindow.Save)
                            {
                                this.logic.SaveGame(1, (int)this.stopwatch.ElapsedMilliseconds);
                                this.model.Status = ModelStatus.GamePlay;
                                this.tickTimer.Start();
                            }
                            else if (pauseMenuWindow.Exit)
                            {
                                GamePlayWindow gamePlayWindow = (GamePlayWindow)Window.GetWindow(this);
                                gamePlayWindow.Close();
                            }
                        }
                    }
                }
            }
        }

        private void Win_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.model.Status == ModelStatus.GamePlay)
            {
                switch (e.Key)
                {
                    case Key.W: this.logic.UnlockWeapon(this.model.PlayerOne); break;
                    case Key.S: this.logic.UnlockWeapon(this.model.PlayerOne); break;
                    case Key.A: this.logic.ChangeAx(this.model.PlayerOne, Direction.Right, false); break;
                    case Key.D: this.logic.ChangeAx(this.model.PlayerOne, Direction.Left, false); break;
                    case Key.F: this.logic.Shoot(this.model.PlayerOne); break;
                    case Key.Up: this.logic.UnlockWeapon(this.model.PlayerTwo); break;
                    case Key.Down: this.logic.UnlockWeapon(this.model.PlayerTwo); break;
                    case Key.Left: this.logic.ChangeAx(this.model.PlayerTwo, Direction.Right, false); break;
                    case Key.Right: this.logic.ChangeAx(this.model.PlayerTwo, Direction.Left, false); break;
                    case Key.N: this.logic.Shoot(this.model.PlayerTwo); break;
                }
            }
        }

        private void EndScreen()
        {
            this.tickTimer.Stop();
            this.stopwatch.Stop();
            double finalTime = (this.model.TimeInTenthsOfSec + (this.stopwatch.ElapsedMilliseconds / 100)) / 10.0;

            if (this.model.Toplist.Count < 10)
            {
                EndgameWindow endgameWindow = new EndgameWindow();
                if (endgameWindow.ShowDialog() == false)
                {
                    TopListItem tli = new TopListItem(endgameWindow.PlayerName, finalTime);
                    this.logic.SaveToToplist(tli);
                    GamePlayWindow gamePlayWindow = (GamePlayWindow)Window.GetWindow(this);
                    gamePlayWindow.Close();
                }
            }
            else if (this.model.Toplist.Last().TimeInSeconds > finalTime)
            {
                EndgameWindow endgameWindow = new EndgameWindow();
                if (endgameWindow.ShowDialog() == false)
                {
                    TopListItem tli = new TopListItem(endgameWindow.PlayerName, finalTime);
                    this.logic.SaveToToplist(tli);
                    GamePlayWindow gamePlayWindow = (GamePlayWindow)Window.GetWindow(this);
                    gamePlayWindow.Close();
                }
            }
            else
            {
                EndgameWindowWithoutTL endgameWindow = new EndgameWindowWithoutTL();
                if (endgameWindow.ShowDialog() == false)
                {
                    GamePlayWindow gamePlayWindow = (GamePlayWindow)Window.GetWindow(this);
                    gamePlayWindow.Close();
                }
            }
        }
    }
}
