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
        internal PictureBox Player;
        private InvadersManager invadersManager;

         private Dictionary<char, Controls> controls;

        internal PlayerInputs(PictureBox Player, InvadersManager invadersManager)
        {
            this.invadersManager = invadersManager;
            this.Player = Player;

            controls = new Dictionary<char, Controls>();
            controls.Add('a', Controls.LEFT);
            controls.Add('d', Controls.RIGHT);
            controls.Add('s', Controls.SHOOT);
        }

        internal void ReadInput(char e)
        {
            if (controls.ContainsKey(e) && invadersManager.MainClock.Enabled)
            {
                switch (controls[e])
                {
                    case Controls.LEFT:
                        {
                            MoveLeft();
                            break;
                        }

                    case Controls.RIGHT:
                        {
                            MoveRight();
                            break;
                        }

                    case Controls.SHOOT:
                        {
                            Shoot();
                            break;
                        }

                    default:
                        break;
                }
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

        private void Shoot()
        {
            if (!invadersManager.MissleLive)
            invadersManager.GenerateMissle(Player.Location);
        }



    }
}
