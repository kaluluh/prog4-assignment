// <copyright file="IRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// Interface of the renderer.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Build drawing method.
        /// </summary>
        /// <param name="drawingContext">The drawing context.</param>
        public void BuildDrawing(DrawingContext drawingContext);
    }
}
