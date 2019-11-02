﻿using EmotionCalculator.EmotionCalculator.FormsUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{
    class SpaceInvadersMain
    {

        private PictureBox GrapX;
        private PictureBox Player;
        private InvadersManager invaderManager;
        internal PlayerInputs playerIManager {get;}

        private List<PictureBox> CalendarElements;
        private AnimationManager animationManager;

        System.Windows.Forms.Timer MainClock, AnimationClock;


        private List<SInvaders> Invaders;

        public int fps { private get; set; }



        internal SpaceInvadersMain(PictureBox grapX)
        {
            GrapX = grapX;
            

            SetupBackGround(grapX);
            SetupPlayer(grapX);
            SetupTimer();

           

            animationManager = new AnimationManager(grapX, AnimationClock);
            invaderManager = new InvadersManager(grapX, animationManager.AnimationElements);
            playerIManager = new PlayerInputs(Player, invaderManager);




        }

       private void SetupTimer()
        {
            MainClock = new System.Windows.Forms.Timer();
            MainClock.Interval = 50;
            MainClock.Tick += StartClock;

            AnimationClock = new System.Windows.Forms.Timer();
            AnimationClock.Interval = 1;
            AnimationClock.Tick += StartAnimationOnClock;

        }

        public void StartAnimation()
        {
            AnimationClock.Start();
        }

        public void StopAnimation()
        {
            AnimationClock.Stop();
        }

        private void StartAnimationOnClock(object sender, EventArgs e)
        {
            animationManager.StartAnimation();
        }

        public void StartTimer()
        {
            MainClock.Start();
        }



        private void StartClock(object sender, EventArgs e)
        {
             invaderManager.UpdateInvaders();
        }



        private void SetupBackGround(PictureBox grapX)
        {
            GrapX = new PictureBox();
            GrapX.Image = grapX.Image;
            GrapX.Size = new Size(grapX.Size.Width, grapX.Size.Height);
            GrapX.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void SetupPlayer(PictureBox grapX)
        {
            Player = new PictureBox();
            Player.Size = new System.Drawing.Size(40, 40);
            Player.Location = new System.Drawing.Point(grapX.Width / 2, 8 * grapX.Height / 10);

            Player.SizeMode = grapX.SizeMode;
            Player.Image = grapX.Image;

            Player.BringToFront();
            Player.Visible = true;

            grapX.Controls.Add(Player);

            //GrapX.Controls.Add(Player);
        }

       






    }
}