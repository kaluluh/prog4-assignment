// <copyright file="Arrow.cs" company="PlaceholderCompany">
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
    /// Arrow class.
    /// </summary>
    public class Arrow : IArrow
    {
        private Rect texture;
        private Rect hitbox;

        /// <summary>
        /// Initializes a new instance of the <see cref="Arrow"/> class.
        /// The constructor of arrow.
        /// </summary>
        public Arrow()
        {
            this.texture = new Rect(-Config.RowSize * 10, -Config.RowSize * 10, 0, 0);
            this.hitbox = new Rect(-Config.RowSize * 10, -Config.RowSize * 10, 0, 0);
            this.Dx = 0;
            this.Aim();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Arrow"/> class.
        /// </summary>
        /// <param name="other">Other.</param>
        /// <param name="direction">Direction.</param>
        public Arrow(Arrow other, Direction direction)
        {
            this.texture = other.texture;
            this.hitbox = other.hitbox;
            this.Dx = direction == Direction.Left ? -Config.MaxWeaponDx : Config.MaxWeaponDx;
            this.ChangeX(direction == Direction.Left ? -this.hitbox.Width : this.hitbox.Width);
        }

        /// <summary>
        /// Gets or sets dx.
        /// </summary>
        public double Dx { get; set; }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        public Rect Texture
        {
            get { return this.texture; }
        }

        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        public Rect Hitbox
        {
            get { return this.hitbox; }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Change x.
        /// </summary>
        /// <param name="diff">Digg.</param>
        public void ChangeX(double diff)
        {
            this.texture.X += diff;
            this.hitbox.X += diff;
        }

        /// <summary>
        /// Change x.
        /// </summary>
        public void ChangeX()
        {
            this.texture.X += this.Dx;
            this.hitbox.X += this.Dx;
        }

        /// <summary>
        /// Set x position.
        /// </summary>
        /// <param name="x">X.</param>
        public void SetX(double x)
        {
            this.texture.X = x;
            this.hitbox.X = x;
        }

        /// <summary>
        /// Set y position.
        /// </summary>
        /// <param name="y">Y.</param>
        public void SetY(double y)
        {
            this.texture.Y = y;
            this.hitbox.Y = y;
        }

        /// <summary>
        /// Aim.
        /// </summary>
        public void Aim()
        {
            this.texture.Width = Config.RowSize * Config.ArrowWidth;
            this.texture.Height = Config.RowSize * Config.ArrowHeight;
            this.hitbox = this.texture;
        }

        /// <summary>
        /// Low.
        /// </summary>
        /// <param name="playerNumber">Player number.</param>
        public void Low(int playerNumber)
        {
            this.texture.Width = Config.RowSize * Config.ArrowWidth;
            this.texture.Height = Config.RowSize * Config.ArrowWidth * 3 / 4;
            this.hitbox = new Rect(-Config.RowSize * 10 * playerNumber, -Config.RowSize * 10 * playerNumber, 0, 0);
        }

        /// <summary>
        /// Stop.
        /// </summary>
        /// <param name="x">X.</param>
        public void Stop(double x)
        {
            if (this.Dx > 0)
            {
                this.texture.X = x + (Config.RowSize * 0.2) - this.texture.Width;
                this.hitbox = default(Rect);
            }
            else
            {
                this.texture.X = x - (Config.RowSize * 0.2);
                this.hitbox = default(Rect);
            }
        }
    }
}
