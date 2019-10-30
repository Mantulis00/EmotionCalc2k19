using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.Snake
{
    class AppleManager 
    {
        private SnakeMain snakeMain;
        private SnakeManager snakeManager;
        private PictureBox apple;
        public AppleManager(SnakeMain snakeMain, SnakeManager snakeManager)
        {
            this.snakeMain = snakeMain;
            this.snakeManager = snakeManager;
        }
        public void SpawnApple()
        {
            apple = new PictureBox();
            apple.BackColor = Color.Green;
            apple.Size = new Size(10, 10);
            Random rng = new Random();
            int appleX = rng.Next(0, snakeMain.Canvas.Size.Width);
            int appleY = rng.Next(0, snakeMain.Canvas.Size.Height);
            apple.Location = new Point(appleX, appleY);
            apple.Visible = true;
            snakeMain.Canvas.Controls.Add(apple);
            apple.BringToFront();
        }
    }
}
