using EmotionCalculator.EmotionCalculator.FormsUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{
     class InvadersManager
    {

        private int  InvaderSize;

        private int InvadersSpeed, InvaderHeightReductor;
        private int MissleSpeed;

       public bool MissleLive {  get; private set; }

        private System.Windows.Forms.Timer MainClock;

        private List<SInvaders> Invaders;

        private PictureBox missle = null;

        PictureBox grapX;
        internal InvadersManager(PictureBox grapX, List<PictureBox> InvadersBones, System.Windows.Forms.Timer MainClock)
        {
            this.grapX = grapX;
            this.MainClock = MainClock;

            Invaders = GenerateInvaders(InvadersBones);
            
            InvadersSpeed = 5;
            InvaderSize = 20;
            MissleSpeed = 15;
            MissleLive = false;

            

        }

        internal void GenerateMissle(Point location)
        {
            missle = new PictureBox();
            missle.Size = new Size(InvaderSize, InvaderSize);
            missle.Location = location;
            missle.BackColor = Color.Red;
            missle.Visible = true;
            missle.BringToFront();

            

            grapX.Controls.Add(missle);
        }



        internal void UpdateInvaders(SpaceInvadersMain main)
        {
            UpdateMissle();
            CheckInvaders();
            CheckGameOver(main);
            missle = ColiderCheck(missle);

        
            foreach(var invader in Invaders)
            {
                invader.InvaderInfo.Left += InvadersSpeed;
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
                    InvaderHeightReductor = Math.Abs(InvadersSpeed);
                    InvadersSpeed *= -1;
                    break;
                }
            }

            

        }

        private void CheckGameOver(SpaceInvadersMain main)
        {
            if (Invaders.Count == 0)
            {
                MainClock.Stop();
                main.GameOver();
              
            }

        }

        private PictureBox ColiderCheck(PictureBox missle)
        {
            if (missle != null)
            {
                foreach (var invader in Invaders.ToList())
                {
                    if (missle.Location.X - invader.InvaderInfo.Size.Width  < invader.InvaderInfo.Location.X
                        && missle.Location.X + invader.InvaderInfo.Size.Width  > invader.InvaderInfo.Location.X
                        )
                    {
                        if (missle.Location.Y - invader.InvaderInfo.Size.Height  < invader.InvaderInfo.Location.Y
                        && missle.Location.Y + invader.InvaderInfo.Size.Height  > invader.InvaderInfo.Location.Y
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
            if (missle != null)
            {
                MissleLive = true;
                missle.Location = new Point(missle.Location.X, missle.Location.Y - MissleSpeed);
                CheckMissle();
            }
        }

        private void CheckMissle()
        {
            if (missle.Location.Y < -1*MissleSpeed)
            {
                MissleLive = false;
                missle.Dispose();
                missle = null;
            }
               
        }


       


        private List<SInvaders> GenerateInvaders(List<PictureBox> invaders)
        {
            List<SInvaders> InvadersAI = new List<SInvaders>();
            
            foreach(var i in invaders)
            {
                SInvaders invader = new SInvaders();
                invader.alive = true;
                invader.InvaderInfo = i;
                InvadersAI.Add(invader);
            }

            return InvadersAI;
        }




        internal void RemoveInvader(SInvaders invader)
        {
            if (InvadersSpeed > 0) InvadersSpeed++;
            else if (InvadersSpeed < 0) InvadersSpeed--;

            invader.InvaderInfo.Dispose();
            Invaders.Remove(invader);
            invader.InvaderInfo = null;
        }


    }
    internal struct SInvaders
    {
        public PictureBox InvaderInfo;
        public bool alive;
    }

}
