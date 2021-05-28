// <copyright file="IWeapon.cs" company="PlaceholderCompany">
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
    using System.Windows.Media;

    /// <summary>
    /// The Weapon interface.
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        /// Gets the position.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        public Rect Hitbox { get; }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        public Rect Texture { get; }

        /// <summary>
        /// Gets a value indicating whether gets the position.
        /// </summary>
        public bool CanKill { get; }

        /// <summary>
        /// Gets the player..
        /// </summary>
        public int Player { get; }

        /// <summary>
        /// Gets the brush.
        /// </summary>
        public Brush B { get; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the locked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets throwed.
        /// </summary>
        public bool Throwed { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or sets onflorr.
        /// </summary>
        public bool OnFloor
        {
            get { return this.Dx == 0; }
        }

        /// <summary>
        /// Gets or sets the dx.
        /// </summary>
        public double Dx { get; set; }

        /// <summary>
        /// Gets or sets dy.
        /// </summary>
        public double Dy { get; set; }

        /// <summary>
        /// Change x.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeX(double diff);

        /// <summary>
        /// Set X.
        /// </summary>
        /// <param name="x">X.</param>
        public void SetX(double x);

        /// <summary>
        /// Set Y.
        /// </summary>
        /// <param name="y">Y.</param>
        public void SetY(double y);

        /// <summary>
        /// Recalculate X.
        /// </summary>
        /// <param name="x">X.</param>
        /// <param name="direction">Direction.</param>
        public void RecalculateX(double x, Direction direction);

        /// <summary>
        /// Recalculate x.
        /// </summary>
        public void RecalculateX();

        /// <summary>
        /// Recalculate y.
        /// </summary>
        public void RecalculateY();

        /// <summary>
        /// Recalculate y.
        /// </summary>
        /// <param name="y">Y.</param>
        public void RecalculateY(double y);

        /// <summary>
        /// Down.
        /// </summary>
        /// <param name="locked">Boolean.</param>
        public void Down(bool locked);

        /// <summary>
        /// Up.
        /// </summary>
        public void Up();

        /// <summary>
        /// Set position.
        /// </summary>
        /// <param name="pos">Position.</param>
        public void SetPos(int pos);

        /// <summary>
        /// Unlock.
        /// </summary>
        public void Unlock();

        /// <summary>
        /// Drop resize.
        /// </summary>
        public void DropResize();

        /// <summary>
        /// Floor resize.
        /// </summary>
        public void FloorResize();

        /// <summary>
        /// Rotate.
        /// </summary>
        /// <returns>Rotate transfrom.</returns>
        public RotateTransform Rotate();
    }
}
