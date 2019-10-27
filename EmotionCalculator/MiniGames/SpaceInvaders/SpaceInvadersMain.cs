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
        private InvadersManager invaderManager;

        private List<SInvaders> Invaders;

        public int fps { private get; set; }



        internal SpaceInvadersMain(PictureBox grapX)
        {
            GrapX = grapX;
            

            invaderManager = new InvadersManager(grapX);

            SetupBackGround(grapX);
            SetupPlayer(grapX);

            // Invaders
            

            //fps
            fps = 24;
        }

        private void SetupBackGround(PictureBox grapX)
        {
            GrapX = new PictureBox();
            GrapX.Image = grapX.Image;
            GrapX.Size = new Size(grapX.Size.Width, grapX.Size.Height);
            GrapX.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        public void SetupPlayer(PictureBox grapX)
        {
            Player = new PictureBox();
            Player.Size = new System.Drawing.Size(40, 40);
            Player.Location = new System.Drawing.Point(grapX.Width / 2, 8 * grapX.Height / 10);

            Player.SizeMode = grapX.SizeMode;
            Player.Image = grapX.Image;

            Player.BringToFront();
            Player.Visible = true;

            grapX.Controls.Add(Player);
            //GrapX.Controls.Add(Player);
        }

        



    }
}
