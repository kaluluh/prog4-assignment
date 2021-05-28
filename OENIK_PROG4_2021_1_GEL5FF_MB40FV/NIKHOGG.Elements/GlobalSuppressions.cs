// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1128:Put constructor initializers on their own line", Justification = "<Unnecassary>", Scope = "member", Target = "~M:NIKHOGG.Elements.Ceiling.#ctor(System.Double,System.Double,System.Double,System.Double)")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1128:Put constructor initializers on their own line", Justification = "<Unnecassary>", Scope = "member", Target = "~M:NIKHOGG.Elements.NeptunLake.#ctor(System.Double,System.Double,System.Double,System.Double)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "It is validated.", Scope = "member", Target = "~M:NIKHOGG.Elements.Arrow.#ctor(NIKHOGG.Elements.Arrow,NIKHOGG.Elements.Direction)")]
[assembly: SuppressMessage("Performance", "CA1805:Do not initialize unnecessarily", Justification = "Not unnecessarily.", Scope = "member", Target = "~P:NIKHOGG.Elements.Config.MaxCameraPos")]
[assembly: SuppressMessage("Performance", "CA1805:Do not initialize unnecessarily", Justification = "Not unnecessarily.", Scope = "member", Target = "~P:NIKHOGG.Elements.Config.MinCameraPos")]
[assembly: SuppressMessage("Performance", "CA1805:Do not initialize unnecessarily", Justification = "Not unnecessarily.", Scope = "member", Target = "~P:NIKHOGG.Elements.Config.RowSize")]
[assembly: SuppressMessage("Performance", "CA1805:Do not initialize unnecessarily", Justification = "Not unnecessarily.", Scope = "member", Target = "~P:NIKHOGG.Elements.Config.Scale")]
[assembly: SuppressMessage("Performance", "CA1805:Do not initialize unnecessarily", Justification = "Not unnecessarily.", Scope = "member", Target = "~P:NIKHOGG.Elements.Config.StartingCameraPos")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Need list.", Scope = "member", Target = "~P:NIKHOGG.Elements.Level.Map")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Need list.", Scope = "member", Target = "~P:NIKHOGG.Elements.Level.DeadlyMapParts")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Has to be modified.", Scope = "member", Target = "~P:NIKHOGG.Elements.Level.DeadlyMapParts")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Has to be modified.", Scope = "member", Target = "~P:NIKHOGG.Elements.Level.Map")]
