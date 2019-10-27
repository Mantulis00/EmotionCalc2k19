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

        private List<SInvaders> Invaders { get; }
        internal InvadersManager(PictureBox grapX)
        {
            Invaders = new List<SInvaders>();
            
            
            InvaderSize = 20;
            InvadersSpacer = 2 * InvaderSize;


            InvadersStartX = 10;
            InvadersStartY = 10;

            InvadersLenght = InvadersStartX + 5 * InvadersSpacer;
            InvadersHeight = InvadersStartY + 3 * InvadersSpacer;

            GenerateInvaders(grapX);

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
