// <copyright file="Sword.cs" company="PlaceholderCompany">
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
    /// Sword class implementation.
    /// </summary>
    public class Sword : IWeapon
    {
        private Rect texture;
        private Rect hitbox;
        private double textureDiff;
        private int position;
        private int angle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sword"/> class.
        /// </summary>
        /// <param name="player">Player number.</param>
        /// <param name="canKill">Can kill?.</param>
        /// <param name="x">X coordination.</param>
        /// <param name="y">Y coordination.</param>
        public Sword(int player, bool canKill, double x, double y)
        {
            this.CanKill = canKill;
            this.Player = player;
            this.position = 2;
            this.hitbox = new Rect(0, 0, Config.RowSize * Config.SwordWidth, Config.RowSize - 2);
            this.texture = new Rect(0, 0, Config.RowSize * Config.SwordWidth, Config.RowSize * Config.SwordWidth / 2);
            this.textureDiff = (this.texture.Height - this.hitbox.Height) / 2;
            this.B = Brushes.Cyan;
            this.Locked = false;
            this.Throwed = false;
            this.Dx = 0;
            this.angle = 0;
            this.RecalculateX(x, Direction.Left);
            this.RecalculateY(y);
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        public int Position
        {
            get { return this.position; }
        }

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
        /// Gets or sets the sword direction.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets can kill.
        /// </summary>
        public bool CanKill { get; private set; }

        /// <summary>
        /// Gets player.
        /// </summary>
        public int Player { get; private set; }

        /// <summary>
        /// Gets the brush.
        /// </summary>
        public Brush B { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the locked boolean.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the throwed.
        /// </summary>
        public bool Throwed { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or sets.
        /// </summary>
        public bool OnFloor
        {
            get { return this.Dx == 0; }
        }

        /// <summary>
        /// Gets or sets Dx.
        /// </summary>
        public double Dx { get; set; }

        /// <summary>
        /// Gets or sets Dy.
        /// </summary>
        public double Dy { get; set; }

        /// <summary>
        /// Change the x coordination of thw Sword.
        /// </summary>
        /// <param name="diff">diff.</param>
        public void ChangeX(double diff)
        {
            this.hitbox.X += diff;
            this.texture.X += diff;
        }

        /// <summary>
        /// Set the x.
        /// </summary>
        /// <param name="x">X.</param>
        public void SetX(double x)
        {
            if (this.Direction == Direction.Left)
            {
                this.texture.X = x - this.texture.Width;
                this.hitbox.X = this.texture.X;
            }
            else
            {
                this.texture.X = x;
                this.hitbox.X = this.texture.X;
            }
        }

        /// <summary>
        /// Set the y position.
        /// </summary>
        /// <param name="y">Y.</param>
        public void SetY(double y)
        {
            this.texture.Y = y;
            this.hitbox.Y = y;
        }

        /// <summary>
        /// Recalculate the x position.
        /// </summary>
        /// <param name="x">X.</param>
        /// <param name="direction">Direction.</param>
        public void RecalculateX(double x, Direction direction) // x = model.P1.X + model.P1.hitbox.Width * 0.2
        {
            this.Direction = direction;

            if (direction == Direction.Right)
            {
                if (this.position == 0)
                {
                    this.texture.X = x - (Config.RowSize
                                          * 2.5);
                }
                else
                {
                    this.texture.X = x;
                }

                this.hitbox.X = x;
            }
            else
            {
                if (this.position == 0)
                {
                    this.texture.X = x + (Config.RowSize
                                          / 2);
                }
                else
                {
                    this.texture.X = x - this.hitbox.Width;
                }

                this.hitbox.X = x - this.hitbox.Width;
            }
        }

        /// <summary>
        /// Recalculate x position.
        /// </summary>
        public void RecalculateX() // after throw/drop
        {
            this.hitbox.X += this.Dx;
            this.texture.X = this.hitbox.X;
        }

        /// <summary>
        /// Recalculate y position.
        /// </summary>
        public void RecalculateY() // after drop
        {
            this.Dy = this.Dy + (Config.PlayerAY * Config.TickTimetoSec);
            this.hitbox.Y += this.Dy;
            this.texture.Y = this.hitbox.Y;
        }

        /// <summary>
        /// Recalculate y position.
        /// </summary>
        /// <param name="y">Y.</param>
        public void RecalculateY(double y)
        {
            if (this.position == 0)
            {
                if (!this.Throwed)
                {
                    this.texture.Y = y - (Config.RowSize * 2.5);
                    this.texture.Height = Config.RowSize * 2;
                    this.texture.Width = Config.RowSize * 2;

                    this.hitbox.Y = -200 * this.Player;
                }
                else
                {
                    this.texture.Y = y - Config.RowSize + 1;
                    this.texture.Height = (Config.RowSize * 2) - 2;
                    this.texture.Width = (Config.RowSize * 2) - 2;
                    this.hitbox.Y = this.texture.Y;
                    this.hitbox.Height = (Config.RowSize * 2) - 2;
                    this.hitbox.Width = (Config.RowSize * 2) - 2;
                }
            }
            else if (this.position == 4)
            {
                this.SetY(-200 * this.Player);
            }
            else
            {
                this.hitbox.Y = y + ((this.position - 2) * Config.RowSize) + 1;
                this.texture.Y = this.hitbox.Y - this.textureDiff;
                this.texture.Width = Config.RowSize * Config.SwordWidth;
                this.texture.Height = Config.RowSize * Config.SwordWidth / 2;
            }
        }

        /// <summary>
        /// Down method.
        /// </summary>
        /// <param name="locked">Boolean.</param>
        public void Down(bool locked)
        {
            if (!this.Locked && this.position < 3)
            {
                this.position++;
            }

            this.Locked = locked;
        }

        /// <summary>
        /// Up method.
        /// </summary>
        public void Up()
        {
            if (!this.Locked && this.position != 0)
            {
                this.position--;
            }

            this.Locked = true;
        }

        /// <summary>
        /// Set position.
        /// </summary>
        /// <param name="pos">Position.</param>
        public void SetPos(int pos)
        {
            this.position = pos;
            this.Locked = pos == 0;
        }

        /// <summary>
        /// Unlock.
        /// </summary>
        public void Unlock()
        {
            this.Locked = false;
        }

        /// <summary>
        /// To string method.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return "sword";
        }

        /// <summary>
        /// Drop resize.
        /// </summary>
        public void DropResize()
        {
            this.texture.Height = (Config.RowSize * 2) - 2;
            this.texture.Width = (Config.RowSize * 2) - 2;
            this.hitbox = this.texture;
        }

        /// <summary>
        /// Floor resize.
        /// </summary>
        public void FloorResize()
        {
            this.texture.Height = Config.RowSize * Config.SwordWidth / 2;
            this.texture.Width = Config.RowSize * Config.SwordWidth;
            this.SetY(this.texture.Y + (this.hitbox.Height - this.texture.Height) + (Config.RowSize * 0.5));
            this.hitbox.Height = Config.RowSize - 2;
            this.hitbox.Width = Config.RowSize * Config.SwordWidth;
        }

        /// <summary>
        /// Rotate.
        /// </summary>
        /// <returns>Rotate transfrom information.</returns>
        public RotateTransform Rotate()
        {
            if (this.Dx < 0)
            {
                this.angle -= Config.TransformAngle;
                if (this.angle < -360)
                {
                    this.angle += 360;
                }
            }
            else
            {
                this.angle += Config.TransformAngle;
                if (this.angle > 360)
                {
                    this.angle -= 360;
                }
            }

            return new RotateTransform(this.angle, this.texture.X + (this.texture.Width / 2), this.texture.Y + (this.texture.Height / 2));
        }
    }
}
