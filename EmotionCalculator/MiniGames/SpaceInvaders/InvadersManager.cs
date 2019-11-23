using EmotionCalculator.EmotionCalculator.Tools.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Resources = EmotionCalculator.Properties.Resources;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{
    class InvadersManager
    {
        private readonly int InvaderSize;
        private readonly int MissileSize;
        private int InvaderHeightReductor;
        private double InvadersSpeed;
        private readonly int MissileSpeed;
        private int score;
        public bool MissleLive { get; private set; }

        internal System.Windows.Forms.Timer MainClock { get; }

        private readonly List<SInvaders> Invaders;

        private PictureBox missile = null;
        readonly PictureBox grapX;
        internal InvadersManager(PictureBox grapX, List<PictureBox> InvadersBones, System.Windows.Forms.Timer MainClock)
        {
            this.grapX = grapX;
            this.MainClock = MainClock;

            Invaders = GenerateInvaders(InvadersBones);

            InvadersSpeed = (36 - Invaders.Count) / 8;
            if (InvadersSpeed < 1) InvadersSpeed = 1;
            InvaderSize = 20;
            MissileSize = 15;
            MissileSpeed = 15;
            MissleLive = false;






        }

        internal void GenerateMissle(Point location)
        {
            if (missile != null)
            {
                missile.Dispose();
                missile = null;
            }

            missile = new PictureBox
            {
                Size = new Size(MissileSize, MissileSize),
                Location = new Point(location.X + InvaderSize / 2, location.Y),
                Image = Resources.emojiFire.ToImage(),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Visible = true
            };
            missile.BringToFront();



            grapX.Controls.Add(missile);
        }



        internal void UpdateInvaders(SpaceInvadersMain main)
        {
            UpdateMissle();
            CheckInvaders();
            CheckGameOver(main);
            missile = ColiderCheck(missile);

            foreach (var invader in Invaders)
            {
                invader.InvaderInfo.Left += (int)InvadersSpeed;
                if (InvaderHeightReductor != 0)
                {
                    invader.InvaderInfo.Top += InvaderHeightReductor;
                }

            }

            InvaderHeightReductor = 0;
        }

        private void CheckInvaders()
        {
            foreach (var invader in Invaders)
            {
                if (invader.InvaderInfo.Location.X + InvadersSpeed + InvaderSize > grapX.Size.Width ||
                   invader.InvaderInfo.Location.X + InvadersSpeed < 0)
                {
                    InvaderHeightReductor = Math.Abs((int)InvadersSpeed);
                    InvadersSpeed *= -1;
                    break;
                }
            }



        }


        private void CheckGameOver(SpaceInvadersMain main)
        {
            if (Invaders.Count == 0)
            {

                main.GameOver(score);

            }
            else if (Invaders[Invaders.Count - 1].InvaderInfo.Location.Y >= main.Player.Location.Y - InvaderSize)
            {
                DisposeInvaders();


                main.GameOver(0);
            }

        }

        private PictureBox ColiderCheck(PictureBox missle)
        {
            if (missle != null)
            {
                foreach (var invader in Invaders.ToList())
                {
                    if (missle.Location.X - missle.Size.Width < invader.InvaderInfo.Location.X
                        && missle.Location.X + missle.Size.Width > invader.InvaderInfo.Location.X
                        )
                    {
                        if (missle.Location.Y - missle.Size.Height < invader.InvaderInfo.Location.Y
                        && missle.Location.Y + missle.Size.Height > invader.InvaderInfo.Location.Y
                        )
                        {
                            missle.Dispose();
                            missle = null;
                            MissleLive = false;

                            RemoveInvader(invader);


                            break;

                        }

                    }
                }
            }
            return missle;
        }




        private void UpdateMissle()
        {
            if (missile != null)
            {
                MissleLive = true;
                missile.Location = new Point(missile.Location.X, missile.Location.Y - MissileSpeed);
                CheckMissle();
            }
        }

        internal void CheckMissle(bool forceDelete = false)
        {
            if (missile != null)
            {
                if (missile.Location.Y < -missile.Size.Height || forceDelete)
                {
                    MissleLive = false;
                    missile.Dispose();
                    missile = null;
                }
            }


        }





        private List<SInvaders> GenerateInvaders(List<PictureBox> invaders)
        {
            List<SInvaders> InvadersAI = new List<SInvaders>();

            foreach (var i in invaders)
            {
                SInvaders invader = new SInvaders
                {
                    alive = true,
                    InvaderInfo = i
                };
                InvadersAI.Add(invader);
            }

            return InvadersAI;
        }




        internal void RemoveInvader(SInvaders invader)
        {


            invader.InvaderInfo.Dispose();
            Invaders.Remove(invader);
            invader.InvaderInfo = null;


            if (InvadersSpeed > 0)
            {
                if (Invaders.Count <= 5) InvadersSpeed += 1;
                else if (Invaders.Count <= 2) InvadersSpeed += 4;
                else InvadersSpeed += 0.4;
            }

            else if (InvadersSpeed < 0)
            {
                if (Invaders.Count <= 5) InvadersSpeed -= 1;
                else if (Invaders.Count <= 2) InvadersSpeed -= 4;
                else InvadersSpeed -= 0.4;
            }


            score++;
        }

        internal void DisposeInvaders()
        {
            foreach (var i in Invaders.ToList())
            {
                i.InvaderInfo.Dispose();
                Invaders.Remove(i);
            }
        }


    }
    internal struct SInvaders
    {
        public PictureBox InvaderInfo;
        public bool alive;
    }

}
