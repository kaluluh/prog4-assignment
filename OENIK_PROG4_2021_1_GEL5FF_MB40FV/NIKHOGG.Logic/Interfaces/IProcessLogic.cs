// <copyright file="IProcessLogic.cs" company="PlaceholderCompany">
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
    /// ProcessLogic interface.
    /// </summary>
    public interface IProcessLogic
    {
        /// <summary>
        /// Event of screen refreshing.
        /// </summary>
        public event EventHandler RefreshScreen;

        /// <summary>
        /// Event of finishing the game.
        /// </summary>
        public event EventHandler Finished;

        /// <summary>
        /// Initialize model.
        /// </summary>
        /// <param name="lvl">Current level.</param>
        /// <param name="actualPlayer">Player on focus.</param>
        void InitModel(int lvl, int actualPlayer);

        /// <summary>
        /// Generate next frame for render.
        /// </summary>
        public void GenerateNextFrame();

        /// <summary>
        /// Moves weapons.
        /// </summary>
        void MoveWeapons();

        /// <summary>
        /// Recalculate camera position.
        /// </summary>
        void RecalculateCamera();

        /// <summary>
        /// Create a "death" task for player.
        /// </summary>
        /// <param name="player">Player.</param>
        void CreateDeathTask(Player player);

        /// <summary>
        /// Change focus to player.
        /// </summary>
        /// <param name="player">Player.</param>
        void ChangeFocus(int player);

        /// <summary>
        /// Get spawnpoint for player.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <returns>Spawnpoint (Y).</returns>
        double SpawnPointY(Player player);

        /// <summary>
        /// Load game from save.
        /// </summary>
        /// <param name="id">ID of save.</param>
        /// <returns>Is loading succesfull.</returns>
        public bool LoadGame(int id);

        /// <summary>
        /// Save game.
        /// </summary>
        /// <param name="id">ID of save.</param>
        /// <param name="timeinmilisec">Current stopwatch time.</param>
        public void SaveGame(int id, int timeinmilisec);

        /// <summary>
        /// Drop weapon to floor.
        /// </summary>
        /// <param name="weapon">Weapon.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="y">Y coordinate.</param>
        public void DropWeapon(IWeapon weapon, Direction direction, double y);

        /// <summary>
        /// Checks if player reached end of window.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <returns>Is he reached end of window.</returns>
        public bool IsReachedEndofMap(Player player);

        /// <summary>
        /// Save result to toplist.
        /// </summary>
        /// <param name="tli">Toplist item.</param>
        public void SaveToToplist(TopListItem tli);
    }
}
