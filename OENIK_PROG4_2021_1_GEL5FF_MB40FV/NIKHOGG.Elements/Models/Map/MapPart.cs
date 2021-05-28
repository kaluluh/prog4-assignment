// <copyright file="MapPart.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Mappart.
    /// </summary>
    public abstract class MapPart : IMapPart
    {
        private Rect area;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapPart"/> class.
        /// Mappart.
        /// </summary>
        /// <param name="y">Y.</param>
        /// <param name="h">H.</param>
        /// <param name="x">X.</param>
        /// <param name="w">W.</param>
        protected MapPart(double y, double h, double x, double w)
        {
            this.area = new Rect(x * Config.Scale, y * Config.RowSize, w * Config.Scale, h * Config.RowSize);
        }

        /// <summary>
        /// Gets the area.
        /// </summary>
        public Rect Area
        {
            get { return this.area; }
        }

        /// <summary>
        /// Change x position.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeX(double diff)
        {
            this.area.X += diff;
        }
    }
}
