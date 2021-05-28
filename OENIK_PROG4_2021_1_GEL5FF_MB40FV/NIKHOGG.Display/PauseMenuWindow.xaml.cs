// <copyright file="PauseMenuWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Display
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using NIKHOGG.Elements;

    /// <summary>
    /// Interaction logic for PauseMenuWindow.xaml.
    /// </summary>
    public partial class PauseMenuWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PauseMenuWindow"/> class.
        /// </summary>
        public PauseMenuWindow()
        {
            this.InitializeComponent();
            this.Background = this.GetBrush(Resource.GetStream(FileType.Image, Config.PauseMenuBGBrush));
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets.
        /// </summary>
        public bool Continue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets.
        /// </summary>
        public bool Save { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets.
        /// </summary>
        public bool Exit { get; set; }

        private Brush GetBrush(Stream stream)
        {
            BitmapImage bg = new BitmapImage();
            bg.BeginInit();
            bg.StreamSource = stream;
            bg.EndInit();
            ImageBrush ib = new ImageBrush(bg);

            return ib;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            this.Continue = true;
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Save = true;
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Exit = true;
            this.Close();
        }
    }
}
