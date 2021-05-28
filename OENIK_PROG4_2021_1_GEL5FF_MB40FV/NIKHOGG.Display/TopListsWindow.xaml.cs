// <copyright file="TopListsWindow.xaml.cs" company="PlaceholderCompany">
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
    using NIKHOGG.Elements;

    /// <summary>
    /// Interaction logic for TopListsWindow.xaml.
    /// </summary>
    public partial class TopListsWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopListsWindow"/> class.
        /// </summary>
        public TopListsWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopListsWindow"/> class.
        /// </summary>
        /// <param name="topListItems">Top lists items.</param>
        public TopListsWindow(List<TopListItem> topListItems)
        {
            this.InitializeComponent();
            this.lbTopList.ItemsSource = topListItems;
        }
    }
}
