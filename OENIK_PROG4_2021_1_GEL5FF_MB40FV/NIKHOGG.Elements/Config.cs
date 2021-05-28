// <copyright file="Config.cs" company="PlaceholderCompany">
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
    /// The configuration class.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Gets or sets tick time.
        /// </summary>
        public static int TickTime { get; set; } = 40;

        /// <summary>
        /// Gets or sets fPS.
        /// </summary>
        public static int FPS { get; set; } = 1000 / TickTime;

        /// <summary>
        /// Gets or sets tick time in seconds.
        /// </summary>
        public static double TickTimetoSec { get; set; } = TickTime / 1000.0;

        /// <summary>
        /// Gets or sets level width.
        /// </summary>
        public static int LevelWidth { get; set; } = 2000;

        /// <summary>
        /// Gets or sets level height.
        /// </summary>
        public static int LevelHeight { get; set; } = 400;

        /// <summary>
        /// Gets or sets scale.
        /// </summary>
        public static double Scale { get; set; } = 0;

        /// <summary>
        /// Gets or sets rows.
        /// </summary>
        public static int Rows { get; set; } = 20;

        /// <summary>
        /// Gets or sets row size.
        /// </summary>
        public static double RowSize { get; set; } = 0;

        /// <summary>
        /// Gets or sets minimum camera position.
        /// </summary>
        public static double MinCameraPos { get; set; } = 0;

        /// <summary>
        /// Gets or sets starting camera position.
        /// </summary>
        public static double StartingCameraPos { get; set; } = 0;

        /// <summary>
        /// Gets or sets maximum camera position.
        /// </summary>
        public static double MaxCameraPos { get; set; } = 0;

        /// <summary>
        /// Gets or sets spaw distance at start.
        /// </summary>
        public static int SpawDistanceAtStart { get; set; } = 250;

        /// <summary>
        /// Gets or sets player a x position.
        /// </summary>
        public static int PlayerAX { get; set; } = 50;

        /// <summary>
        /// Gets or sets player a y position.
        /// </summary>
        public static int PlayerAY { get; set; } = 100;

        /// <summary>
        /// Gets or sets maximum velocity of players.
        /// </summary>
        public static int MaxPlayerDX { get; set; } = 13;

        /// <summary>
        /// Gets or sets jump speed.
        /// </summary>
        public static int JumpSpeed { get; set; } = 50;

        /// <summary>
        /// Gets or sets minimum distance to side.
        /// </summary>
        public static int MinDistanceToSide { get; set; } = 150;

        /// <summary>
        /// Gets or sets minimum respawn distance.
        /// </summary>
        public static int MinRespawnDistance { get; set; } = 400;

        /// <summary>
        /// Gets or sets respawn time in second.
        /// </summary>
        public static int RespawnTimeInSec { get; set; } = 2;

        /// <summary>
        /// Gets or sets the Respawn velocity.
        /// </summary>
        public static int RespawnDX { get; set; } = 30;

        /// <summary>
        /// Gets or sets player width.
        /// </summary>
        public static int PlayerWidth { get; set; } = 2;

        /// <summary>
        /// Gets or sets player height.
        /// </summary>
        public static int PlayerHeight { get; set; } = 3;

        /// <summary>
        /// Gets or sets maximum weapon velocity.
        /// </summary>
        public static int MaxWeaponDx { get; set; } = 30;

        /// <summary>
        /// Gets or sets player weapon distance.
        /// </summary>
        public static double PlayerWeaponDistance { get; set; } = 0.3;

        /// <summary>
        /// Gets or sets sword width.
        /// </summary>
        public static int SwordWidth { get; set; } = 3;

        /// <summary>
        /// Gets or sets arrow width.
        /// </summary>
        public static double ArrowWidth { get; set; } = 2.5;

        /// <summary>
        /// Gets or sets arrow height.
        /// </summary>
        public static double ArrowHeight { get; set; } = 0.9;

        /// <summary>
        /// Gets or sets attack speed.
        /// </summary>
        public static int AttackSpeed { get; set; } = 10;

        /// <summary>
        /// Gets or sets transfrom angle.
        /// </summary>
        public static int TransformAngle { get; set; } = 30;

        /// <summary>
        /// Gets or sets level indicator Y position.
        /// </summary>
        public static int LevelIndicatorY { get; set; } = 75;

        /// <summary>
        /// Gets or sets level indicator width.
        /// </summary>
        public static int LevelIndicatorWidth { get; set; } = 80;

        /// <summary>
        /// Gets or sets level indicator height.
        /// </summary>
        public static int LevelIndicatorHeight { get; set; } = 60;

        /// <summary>
        /// Gets or sets level indicator distance.
        /// </summary>
        public static int LevelIndicatorDistance { get; set; } = 30;

        /// <summary>
        /// Gets or sets level indicator gradient path.
        /// </summary>
        public static string LevelIndicatorGradientPath { get; set; } = "lvlindicator_gradient.png";

        /// <summary>
        /// Gets or sets backdoor interior background path.
        /// </summary>
        public static string BackdoorInteriorBGPath { get; set; } = "hatso_bejarat_belul_bg.png";

        /// <summary>
        /// Gets or sets or set first floor background path.
        /// </summary>
        public static string FirstFloorBGPath { get; set; } = "elso_emelet_bg.png";

        /// <summary>
        /// Gets or sets first floor background path.
        /// </summary>
        public static string FirstFloorFGPath { get; set; } = "elso_emelet_fg.png";

        /// <summary>
        /// Gets or sets audmax background path.
        /// </summary>
        public static string AudmaxBGPath { get; set; } = "audmax_bg.png";

        /// <summary>
        /// Gets or sets audmax foreground path.
        /// </summary>
        public static string AudmaxFGPath { get; set; } = "audmax_fg.png";

        /// <summary>
        /// Gets or sets smoking path.
        /// </summary>
        public static string SmokingPath { get; set; } = "smoking.png";

        /// <summary>
        /// Gets or sets smoking foreground path.
        /// </summary>
        public static string SmokingFgPath { get; set; } = "smoking_frgrnd.png";

        /// <summary>
        /// Gets or sets aula path.
        /// </summary>
        public static string AulaPath { get; set; } = "aula.png";

        /// <summary>
        /// Gets or sets entrance path.
        /// </summary>
        public static string EntrancePath { get; set; } = "obudaiegyetem.png";

        /// <summary>
        /// Gets or sets neptun lake path.
        /// </summary>
        public static string NeptunLakePath { get; set; } = "neptun_to.png";

        /// <summary>
        /// Gets or sets first entrance path.
        /// </summary>
        public static string FirstEntrancePath { get; set; } = "first_entrance.png";

        /// <summary>
        /// Gets or sets small smoking path.
        /// </summary>
        public static string SmallSmokingPath { get; set; } = "small_smoking.png";

        /// <summary>
        /// Gets or sets main menu background.
        /// </summary>
        public static string MainMenuBckgrnd { get; set; } = "background.png";

        /// <summary>
        /// Gets or sets pause menu background.
        /// </summary>
        public static string PauseMenuBGBrush { get; set; } = "pause_menu_bckgrnd.png";

        /// <summary>
        /// Gets or sets neptun sword left path.
        /// </summary>
        public static string NeptunSwordLeftPath { get; set; } = "neptun_kard_l.png";

        /// <summary>
        /// Gets or sets neptun sword right path.
        /// </summary>
        public static string NeptunSwordRightPath { get; set; } = "neptun_kard_r.png";

        /// <summary>
        /// Gets or sets neptun sword throw left path.
        /// </summary>
        public static string NeptunSwordThrowLeftPath { get; set; } = "neptun_kard_l_t.png";

        /// <summary>
        /// Gets or sets neptun sword throw right path.
        /// </summary>
        public static string NeptunSwordThrowRightPath { get; set; } = "neptun_kard_r_t.png";

        /// <summary>
        /// Gets or sets neptun sword throw right path.
        /// </summary>
        public static string FinishPath { get; set; } = "finish.png";

        /// <summary>
        /// Gets or sets bow left path.
        /// </summary>
        public static string BowLeftPath { get; set; } = "ij_l.png";

        /// <summary>
        /// Gets or sets bow right path.
        /// </summary>
        public static string BowRightPath { get; set; } = "ij_r.png";

        /// <summary>
        /// Gets or sets bow strecthed left path.
        /// </summary>
        public static string BowStretchedLeftPath { get; set; } = "ij_stretched_l.png";

        /// <summary>
        /// Gets or sets bow streched right path.
        /// </summary>
        public static string BowStretchedRightPath { get; set; } = "ij_stretched_r.png";

        /// <summary>
        /// Gets or sets bow throw left path.
        /// </summary>
        public static string BowThrowLeftPath { get; set; } = "ij_l_t.png";

        /// <summary>
        /// Gets or sets bow throw right path.
        /// </summary>
        public static string BowThrowRightPath { get; set; } = "ij_r_t.png";

        /// <summary>
        /// Gets or sets bow floor path.
        /// </summary>
        public static string BowFloorPath { get; set; } = "ij_f.png";

        /// <summary>
        /// Gets or sets arrow left path.
        /// </summary>
        public static string ArrowLeftPath { get; set; } = "arrow_l.png";

        /// <summary>
        /// Gets or sets arrow right path.
        /// </summary>
        public static string ArrowRightPath { get; set; } = "arrow_r.png";

        /// <summary>
        /// Gets or sets arrow low left path.
        /// </summary>
        public static string ArrowLowLeftPath { get; set; } = "arrow_low_l.png";

        /// <summary>
        /// Gets or sets arrow lofw rifht path.
        /// </summary>
        public static string ArrowLowRightPath { get; set; } = "arrow_low_r.png";

        /// <summary>
        /// Gets or sets player one head left path.
        /// </summary>
        public static string P1HeadLeftPath { get; set; } = "p1_head_l.png";

        /// <summary>
        /// Gets or sets player one head right path.
        /// </summary>
        public static string P1HeadRightPath { get; set; } = "p1_head_r.png";

        /// <summary>
        /// Gets or sets player one bow 1 left path.
        /// </summary>
        public static string P1Bow1LeftPath { get; set; } = "p1_bow_1_l.png";

        /// <summary>
        /// Gets or sets player one bow 1 right path.
        /// </summary>
        public static string P1Bow1RightPath { get; set; } = "p1_bow_1_r.png";

        /// <summary>
        /// Gets or sets player bow 1 streched left path.
        /// </summary>
        public static string P1Bow1StretchedLeftPath { get; set; } = "p1_bow_s_1_l.png";

        /// <summary>
        /// Gets or sets player one bow 1 strecthed right path.
        /// </summary>
        public static string P1Bow1StretchedRightPath { get; set; } = "p1_bow_s_1_r.png";

        /// <summary>
        /// Gets or sets player one bow 2 left path.
        /// </summary>
        public static string P1Bow2LeftPath { get; set; } = "p1_bow_2_l.png";

        /// <summary>
        /// Gets or sets player one bow 2 right path.
        /// </summary>
        public static string P1Bow2RightPath { get; set; } = "p1_bow_2_r.png";

        /// <summary>
        /// Gets or sets p1 leg stand lefth path.
        /// </summary>
        public static string P1LegStandLeftPath { get; set; } = "p1_leg_l_0.png";

        /// <summary>
        /// Gets or sets p1 leg stand right path.
        /// </summary>
        public static string P1LegStandRightPath { get; set; } = "p1_leg_r_0.png";

        /// <summary>
        /// Gets or sets p1 leg 1 left path.
        /// </summary>
        public static string P1Leg1LeftPath { get; set; } = "p1_leg_l_1.png";

        /// <summary>
        /// Gets or sets p1 leg 1 right path.
        /// </summary>
        public static string P1Leg1RightPath { get; set; } = "p1_leg_r_1.png";

        /// <summary>
        /// Gets or sets p1 leg 2 left path.
        /// </summary>
        public static string P1Leg2LeftPath { get; set; } = "p1_leg_l_2.png";

        /// <summary>
        /// Gets or sets p1 leg 2 right path.
        /// </summary>
        public static string P1Leg2RightPath { get; set; } = "p1_leg_r_2.png";

        /// <summary>
        /// Gets or sets p1 squat lefth path.
        /// </summary>
        public static string P1SquatLeftPath { get; set; } = "p1_squat_l.png";

        /// <summary>
        /// Gets or sets p1 squat right path.
        /// </summary>
        public static string P1SquatRightPath { get; set; } = "p1_squat_r.png";

        /// <summary>
        /// Gets or sets p1 sword 1 left path.
        /// </summary>
        public static string P1Sword1LeftPath { get; set; } = "p1_sword_1_l.png";

        /// <summary>
        /// Gets or sets p1 sword 1 right path.
        /// </summary>
        public static string P1Sword1RightPath { get; set; } = "p1_sword_1_r.png";

        /// <summary>
        /// Gets or sets p1 sword 1 lefth path.
        /// </summary>
        public static string P1Sword2LeftPath { get; set; } = "p1_sword_2_l.png";

        /// <summary>
        /// Gets or sets p1 sword 2 right path.
        /// </summary>
        public static string P1Sword2RightPath { get; set; } = "p1_sword_2_r.png";

        /// <summary>
        /// Gets or sets p1 sowrd 3 left path.
        /// </summary>
        public static string P1Sword3LeftPath { get; set; } = "p1_sword_3_l.png";

        /// <summary>
        /// Gets or sets p1 sword 3 right path.
        /// </summary>
        public static string P1Sword3RightPath { get; set; } = "p1_sword_3_r.png";

        /// <summary>
        /// Gets or sets p1 sowrd attack 1 lefth path.
        /// </summary>
        public static string P1SwordAttack1LeftPath { get; set; } = "p1_sword_attack_1_l.png";

        /// <summary>
        /// Gets or sets p1 sowrd attack 1 right path.
        /// </summary>
        public static string P1SwordAttack1RightPath { get; set; } = "p1_sword_attack_1_r.png";

        /// <summary>
        /// Gets or sets p1 sowrd attack 2 lefth path.
        /// </summary>
        public static string P1SwordAttack2LeftPath { get; set; } = "p1_sword_attack_2_l.png";

        /// <summary>
        /// Gets or sets p1 sowrd attack 2 right path.
        /// </summary>
        public static string P1SwordAttack2RightPath { get; set; } = "p1_sword_attack_2_r.png";

        /// <summary>
        /// Gets or sets p1 sowrd attack 1 lefth path.
        /// </summary>
        public static string P1SwordAttack3LeftPath { get; set; } = "p1_sword_attack_3_l.png";

        /// <summary>
        /// Gets or sets p1 sowrd attack 1 right path.
        /// </summary>
        public static string P1SwordAttack3RightPath { get; set; } = "p1_sword_attack_3_r.png";

        /// <summary>
        /// Gets or sets p1 sord squat left path.
        /// </summary>
        public static string P1SwordSquatLeftPath { get; set; } = "p1_sword_squat_l.png";

        /// <summary>
        /// Gets or sets p1 sword squat right path.
        /// </summary>
        public static string P1SwordSquatRightPath { get; set; } = "p1_sword_squat_r.png";

        /// <summary>
        /// Gets or sets p1 throw left path.
        /// </summary>
        public static string P1ThrowLeftPath { get; set; } = "p1_up_l.png";

        /// <summary>
        /// Gets or sets p1 throw right path.
        /// </summary>
        public static string P1ThrowRightPath { get; set; } = "p1_up_r.png";

        /// <summary>
        /// Gets or sets player two head left path.
        /// </summary>
        public static string P2HeadLeftPath { get; set; } = "p2_head_l.png";

        /// <summary>
        /// Gets or sets player two head right path.
        /// </summary>
        public static string P2HeadRightPath { get; set; } = "p2_head_r.png";

        /// <summary>
        /// Gets or sets player two bow 1 left path.
        /// </summary>
        public static string P2Bow1LeftPath { get; set; } = "p2_bow_1_l.png";

        /// <summary>
        /// Gets or sets player two bow 1 right path.
        /// </summary>
        public static string P2Bow1RightPath { get; set; } = "p2_bow_1_r.png";

        /// <summary>
        /// Gets or sets player bow 1 streched left path.
        /// </summary>
        public static string P2Bow1StretchedLeftPath { get; set; } = "p2_bow_s_1_l.png";

        /// <summary>
        /// Gets or sets player two bow 1 strecthed right path.
        /// </summary>
        public static string P2Bow1StretchedRightPath { get; set; } = "p2_bow_s_1_r.png";

        /// <summary>
        /// Gets or sets player two bow 2 left path.
        /// </summary>
        public static string P2Bow2LeftPath { get; set; } = "p2_bow_2_l.png";

        /// <summary>
        /// Gets or sets player two bow 2 right path.
        /// </summary>
        public static string P2Bow2RightPath { get; set; } = "p2_bow_2_r.png";

        /// <summary>
        /// Gets or sets p2 leg stand lefth path.
        /// </summary>
        public static string P2LegStandLeftPath { get; set; } = "p2_leg_l_0.png";

        /// <summary>
        /// Gets or sets p2 leg stand right path.
        /// </summary>
        public static string P2LegStandRightPath { get; set; } = "p2_leg_r_0.png";

        /// <summary>
        /// Gets or sets p2 leg 1 left path.
        /// </summary>
        public static string P2Leg1LeftPath { get; set; } = "p2_leg_l_1.png";

        /// <summary>
        /// Gets or sets p2 leg 1 right path.
        /// </summary>
        public static string P2Leg1RightPath { get; set; } = "p2_leg_r_1.png";

        /// <summary>
        /// Gets or sets p2 leg 2 left path.
        /// </summary>
        public static string P2Leg2LeftPath { get; set; } = "p2_leg_l_2.png";

        /// <summary>
        /// Gets or sets p2 leg 2 right path.
        /// </summary>
        public static string P2Leg2RightPath { get; set; } = "p2_leg_r_2.png";

        /// <summary>
        /// Gets or sets p2 squat lefth path.
        /// </summary>
        public static string P2SquatLeftPath { get; set; } = "p2_squat_l.png";

        /// <summary>
        /// Gets or sets p2 squat right path.
        /// </summary>
        public static string P2SquatRightPath { get; set; } = "p2_squat_r.png";

        /// <summary>
        /// Gets or sets p2 sword 1 left path.
        /// </summary>
        public static string P2Sword1LeftPath { get; set; } = "p2_sword_1_l.png";

        /// <summary>
        /// Gets or sets p2 sword 1 right path.
        /// </summary>
        public static string P2Sword1RightPath { get; set; } = "p2_sword_1_r.png";

        /// <summary>
        /// Gets or sets p2 sword 1 lefth path.
        /// </summary>
        public static string P2Sword2LeftPath { get; set; } = "p2_sword_2_l.png";

        /// <summary>
        /// Gets or sets p2 sword 2 right path.
        /// </summary>
        public static string P2Sword2RightPath { get; set; } = "p2_sword_2_r.png";

        /// <summary>
        /// Gets or sets p2 sowrd 3 left path.
        /// </summary>
        public static string P2Sword3LeftPath { get; set; } = "p2_sword_3_l.png";

        /// <summary>
        /// Gets or sets p2 sword 3 right path.
        /// </summary>
        public static string P2Sword3RightPath { get; set; } = "p2_sword_3_r.png";

        /// <summary>
        /// Gets or sets p2 sowrd attack 1 lefth path.
        /// </summary>
        public static string P2SwordAttack1LeftPath { get; set; } = "p2_sword_attack_1_l.png";

        /// <summary>
        /// Gets or sets p2 sowrd attack 1 right path.
        /// </summary>
        public static string P2SwordAttack1RightPath { get; set; } = "p2_sword_attack_1_r.png";

        /// <summary>
        /// Gets or sets p2 sowrd attack 2 lefth path.
        /// </summary>
        public static string P2SwordAttack2LeftPath { get; set; } = "p2_sword_attack_2_l.png";

        /// <summary>
        /// Gets or sets p2 sowrd attack 2 right path.
        /// </summary>
        public static string P2SwordAttack2RightPath { get; set; } = "p2_sword_attack_2_r.png";

        /// <summary>
        /// Gets or sets p2 sowrd attack 1 lefth path.
        /// </summary>
        public static string P2SwordAttack3LeftPath { get; set; } = "p2_sword_attack_3_l.png";

        /// <summary>
        /// Gets or sets p2 sowrd attack 1 right path.
        /// </summary>
        public static string P2SwordAttack3RightPath { get; set; } = "p2_sword_attack_3_r.png";

        /// <summary>
        /// Gets or sets p2 sord squat left path.
        /// </summary>
        public static string P2SwordSquatLeftPath { get; set; } = "p2_sword_squat_l.png";

        /// <summary>
        /// Gets or sets p2 sword squat right path.
        /// </summary>
        public static string P2SwordSquatRightPath { get; set; } = "p2_sword_squat_r.png";

        /// <summary>
        /// Gets or sets p2 throw left path.
        /// </summary>
        public static string P2ThrowLeftPath { get; set; } = "p2_up_l.png";

        /// <summary>
        /// Gets or sets p2 throw right path.
        /// </summary>
        public static string P2ThrowRightPath { get; set; } = "p2_up_r.png";
    }
}
