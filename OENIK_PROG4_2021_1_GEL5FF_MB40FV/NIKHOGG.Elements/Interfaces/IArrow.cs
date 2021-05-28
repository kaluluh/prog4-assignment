// <copyright file="IArrow.cs" company="PlaceholderCompany">
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
    /// Arrow interface.
    /// </summary>
    public interface IArrow
    {
        /// <summary>
        /// Gets the texture.
        /// </summary>đ
        public Rect Texture { get; }

        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        public Rect Hitbox { get; }

        /// <summary>
        /// Gets or sets the velocity.
        /// </summary>
        public double Dx { get; set; }

        /// <summary>
        /// Change x coordination.
        /// </summary>
        /// <param name="diff">Double.</param>
        public void ChangeX(double diff);

        /// <summary>
        /// Change X coordination.
        /// </summary>
        public void ChangeX();
    }
}
