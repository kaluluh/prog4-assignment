// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using NIKHOGG.Elements;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.Background = this.GetBrush(Resource.GetStream(FileType.Image, Config.MainMenuBckgrnd));
        }

        private Brush GetBrush(Stream stream)
        {
            BitmapImage bg = new BitmapImage();
            bg.BeginInit();
            bg.StreamSource = stream;
            bg.EndInit();
            ImageBrush ib = new ImageBrush(bg);

            return ib;
        }
    }
}
