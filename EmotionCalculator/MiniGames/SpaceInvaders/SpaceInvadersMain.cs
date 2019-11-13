using EmotionCalculator.EmotionCalculator.FormsUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{
    class SpaceInvadersMain
    {

        //private PictureBox GrapX;
        internal PictureBox Player { get; set; }
        private InvadersManager invaderManager;
        internal PlayerInputs playerIManager { get; set; }

        private AnimationManager animationManager;

        // two different clocks, one for animations other for game
        System.Windows.Forms.Timer MainClock, AnimationClock;

        BaseForm baseForm;

        private List<SInvaders> Invaders;

        public int fps { private get; set; }



        internal SpaceInvadersMain(PictureBox grapX, BaseForm baseForm)
        {
            // GrapX = grapX;
            this.baseForm = baseForm;

            // SetupBackGround(grapX);
            SetupPlayer(grapX);
            SetupTimer();


            //InvadersAIs are created and their locations are set in animationManager
            animationManager = new AnimationManager(grapX, AnimationClock);
            //InvadersManager refreshes invaders locations, checks if missle hits them, overall handles invaders and missles
            invaderManager = new InvadersManager(grapX, animationManager.AnimationElements, MainClock);
            //playerManager manages player, reads its inputs
            playerIManager = new PlayerInputs(Player, invaderManager);
        }

        private void SetupTimer()
        {
            MainClock = new System.Windows.Forms.Timer();
            MainClock.Interval = 50;
            MainClock.Tick += StartClock;

            AnimationClock = new System.Windows.Forms.Timer();
            AnimationClock.Interval = 30;
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
            animationManager.StartAnimation(this);
        }

        public void StartTimer()
        {


            MainClock.Start();
        }

        private void StartClock(object sender, EventArgs e)
        {
            invaderManager.UpdateInvaders(this);
        }


        private void SetupPlayer(PictureBox grapX)
        {
            Player = new PictureBox();
            Player.Size = new System.Drawing.Size(40, 40);
            Player.Location = new System.Drawing.Point(grapX.Width / 2, 8 * grapX.Height / 10);

            Player.SizeMode = grapX.SizeMode;
            Player.Image = Properties.Resources.emojiCringe;
            Player.BackColor = Color.Transparent;

            Player.BringToFront();
            Player.Visible = true;

            grapX.Controls.Add(Player);


        }

        public void GameOver(int score)
        {
            MainClock.Stop();
            baseForm.MainManager.GameManager.Value.AuxThread = null;
            //baseForm.MainManager.GameManager = Lazy<GameManager>


            Player.Dispose();
            Player = null;

            baseForm.MainManager.SettingsManager[EmotionCalculator.Logic.Settings.SettingType.Game] = EmotionCalculator.Logic.Settings.SettingStatus.Disabled;
            baseForm.MainManager.MonthManager.Refresh();
        }
    }
}
