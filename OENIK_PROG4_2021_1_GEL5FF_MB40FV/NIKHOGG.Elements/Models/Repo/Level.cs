// <copyright file="Level.cs" company="PlaceholderCompany">
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
    /// Level class implemented.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        public Level()
        {
            this.Map = new List<MapPart>();
            this.DeadlyMapParts = new List<MapPart>();
            this.Finish = null;
        }

        /// <summary>
        /// Gets or sets floors and ceilings.
        /// </summary>
        public List<MapPart> Map { get; set; }

        /// <summary>
        /// Gets or sets neptun lakes.
        /// </summary>
        public List<MapPart> DeadlyMapParts { get; set; }

        /// <summary>
        /// Gets or sets finish area.
        /// </summary>
        public Finish Finish { get; set; }
    }
}
