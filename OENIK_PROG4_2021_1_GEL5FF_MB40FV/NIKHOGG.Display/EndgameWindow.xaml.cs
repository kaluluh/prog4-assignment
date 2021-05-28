// <copyright file="EndgameWindow.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for EndgameWindow.xaml.
    /// </summary>
    public partial class EndgameWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndgameWindow"/> class.
        /// </summary>
        public EndgameWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets name of player.
        /// </summary>
        public string PlayerName { get; set; }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.PlayerName = this.Player_Name.Text;
            this.Close();
        }
    }
}
