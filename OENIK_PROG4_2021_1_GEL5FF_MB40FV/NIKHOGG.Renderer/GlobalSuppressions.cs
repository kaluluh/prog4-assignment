// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0090:Use 'new(...)'", Justification = "<Unnecessarry>", Scope = "member", Target = "~M:NIKHOGG.Renderer.NIKHOGGRenderer.DrawGame(System.Windows.Media.DrawingContext)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "No need to be static.", Scope = "member", Target = "~M:NIKHOGG.Renderer.NIKHOGGRenderer.GetBrush(System.IO.Stream)~System.Windows.Media.Brush")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "No need to be static.", Scope = "member", Target = "~M:NIKHOGG.Renderer.NIKHOGGRenderer.GetIngameMenu~System.Windows.Media.DrawingGroup")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "It is validated.", Scope = "member", Target = "~M:NIKHOGG.Renderer.NIKHOGGRenderer.BuildDrawing(System.Windows.Media.DrawingContext)")]
