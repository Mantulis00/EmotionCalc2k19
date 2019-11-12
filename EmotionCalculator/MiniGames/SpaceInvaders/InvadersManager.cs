﻿using EmotionCalculator.EmotionCalculator.FormsUI;
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

        private int  InvaderSize, MissileSize;

        private int InvaderHeightReductor;
        private double InvadersSpeed;
        private int MissleSpeed;
        private int score;
       public bool MissleLive {  get; private set; }

        internal System.Windows.Forms.Timer MainClock { get; }

        private List<SInvaders> Invaders;

        private PictureBox missle = null;

        PictureBox grapX;
        internal InvadersManager(PictureBox grapX, List<PictureBox> InvadersBones, System.Windows.Forms.Timer MainClock)
        {
            this.grapX = grapX;
            this.MainClock = MainClock;

            Invaders = GenerateInvaders(InvadersBones);

            InvadersSpeed = (36 - Invaders.Count ) / 8;
            if (InvadersSpeed < 1) InvadersSpeed = 1;
            InvaderSize = 20;
            MissileSize = 15;
            MissleSpeed = 15;
            MissleLive = false;

           




        }

        internal void GenerateMissle(Point location)
        {
            missle = new PictureBox();
            missle.Size = new Size(MissileSize, MissileSize);
            missle.Location = new Point(location.X+InvaderSize/2, location.Y);
            missle.Image = Properties.Resources.emojiFire;
            missle.SizeMode = PictureBoxSizeMode.StretchImage;
            missle.BackColor = Color.Transparent;
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
            else if (Invaders[Invaders.Count-1].InvaderInfo.Location.Y >= main.Player.Location.Y - InvaderSize )
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
                        && missle.Location.X + missle.Size.Width  > invader.InvaderInfo.Location.X
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
            if (missle != null)
            {
                MissleLive = true;
                missle.Location = new Point(missle.Location.X, missle.Location.Y - MissleSpeed);
                CheckMissle();
            }
        }

        private void CheckMissle()
        {
            if (missle.Location.Y < -missle.Size.Height)
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
            

            invader.InvaderInfo.Dispose();
            Invaders.Remove(invader);
            invader.InvaderInfo = null;


            if (InvadersSpeed > 0)
            {
                if (Invaders.Count <= 5) InvadersSpeed += 1;
                else if (Invaders.Count <= 2) InvadersSpeed += 4;
                else InvadersSpeed+=0.4;
            }

            else if (InvadersSpeed < 0)
            {
                if (Invaders.Count <= 5) InvadersSpeed -= 1;
                else if (Invaders.Count <= 2) InvadersSpeed -= 4;
                else InvadersSpeed-=0.4;
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
