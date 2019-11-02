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
        private int InvadersLenght, InvadersHeight, InvadersSpacer;
        private int InvadersStartX, InvadersStartY, InvaderSize;

        private int InvadersSpeed, InvaderHeightReductor;
        private int MissleSpeed;

       public bool MissleLive {  get; private set; }

        private bool Colider;

        private List<SInvaders> Invaders;

        private PictureBox missle = null;

        PictureBox grapX;
        internal InvadersManager(PictureBox grapX, List<PictureBox> InvadersBones)
        {
            this.grapX = grapX;

            Invaders = GenerateInvaders(InvadersBones);
            
            
            InvaderSize = 20;
            InvadersSpacer = 2 * InvaderSize;


            InvadersStartX = 10;
            InvadersStartY = 10;
            InvadersSpeed = 10;
            MissleSpeed = 20;
            MissleLive = false;

            InvadersLenght = InvadersStartX + 5 * InvadersSpacer;
            InvadersHeight = InvadersStartY + 3 * InvadersSpacer;

            Colider = false;
            

          //  GenerateInvaders(grapX);

        }

        internal void GenerateMissle(Point location)
        {
            missle = new PictureBox();
            missle.Size = new Size(InvaderSize, InvaderSize);
            missle.Location = location;
            missle.BackColor = Color.Blue;
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




        /*
        private void GenerateInvaders(PictureBox grapX)
        {
            for (int y = InvadersStartY; y < InvadersHeight; y += InvadersSpacer)
            {
                for (int x = InvadersStartX; x < InvadersLenght; x += InvadersSpacer)
                {
                    AddInvader(x, y, grapX);
                }
            }
        }*/


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



        /*
        private void AddInvader(int locationX, int locationY, PictureBox grapX)
        {
            SInvaders Invader = new SInvaders();
            Invader.InvaderInfo = new PictureBox();
            Invader.InvaderInfo.Size = new Size(InvaderSize, InvaderSize);
            Invader.InvaderInfo.Location = new System.Drawing.Point(locationX, locationY);
            Invader.InvaderInfo.BackColor = Color.Red;
            Invader.InvaderInfo.Visible = true;
            Invader.InvaderInfo.BringToFront();
            Invader.alive = true;
            grapX.Controls.Add(Invader.InvaderInfo);

            // if invader alive

            Invaders.Add(Invader);
        }*/

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
