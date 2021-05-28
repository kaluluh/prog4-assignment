// <copyright file="Player.cs" company="PlaceholderCompany">
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
    /// Direction.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Left.
        /// </summary>
        Left,

        /// <summary>
        /// Right.
        /// </summary>
        Right,
    }

    /// <summary>
    /// Player.
    /// </summary>
    public class Player : IPlayer
    {
        private Rect texture;
        private Rect headHitbox;
        private Rect hitbox;
        private IWeapon weapon;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="playerNumber">Plyyer number.</param>
        /// <param name="x">X.</param>
        /// <param name="y">Y.</param>
        /// <param name="w">W.</param>
        /// <param name="h">H.</param>
        /// <param name="b">B.</param>
        public Player(int playerNumber, double x, double y, double w, double h, Brush b)
        {
            this.PlayerNumber = playerNumber;
            this.hitbox = new Rect(x, y - ((h / 3) * 2), w, (h / 3) * 2);
            this.headHitbox = new Rect(x + (w / 4), y - h, w / 2, h / 3);
            this.texture = new Rect(x, y - h, w, h);
            this.TestYRespawn = this.hitbox.Y;
            this.Dx = 0;
            this.Dy = 0;
            this.Ay = 0;
            this.Brush = b;
            this.Moving = false;
            this.IsAttack = false;
            this.Dead = true;
            this.CantMove = false;
            this.LastWeaponWasSword = false;
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        public Rect Texture
        {
            get { return this.texture; }
        }

        /// <summary>
        /// Gets the head hitbox.
        /// </summary>
        public Rect HeadHitbox
        {
            get { return this.headHitbox; }
        }

        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        public Rect Hitbox
        {
            get { return this.hitbox; }
        }

        /// <summary>
        /// Gets or sets the weapon.
        /// </summary>
        public IWeapon Weapon
        {
            get { return this.weapon; } set { this.weapon = value; }
        }

        /// <summary>
        /// Gets or sets direction.
        /// </summary>
        public Direction Direction { get; set; } // true - jobbra, false - balra

        /// <summary>
        /// Gets player number.
        /// </summary>
        public int PlayerNumber { get; private set; }

        /// <summary>
        /// Gets or sets dx.
        /// </summary>
        public double Dx { get; set; }

        /// <summary>
        /// Gets or sets dy.
        /// </summary>
        public double Dy { get; set; }

        /// <summary>
        /// Gets or sets ax.
        /// </summary>
        public int Ax { get; set; }

        /// <summary>
        /// Gets or sets Ay.
        /// </summary>
        public int Ay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets moving.
        /// </summary>
        public bool Moving { get; set; }

        /// <summary>
        /// Gets brush.
        /// </summary>
        public Brush Brush { get; private set; }

        /// <summary>
        /// Gets the left.
        /// </summary>
        public double Left
        {
            get { return this.hitbox.X; }
        }

        /// <summary>
        /// Gets the right.
        /// </summary>
        public double Right
        {
            get { return this.hitbox.X + this.hitbox.Width; }
        }

        /// <summary>
        /// Gets test y respawn.
        /// </summary>
        public double TestYRespawn { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets  dead.
        /// </summary>
        public bool Dead { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets is attack.
        /// </summary>
        public bool IsAttack { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets can moce.
        /// </summary>
        public bool CantMove { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or sets locked.
        /// </summary>
        public bool Locked
        {
            get { return this.Dead || this.IsAttack || this.CantMove; }
        }

        /// <summary>
        /// Gets a value indicating whether gets or sets can jump.
        /// </summary>
        public bool CanJump
        {
            get { return this.Ay == 0; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets last weapong was sword.
        /// </summary>
        public bool LastWeaponWasSword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets is squat.
        /// </summary>
        public bool IsSquat { get; set; }

        /// <summary>
        /// Generate Weapon method.
        /// </summary>
        public void GenerateWeapon()
        {
            if (this.LastWeaponWasSword)
            {
                if (this.PlayerNumber == 1)
                {
                    this.weapon = new Bow(this.PlayerNumber, true, this.Right - (this.texture.Width * Config.PlayerWeaponDistance), this.hitbox.Y);
                }
                else
                {
                    this.weapon = new Bow(this.PlayerNumber, true, this.Left + (this.texture.Width * Config.PlayerWeaponDistance), this.hitbox.Y);
                }

                this.LastWeaponWasSword = false;
            }
            else
            {
                if (this.PlayerNumber == 1)
                {
                    this.weapon = new Sword(this.PlayerNumber, true, this.Right - (this.texture.Width * Config.PlayerWeaponDistance), this.hitbox.Y);
                }
                else
                {
                    this.weapon = new Sword(this.PlayerNumber, true, this.Left + (this.texture.Width * Config.PlayerWeaponDistance), this.hitbox.Y);
                }

                this.LastWeaponWasSword = true;
            }
        }

        /// <summary>
        /// Change x.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeX(double diff)
        {
            this.hitbox.X += diff;
            this.headHitbox.X += diff;
            this.texture.X += diff;
            if (this.Weapon != null)
            {
                if (this.Direction == Direction.Right)
                {
                    if (this.IsAttack)
                    {
                        this.Weapon.RecalculateX(this.Right + (this.texture.Width * Config.PlayerWeaponDistance), this.Direction);
                    }
                    else
                    {
                        this.Weapon.RecalculateX(this.Right - (this.texture.Width * Config.PlayerWeaponDistance), this.Direction);
                    }
                }
                else
                {
                    if (this.IsAttack)
                    {
                        this.Weapon.RecalculateX(this.Left - (this.texture.Width * Config.PlayerWeaponDistance), this.Direction);
                    }
                    else
                    {
                        this.Weapon.RecalculateX(this.Left + (this.texture.Width * Config.PlayerWeaponDistance), this.Direction);
                    }
                }
            }
        }

        /// <summary>
        /// Change y.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeY(double diff)
        {
            this.hitbox.Y += diff;
            this.headHitbox.Y += diff;
            this.texture.Y += diff;
            if (this.Weapon != null)
            {
                this.Weapon.RecalculateY(this.hitbox.Y);
            }
        }

        /// <summary>
        /// Reset player.
        /// </summary>
        /// <param name="newPos">New position.</param>
        public void ResetPlayer(double newPos)
        {
            this.texture.X = newPos;
            this.hitbox.X = newPos;
            this.headHitbox.X = newPos + (this.texture.Width / 4);
            this.Ax = 0;
            this.Dx = 0;
        }

        /// <summary>
        /// SEt y.
        /// </summary>
        /// <param name="y">Y.</param>
        public void SetY(double y)
        {
            this.texture.Y = y;
            this.headHitbox.Y = y;
            this.hitbox.Y = y + this.headHitbox.Height;
        }

        /// <summary>
        /// Recalculate D.
        /// </summary>
        public void RecalculateD()
        {
            this.RecalculateDX();
            this.RecalculateDY();
        }

        /// <summary>
        /// Recalculate d x.
        /// </summary>
        public void RecalculateDX()
        {
            this.Dx = this.Dx + (this.Ax * Config.TickTimetoSec);
            if (!this.Moving && ((this.Ax < 0 && this.Dx < this.Ax * Config.TickTimetoSec) || (this.Ax > 0 && this.Dx > -this.Ax * Config.TickTimetoSec)))
            {
                this.Ax = 0;
                this.Dx = 0;
                this.CantMove = false;
            }

            if (!this.Locked && Math.Abs(this.Dx) > Config.MaxPlayerDX)
            {
                if (this.Dx > 0)
                {
                    this.Dx = Config.MaxPlayerDX;
                }
                else
                {
                    this.Dx = -Config.MaxPlayerDX;
                }
            }
        }

        /// <summary>
        /// Recalculate d y.
        /// </summary>
        public void RecalculateDY()
        {
            this.Dy = this.Dy + (this.Ay * Config.TickTimetoSec);
            if (this.Dy > Config.JumpSpeed)
            {
                this.Dy = Config.JumpSpeed;
            }
        }

        /// <summary>
        /// Death.
        /// </summary>
        public void Death()
        {
            this.Dead = true;
            this.texture.Y = -1000;
            this.hitbox.Y = -1000;
            this.headHitbox.Y = -1000;
            this.Weapon = null;
            this.Dx = 0;
            this.Dy = 0;
            this.Ax = 0;
            this.Ay = 0;
        }

        /// <summary>
        /// Spawn.
        /// </summary>
        /// <param name="y">Y.</param>
        public void Spawn(double y)
        {
            this.texture.Y = y;
            this.headHitbox.Y = y;
            this.hitbox.Y = y + Config.RowSize;
            if (this.Dead)
            {
                this.Dead = false;
                this.GenerateWeapon();
            }
        }

        /// <summary>
        /// Attack.
        /// </summary>
        public void Attack()
        {
            if (this.Weapon is Sword)
            {
                if (!this.IsSquat)
                {
                    this.Moving = true;
                    this.IsAttack = true;

                    if (this.Direction == Direction.Right)
                    {
                        this.Dx = Math.Max(this.Dx + Config.AttackSpeed, Config.MaxPlayerDX);
                        this.Ax = -Config.PlayerAX;

                        this.texture.Width += Config.RowSize * 2;

                        while (this.Dx > 0)
                        {
                            Thread.Sleep(Config.TickTime);
                        }
                    }
                    else
                    {
                        this.Dx = Math.Min(this.Dx - Config.AttackSpeed, -Config.MaxPlayerDX);
                        this.Ax = Config.PlayerAX;

                        this.texture.X += -Config.RowSize * 2;
                        this.texture.Width += Config.RowSize * 2;

                        while (this.Dx < 0)
                        {
                            Thread.Sleep(Config.TickTime);
                        }
                    }

                    this.texture.X = this.hitbox.X;
                    this.texture.Width = this.hitbox.Width;
                    this.IsAttack = false;
                    this.Moving = false;
                }
            }
            else if (this.Weapon is Bow)
            {
                (this.Weapon as Bow).Stretched = true;
            }
        }

        /// <summary>
        /// Shoot.
        /// </summary>
        /// <returns>Arrow.</returns>
        public Arrow Shoot()
        {
            Arrow result = null;
            if ((this.weapon as Bow).CanShoot)
            {
                result = new Arrow((this.weapon as Bow).Arrow, this.Direction);
            }

            // (weapon as Bow).Source.Dispose();
            // (weapon as Bow).Source = new CancellationTokenSource();
            (this.weapon as Bow).CanShoot = false;
            (this.weapon as Bow).Stretched = false;

            return result;
        }

        /// <summary>
        /// Knock back.
        /// </summary>
        public void Knockback()
        {
            this.CantMove = true;
            this.Moving = false;
            if (this.Direction == Direction.Left)
            {
                this.Dx = Config.MaxPlayerDX;
                this.Ax = -Config.PlayerAX;
            }
            else
            {
                this.Dx = -Config.MaxPlayerDX;
                this.Ax = Config.PlayerAX;
            }
        }

        /// <summary>
        /// Squat.
        /// </summary>
        public void Squat()
        {
            this.IsSquat = true;
            this.headHitbox.Y = this.texture.Y + (Config.RowSize * 2);
            this.hitbox.Y = this.texture.Y + (Config.RowSize * 2);
            this.hitbox.Height = Config.RowSize;
            if (this.Weapon != null)
            {
                if (this.Weapon is Sword)
                {
                    this.Weapon.SetPos(4);
                }
                else
                {
                    this.Weapon.SetPos(3);
                }
            }
        }

        /// <summary>
        /// Stand up.
        /// </summary>
        public void StandUp()
        {
            this.headHitbox.Y = this.texture.Y;
            this.hitbox.Y = this.texture.Y + Config.RowSize;
            this.hitbox.Height = Config.RowSize * 2;
            if (this.Weapon != null)
            {
                if (this.Weapon is Sword)
                {
                    this.Weapon.SetPos(3);
                }
                else
                {
                    this.Weapon.SetPos(2);
                }
            }

            this.IsSquat = false;
        }
    }
}
