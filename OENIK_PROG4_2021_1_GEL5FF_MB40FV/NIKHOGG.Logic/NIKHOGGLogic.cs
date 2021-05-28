// <copyright file="NIKHOGGLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using NIKHOGG.Elements;
    using NIKHOGG.Model;
    using NIKHOGG.Repo;

    /// <summary>
    /// Implementation of logic.
    /// </summary>
    public class NIKHOGGLogic : ILogic
    {
        private IModel model;
        private IStorageRepo repository;
        private List<Task> tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="NIKHOGGLogic"/> class.
        /// </summary>
        /// <param name="model">Model.</param>
        public NIKHOGGLogic(IModel model)
        {
            this.model = model;
            this.repository = new NIKHOGGRepo();
            this.tasks = new List<Task>();

            this.model.Toplist = this.repository.GetTopList();
            this.InitModel(4, 0);
        }

        /// <inheritdoc/>
        public event EventHandler RefreshScreen;

        /// <inheritdoc/>
        public event EventHandler Finished;

        /// <inheritdoc/>
        public void InitModel(int lvl, int actualPlayer)
        {
            this.model.Status = ModelStatus.Loading;
            this.model.CurrentLevel = lvl;
            this.model.ActualPlayer = actualPlayer;
            this.model.Map.Clear();
            this.model.DeadlyMapParts.Clear();
            this.model.Map.Clear();
            this.model.ThrowedWeapons.Clear();
            this.model.DroppedWeapons.Clear();
            this.model.WeaponsOnFloor.Clear();
            this.model.Arrows.Clear();
            this.model.StaticArrows.Clear();
            Stream stream = Resource.GetStream(FileType.Level, $"0{lvl}.json");
            Level lvlLoaded = this.repository.LoadLevel(stream);
            this.model.Map = lvlLoaded.Map;
            this.model.DeadlyMapParts = lvlLoaded.DeadlyMapParts;
            this.model.Finish = lvlLoaded.Finish;

            foreach (Task task in this.tasks)
            {
                task.Wait();
            }

            this.tasks.Clear();

            switch (this.model.ActualPlayer)
            {
                case 0: this.model.CameraPos = Config.StartingCameraPos; break;
                case 1: this.model.CameraPos = Config.MinCameraPos; break;
                case 2: this.model.CameraPos = Config.MaxCameraPos; break;
            }

            foreach (MapPart mapPart in this.model.Map)
            {
                switch (this.model.ActualPlayer)
                {
                    case 0: mapPart.ChangeX(Config.StartingCameraPos); break;
                    case 1: mapPart.ChangeX(Config.MinCameraPos); break;
                    case 2: mapPart.ChangeX(Config.MaxCameraPos); break;
                }
            }

            foreach (MapPart mapPart in this.model.DeadlyMapParts)
            {
                switch (this.model.ActualPlayer)
                {
                    case 0: mapPart.ChangeX(Config.StartingCameraPos); break;
                    case 1: mapPart.ChangeX(Config.MinCameraPos); break;
                    case 2: mapPart.ChangeX(Config.MaxCameraPos); break;
                }
            }

            if (this.model.Finish != null)
            {
                switch (this.model.ActualPlayer)
                {
                    case 0: this.model.Finish.ChangeX(Config.StartingCameraPos); break;
                    case 1: this.model.Finish.ChangeX(Config.MinCameraPos); break;
                    case 2: this.model.Finish.ChangeX(Config.MaxCameraPos); break;
                }
            }

            if (this.model.ActualPlayer == 1)
            {
                this.model.PlayerOne.ResetPlayer(Config.MinDistanceToSide);
                this.model.PlayerTwo.ResetPlayer(Config.MinDistanceToSide + Config.MinRespawnDistance);
            }

            if (this.model.ActualPlayer == 2)
            {
                this.model.PlayerTwo.ResetPlayer(this.model.WindowWidth - Config.MinDistanceToSide);
                this.model.PlayerOne.ResetPlayer(this.model.WindowWidth - Config.MinDistanceToSide - Config.MinRespawnDistance);
            }

            if (lvl != 1)
            {
                this.Spawn(this.model.PlayerOne);
            }
            else
            {
                this.LockPlayer(this.model.PlayerOne);
            }

            if (lvl != 7)
            {
                this.Spawn(this.model.PlayerTwo);
            }
            else
            {
                this.LockPlayer(this.model.PlayerTwo);
            }

            if (this.model.ActualPlayer != 0)
            {
                Thread.Sleep(1500);
            }

            this.model.Status = ModelStatus.GamePlay;
        }

        /// <inheritdoc/>
        public bool LoadGame(int id)
        {
            SavedGameInfo savedGameInfo = this.repository.LoadGame(id);

            if (savedGameInfo == null)
            {
                return false;
            }

            this.model.CurrentLevel = savedGameInfo.CurrentLevel;
            this.model.ActualPlayer = savedGameInfo.ActualPlayer;
            this.model.TimeInTenthsOfSec = savedGameInfo.TimeInTenthsOfSec;

            this.model.Map.Clear();
            this.model.DeadlyMapParts.Clear();
            this.model.Map.Clear();
            this.model.ThrowedWeapons.Clear();
            this.model.DroppedWeapons.Clear();
            this.model.WeaponsOnFloor.Clear();
            this.model.Arrows.Clear();
            this.model.StaticArrows.Clear();

            Stream stream = Resource.GetStream(FileType.Level, $"0{savedGameInfo.CurrentLevel}.json");
            Level lvlLoaded = this.repository.LoadLevel(stream);
            this.model.Map = lvlLoaded.Map;
            this.model.DeadlyMapParts = lvlLoaded.DeadlyMapParts;
            this.model.Finish = lvlLoaded.Finish;

            foreach (Task task in this.tasks)
            {
                task.Wait();
            }

            this.tasks.Clear();

            this.model.CameraPos = savedGameInfo.CameraPosition;
            foreach (MapPart mapPart in this.model.Map)
            {
                mapPart.ChangeX(savedGameInfo.CameraPosition);
            }

            foreach (MapPart mapPart in this.model.DeadlyMapParts)
            {
                mapPart.ChangeX(savedGameInfo.CameraPosition);
            }

            if (this.model.Finish != null)
            {
                this.model.Finish.ChangeX(savedGameInfo.CameraPosition);
            }

            this.model.PlayerOne.ResetPlayer(savedGameInfo.P1Position.X);
            this.model.PlayerOne.SetY(savedGameInfo.P1Position.Y);
            this.model.PlayerOne.LastWeaponWasSword = savedGameInfo.P1Weapon.Contains("bow");
            this.model.PlayerOne.Dead = true;
            this.model.PlayerTwo.ResetPlayer(savedGameInfo.P2Position.X);
            this.model.PlayerTwo.SetY(savedGameInfo.P2Position.Y);
            this.model.PlayerTwo.LastWeaponWasSword = savedGameInfo.P2Weapon.Contains("bow");
            this.model.PlayerTwo.Dead = true;

            this.Spawn(this.model.PlayerOne);
            this.Spawn(this.model.PlayerTwo);

            if (savedGameInfo.P1Weapon.Contains("empty"))
            {
                this.model.PlayerOne.Weapon = null;
                this.model.PlayerOne.LastWeaponWasSword = savedGameInfo.P1Weapon.Contains("bow");
            }

            if (savedGameInfo.P2Weapon.Contains("empty"))
            {
                this.model.PlayerTwo.Weapon = null;
                this.model.PlayerTwo.LastWeaponWasSword = savedGameInfo.P1Weapon.Contains("bow");
            }

            if (this.model.ActualPlayer != 0)
            {
                Thread.Sleep(1500);
            }

            this.model.Status = ModelStatus.GamePlay;

            return true;
        }

        /// <inheritdoc/>
        public void SaveGame(int id, int timeinmilisec)
        {
            SavedGameInfo savedGameInfo = new SavedGameInfo();

            savedGameInfo.ActualPlayer = this.model.ActualPlayer;
            savedGameInfo.CameraPosition = this.model.CameraPos;
            savedGameInfo.CurrentLevel = this.model.CurrentLevel;
            savedGameInfo.P1Position = new Point(this.model.PlayerOne.Texture.X, this.model.PlayerOne.Texture.Y);
            savedGameInfo.P1Weapon = this.model.PlayerOne.Weapon?.ToString() ?? (this.model.PlayerOne.LastWeaponWasSword ? "bow_empty" : "sword_empty");
            if (this.model.PlayerOne.Dead)
            {
                savedGameInfo.P1Weapon = this.model.PlayerOne.LastWeaponWasSword ? "bow" : "sword";
            }

            savedGameInfo.P2Position = new Point(this.model.PlayerTwo.Texture.X, this.model.PlayerTwo.Texture.Y);
            savedGameInfo.P2Weapon = this.model.PlayerTwo.Weapon?.ToString() ?? (this.model.PlayerTwo.LastWeaponWasSword ? "bow_empty" : "sword_empty");
            if (this.model.PlayerTwo.Dead)
            {
                savedGameInfo.P2Weapon = this.model.PlayerTwo.LastWeaponWasSword ? "bow" : "sword";
            }

            savedGameInfo.TimeInTenthsOfSec = (timeinmilisec / 100) + this.model.TimeInTenthsOfSec;

            this.repository.SaveGame(id, savedGameInfo);
        }

        /// <inheritdoc/>
        public void ChangeAx(Player player, Direction d, bool moving)
        {
            if (!player.Locked)
            {
                if (d == Direction.Left)
                {
                    player.Ax = -Config.PlayerAX;
                    player.Moving = moving;
                }
                else
                {
                    player.Ax = Config.PlayerAX;
                    player.Moving = moving;
                }
            }
        }

        /// <inheritdoc/>
        public void Move(Player player)
        {
            switch (player.PlayerNumber)
            {
                case 1: this.MoveP1OnX(); break;
                case 2: this.MoveP2OnX(); break;
            }

            if (this.model.Status == ModelStatus.Loading)
            {
                return;
            }

            this.MoveOnY(player);
        }

        /// <inheritdoc/>
        public void MoveP1OnX()
        {
            if (this.model.PlayerOne.Left > -this.model.PlayerOne.Dx)
            {
                if (this.model.ActualPlayer == 0)
                {
                    if (this.model.PlayerOne.Right + this.model.PlayerOne.Dx < this.model.WindowWidth)
                    {
                        this.model.PlayerOne.ChangeX(this.model.PlayerOne.Dx);
                    }
                    else
                    {
                        this.model.PlayerOne.ChangeX(this.model.WindowWidth - this.model.PlayerOne.Right);
                        this.model.PlayerOne.Dx = 0;
                    }
                }
                else
                {
                    // nem lehet kimenni az ablakból, ha egyik játékoson sincs fókusz
                    this.model.PlayerOne.ChangeX(this.model.PlayerOne.Dx);
                    if (this.IsDead(this.model.PlayerOne))
                    {
                        if (this.IsReachedEndofMap(this.model.PlayerOne))
                        {
                            this.model.Status = ModelStatus.Loading;
                            return;
                        }
                        else
                        {
                            this.CreateDeathTask(this.model.PlayerOne);
                        }
                    }
                }
            }
            else if (this.model.PlayerOne.Left > 0)
            {
                this.model.PlayerOne.ChangeX(-this.model.PlayerOne.Left);
                this.model.PlayerOne.Dx = 0;
            }

            // ütközésvizsgálat
            foreach (MapPart mapPart in this.model.Map)
            {
                if (this.model.PlayerOne.Hitbox.IntersectsWith(mapPart.Area))
                {
                    if (this.model.PlayerOne.Dx > 0)
                    {
                        this.model.PlayerOne.ChangeX(mapPart.Area.Left - this.model.PlayerOne.Right - 1);
                    }
                    else if (this.model.PlayerOne.Dx < 0)
                    {
                        this.model.PlayerOne.ChangeX(mapPart.Area.Right - this.model.PlayerOne.Left + 1);
                    }

                    this.model.PlayerOne.Dx = 0;
                }
            }

            if (!this.model.PlayerOne.Dead)
            {
                this.CheckFloorUnder(this.model.PlayerOne);
            }
        }

        /// <inheritdoc/>
        public void MoveP2OnX()
        {
            if (this.model.PlayerTwo.Right + this.model.PlayerTwo.Dx < this.model.WindowWidth)
            {
                if (this.model.ActualPlayer != 0)
                {
                    this.model.PlayerTwo.ChangeX(this.model.PlayerTwo.Dx);
                    if (this.IsDead(this.model.PlayerTwo))
                    {
                        if (this.IsReachedEndofMap(this.model.PlayerTwo))
                        {
                            this.model.Status = ModelStatus.Loading;
                            return;
                        }
                        else
                        {
                            this.CreateDeathTask(this.model.PlayerTwo);
                        }
                    }
                }
                else
                {
                    // nem lehet kimenni az ablakból, ha egyik játékoson sincs fókusz
                    if (this.model.PlayerTwo.Left + this.model.PlayerTwo.Dx > 0)
                    {
                        this.model.PlayerTwo.ChangeX(this.model.PlayerTwo.Dx);
                    }
                    else
                    {
                        this.model.PlayerTwo.ChangeX(-this.model.PlayerTwo.Left);
                        this.model.PlayerTwo.Dx = 0;
                    }
                }
            }
            else if (this.model.PlayerTwo.Right < this.model.WindowWidth)
            {
                this.model.PlayerTwo.ChangeX(this.model.WindowWidth - this.model.PlayerTwo.Right);
                this.model.PlayerTwo.Dx = 0;
            }

            // ütközésvizsgálat
            foreach (MapPart mapPart in this.model.Map)
            {
                if (this.model.PlayerTwo.Hitbox.IntersectsWith(mapPart.Area))
                {
                    if (this.model.PlayerTwo.Dx > 0)
                    {
                        this.model.PlayerTwo.ChangeX(mapPart.Area.Left - this.model.PlayerTwo.Right - 1);
                    }
                    else if (this.model.PlayerTwo.Dx < 0)
                    {
                        this.model.PlayerTwo.ChangeX(mapPart.Area.Right - this.model.PlayerTwo.Left + 1);
                    }

                    this.model.PlayerTwo.Dx = 0;
                }
            }

            if (!this.model.PlayerTwo.Dead)
            {
                this.CheckFloorUnder(this.model.PlayerTwo);
            }
        }

        /// <inheritdoc/>
        public void CheckFloorUnder(Player player)
        {
            if (this.SpawnPointY(player) - player.Hitbox.Height != player.Hitbox.Y)
            {
                player.Ay = Config.PlayerAY;
            }
        }

        /// <inheritdoc/>
        public void MoveOnY(Player player)
        {
            player.ChangeY(player.Dy);

            if (player.Dy < 0)
            {
                foreach (Ceiling ceiling in this.model.Map.Where(x => x is Ceiling))
                {
                    if (player.Texture.IntersectsWith(ceiling.Area))
                    {
                        player.ChangeY(ceiling.Area.Bottom - player.Texture.Y + 1);
                        player.Dy = 0;
                    }
                }
            }
            else if (player.Dy > 0)
            {
                foreach (Floor floor in this.model.Map.Where(x => x is Floor))
                {
                    if (player.Hitbox.IntersectsWith(floor.Area))
                    {
                        player.ChangeY(floor.Area.Y - player.Hitbox.Bottom - 1);
                        player.Dy = 0;
                        player.Ay = 0;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void MoveP1ToRespawnPos()
        {
            int count = 0;
            double defaultDiff;
            double diff;

            this.model.PlayerOne.Death();

            if (this.model.CameraPos > -200)
            {
                double respawnPoint = this.model.WindowWidth - (Config.MinDistanceToSide * 2);
                defaultDiff = (respawnPoint - this.model.PlayerOne.Left) / (Config.FPS * Config.RespawnTimeInSec);

                while (count < Config.FPS * Config.RespawnTimeInSec)
                {
                    diff = defaultDiff;
                    if (this.model.PlayerOne.Left + defaultDiff < respawnPoint)
                    {
                        this.model.PlayerOne.ChangeX(diff);
                    }
                    else
                    {
                        diff = respawnPoint - this.model.PlayerOne.Left;
                        this.model.PlayerOne.ChangeX(diff);
                    }

                    count++;
                    Thread.Sleep(Config.TickTime);
                }

                if (this.model.ActualPlayer == 0)
                {
                    this.model.PlayerOne.ChangeX(-(this.model.PlayerOne.Texture.X - Config.MinDistanceToSide));
                }
            }
            else
            {
                defaultDiff = -(this.model.PlayerOne.Right - (this.model.PlayerTwo.Left - Config.MinRespawnDistance)) / (Config.FPS * Config.RespawnTimeInSec) * 2;
                if (defaultDiff > -Config.RespawnDX)
                {
                    defaultDiff = -Config.RespawnDX;
                    if (this.model.PlayerOne.Right < this.model.PlayerTwo.Left - Config.MinRespawnDistance)
                    {
                        defaultDiff *= -1;
                    }
                }

                while (count < Config.FPS * Config.RespawnTimeInSec)
                {
                    diff = defaultDiff;

                    // ha a respawn pointtol jobbra van
                    if (defaultDiff < 0 && this.model.PlayerOne.Right + diff > this.model.PlayerTwo.Left - Config.MinRespawnDistance)
                    {
                        // nem léphet ki az ablakból
                        if (this.model.PlayerOne.Left + diff > Config.MinDistanceToSide)
                        {
                            this.model.PlayerOne.ChangeX(diff);
                        }
                        else
                        {
                            diff = this.model.PlayerOne.Left - Config.MinDistanceToSide;
                            this.model.PlayerOne.ChangeX(diff);
                        }
                    }
                    else if (defaultDiff > 0)
                    {
                        // ha a respawn pointtol balra van
                        if (this.model.PlayerOne.Right + diff < this.model.PlayerTwo.Left - Config.MinRespawnDistance)
                        {
                            this.model.PlayerOne.ChangeX(diff);
                        }
                        else
                        {
                            // túllépné a respawn pointot
                            diff = this.model.PlayerTwo.Left - Config.MinRespawnDistance - this.model.PlayerOne.Right;
                            this.model.PlayerOne.ChangeX(diff);
                        }
                    }
                    else
                    {
                        // túllépné a respawn pointot
                        diff = this.model.PlayerTwo.Left - Config.MinRespawnDistance - this.model.PlayerOne.Right;

                        // nem léphet ki az ablakból
                        if (this.model.PlayerOne.Left + diff > Config.MinDistanceToSide)
                        {
                            this.model.PlayerOne.ChangeX(diff);
                        }
                        else
                        {
                            diff = this.model.PlayerOne.Left - Config.MinDistanceToSide;
                            this.model.PlayerOne.ChangeX(diff);
                        }
                    }

                    count++;
                    Thread.Sleep(Config.TickTime);
                }
            }

            this.Spawn(this.model.PlayerOne);
        }

        /// <inheritdoc/>
        public void MoveP2ToRespawnPos()
        {
            int count = 0;
            double defaultDiff;
            double diff;

            this.model.PlayerTwo.Death();

            if (this.model.CameraPos < -(this.model.LevelWidth - this.model.WindowWidth - 200))
            {
                double respawnPoint = Config.MinDistanceToSide * 2;
                defaultDiff = (respawnPoint - this.model.PlayerTwo.Right) / (Config.FPS * Config.RespawnTimeInSec);

                while (count < Config.FPS * Config.RespawnTimeInSec)
                {
                    diff = defaultDiff;
                    if (this.model.PlayerTwo.Right + defaultDiff > respawnPoint)
                    {
                        this.model.PlayerTwo.ChangeX(diff);
                    }
                    else
                    {
                        diff = respawnPoint - this.model.PlayerTwo.Right;
                        this.model.PlayerTwo.ChangeX(diff);
                    }

                    count++;
                    Thread.Sleep(Config.TickTime);
                }

                if (this.model.ActualPlayer == 0)
                {
                    this.model.PlayerTwo.ChangeX(this.model.WindowWidth - Config.MinDistanceToSide - this.model.PlayerTwo.Texture.X);
                }
            }
            else
            {
                defaultDiff = ((this.model.PlayerOne.Right + Config.MinRespawnDistance) - this.model.PlayerTwo.Left) / (Config.FPS * Config.RespawnTimeInSec) * 2;
                if (defaultDiff < Config.RespawnDX)
                {
                    defaultDiff = Config.RespawnDX;
                    if (this.model.PlayerOne.Right + Config.MinRespawnDistance < this.model.PlayerTwo.Left)
                    {
                        defaultDiff *= -1;
                    }
                }

                while (count < Config.FPS * Config.RespawnTimeInSec)
                {
                    diff = defaultDiff;

                    // ha a respawn pointtól jobbra van
                    if (defaultDiff > 0 && this.model.PlayerTwo.Left + diff < this.model.PlayerOne.Right + Config.MinRespawnDistance)
                    {
                        // nem léphet ki az ablakból
                        if (this.model.PlayerTwo.Right + diff < this.model.WindowWidth - Config.MinDistanceToSide)
                        {
                            this.model.PlayerTwo.ChangeX(diff);
                        }
                        else
                        {
                            diff = this.model.WindowWidth - Config.MinDistanceToSide - this.model.PlayerTwo.Right;
                            this.model.PlayerTwo.ChangeX(diff);
                        }
                    }
                    else if (defaultDiff < 0)
                    {
                        // ha a respawn pointtól jobbra van
                        if (this.model.PlayerTwo.Left + diff > this.model.PlayerOne.Right + Config.MinRespawnDistance)
                        {
                            this.model.PlayerTwo.ChangeX(diff);
                        }
                        else
                        {
                            // túllépné a respawn pointot
                            diff = (this.model.PlayerOne.Right + Config.MinRespawnDistance) - this.model.PlayerTwo.Left;
                            this.model.PlayerTwo.ChangeX(diff);
                        }
                    }
                    else
                    {
                        // túllépné a respawn pointot
                        diff = this.model.PlayerOne.Right + Config.MinRespawnDistance - this.model.PlayerTwo.Left;

                        // nem léphet ki az ablakból
                        if (this.model.PlayerTwo.Right + diff < this.model.WindowWidth - Config.MinDistanceToSide)
                        {
                            this.model.PlayerTwo.ChangeX(diff);
                        }
                        else
                        {
                            diff = this.model.WindowWidth - Config.MinDistanceToSide - this.model.PlayerTwo.Right;
                            this.model.PlayerTwo.ChangeX(diff);
                        }
                    }

                    count++;
                    Thread.Sleep(Config.TickTime);
                }
            }

            this.Spawn(this.model.PlayerTwo);
        }

        /// <inheritdoc/>
        public void Spawn(Player player)
        {
            double y = this.SpawnPointY(player);
            while (y > this.model.WindowHeight)
            {
                player.ChangeX(-100);
                y = this.SpawnPointY(player);
            }

            player.Spawn(y - player.Texture.Height);
        }

        /// <inheritdoc/>
        public double SpawnPointY(Player player)
        {
            double spawnPoint = int.MaxValue;
            foreach (Floor floor in this.model.Map.Where(x => x is Floor))
            {
                if (((player.Hitbox.X > floor.Area.Left && player.Hitbox.X < floor.Area.Right) || (player.Hitbox.Right > floor.Area.Left && player.Hitbox.Right < floor.Area.Right)) && floor.Area.Y > player.HeadHitbox.Y)
                {
                    if (floor.Area.Y < spawnPoint)
                    {
                        spawnPoint = floor.Area.Y;
                    }
                }
            }

            return spawnPoint - 1;
        }

        /// <inheritdoc/>
        public void WeaponUp(Player player)
        {
            if (player.Weapon != null)
            {
                player.Weapon.Up();
            }
        }

        /// <inheritdoc/>
        public void WeaponDown(Player player)
        {
            if (player.Weapon is Sword)
            {
                if (player.Weapon != null && player.Weapon.Position != 3)
                {
                    player.Weapon.Down(true);
                }
                else if (player.Dy == 0)
                {
                    player.Squat();
                }
            }
            else
            {
                if (player.Weapon != null && player.Weapon.Position != 2)
                {
                    player.Weapon.Down(true);
                }
                else if (player.Dy == 0)
                {
                    player.Squat();
                }
            }
        }

        /// <inheritdoc/>
        public void UnlockWeapon(Player player)
        {
            if (!player.IsSquat && player.Weapon != null)
            {
                player.Weapon.Unlock();
                if (player.Weapon.Position == 0)
                {
                    player.Weapon.Down(false);
                }
            }
            else
            {
                if (player.IsSquat)
                {
                    if (player.Weapon == null)
                    {
                        IWeapon weapon = this.model.WeaponsOnFloor.Where(x => player.Hitbox.IntersectsWith(x.Texture)).FirstOrDefault();

                        if (weapon != null)
                        {
                            if (weapon is Sword)
                            {
                                player.LastWeaponWasSword = false;
                            }
                            else
                            {
                                player.LastWeaponWasSword = true;
                            }

                            player.GenerateWeapon();
                            this.model.WeaponsOnFloor.Remove(weapon);
                        }
                    }

                    player.StandUp();
                }
            }
        }

        /// <inheritdoc/>
        public void Attack(Player player)
        {
            if (player.Weapon != null && !player.IsAttack)
            {
                if (player.Weapon is Sword)
                {
                    if (player.Weapon.Position != 0)
                    {
                        Task task = new Task(() => player.Attack(), TaskCreationOptions.LongRunning);
                        task.Start();
                        this.tasks.Add(task);
                    }
                    else
                    {
                        this.ThrowWeapon(player);
                    }
                }
                else
                {
                    if (player.Weapon.Position != 0)
                    {
                        player.Attack();
                        Task task = new Task(() => { this.BowStrech(player); }, TaskCreationOptions.LongRunning);
                        task.Start();
                        this.tasks.Add(task);
                    }
                    else
                    {
                        this.ThrowWeapon(player);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void BowStrech(Player player)
        {
            Thread.Sleep(50);
            for (int i = 0; i < 6; i++)
            {
                if (player.Weapon != null && (player.Weapon as Bow).Stretched)
                {
                    Thread.Sleep(50);
                }
                else
                {
                    return;
                }
            }

            (player.Weapon as Bow).CanShoot = true;
        }

        /// <inheritdoc/>
        public void ThrowWeapon(Player player)
        {
            player.Weapon.Throwed = true;
            if (player.Weapon is Bow)
            {
                (player.Weapon as Bow).ArrowNull();
                (player.Weapon as Bow).SetX(player.Direction == Direction.Left ? player.Hitbox.X : player.Hitbox.Right);
            }

            player.Weapon.Dx = player.Direction == Direction.Right ? Config.MaxWeaponDx : -Config.MaxWeaponDx;
            player.Weapon.ChangeX(player.Direction == Direction.Right ? Config.MaxPlayerDX + 10 : -Config.MaxPlayerDX - 10);
            player.Weapon.RecalculateY(player.Hitbox.Y);
            this.model.ThrowedWeapons.Add(player.Weapon);
            player.Weapon = null;
        }

        /// <inheritdoc/>
        public void DropWeapon(IWeapon weapon, Direction direction, double y)
        {
            if (weapon != null)
            {
                if (direction == Direction.Left)
                {
                    weapon.Dx = -Config.MaxWeaponDx / 5;
                }
                else
                {
                    weapon.Dx = Config.MaxWeaponDx / 5;
                }

                weapon.Dy = -Config.JumpSpeed / 3;
                weapon.DropResize();
                weapon.SetY(y);
                this.model.DroppedWeapons.Add(weapon);
            }
        }

        /// <inheritdoc/>
        public void Shoot(Player player)
        {
            if (player.Weapon is Bow)
            {
                Arrow arrow = player.Shoot();
                if (arrow != null)
                {
                    this.model.Arrows.Add(arrow);
                }
            }
        }

        /// <inheritdoc/>
        public void Jump(Player player)
        {
            if (player.CanJump && !player.Locked)
            {
                player.Ay = Config.PlayerAY;
                player.Dy = -Config.JumpSpeed;
            }
        }

        /// <inheritdoc/>
        public void GenerateNextFrame()
        {
            if (this.model.Status == ModelStatus.Loading)
            {
                return;
            }

            this.model.PlayerOne.RecalculateD();
            this.model.PlayerTwo.RecalculateD();

            this.Move(this.model.PlayerOne);
            if (this.model.Status == ModelStatus.Loading)
            {
                this.RefreshScreen?.Invoke(this, EventArgs.Empty);
                new Task(() => this.InitModel(this.model.ActualPlayer == 1 ? this.model.CurrentLevel + 1 : this.model.CurrentLevel - 1, this.model.ActualPlayer), TaskCreationOptions.LongRunning).Start();
                return;
            }

            this.Move(this.model.PlayerTwo);
            if (this.model.Status == ModelStatus.Loading)
            {
                this.RefreshScreen?.Invoke(this, EventArgs.Empty);
                new Task(() => this.InitModel(this.model.ActualPlayer == 1 ? this.model.CurrentLevel + 1 : this.model.CurrentLevel - 1, this.model.ActualPlayer), TaskCreationOptions.LongRunning).Start();
                return;
            }

            this.model.PlayerOne.Direction = this.model.SwappedPlayers ? Direction.Left : Direction.Right;
            this.model.PlayerTwo.Direction = this.model.SwappedPlayers ? Direction.Right : Direction.Left;

            this.MoveWeapons();
            this.DetectWeaponCollision();

            this.DetectKill();

            if (this.model.ActualPlayer != 0)
            {
                this.RecalculateCamera();
            }

            this.IsFinished();

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        public void MoveWeapons()
        {
            this.model.Arrows.ForEach(x => { x.ChangeX(); });

            for (int i = 0; i < this.model.ThrowedWeapons.Count; i++)
            {
                IWeapon weapon = this.model.ThrowedWeapons[i];
                weapon.RecalculateX();

                foreach (MapPart mapPart in this.model.Map)
                {
                    if (weapon.Hitbox.IntersectsWith(mapPart.Area))
                    {
                        if (weapon.Dx < 0)
                        {
                            weapon.ChangeX(mapPart.Area.Right - weapon.Hitbox.X + 2);
                            this.DropWeapon(weapon, Direction.Right, weapon.Hitbox.Y);
                            this.model.ThrowedWeapons.RemoveAt(i--);
                        }
                        else
                        {
                            weapon.ChangeX(-(weapon.Hitbox.Right - mapPart.Area.X + 2));
                            this.DropWeapon(weapon, Direction.Left, weapon.Hitbox.Y);
                            this.model.ThrowedWeapons.RemoveAt(i--);
                        }

                        break;
                    }
                }
            }

            for (int i = 0; i < this.model.DroppedWeapons.Count; i++)
            {
                this.model.DroppedWeapons[i].RecalculateX();
                foreach (MapPart mapPart in this.model.Map.Where(x => x is Floor))
                {
                    if (this.model.DroppedWeapons[i].Hitbox.IntersectsWith(mapPart.Area))
                    {
                        this.model.DroppedWeapons[i].SetX(this.model.DroppedWeapons[i].Dx > 0 ? mapPart.Area.X - this.model.DroppedWeapons[i].Hitbox.Width : mapPart.Area.Right);
                        this.model.DroppedWeapons[i].Dx = -this.model.DroppedWeapons[i].Dx;
                        break;
                    }
                }

                this.model.DroppedWeapons[i].RecalculateY();

                if (this.model.DroppedWeapons[i].Hitbox.Y > this.model.WindowHeight)
                {
                    this.model.DroppedWeapons.RemoveAt(i--);
                }
                else
                {
                    foreach (MapPart mapPart in this.model.Map.Where(x => x is Floor))
                    {
                        if (this.model.DroppedWeapons[i].Hitbox.IntersectsWith(mapPart.Area))
                        {
                            this.model.DroppedWeapons[i].SetY(mapPart.Area.Top - this.model.DroppedWeapons[i].Hitbox.Height);
                            this.model.DroppedWeapons[i].Dy = 0;
                            this.model.DroppedWeapons[i].FloorResize();
                            this.model.WeaponsOnFloor.Add(this.model.DroppedWeapons[i]);
                            this.model.DroppedWeapons.RemoveAt(i--);
                            break;
                        }
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void RecalculateCamera()
        {
            bool swappedPlayer = this.model.SwappedPlayers;
            double diff;
            if (!swappedPlayer)
            {
                diff = (this.model.WindowWidth / 2) - (this.model.PlayerOne.Right + ((this.model.PlayerTwo.Left - this.model.PlayerOne.Right) / 2));
            }
            else
            {
                diff = (this.model.WindowWidth / 2) - (this.model.PlayerTwo.Right + ((this.model.PlayerOne.Left - this.model.PlayerTwo.Right) / 2));
            }

            // a fókuszban lévő játékos nem tudja elhagyni a pályát, követi a kamera elhagyja a pályát
            if (diff != 0)
            {
                if (this.model.ActualPlayer == 1)
                {
                    if (this.model.PlayerOne.Right + diff >= this.model.WindowWidth - Config.MinDistanceToSide)
                    {
                        diff = this.model.WindowWidth - Config.MinDistanceToSide - this.model.PlayerOne.Right;
                    }
                }
                else if (this.model.ActualPlayer == 2)
                {
                    if (this.model.PlayerTwo.Left + diff <= Config.MinDistanceToSide)
                    {
                        diff = Config.MinDistanceToSide - this.model.PlayerTwo.Left;
                    }
                }
            }

            // kamera a pályán marad
            if (diff != 0)
            {
                // a kamera nem megy ki balra a pályáról
                if (this.model.CameraPos + diff >= 0)
                {
                    diff = -this.model.CameraPos;
                }

                // a kamera nem megy ki jobbra a pályáról
                if (this.model.CameraPos + diff <= -(this.model.LevelWidth - this.model.WindowWidth))
                {
                    diff = -(this.model.LevelWidth - this.model.WindowWidth + this.model.CameraPos);
                }
            }

            if (diff != 0)
            {
                this.model.PlayerOne.ChangeX(diff);
                this.model.PlayerTwo.ChangeX(diff);
                this.model.CameraPos += diff;
                foreach (MapPart mapPart in this.model.Map)
                {
                    mapPart.ChangeX(diff);
                }

                foreach (MapPart mapPart in this.model.DeadlyMapParts)
                {
                    mapPart.ChangeX(diff);
                }

                foreach (IWeapon weapon in this.model.ThrowedWeapons)
                {
                    weapon.ChangeX(diff);
                }

                foreach (IWeapon weapon in this.model.DroppedWeapons)
                {
                    weapon.ChangeX(diff);
                }

                foreach (IWeapon weapon in this.model.WeaponsOnFloor)
                {
                    weapon.ChangeX(diff);
                }

                foreach (Arrow arrow in this.model.Arrows)
                {
                    arrow.ChangeX(diff);
                }

                foreach (Arrow arrow in this.model.StaticArrows)
                {
                    arrow.ChangeX(diff);
                }

                if (this.model.Finish != null)
                {
                    this.model.Finish.ChangeX(diff);
                }
            }
        }

        /// <inheritdoc/>
        public bool IsDead(Player player)
        {
            return player.Right < 0 || player.Left > this.model.WindowWidth;
        }

        /// <inheritdoc/>
        public bool IsReachedEndofMap(Player player)
        {
            if (player.PlayerNumber == 1)
            {
                return this.model.ActualPlayer == 1 && player.Texture.X > this.model.WindowWidth;
            }
            else
            {
                return this.model.ActualPlayer == 2 && player.Texture.Right < 0;
            }
        }

        /// <inheritdoc/>
        public void CreateDeathTask(Player player)
        {
            this.DropWeapon(player.Weapon, player.Direction, player.Texture.Y);
            player.Weapon = null;

            Task task;
            switch (player.PlayerNumber)
            {
                case 1:
                    this.model.PlayerOne.Dead = true; // minél hamarabb át kell állítani
                    task = new Task(() => this.MoveP1ToRespawnPos(), TaskCreationOptions.LongRunning);
                    task.Start();
                    this.tasks.Add(task);
                    this.ChangeFocus(2);
                    break;

                case 2:
                    this.model.PlayerTwo.Dead = true;
                    task = new Task(() => this.MoveP2ToRespawnPos(), TaskCreationOptions.LongRunning);
                    task.Start();
                    this.tasks.Add(task);
                    this.ChangeFocus(1);
                    break;
            }
        }

        /// <inheritdoc/>
        public void ChangeFocus(int player)
        {
            switch (player)
            {
                case 1:
                    if (!this.model.PlayerOne.Dead)
                    {
                        this.model.ActualPlayer = 1;
                    }
                    else
                    {
                        this.model.ActualPlayer = 0;
                    }

                    break;
                case 2:
                    if (!this.model.PlayerTwo.Dead)
                    {
                        this.model.ActualPlayer = 2;
                    }
                    else
                    {
                        this.model.ActualPlayer = 0;
                    }

                    break;
            }
        }

        /// <inheritdoc/>
        public void DetectKill()
        {
            if (this.model.PlayerTwo.Weapon != null && (this.model.PlayerOne.Hitbox.IntersectsWith(this.model.PlayerTwo.Weapon.Hitbox) || this.model.PlayerOne.HeadHitbox.IntersectsWith(this.model.PlayerTwo.Weapon.Hitbox)))
            {
                this.CreateDeathTask(this.model.PlayerOne);
            }

            if (this.model.PlayerOne.Weapon != null && (this.model.PlayerTwo.Hitbox.IntersectsWith(this.model.PlayerOne.Weapon.Hitbox) || this.model.PlayerTwo.HeadHitbox.IntersectsWith(this.model.PlayerOne.Weapon.Hitbox)))
            {
                this.CreateDeathTask(this.model.PlayerTwo);
            }

            for (int i = 0; i < this.model.ThrowedWeapons.Count; i++)
            {
                if (!this.model.PlayerOne.Dead && (this.model.PlayerOne.HeadHitbox.IntersectsWith(this.model.ThrowedWeapons[i].Hitbox) || this.model.PlayerOne.Hitbox.IntersectsWith(this.model.ThrowedWeapons[i].Hitbox)))
                {
                    if (this.model.ThrowedWeapons[i] is Sword)
                    {
                        this.CreateDeathTask(this.model.PlayerOne);
                    }
                    else
                    {
                        this.DropWeapon(this.model.PlayerOne.Weapon, this.model.PlayerTwo.Direction, this.model.PlayerOne.Texture.Y);
                        this.model.PlayerOne.Weapon = null;
                    }

                    this.DropWeapon(this.model.ThrowedWeapons[i], this.model.ThrowedWeapons[i].Dx < 0 ? Direction.Right : Direction.Left, this.model.ThrowedWeapons[i].Texture.Y);
                    this.model.ThrowedWeapons.RemoveAt(i--);
                }
                else if (!this.model.PlayerTwo.Dead && (this.model.PlayerTwo.HeadHitbox.IntersectsWith(this.model.ThrowedWeapons[i].Hitbox) || this.model.PlayerTwo.Hitbox.IntersectsWith(this.model.ThrowedWeapons[i].Hitbox)))
                {
                    if (this.model.ThrowedWeapons[i] is Sword)
                    {
                        this.CreateDeathTask(this.model.PlayerTwo);
                    }
                    else
                    {
                        this.DropWeapon(this.model.PlayerTwo.Weapon, this.model.PlayerTwo.Direction, this.model.PlayerTwo.Texture.Y);
                        this.model.PlayerTwo.Weapon = null;
                    }

                    this.DropWeapon(this.model.ThrowedWeapons[i], this.model.ThrowedWeapons[i].Dx < 0 ? Direction.Right : Direction.Left, this.model.ThrowedWeapons[i].Texture.Y);
                    this.model.ThrowedWeapons.RemoveAt(i--);
                }
            }

            for (int i = 0; i < this.model.Arrows.Count; i++)
            {
                if (!this.model.PlayerOne.Dead && (this.model.PlayerOne.HeadHitbox.IntersectsWith(this.model.Arrows[i].Hitbox) || this.model.PlayerOne.Hitbox.IntersectsWith(this.model.Arrows[i].Hitbox)))
                {
                    this.CreateDeathTask(this.model.PlayerOne);
                    this.model.Arrows.RemoveAt(i--);
                }
                else if (!this.model.PlayerTwo.Dead && (this.model.PlayerTwo.HeadHitbox.IntersectsWith(this.model.Arrows[i].Hitbox) || this.model.PlayerTwo.Hitbox.IntersectsWith(this.model.Arrows[i].Hitbox)))
                {
                    this.CreateDeathTask(this.model.PlayerTwo);
                    this.model.Arrows.RemoveAt(i--);
                }
            }

            foreach (MapPart mapPart in this.model.DeadlyMapParts)
            {
                if (!this.model.PlayerOne.Dead && this.model.PlayerOne.Hitbox.IntersectsWith(mapPart.Area) && this.model.PlayerOne.Hitbox.Y > mapPart.Area.Y)
                {
                    this.CreateDeathTask(this.model.PlayerOne);
                }

                if (!this.model.PlayerTwo.Dead && this.model.PlayerTwo.Hitbox.IntersectsWith(mapPart.Area) && this.model.PlayerTwo.Hitbox.Y > mapPart.Area.Y)
                {
                    this.CreateDeathTask(this.model.PlayerTwo);
                }
            }
        }

        /// <inheritdoc/>
        public void DetectWeaponCollision()
        {
            this.PlayersWeaponsCollision();
            this.WeaponsCollision();
            this.ArrowCollision();
        }

        /// <inheritdoc/>
        public void SaveToToplist(TopListItem tli)
        {
            if (this.model.Toplist.Count == 10)
            {
                this.model.Toplist.Remove(this.model.Toplist.Last());
            }

            this.model.Toplist.Add(tli);
            this.repository.ToTopList(this.model.Toplist);
        }

        private void PlayersWeaponsCollision()
        {
            if (this.model.PlayerOne.Weapon is Sword && this.model.PlayerTwo.Weapon is Sword)
            {
                if (this.model.PlayerOne.Weapon.Hitbox.IntersectsWith(this.model.PlayerTwo.Weapon.Hitbox))
                {
                    this.CreateKnockbackTasks();
                }
            }
        }

        private void WeaponsCollision()
        {
            for (int i = 0; i < this.model.ThrowedWeapons.Count; i++)
            {
                bool deleted = false;
                for (int j = i + 1; j < this.model.ThrowedWeapons.Count; j++)
                {
                    if (this.model.ThrowedWeapons[i].Hitbox.IntersectsWith(this.model.ThrowedWeapons[j].Hitbox))
                    {
                        deleted = true;
                        this.DropWeapon(this.model.ThrowedWeapons[i], this.model.ThrowedWeapons[i].Dx < 0 ? Direction.Right : Direction.Left, this.model.ThrowedWeapons[i].Texture.Y);
                        this.DropWeapon(this.model.ThrowedWeapons[j], this.model.ThrowedWeapons[j].Dx < 0 ? Direction.Right : Direction.Left, this.model.ThrowedWeapons[j].Texture.Y);
                        this.model.ThrowedWeapons.RemoveAt(j--);
                        this.model.ThrowedWeapons.RemoveAt(i--);
                        j--;
                    }
                }

                if (!deleted)
                {
                    if (this.model.PlayerOne.Weapon != null && this.model.ThrowedWeapons[i].Hitbox.IntersectsWith(this.model.PlayerOne.Weapon.Hitbox))
                    {
                        this.DropWeapon(this.model.ThrowedWeapons[i], this.model.ThrowedWeapons[i].Dx < 0 ? Direction.Right : Direction.Left, this.model.ThrowedWeapons[i].Texture.Y);
                        this.model.ThrowedWeapons.Remove(this.model.ThrowedWeapons[i]);
                    }
                    else if (this.model.PlayerTwo.Weapon != null && this.model.ThrowedWeapons[i].Hitbox.IntersectsWith(this.model.PlayerTwo.Weapon.Hitbox))
                    {
                        this.DropWeapon(this.model.ThrowedWeapons[i], this.model.ThrowedWeapons[i].Dx < 0 ? Direction.Right : Direction.Left, this.model.ThrowedWeapons[i].Texture.Y);
                        this.model.ThrowedWeapons.Remove(this.model.ThrowedWeapons[i]);
                    }
                }
            }
        }

        private void ArrowCollision()
        {
            for (int i = 0; i < this.model.Arrows.Count; i++)
            {
                bool deleted = false;
                int j = 0;
                while (!deleted && j < this.model.Map.Count)
                {
                    if (this.model.Arrows[i].Hitbox.IntersectsWith(this.model.Map[j].Area))
                    {
                        deleted = true;
                        if (this.model.Arrows[i].Dx > 0)
                        {
                            this.model.Arrows[i].SetX(this.model.Map[j].Area.X + (Config.RowSize * 0.2) - this.model.Arrows[i].Hitbox.Width);
                        }
                        else
                        {
                            this.model.Arrows[i].SetX(this.model.Map[j].Area.Right - (Config.RowSize * 0.2));
                        }

                        this.model.Arrows[i].Direction = this.model.Arrows[i].Dx > 0 ? Direction.Right : Direction.Left;
                        this.model.Arrows[i].Dx = 0;
                    }

                    j++;
                }

                if (!deleted)
                {
                    if (this.model.PlayerOne.Weapon != null && this.model.Arrows[i].Hitbox.IntersectsWith(this.model.PlayerOne.Weapon.Hitbox))
                    {
                        if (this.model.Arrows[i].Dx > 0)
                        {
                            this.model.Arrows[i].SetX(this.model.PlayerOne.Weapon.Hitbox.X - this.model.Arrows[i].Hitbox.Width);
                        }
                        else
                        {
                            this.model.Arrows[i].SetX(this.model.PlayerOne.Weapon.Hitbox.Right);
                        }

                        this.model.Arrows[i].Dx *= -1;
                    }
                    else if (this.model.PlayerTwo.Weapon != null && this.model.Arrows[i].Hitbox.IntersectsWith(this.model.PlayerTwo.Weapon.Hitbox))
                    {
                        if (this.model.Arrows[i].Dx > 0)
                        {
                            this.model.Arrows[i].SetX(this.model.PlayerTwo.Weapon.Hitbox.X - this.model.Arrows[i].Hitbox.Width);
                        }
                        else
                        {
                            this.model.Arrows[i].SetX(this.model.PlayerTwo.Weapon.Hitbox.Right);
                        }

                        this.model.Arrows[i].Dx *= -1;
                    }
                }

                if (deleted)
                {
                    this.model.StaticArrows.Add(this.model.Arrows[i]);
                    this.model.Arrows.RemoveAt(i);
                    i--;
                }
                else if (this.model.Arrows[i].Hitbox.X > this.model.WindowWidth || this.model.Arrows[i].Hitbox.Right < 0)
                {
                    deleted = true;
                    this.model.Arrows.RemoveAt(i);
                    i--;
                }

                if (!deleted)
                {
                    for (int k = i + 1; k < this.model.Arrows.Count; k++)
                    {
                        if (this.model.Arrows[i].Hitbox.IntersectsWith(this.model.Arrows[k].Hitbox))
                        {
                            // DropToFloor
                            this.model.Arrows.RemoveAt(k--);
                            this.model.Arrows.RemoveAt(i--);
                        }
                    }
                }
            }
        }

        private void CreateKnockbackTasks()
        {
            Task task = new Task(() => this.model.PlayerOne.Knockback(), TaskCreationOptions.LongRunning);
            task.Start();
            this.tasks.Add(task);
            task = new Task(() => this.model.PlayerTwo.Knockback(), TaskCreationOptions.LongRunning);
            task.Start();
            this.tasks.Add(task);
        }

        private void LockPlayer(Player player)
        {
            player.ResetPlayer(player.PlayerNumber == 1 ? 0 : this.model.WindowWidth);
            player.SetY(-500);
            player.Dead = true;
        }

        private void IsFinished()
        {
            if (this.model.Finish != null && (this.model.PlayerOne.Texture.IntersectsWith(this.model.Finish.Area) || this.model.PlayerTwo.Texture.IntersectsWith(this.model.Finish.Area)))
            {
                this.Finished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
