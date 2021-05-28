// <copyright file="LogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RLCSX.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using NIKHOGG.Elements;
    using NIKHOGG.Logic;
    using NIKHOGG.Model;
    using NUnit.Framework;

    /// <summary>LogicTests class.</summary>
    [TestFixture]
    public class LogicTests
    {
        private ILogic logic;
        private IModel model;

        /// <summary>Create model and logic.</summary>
        [SetUp]
        public void Init()
        {
            Config.Scale = 400 / 500.0;
            Config.RowSize = 500 / Config.Rows;
            Config.StartingCameraPos = 250;
            Config.MaxCameraPos = 500 - (Config.LevelWidth * Config.Scale);

            this.model = new NIKHOGGModel(Config.LevelWidth * Config.Scale, 500, 500, 500);
            this.logic = new NIKHOGGLogic(this.model);
        }

        /// <summary>
        /// Test for play jump.
        /// </summary>
        [Test]
        public void Test1()
        {
            double a = this.model.PlayerOne.Dy;
            this.logic.Jump(this.model.PlayerOne);
            Assert.That(this.model.PlayerOne.Dy != a);
        }

        /// <summary>
        /// Test for player move.
        /// </summary>
        [Test]
        public void Test2()
        {
            this.logic.ChangeAx(this.model.PlayerOne, Direction.Left, true);
            Assert.That(this.model.PlayerOne.Ax == -Config.PlayerAX);
        }

        /// <summary>
        /// Test for attack.
        /// </summary>
        [Test]
        public void Test3()
        {
            bool a = this.model.PlayerOne.IsAttack;
            this.logic.Attack(this.model.PlayerOne);
            Thread.Sleep(200);
            Assert.That(a != this.model.PlayerOne.IsAttack);
        }

        /// <summary>
        /// Test for focus change.
        /// </summary>
        [Test]
        public void Test4()
        {
            this.model.PlayerOne.Dead = true;
            this.logic.ChangeFocus(1);
            Assert.That(this.model.ActualPlayer == 0);
        }

        /// <summary>
        /// Test for throwing weapon.
        /// </summary>
        [Test]
        public void Test5()
        {
            this.logic.ThrowWeapon(this.model.PlayerOne);
            Assert.That(this.model.PlayerOne.Weapon == null);
        }
    }
}
