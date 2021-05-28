// <copyright file="Resource.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Elements
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// FileType enum.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// Level file.
        /// </summary>
        Level,

        /// <summary>
        /// Image file.
        /// </summary>
        Image,

        /// <summary>
        /// P1 file.
        /// </summary>
        P1,

        /// <summary>
        /// P2 file.
        /// </summary>
        P2,
    }

    /// <summary>
    /// Resource class.
    /// </summary>
    public static class Resource
    {
        /// <summary>
        /// Get the stream method.
        /// </summary>
        /// <param name="fileType">The fily type.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>Stream.</returns>
        public static Stream GetStream(FileType fileType, string fileName)
        {
            switch (fileType)
            {
                case FileType.Level:
                    return Assembly.GetExecutingAssembly().GetManifestResourceStream($"NIKHOGG.Elements.Levels.{fileName}");
                case FileType.Image:
                    return Assembly.GetExecutingAssembly().GetManifestResourceStream($"NIKHOGG.Elements.Graphic.{fileName}");
                case FileType.P1:
                    return Assembly.GetExecutingAssembly().GetManifestResourceStream($"NIKHOGG.Elements.Graphic.P1.{fileName}");

                case FileType.P2:
                    return Assembly.GetExecutingAssembly().GetManifestResourceStream($"NIKHOGG.Elements.Graphic.P2.{fileName}");
                default:
                    return null;
            }
        }
    }
}
