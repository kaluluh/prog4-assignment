// <copyright file="MenuLogic.cs" company="PlaceholderCompany">
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
    using NIKHOGG.Repo;

    /// <summary>
    /// MenuLogic implementation.
    /// </summary>
    public class MenuLogic
    {
        private IStorageRepo repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuLogic"/> class.
        /// </summary>
        public MenuLogic()
        {
            this.repository = new NIKHOGGRepo();
        }

        /// <summary>
        /// Read toplist from file.
        /// </summary>
        /// <returns>Toplist.</returns>
        public List<TopListItem> GetTopList()
        {
            return this.repository.GetTopList();
        }
    }
}
