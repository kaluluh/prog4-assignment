// <copyright file="IDetectLogic.cs" company="PlaceholderCompany">
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
    using NIKHOGG.Model;

    /// <summary>
    /// IDetectLogic interface.
    /// </summary>
    public interface IDetectLogic
    {
        /// <summary>
        /// Detect kill.
        /// </summary>
        public void DetectKill();

        /// <summary>
        /// Detect weapons' collision.
        /// </summary>
        public void DetectWeaponCollision();

        /// <summary>
        /// Check if player is dead.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <returns>Is he dead or not.</returns>
        public bool IsDead(Player player);
    }
}
