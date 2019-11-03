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


        private List<SInvaders> Invaders;

        private PictureBox missle = null;

        PictureBox grapX;
        internal InvadersManager(PictureBox grapX, List<PictureBox> InvadersBones)
        {
            this.grapX = grapX;

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



        internal void UpdateInvaders()
        {
            UpdateMissle();
            CheckInvaders();
            missle = ColiderCheck(missle);

        
            foreach(var invader in Invaders)
            {
                invader.InvaderInfo.Location = new Point(
                    invader.InvaderInfo.Location.X + InvadersSpeed, 
                    invader.InvaderInfo.Location.Y + InvaderHeightReductor);
            }

            InvaderHeightReductor = 0;
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
                            invader.InvaderInfo.Visible = false;
                            Invaders.Remove(invader);
                            
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




        internal void RemoveInvader(int InvaderN)
        {
            Invaders.RemoveAt(InvaderN);
        }


    }
    internal struct SInvaders
    {
        public PictureBox InvaderInfo;
        public bool alive;
    }

}
