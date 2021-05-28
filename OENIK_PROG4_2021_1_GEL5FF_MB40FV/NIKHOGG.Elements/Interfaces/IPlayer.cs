// <copyright file="IPlayer.cs" company="PlaceholderCompany">
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
    /// Player interface.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets the texture.
        /// </summary>
        public Rect Texture { get; }

        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        public Rect Hitbox { get; }

        /// <summary>
        /// Gets the head hitbox.
        /// </summary>
        public Rect HeadHitbox { get; }

        /// <summary>
        /// Gets or sets the weapong.
        /// </summary>
        public IWeapon Weapon { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        public Direction Direction { get; set; } // true - jobbra, false - balra

        /// <summary>
        /// Gets the playernumber.
        /// </summary>
        public int PlayerNumber { get; }

        /// <summary>
        /// Gets or sets the d x position.
        /// </summary>
        public double Dx { get; set; }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        public double Dy { get; set; }

        /// <summary>
        /// Gets or sets Ax.
        /// </summary>
        public int Ax { get; set; }

        /// <summary>
        /// Gets or sets Ay.
        /// </summary>
        public int Ay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets moving, true or false.
        /// </summary>
        public bool Moving { get; set; }

        /// <summary>
        /// Gets the left.
        /// </summary>
        public double Left { get; }

        /// <summary>
        /// Gets the right position.
        /// </summary>
        public double Right { get; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets dead.
        /// </summary>
        public bool Dead { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets.
        /// </summary>
        public bool IsAttack { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or.
        /// </summary>
        public bool Locked { get; }

        /// <summary>
        /// Gets a value indicating whether gets.
        /// </summary>
        public bool CanJump { get; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets.
        /// </summary>
        public bool LastWeaponWasSword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets.
        /// </summary>
        public bool IsSquat { get; set; }

        /// <summary>
        /// Generate weapon.
        /// </summary>
        public void GenerateWeapon();

        /// <summary>
        /// Change x.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeX(double diff);

        /// <summary>
        /// Change y.
        /// </summary>
        /// <param name="diff">Diff.</param>
        public void ChangeY(double diff);

        /// <summary>
        /// Reset player.
        /// </summary>
        /// <param name="newPos">New positon.</param>
        public void ResetPlayer(double newPos);

        /// <summary>
        /// Recalculate D .
        /// </summary>
        public void RecalculateD();

        /// <summary>
        /// Recalculate dx.
        /// </summary>
        public void RecalculateDX();

        /// <summary>
        /// Recalculate dy.
        /// </summary>
        public void RecalculateDY();

        /// <summary>
        /// Death.
        /// </summary>
        public void Death();

        /// <summary>
        /// Spawn.
        /// </summary>
        /// <param name="y">Y.</param>
        public void Spawn(double y);

        /// <summary>
        /// Attack.
        /// </summary>
        public void Attack();

        /// <summary>
        /// Knock back.
        /// </summary>
        public void Knockback();

        /// <summary>
        /// Squat.
        /// </summary>
        public void Squat();

        /// <summary>
        /// Stand up.
        /// </summary>
        public void StandUp();
    }
}
