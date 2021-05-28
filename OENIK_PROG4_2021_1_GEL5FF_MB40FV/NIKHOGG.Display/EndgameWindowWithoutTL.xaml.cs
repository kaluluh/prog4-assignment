// <copyright file="EndgameWindowWithoutTL.xaml.cs" company="PlaceholderCompany">
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
    /// Interaction logic for EndgameWindowWithoutTL.xaml.
    /// </summary>
    public partial class EndgameWindowWithoutTL : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndgameWindowWithoutTL"/> class.
        /// </summary>
        public EndgameWindowWithoutTL()
        {
            this.InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
