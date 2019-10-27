using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{

    class PlayerInputs
    {
        private PictureBox Player;

        internal PlayerInputs(PictureBox Player)
        {
            this.Player = Player;
        }

        internal void ReadInput(char e)
        {
            if (e == 'a')
            {
                MoveLeft();
            }
            else if (e == 'd')
            {
                MoveRight();
            }
        }

        private bool CheckBorders(int jumpLenght)
        {
            bool allow;

            if (Player.Parent.Size.Width - Player.Size.Width > Player.Location.X + jumpLenght
                && 0 < Player.Location.X + jumpLenght)
            {
                allow = true;
            }
            else
                allow = false;


            return allow;
        }

        private void MoveRight()
        {
            if (CheckBorders(Player.Size.Width / 4))
            Player.Location = new Point(Player.Location.X + Player.Size.Width / 4, Player.Location.Y);
        }

        private void MoveLeft()
        {
            if (CheckBorders((Player.Size.Width / 4) * (-1)))
                Player.Location = new Point(Player.Location.X - Player.Size.Width/4, Player.Location.Y);
        }



    }
}
