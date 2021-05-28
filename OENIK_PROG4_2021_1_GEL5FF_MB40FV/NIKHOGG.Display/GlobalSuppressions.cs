// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1115:Parameter should follow comma", Justification = "<Unnecessary>")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<Unnecessary>", Scope = "member", Target = "~M:NIKHOGG.Display.ViewModel.#ctor")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Need list.", Scope = "member", Target = "~M:NIKHOGG.Display.TopListsWindow.#ctor(System.Collections.Generic.List{NIKHOGG.Elements.TopListItem})")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "No need to be static.", Scope = "member", Target = "~M:NIKHOGG.Display.MainWindow.GetBrush(System.IO.Stream)~System.Windows.Media.Brush")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "No need to be static.", Scope = "member", Target = "~M:NIKHOGG.Display.PauseMenuWindow.GetBrush(System.IO.Stream)~System.Windows.Media.Brush")]
