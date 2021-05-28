// <copyright file="ViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Display
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using NIKHOGG.Logic;
    using NIKHOGG.Model;

    /// <summary>
    /// View model implementation.
    /// </summary>
    public class ViewModel : ViewModelBase
    {
        private MenuLogic logic;

        /// <summary>
        /// Gets the start command.
        /// </summary>
        public ICommand StartGameCommand { get; private set; }

        /// <summary>
        /// Gets the load game command.
        /// </summary>
        public ICommand LoadGameCommand { get; private set; }

        /// <summary>
        /// Gets the top lists command.
        /// </summary>
        public ICommand TopListsCommand { get; private set; }

        /// <summary>
        /// Gets the exit game command.
        /// </summary>
        public ICommand ExitGameCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.logic = new MenuLogic();

            this.StartGameCommand = new RelayCommand(() =>
            {
                GamePlayWindow win = new GamePlayWindow();
                win.ShowDialog();
            });
            this.LoadGameCommand = new RelayCommand(() =>
            {
                GamePlayWindow win = new GamePlayWindow();
                ((GameControl)win.Content).LoadGame();
                win.ShowDialog();
            });
            this.TopListsCommand = new RelayCommand(() =>
            {
                TopListsWindow win = new TopListsWindow(this.logic.GetTopList());
                win.ShowDialog();
            });
            this.ExitGameCommand = new RelayCommand(() =>
            {
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                win.Close();
            });
        }
    }
}
