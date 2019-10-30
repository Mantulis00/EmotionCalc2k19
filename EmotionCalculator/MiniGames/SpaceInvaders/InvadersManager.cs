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
        private bool ReduceHeight;

        private List<SInvaders> Invaders;

        PictureBox grapX;
        internal InvadersManager(PictureBox grapX)
        {
            this.grapX = grapX;

            Invaders = new List<SInvaders>();
            
            
            InvaderSize = 20;
            InvadersSpacer = 2 * InvaderSize;


            InvadersStartX = 10;
            InvadersStartY = 10;
            InvadersSpeed = 10;
            ReduceHeight = false;

            InvadersLenght = InvadersStartX + 5 * InvadersSpacer;
            InvadersHeight = InvadersStartY + 3 * InvadersSpacer;

            

            GenerateInvaders(grapX);

        }

        internal void UpdateInvaders()
        {
            CheckInvaders();
            foreach(var invader in Invaders)
            {
                invader.InvaderInfo.Location = new Point(
                    invader.InvaderInfo.Location.X + InvadersSpeed, 
                    invader.InvaderInfo.Location.Y + InvaderHeightReductor);
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





        private void GenerateInvaders(PictureBox grapX)
        {
            for (int y = InvadersStartY; y < InvadersHeight; y += InvadersSpacer)
            {
                for (int x = InvadersStartX; x < InvadersLenght; x += InvadersSpacer)
                {
                    AddInvader(x, y, grapX);
                }
            }
        }



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
