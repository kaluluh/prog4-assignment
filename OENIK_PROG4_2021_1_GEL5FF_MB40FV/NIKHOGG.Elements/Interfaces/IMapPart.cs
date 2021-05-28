// <copyright file="IMapPart.cs" company="PlaceholderCompany">
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
    /// Interface mappart.
    /// </summary>
    public interface IMapPart
    {
        /// <summary>
        /// Gets the area.
        /// </summary>
        public Rect Area { get; }

        /// <summary>
        /// Change the x position.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeX(double diff);
    }
}
