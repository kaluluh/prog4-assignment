// <copyright file="SavedGameInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Saved game info.
    /// </summary>
    public class SavedGameInfo
    {
        /// <summary>
        /// Gets or sets camerapositon.
        /// </summary>
        public double CameraPosition { get; set; }

        /// <summary>
        /// Gets or sets current level.
        /// </summary>
        public int CurrentLevel { get; set; }

        /// <summary>
        /// Gets or sets actual player.
        /// </summary>
        public int ActualPlayer { get; set; }

        /// <summary>
        /// Gets or sets p1 weapon.
        /// </summary>
        public string P1Weapon { get; set; }

        /// <summary>
        /// Gets or sets p2 weapon.
        /// </summary>
        public string P2Weapon { get; set; }

        /// <summary>
        /// Gets or sets p1 position.
        /// </summary>
        public Point P1Position { get; set; }

        /// <summary>
        /// Gets or sets p2 position.
        /// </summary>
        public Point P2Position { get; set; }

        /// <summary>
        /// Gets or sets time in secondum.
        /// </summary>
        public int TimeInTenthsOfSec { get; set; }
    }
}
