// <copyright file="Floor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Floor.
    /// </summary>
    public class Floor : MapPart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Floor"/> class.
        /// </summary>
        /// <param name="y">y.</param>
        /// <param name="h">h.</param>
        /// <param name="x">x.</param>
        /// <param name="w">w.</param>
        public Floor(double y, double h, double x, double w)
            : base(y, h, x, w)
        {
        }
    }
}
