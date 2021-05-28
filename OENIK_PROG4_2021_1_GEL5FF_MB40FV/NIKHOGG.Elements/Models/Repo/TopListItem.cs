// <copyright file="TopListItem.cs" company="PlaceholderCompany">
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
    /// Top list item.
    /// </summary>
    public class TopListItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopListItem"/> class.
        /// Top list item.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="timeInSeconds">Time in seconds.</param>
        public TopListItem(string name, double timeInSeconds)
        {
            this.Name = name;
            this.TimeInSeconds = timeInSeconds;
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the time in seconds.
        /// </summary>
        public double TimeInSeconds { get; set; }

        /// <summary>
        /// To string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"{this.Name} - {this.TimeInSeconds}s";
        }
    }
}
