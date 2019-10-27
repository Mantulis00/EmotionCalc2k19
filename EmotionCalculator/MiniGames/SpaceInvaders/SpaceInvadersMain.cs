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
    class SpaceInvadersMain
    {
        private PictureBox GrapX;
        private PictureBox Player;
        private List<PictureBox> Invaders;

        public int fps { private get; set; }


        private int InvadersLenght, InvadersHeight, InvadersSpacer;
        private int InvadersStartX, InvadersStartY;
        SpaceInvadersMain()
        {
            //
            GrapX = new PictureBox(); 
            Player = new PictureBox();

            SetupPlayer();

            // Options
            InvadersLenght = 5;
            InvadersHeight = 3;
            InvadersSpacer = 40;

            InvadersStartX = 50;
            InvadersStartY = 50;

        }

        private void SetupBackGround(BaseForm baseForm)
        {
            GrapX.Image = baseForm.BackgroundImage;
            GrapX.Size = baseForm.BackgroundImage.Size;
            GrapX.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void SetupPlayer()
        {
            Player.Size = new System.Drawing.Size(40, 40);
            Player.Location = new System.Drawing.Point(GrapX.Size.Width / 2, GrapX.Height);

            GrapX.Controls.Add(Player);
        }

        private void GenerateInvaders()
        {
           for (int y = InvadersStartY; y < InvadersHeight; y+=InvadersSpacer)
            {
                for (int x = InvadersStartX; x < InvadersLenght; x+=InvadersSpacer)
                {
                    AddInvader(x, y);
                }
            }
        }

        private void AddInvader(int locationX, int locationY)
        {
            PictureBox Invader = new PictureBox();
            Invader.Size = new Size(Player.Size.Width, Player.Size.Height);
            Invader.Location = new System.Drawing.Point(locationX, locationY);
        }

        private void RemoveInvader(int InvaderN)
        {
            Invaders.RemoveAt(InvaderN);
        }



    }
}
