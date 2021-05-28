// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:Field names should begin with lower-case letter", Justification = "<Unnecesarry>", Scope = "member", Target = "~F:NIKHOGG.Repo.NIKHOGGRepo.SAVE_PREFIX")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "<Unnecesarry>", Scope = "member", Target = "~F:NIKHOGG.Repo.NIKHOGGRepo.SAVE_PREFIX")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Lsit needed.", Scope = "member", Target = "~M:NIKHOGG.Repo.IStorageRepo.GetSavedGames~System.Collections.Generic.List{System.Int32}")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Lsit needed.", Scope = "member", Target = "~M:NIKHOGG.Repo.IStorageRepo.GetTopList~System.Collections.Generic.List{NIKHOGG.Elements.TopListItem}")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Lsit needed.", Scope = "member", Target = "~M:NIKHOGG.Repo.IStorageRepo.ToTopList(System.Collections.Generic.List{NIKHOGG.Elements.TopListItem})")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "It is validated.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.SaveGame(System.Int32,NIKHOGG.Elements.SavedGameInfo)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Why?", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.GetSavedGames~System.Collections.Generic.List{System.Int32}")]
[assembly: SuppressMessage("Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Working.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.GetSavedGames~System.Collections.Generic.List{System.Int32}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Working.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.GetSavedGames~System.Collections.Generic.List{System.Int32}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Working.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.GetTopList~System.Collections.Generic.List{NIKHOGG.Elements.TopListItem}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Working.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.LoadGame(System.Int32)~NIKHOGG.Elements.SavedGameInfo")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<Working.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.LoadLevel(System.IO.Stream)~NIKHOGG.Elements.Level")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "No need for that.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.GetTopList~System.Collections.Generic.List{NIKHOGG.Elements.TopListItem}")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "No need for that.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.LoadGame(System.Int32)~NIKHOGG.Elements.SavedGameInfo")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "No need for that.", Scope = "member", Target = "~M:NIKHOGG.Repo.NIKHOGGRepo.LoadLevel(System.IO.Stream)~NIKHOGG.Elements.Level")]
