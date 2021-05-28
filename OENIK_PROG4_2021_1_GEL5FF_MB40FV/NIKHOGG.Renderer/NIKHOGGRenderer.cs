// <copyright file="NIKHOGGRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NIKHOGG.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using NIKHOGG.Elements;
    using NIKHOGG.Model;

    /// <summary>
    /// The renderer implemantion.
    /// </summary>
    public class NIKHOGGRenderer : IRenderer
    {
        private IModel model;
        private int runCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="NIKHOGGRenderer"/> class.
        /// </summary>
        /// <param name="model">IModel interface.</param>
        public NIKHOGGRenderer(IModel model)
        {
            this.model = model;
            this.runCounter = 0;
            this.SetupBrushes();
        }

        private Brush LvlIndicatorGradientBrush { get; set; }

        private Brush BackdoorInteriorBGBrush { get; set; }

        private Brush FirstFloorBGBrush { get; set; }

        private Brush FirstFloorFGBrush { get; set; }

        private Brush AudMaxBGBrush { get; set; }

        private Brush AudMaxFGBrush { get; set; }

        private Brush AulaBrush { get; set; }

        private Brush SmokingBrush { get; set; }

        private Brush SmokingFrgrndBrush { get; set; }

        private Brush EntranceBrush { get; set; }

        private Brush NeptunLakeBrush { get; set; }

        private Brush FinishBrush { get; set; }

        private Brush FirstEntranceBrush { get; set; }

        private Brush SmallSmokingBrush { get; set; }

        private Dictionary<int, Brush> LevelMappingBG { get; set; }

        private Dictionary<int, Brush> LevelMappingFG { get; set; }

        private Brush NeptunSwordBrushRight { get; set; }

        private Brush NeptunSwordBrushLeft { get; set; }

        private Brush NeptunSwordBrushThrowRight { get; set; }

        private Brush NeptunSwordBrushThrowLeft { get; set; }

        private Brush BowBrushRight { get; set; }

        private Brush BowBrushLeft { get; set; }

        private Brush BowStretchedBrushRight { get; set; }

        private Brush BowStretchedBrushLeft { get; set; }

        private Brush BowBrushThrowRight { get; set; }

        private Brush BowBrushThrowLeft { get; set; }

        private Brush BowBrushFloor { get; set; }

        private Brush ArrowBrushRight { get; set; }

        private Brush ArrowBrushLeft { get; set; }

        private Brush ArrowLowBrushRight { get; set; }

        private Brush ArrowLowBrushLeft { get; set; }

        private Brush P1HeadLeftBrush { get; set; }

        private Brush P1HeadRightBrush { get; set; }

        private Brush P1Bow1LeftBrush { get; set; }

        private Brush P1Bow1RightBrush { get; set; }

        private Brush P1Bow1StretchedLeftBrush { get; set; }

        private Brush P1Bow1StretchedRightBrush { get; set; }

        private Brush P1Bow2LeftBrush { get; set; }

        private Brush P1Bow2RightBrush { get; set; }

        private Brush P1LegStandLeftBrush { get; set; }

        private Brush P1LegStandRightBrush { get; set; }

        private Brush P1Leg1LeftBrush { get; set; }

        private Brush P1Leg1RightBrush { get; set; }

        private Brush P1Leg2LeftBrush { get; set; }

        private Brush P1Leg2RightBrush { get; set; }

        private Brush P1SquatLeftBrush { get; set; }

        private Brush P1SquatRightBrush { get; set; }

        private Brush P1Sword1LeftBrush { get; set; }

        private Brush P1Sword1RightBrush { get; set; }

        private Brush P1Sword2LeftBrush { get; set; }

        private Brush P1Sword2RightBrush { get; set; }

        private Brush P1Sword3LeftBrush { get; set; }

        private Brush P1Sword3RightBrush { get; set; }

        private Brush P1SwordAttack1LeftBrush { get; set; }

        private Brush P1SwordAttack1RightBrush { get; set; }

        private Brush P1SwordAttack2LeftBrush { get; set; }

        private Brush P1SwordAttack2RightBrush { get; set; }

        private Brush P1SwordAttack3LeftBrush { get; set; }

        private Brush P1SwordAttack3RightBrush { get; set; }

        private Brush P1SwordSquatLeftBrush { get; set; }

        private Brush P1SwordSquatRightBrush { get; set; }

        private Brush P1ThrowLeftBrush { get; set; }

        private Brush P1ThrowRightBrush { get; set; }

        private Brush P2HeadLeftBrush { get; set; }

        private Brush P2HeadRightBrush { get; set; }

        private Brush P2Bow1LeftBrush { get; set; }

        private Brush P2Bow1RightBrush { get; set; }

        private Brush P2Bow1StretchedLeftBrush { get; set; }

        private Brush P2Bow1StretchedRightBrush { get; set; }

        private Brush P2Bow2LeftBrush { get; set; }

        private Brush P2Bow2RightBrush { get; set; }

        private Brush P2LegStandLeftBrush { get; set; }

        private Brush P2LegStandRightBrush { get; set; }

        private Brush P2Leg1LeftBrush { get; set; }

        private Brush P2Leg1RightBrush { get; set; }

        private Brush P2Leg2LeftBrush { get; set; }

        private Brush P2Leg2RightBrush { get; set; }

        private Brush P2SquatLeftBrush { get; set; }

        private Brush P2SquatRightBrush { get; set; }

        private Brush P2Sword1LeftBrush { get; set; }

        private Brush P2Sword1RightBrush { get; set; }

        private Brush P2Sword2LeftBrush { get; set; }

        private Brush P2Sword2RightBrush { get; set; }

        private Brush P2Sword3LeftBrush { get; set; }

        private Brush P2Sword3RightBrush { get; set; }

        private Brush P2SwordAttack1LeftBrush { get; set; }

        private Brush P2SwordAttack1RightBrush { get; set; }

        private Brush P2SwordAttack2LeftBrush { get; set; }

        private Brush P2SwordAttack2RightBrush { get; set; }

        private Brush P2SwordAttack3LeftBrush { get; set; }

        private Brush P2SwordAttack3RightBrush { get; set; }

        private Brush P2SwordSquatLeftBrush { get; set; }

        private Brush P2SwordSquatRightBrush { get; set; }

        private Brush P2ThrowLeftBrush { get; set; }

        private Brush P2ThrowRightBrush { get; set; }

        /// <summary>
        /// Build drawings.
        /// </summary>
        /// <param name="drawingContext">The drawing context.</param>
        public void BuildDrawing(DrawingContext drawingContext)
        {
            switch (this.model.Status)
            {
                case ModelStatus.Loading: this.DrawLoadingScreen(drawingContext); break;
                case ModelStatus.GamePlay: this.DrawGame(drawingContext); break;
                case ModelStatus.Paused: this.DrawGame(drawingContext); break;
            }
        }

        /// <summary>
        /// Gets the brush by a stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The brush.</returns>
        private Brush GetBrush(Stream stream)
        {
            BitmapImage bg = new BitmapImage();
            bg.BeginInit();
            bg.StreamSource = stream;
            bg.EndInit();
            ImageBrush ib = new ImageBrush(bg);

            return ib;
        }

        private void SetupBrushes()
        {
            this.LvlIndicatorGradientBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.LevelIndicatorGradientPath));
            this.BackdoorInteriorBGBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.BackdoorInteriorBGPath));
            this.FirstFloorBGBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.FirstFloorBGPath));
            this.FirstFloorFGBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.FirstFloorFGPath));
            this.AudMaxBGBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.AudmaxBGPath));
            this.AudMaxFGBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.AudmaxFGPath));
            this.EntranceBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.EntrancePath));
            this.AulaBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.AulaPath));
            this.SmokingBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.SmokingPath));
            this.SmokingFrgrndBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.SmokingFgPath));
            this.NeptunLakeBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.NeptunLakePath));
            this.FinishBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.FinishPath));
            this.FirstEntranceBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.FirstEntrancePath));
            this.SmallSmokingBrush = this.GetBrush(Resource.GetStream(FileType.Image, Config.SmallSmokingPath));

            this.LevelMappingBG = new Dictionary<int, Brush>();
            this.LevelMappingBG.Add(1, this.FirstEntranceBrush);
            this.LevelMappingBG.Add(2, this.BackdoorInteriorBGBrush);
            this.LevelMappingBG.Add(3, this.FirstFloorBGBrush);
            this.LevelMappingBG.Add(4, this.SmokingBrush);
            this.LevelMappingBG.Add(5, this.AudMaxBGBrush);
            this.LevelMappingBG.Add(6, this.AulaBrush);
            this.LevelMappingBG.Add(7, this.EntranceBrush);

            this.LevelMappingFG = new Dictionary<int, Brush>();
            this.LevelMappingFG.Add(1, Brushes.Transparent);
            this.LevelMappingFG.Add(2, Brushes.Transparent);
            this.LevelMappingFG.Add(3, this.FirstFloorFGBrush);
            this.LevelMappingFG.Add(4, this.SmokingFrgrndBrush);
            this.LevelMappingFG.Add(5, this.AudMaxFGBrush);
            this.LevelMappingFG.Add(6, Brushes.Transparent);
            this.LevelMappingFG.Add(7, Brushes.Transparent);

            this.NeptunSwordBrushLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.NeptunSwordLeftPath));
            this.NeptunSwordBrushRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.NeptunSwordRightPath));
            this.NeptunSwordBrushThrowLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.NeptunSwordThrowLeftPath));
            this.NeptunSwordBrushThrowRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.NeptunSwordThrowRightPath));

            this.BowBrushLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowLeftPath));
            this.BowBrushRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowRightPath));
            this.BowStretchedBrushLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowStretchedLeftPath));
            this.BowStretchedBrushRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowStretchedRightPath));
            this.BowBrushThrowLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowThrowLeftPath));
            this.BowBrushThrowRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowThrowRightPath));
            this.BowBrushFloor = this.GetBrush(Resource.GetStream(FileType.Image, Config.BowFloorPath));

            this.ArrowBrushLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.ArrowLeftPath));
            this.ArrowBrushRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.ArrowRightPath));
            this.ArrowLowBrushLeft = this.GetBrush(Resource.GetStream(FileType.Image, Config.ArrowLowLeftPath));
            this.ArrowLowBrushRight = this.GetBrush(Resource.GetStream(FileType.Image, Config.ArrowLowRightPath));

            this.P1HeadLeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1HeadLeftPath));
            this.P1HeadRightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1HeadRightPath));
            this.P1Bow1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Bow1LeftPath));
            this.P1Bow1RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Bow1RightPath));
            this.P1Bow1StretchedLeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Bow1StretchedLeftPath));
            this.P1Bow1StretchedRightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Bow1StretchedRightPath));
            this.P1Bow2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Bow2LeftPath));
            this.P1Bow2RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Bow2RightPath));
            this.P1LegStandLeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1LegStandLeftPath));
            this.P1LegStandRightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1LegStandRightPath));
            this.P1Leg1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Leg1LeftPath));
            this.P1Leg1RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Leg1RightPath));
            this.P1Leg2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Leg2LeftPath));
            this.P1Leg2RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Leg2RightPath));
            this.P1SquatLeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SquatLeftPath));
            this.P1SquatRightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SquatRightPath));
            this.P1Sword1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Sword1LeftPath));
            this.P1Sword1RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Sword1RightPath));
            this.P1Sword2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Sword2LeftPath));
            this.P1Sword2RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Sword2RightPath));
            this.P1Sword3LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Sword3LeftPath));
            this.P1Sword3RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1Sword3RightPath));
            this.P1SwordAttack1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordAttack1LeftPath));
            this.P1SwordAttack1RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordAttack1RightPath));
            this.P1SwordAttack2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordAttack2LeftPath));
            this.P1SwordAttack2RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordAttack2RightPath));
            this.P1SwordAttack3LeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordAttack3LeftPath));
            this.P1SwordAttack3RightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordAttack3RightPath));
            this.P1SwordSquatLeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordSquatLeftPath));
            this.P1SwordSquatRightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1SwordSquatRightPath));
            this.P1ThrowLeftBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1ThrowLeftPath));
            this.P1ThrowRightBrush = this.GetBrush(Resource.GetStream(FileType.P1, Config.P1ThrowRightPath));

            this.P2HeadLeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2HeadLeftPath));
            this.P2HeadRightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2HeadRightPath));
            this.P2Bow1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Bow1LeftPath));
            this.P2Bow1RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Bow1RightPath));
            this.P2Bow1StretchedLeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Bow1StretchedLeftPath));
            this.P2Bow1StretchedRightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Bow1StretchedRightPath));
            this.P2Bow2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Bow2LeftPath));
            this.P2Bow2RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Bow2RightPath));
            this.P2LegStandLeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2LegStandLeftPath));
            this.P2LegStandRightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2LegStandRightPath));
            this.P2Leg1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Leg1LeftPath));
            this.P2Leg1RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Leg1RightPath));
            this.P2Leg2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Leg2LeftPath));
            this.P2Leg2RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Leg2RightPath));
            this.P2SquatLeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SquatLeftPath));
            this.P2SquatRightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SquatRightPath));
            this.P2Sword1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Sword1LeftPath));
            this.P2Sword1RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Sword1RightPath));
            this.P2Sword2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Sword2LeftPath));
            this.P2Sword2RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Sword2RightPath));
            this.P2Sword3LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Sword3LeftPath));
            this.P2Sword3RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2Sword3RightPath));
            this.P2SwordAttack1LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordAttack1LeftPath));
            this.P2SwordAttack1RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordAttack1RightPath));
            this.P2SwordAttack2LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordAttack2LeftPath));
            this.P2SwordAttack2RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordAttack2RightPath));
            this.P2SwordAttack3LeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordAttack3LeftPath));
            this.P2SwordAttack3RightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordAttack3RightPath));
            this.P2SwordSquatLeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordSquatLeftPath));
            this.P2SwordSquatRightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2SwordSquatRightPath));
            this.P2ThrowLeftBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2ThrowLeftPath));
            this.P2ThrowRightBrush = this.GetBrush(Resource.GetStream(FileType.P2, Config.P2ThrowRightPath));
        }

        private void DrawLoadingScreen(DrawingContext drawingContext)
        {
            DrawingGroup loadingScreen = new DrawingGroup();
            loadingScreen.Children.Add(new GeometryDrawing(Brushes.Black, null, new RectangleGeometry(new Rect(0 + this.model.CameraPos, 0, this.model.LevelWidth, this.model.LevelHeight))));
            drawingContext.DrawDrawing(loadingScreen);
        }

        private void DrawGame(DrawingContext drawingContext)
        {
            this.RunCounterPlus();

            drawingContext.DrawDrawing(this.GetBackGround());

            this.DrawThrowedAndDroppedWeapons(drawingContext);

            drawingContext.DrawDrawing(this.GetWeaponsOnFloor());

            drawingContext.DrawDrawing(this.GetArrows());

            drawingContext.DrawDrawing(this.GetP1());
            drawingContext.DrawDrawing(this.GetP2());

            drawingContext.DrawDrawing(this.GetMapParts());

            drawingContext.DrawDrawing(this.GetForeGround());

            drawingContext.DrawDrawing(this.GetLvlIndicator());

            if (this.model.Status == ModelStatus.Paused)
            {
                drawingContext.DrawDrawing(this.GetIngameMenu());
            }
        }

        private DrawingGroup GetIngameMenu()
        {
            DrawingGroup ingameMenu = new DrawingGroup();

            return ingameMenu;
        }

        private void RunCounterPlus()
        {
            this.runCounter++;
            if (this.runCounter >= 10)
            {
                this.runCounter = 0;
            }
        }

        private Brush GetThrowedDroppedWeaponBrush(IWeapon weapon)
        {
            if (weapon is Sword)
            {
                if (weapon.Dx < 0)
                {
                    return this.NeptunSwordBrushThrowRight;
                }
                else
                {
                    return this.NeptunSwordBrushThrowLeft;
                }
            }
            else
            {
                if (weapon.Dx < 0)
                {
                    return this.BowBrushThrowRight;
                }
                else
                {
                    return this.BowBrushThrowLeft;
                }
            }
        }

        private void DrawThrowedAndDroppedWeapons(DrawingContext drawingContext)
        {
            foreach (IWeapon weapon in this.model.ThrowedWeapons.Concat(this.model.DroppedWeapons))
            {
                DrawingGroup tmp = new DrawingGroup();
                tmp.Children.Add(new GeometryDrawing(this.GetThrowedDroppedWeaponBrush(weapon), null, new RectangleGeometry(weapon.Texture)));
                tmp.Transform = weapon.Rotate();

                drawingContext.DrawDrawing(tmp);
            }
        }

        private DrawingGroup GetWeaponsOnFloor()
        {
            DrawingGroup weaponsOnFloor = new DrawingGroup();
            foreach (IWeapon weapon in this.model.WeaponsOnFloor)
            {
                if (weapon is Sword)
                {
                    weaponsOnFloor.Children.Add(new GeometryDrawing(weapon.Dx < 0 ? this.NeptunSwordBrushLeft : this.NeptunSwordBrushRight, null, new RectangleGeometry(weapon.Texture)));
                }
                else
                {
                    weaponsOnFloor.Children.Add(new GeometryDrawing(this.BowBrushFloor, null, new RectangleGeometry(weapon.Texture)));
                }
            }

            return weaponsOnFloor;
        }

        private DrawingGroup GetArrows()
        {
            DrawingGroup arrows = new DrawingGroup();
            foreach (Arrow arrow in this.model.Arrows)
            {
                arrows.Children.Add(new GeometryDrawing(arrow.Dx < 0 ? this.ArrowBrushLeft : this.ArrowBrushRight, null, new RectangleGeometry(arrow.Hitbox)));
            }

            foreach (Arrow arrow in this.model.StaticArrows)
            {
                arrows.Children.Add(new GeometryDrawing(arrow.Direction == Direction.Left ? this.ArrowBrushLeft : this.ArrowBrushRight, null, new RectangleGeometry(arrow.Hitbox)));
            }

            return arrows;
        }

        private DrawingGroup GetWeaponForPlayer(Player player)
        {
            DrawingGroup weapon = new DrawingGroup();
            if (player.Weapon != null)
            {
                if (player.Weapon is Sword)
                {
                    if (player.Weapon.Position == 0)
                    {
                        weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.NeptunSwordBrushThrowLeft : this.NeptunSwordBrushThrowRight, null, new RectangleGeometry(player.Weapon.Texture)));
                    }
                    else
                    {
                        // weapon.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry(player.Weapon.Hitbox)));
                        weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.NeptunSwordBrushLeft : this.NeptunSwordBrushRight, null, new RectangleGeometry(player.Weapon.Texture)));
                    }
                }
                else
                {
                    if (player.Weapon.Position == 0)
                    {
                        weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.BowBrushThrowLeft : this.BowBrushThrowRight, null, new RectangleGeometry(player.Weapon.Texture)));
                    }
                    else
                    {
                        if ((player.Weapon as Bow).Stretched)
                        {
                            // weapon.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry((player.Weapon as Bow).Arrow.Hitbox)));
                            weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.BowStretchedBrushLeft : this.BowStretchedBrushRight, null, new RectangleGeometry(player.Weapon.Texture)));
                            weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.ArrowBrushLeft : this.ArrowBrushRight, null, new RectangleGeometry((player.Weapon as Bow).Arrow.Texture)));
                        }
                        else
                        {
                            // weapon.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry((player.Weapon as Bow).Arrow.Hitbox)));
                            weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.BowBrushLeft : this.BowBrushRight, null, new RectangleGeometry(player.Weapon.Texture)));
                            weapon.Children.Add(new GeometryDrawing(player.Direction == Direction.Left ? this.ArrowLowBrushLeft : this.ArrowLowBrushRight, null, new RectangleGeometry((player.Weapon as Bow).Arrow.Texture)));
                        }
                    }
                }
            }

            return weapon;
        }

        private DrawingGroup GetBackGround()
        {
            return new DrawingGroup()
            {
                Children = new DrawingCollection()
                {
                new GeometryDrawing(this.LevelMappingBG.GetValueOrDefault(this.model.CurrentLevel, this.FirstEntranceBrush), null, new RectangleGeometry(new Rect(0 + this.model.CameraPos, 0, this.model.LevelWidth, this.model.LevelHeight))),
                },
            };
        }

        private DrawingGroup GetForeGround()
        {
            return new DrawingGroup()
            {
                Children = new DrawingCollection()
                {
                new GeometryDrawing(this.LevelMappingFG.GetValueOrDefault(this.model.CurrentLevel, this.FirstEntranceBrush), null, new RectangleGeometry(new Rect(0 + this.model.CameraPos, 0, this.model.LevelWidth, this.model.LevelHeight))),
                },
            };
        }

        private DrawingGroup GetP1()
        {
            DrawingGroup playerGroup = new DrawingGroup();

            // playerGroup.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry(model.P1.Hitbox)));
            // playerGroup.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry(model.P1.HeadHitbox)));
            if (!this.model.PlayerOne.IsSquat && !this.model.PlayerOne.IsAttack)
            {
                if (this.model.PlayerOne.Dx == 0)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1LegStandLeftBrush : this.P1LegStandRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                }
                else
                {
                    if (this.runCounter < 5)
                    {
                        playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Leg1LeftBrush : this.P1Leg1RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                    }
                    else
                    {
                        playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Leg2LeftBrush : this.P1Leg2RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                    }
                }
            }

            if (this.model.PlayerOne.Weapon == null)
            {
                if (this.model.PlayerOne.IsSquat)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1SquatLeftBrush : this.P1SquatRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                }
                else
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1ThrowLeftBrush : this.P1ThrowRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                }
            }
            else if (this.model.PlayerOne.Weapon is Sword)
            {
                if (this.model.PlayerOne.IsSquat)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1SwordSquatLeftBrush : this.P1SwordSquatRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                }
                else if (this.model.PlayerOne.IsAttack)
                {
                    switch (this.model.PlayerOne.Weapon.Position)
                    {
                        case 1:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1SwordAttack1LeftBrush : this.P1SwordAttack1RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                        case 2:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1SwordAttack2LeftBrush : this.P1SwordAttack2RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                        case 3:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1SwordAttack3LeftBrush : this.P1SwordAttack3RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                    }
                }
                else
                {
                    switch (this.model.PlayerOne.Weapon.Position)
                    {
                        case 0:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1ThrowLeftBrush : this.P1ThrowRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                        case 1:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Sword1LeftBrush : this.P1Sword1RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                        case 2:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Sword2LeftBrush : this.P1Sword2RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                        case 3:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Sword3LeftBrush : this.P1Sword3RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                    }
                }
            }
            else if (this.model.PlayerOne.Weapon is Bow)
            {
                if (this.model.PlayerOne.IsSquat)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Bow2LeftBrush : this.P1Bow2RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                }
                else
                {
                    switch (this.model.PlayerOne.Weapon.Position)
                    {
                        case 0:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1ThrowLeftBrush : this.P1ThrowRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            break;
                        case 2:
                            if ((this.model.PlayerOne.Weapon as Bow).Stretched)
                            {
                                playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Bow1StretchedLeftBrush : this.P1Bow1StretchedRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            }
                            else
                            {
                                playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1Bow1LeftBrush : this.P1Bow1RightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
                            }

                            break;
                    }
                }
            }

            foreach (var item in this.GetWeaponForPlayer(this.model.PlayerOne).Children)
            {
                playerGroup.Children.Add(item);
            }

            if (!this.model.PlayerOne.IsSquat && !this.model.PlayerOne.IsAttack)
            {
                playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerOne.Direction == Direction.Left ? this.P1HeadLeftBrush : this.P1HeadRightBrush, null, new RectangleGeometry(this.model.PlayerOne.Texture)));
            }

            return playerGroup;
        }

        private DrawingGroup GetP2()
        {
            DrawingGroup playerGroup = new DrawingGroup();

            // playerGroup.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry(model.P2.Hitbox)));
            // playerGroup.Children.Add(new GeometryDrawing(Brushes.Cyan, null, new RectangleGeometry(model.P2.HeadHitbox)));
            if (!this.model.PlayerTwo.IsSquat && !this.model.PlayerTwo.IsAttack)
            {
                if (this.model.PlayerTwo.Dx == 0)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2LegStandLeftBrush : this.P2LegStandRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                }
                else
                {
                    if (this.runCounter < 5)
                    {
                        playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Leg1LeftBrush : this.P2Leg1RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                    }
                    else
                    {
                        playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Leg2LeftBrush : this.P2Leg2RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                    }
                }
            }

            if (this.model.PlayerTwo.Weapon == null)
            {
                if (this.model.PlayerTwo.IsSquat)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2SquatLeftBrush : this.P2SquatRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                }
                else
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2ThrowLeftBrush : this.P2ThrowRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                }
            }
            else if (this.model.PlayerTwo.Weapon is Sword)
            {
                if (this.model.PlayerTwo.IsSquat)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2SwordSquatLeftBrush : this.P2SwordSquatRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                }
                else if (this.model.PlayerTwo.IsAttack)
                {
                    switch (this.model.PlayerTwo.Weapon.Position)
                    {
                        case 1:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2SwordAttack1LeftBrush : this.P2SwordAttack1RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                        case 2:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2SwordAttack2LeftBrush : this.P2SwordAttack2RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                        case 3:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2SwordAttack3LeftBrush : this.P2SwordAttack3RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                    }
                }
                else
                {
                    switch (this.model.PlayerTwo.Weapon.Position)
                    {
                        case 0:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2ThrowLeftBrush : this.P2ThrowRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                        case 1:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Sword1LeftBrush : this.P2Sword1RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                        case 2:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Sword2LeftBrush : this.P2Sword2RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                        case 3:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Sword3LeftBrush : this.P2Sword3RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                    }
                }
            }
            else if (this.model.PlayerTwo.Weapon is Bow)
            {
                if (this.model.PlayerTwo.IsSquat)
                {
                    playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Bow2LeftBrush : this.P2Bow2RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                }
                else
                {
                    switch (this.model.PlayerTwo.Weapon.Position)
                    {
                        case 0:
                            playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2ThrowLeftBrush : this.P2ThrowRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            break;
                        case 2:
                            if ((this.model.PlayerTwo.Weapon as Bow).Stretched)
                            {
                                playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Bow1StretchedLeftBrush : this.P2Bow1StretchedRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            }
                            else
                            {
                                playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2Bow1LeftBrush : this.P2Bow1RightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
                            }

                            break;
                    }
                }
            }

            foreach (var item in this.GetWeaponForPlayer(this.model.PlayerTwo).Children)
            {
                playerGroup.Children.Add(item);
            }

            if (!this.model.PlayerTwo.IsSquat && !this.model.PlayerTwo.IsAttack)
            {
                playerGroup.Children.Add(new GeometryDrawing(this.model.PlayerTwo.Direction == Direction.Left ? this.P2HeadLeftBrush : this.P2HeadRightBrush, null, new RectangleGeometry(this.model.PlayerTwo.Texture)));
            }

            return playerGroup;
        }

        private DrawingGroup GetMapParts()
        {
            DrawingGroup mapParts = new DrawingGroup();
            foreach (MapPart mapPart in this.model.DeadlyMapParts)
            {
                mapParts.Children.Add(new GeometryDrawing(this.NeptunLakeBrush, null, new RectangleGeometry(mapPart.Area)));
            }

            if (this.model.Finish != null)
            {
                mapParts.Children.Add(new GeometryDrawing(this.FinishBrush, null, new RectangleGeometry(this.model.Finish.Area)));
            }

            return mapParts;
        }

        private DrawingGroup GetLvlIndicator()
        {
            DrawingGroup indicator = new DrawingGroup();
            for (int i = 0; i < this.model.LevelIndicator.Count; i++)
            {
                switch (this.model.ActualPlayer)
                {
                    case 0:
                        if (i == this.model.CurrentLevel - 1)
                        {
                            indicator.Children.Add(new GeometryDrawing(this.LvlIndicatorGradientBrush, new Pen(this.LvlIndicatorGradientBrush, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }
                        else if (i < this.model.CurrentLevel - 1)
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.Transparent, new Pen(Brushes.White, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }
                        else
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.Transparent, new Pen(Brushes.Black, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }

                        break;
                    case 1:
                        if (i == this.model.CurrentLevel - 1)
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }
                        else if (i < this.model.CurrentLevel - 1)
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }
                        else
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.Transparent, new Pen(Brushes.Black, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }

                        break;
                    case 2:
                        if (i == this.model.CurrentLevel - 1)
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }
                        else if (i < this.model.CurrentLevel - 1)
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.Transparent, new Pen(Brushes.White, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }
                        else
                        {
                            indicator.Children.Add(new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 5), new RectangleGeometry(this.model.LevelIndicator[i], 10, 10)));
                        }

                        break;
                }
            }

            return indicator;
        }
    }
}