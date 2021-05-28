// <copyright file="Ceiling.cs" company="PlaceholderCompany">
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
    /// Ceiling.
    /// </summary>
    public class Ceiling : MapPart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ceiling"/> class.
        /// </summary>
        /// <param name="y">Y.</param>
        /// <param name="h">H.</param>
        /// <param name="x">X.</param>
        /// <param name="w">W.</param>
        public Ceiling(double y, double h, double x, double w) : base(y, h, x, w)
        {
        }
    }
}
