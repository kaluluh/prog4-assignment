// <copyright file="IPlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NIKHOGG.Elements;

    /// <summary>
    /// IPlayerLogic interface.
    /// </summary>
    public interface IPlayerLogic
    {
        /// <summary>
        /// Change acceleration of player.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="d">Direction.</param>
        /// <param name="moving">Accelerates or slows down.</param>
        public void ChangeAx(Player player, Direction d, bool moving);

        /// <summary>
        /// Move player.
        /// </summary>
        /// <param name="player">Player.</param>
        void Move(Player player);

        /// <summary>
        /// Move player one on X.
        /// </summary>
        void MoveP1OnX();

        /// <summary>
        /// Move player two on X.
        /// </summary>
        void MoveP2OnX();

        /// <summary>
        /// Check there is floow under player.
        /// </summary>
        /// <param name="player">Player.</param>
        void CheckFloorUnder(Player player);

        /// <summary>
        /// Move player on Y.
        /// </summary>
        /// <param name="player">Player.</param>
        void MoveOnY(Player player);

        /// <summary>
        /// Move player one on.
        /// </summary>
        void MoveP1ToRespawnPos();

        /// <summary>
        /// Move player two on.
        /// </summary>
        void MoveP2ToRespawnPos();

        /// <summary>
        /// Spawn player.
        /// </summary>
        /// <param name="player">Player.</param>
        void Spawn(Player player);

        /// <summary>
        /// Lift weapon for player.
        /// </summary>
        /// <param name="player">Player.</param>
        public void WeaponUp(Player player);

        /// <summary>
        /// Lower weapon for player.
        /// </summary>
        /// <param name="player">Player.</param>
        public void WeaponDown(Player player);

        /// <summary>
        /// Unlock weapon for player.
        /// </summary>
        /// <param name="player">Player.</param>
        public void UnlockWeapon(Player player);

        /// <summary>
        /// Player start attacking.
        /// </summary>
        /// <param name="player">Player.</param>
        public void Attack(Player player);

        /// <summary>
        /// Throw weapon for player.
        /// </summary>
        /// <param name="player">Player.</param>
        void ThrowWeapon(Player player);

        /// <summary>
        /// Shoot with player's weapon.
        /// </summary>
        /// <param name="player">Player.</param>
        void Shoot(Player player);

        /// <summary>
        /// Jump.
        /// </summary>
        /// <param name="player">Player.</param>
        public void Jump(Player player);

        /// <summary>
        /// Streches bow.
        /// </summary>
        /// <param name="player">Player.</param>
        public void BowStrech(Player player);
    }
}
