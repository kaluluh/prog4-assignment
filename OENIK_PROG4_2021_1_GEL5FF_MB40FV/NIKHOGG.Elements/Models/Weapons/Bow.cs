// <copyright file="Bow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Bow implementation.
    /// </summary>
    public class Bow : IWeapon
    {
        private Rect texture;
        private Rect hitbox;
        private int position;
        private int angle;
        private Arrow arrow;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bow"/> class.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="canKill">Can kill.</param>
        /// <param name="x">X.</param>
        /// <param name="y">Y.</param>
        public Bow(int player, bool canKill, double x, double y)
        {
            // source = new CancellationTokenSource();
            this.CanKill = canKill;
            this.Player = player;
            this.position = 2;
            this.arrow = new Arrow();
            this.hitbox = new Rect(-500 * player, -500 * player, (Config.RowSize * 2) - 2, (Config.RowSize * 2) - 2);
            this.texture = new Rect(0, 0, (Config.RowSize * 2) - 2, (Config.RowSize * 2) - 2);
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
        /// Gets the arrow.
        /// </summary>
        public Arrow Arrow
        {
            get { return this.arrow; }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets the can kill.
        /// </summary>
        public bool CanKill { get; private set; }

        /// <summary>
        /// Gets the player.
        /// </summary>
        public int Player { get; private set; }

        /// <summary>
        /// Gets the brush.
        /// </summary>
        public Brush B { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the locked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the strecthed.
        /// </summary>
        public bool Stretched { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the can shoot.
        /// </summary>
        public bool CanShoot { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the throwed.
        /// </summary>
        public bool Throwed { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or sets the on floor.
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
        /// Change x.
        /// </summary>
        /// <param name="diff">iff.</param>
        public void ChangeX(double diff)
        {
            this.texture.X += diff;
            if (this.arrow != null)
            {
                this.arrow.ChangeX(diff);
            }
        }

        /// <summary>
        /// Set x.
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
        /// Set y.
        /// </summary>
        /// <param name="y">Y.</param>
        public void SetY(double y)
        {
            this.texture.Y = y;
            this.hitbox.Y = y;
        }

        /// <summary>
        /// Recalculate X.
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
                    this.texture.X = x - (Config.RowSize * 2.5);
                }
                else
                {
                    this.texture.X = x - (Config.RowSize * 1.2);
                }

                if (this.arrow != null)
                {
                    if (this.Stretched)
                    {
                        this.arrow.SetX(this.texture.X + (Config.RowSize * 0.4));
                    }
                    else
                    {
                        this.arrow.SetX(this.texture.X + Config.RowSize);
                    }
                }
            }
            else
            {
                if (this.position == 0)
                {
                    this.texture.X = x + (Config.RowSize / 2);
                }
                else
                {
                    this.texture.X = x + (Config.RowSize * 1.2) - this.texture.Width;
                }

                if (this.arrow != null)
                {
                    if (this.Stretched)
                    {
                        this.arrow.SetX(this.texture.X - (Config.RowSize * 0.6));
                    }
                    else
                    {
                        this.arrow.SetX(this.texture.X - (Config.RowSize * 1.6));
                    }
                }
            }
        }

        /// <summary>
        /// Recalculate x.
        /// </summary>
        public void RecalculateX() // after throw
        {
            this.hitbox.X += this.Dx;
            this.texture.X = this.hitbox.X;
        }

        /// <summary>
        /// Recalculate y.
        /// </summary>
        public void RecalculateY() // after drop
        {
            this.Dy = this.Dy + (Config.PlayerAY * Config.TickTimetoSec);
            this.hitbox.Y += this.Dy;
            this.texture.Y = this.hitbox.Y;
        }

        /// <summary>
        /// Recalculate y.
        /// </summary>
        /// <param name="y">Y.</param>
        public void RecalculateY(double y)
        {
            if (this.position == 0)
            {
                if (this.arrow != null)
                {
                    this.arrow.SetY(-1000 * this.Player);
                }

                if (!this.Throwed)
                {
                    this.texture.Y = y - (Config.RowSize * 2);
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
            else
            {
                this.texture.Y = y + (Config.RowSize * 0.1);
                this.texture.Y += this.position == 2 ? (this.position - 2.5) * Config.RowSize : (this.position - 3.5) * Config.RowSize;
                this.arrow.SetY(this.texture.Y + this.texture.Width - this.arrow.Texture.Width + Config.RowSize);
                if (this.Stretched)
                {
                    this.arrow.Aim();
                }
                else
                {
                    this.arrow.Low(this.Player);
                }
            }
        }

        /// <summary>
        /// Down.
        /// </summary>
        /// <param name="locked">Locked.</param>
        public void Down(bool locked)
        {
            if (!this.Locked && this.position == 0)
            {
                this.position += 2;
            }

            this.Locked = locked;
        }

        /// <summary>
        /// Up.
        /// </summary>
        public void Up()
        {
            if (!this.Locked && this.position == 2)
            {
                this.position -= 2;
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
        /// Arrow null.
        /// </summary>
        public void ArrowNull()
        {
            this.arrow = null;
        }

        /// <summary>
        /// To string method.
        /// </summary>
        /// <returns>Bow.</returns>
        public override string ToString()
        {
            return "bow";
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
            this.texture.Height = Config.RowSize * 2 * 0.36;
            this.SetY(this.texture.Y + (this.hitbox.Height - this.texture.Height));
            this.hitbox.Height = Config.RowSize * 2 * 0.36;
        }

        /// <summary>
        /// Rotate.
        /// </summary>
        /// <returns>Rotate transform.</returns>
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
