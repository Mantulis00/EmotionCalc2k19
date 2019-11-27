using EmotionCalculator.EmotionCalculator.FormsUI;
using EmotionCalculator.EmotionCalculator.Tools.Web;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{
    class SpaceInvadersMain
    {
        //private PictureBox GrapX;
        internal PictureBox Player { get; set; }
        private readonly InvadersManager invaderManager;
        internal PlayerInputs PlayerIManager { get; set; }

        private readonly AnimationManager animationManager;

        // two different clocks, one for animations other for game
        System.Windows.Forms.Timer MainClock, AnimationClock;
        readonly BaseForm baseForm;


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
            PlayerIManager = new PlayerInputs(Player, invaderManager);
        }

        private void SetupTimer()
        {
            MainClock = new Timer
            {
                Interval = 50
            };
            MainClock.Tick += StartClock;

            AnimationClock = new Timer
            {
                Interval = 30
            };
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
            Player = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(grapX.Width / 2, 8 * grapX.Height / 10),

                SizeMode = grapX.SizeMode,
                Image = Properties.Resources.emojiCringe.ToImage(),
                BackColor = Color.Transparent
            };

            Player.BringToFront();
            Player.Visible = true;

            grapX.Controls.Add(Player);


        }

        public void GameOver(int score)
        {
            MainClock.Stop();
            //baseForm.MainManager.GameManager.Value.gameStatus();
            invaderManager.CheckMissle(true);
            Player.Dispose();
            Player = null;
        }
    }
}
