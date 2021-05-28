// <copyright file="IStorageRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Repo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NIKHOGG.Elements;

    /// <summary>
    /// Rapository interface implementation.
    /// </summary>
    public interface IStorageRepo
    {
        /// <summary>
        /// Save game.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="savedGameInfo"> Save game info.</param>
        public void SaveGame(int id, SavedGameInfo savedGameInfo);

        /// <summary>
        /// Get saved games.
        /// </summary>
        /// <returns>List of int.</returns>
        public List<int> GetSavedGames();

        /// <summary>
        /// Load game.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Saved game info.</returns>
        public SavedGameInfo LoadGame(int id);

        /// <summary>
        /// To top list.
        /// </summary>
        /// <param name="toplist">Time.</param>
        public void ToTopList(List<TopListItem> toplist);

        /// <summary>
        /// Get top list.
        /// </summary>
        /// <returns>List of top list item.</returns>
        public List<TopListItem> GetTopList();

        /// <summary>
        /// Load level.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <returns>List of map part.</returns>
        public Level LoadLevel(Stream stream);
    }
}
