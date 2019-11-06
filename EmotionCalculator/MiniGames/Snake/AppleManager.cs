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
        internal PictureBox apple;
        private List<PictureBox> apples;
        private int everyEmojiIs = 4;
        public AppleManager(SnakeMain snakeMain, SnakeManager snakeManager)
        {
            this.snakeMain = snakeMain;
            this.snakeManager = snakeManager;
            apples = GetApples();
        }
        internal bool SpawnApple()
        {
            if (apple != null)
            {
                snakeMain.Canvas.Controls.Remove(apple);
            }
            if (apples.Count == 0)
            {
                snakeMain.Stop();
                return false;
            }
            int appleDimension = 20;
            apple = new PictureBox();
            apple.BackColor = Color.Transparent;
            apple.Image = apples[0].Image;
            apples.RemoveAt(0);
            apple.Size = new Size(appleDimension, appleDimension);
            apple.SizeMode = PictureBoxSizeMode.StretchImage;
            Random rng = new Random();
            int appleX = rng.Next(0, snakeMain.Canvas.Size.Width-appleDimension);
            int appleY = rng.Next(0, snakeMain.Canvas.Size.Height-appleDimension);
            apple.Location = new Point(appleX, appleY);
            apple.Visible = true;
            snakeMain.Canvas.Controls.Add(apple);
            apple.BringToFront();
            return true;
        }

        private List<PictureBox> GetApples()
        {
            PictureBox something = snakeMain.Canvas;
            List<PictureBox> apples = new List<PictureBox>();
            for (int i = 0; i < 42; i++)
            {
                for (int j = 0; j < something.Controls[i].Controls.Count; j++)
                {
                    if (something.Controls[i].Controls[j] is PictureBox cell)
                    {
                        if (cell.Image == null)
                        {
                            continue;
                        }
                        PictureBox apple = new PictureBox
                        {
                            Image = cell.Image,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.Transparent
                        };
                        for (int multi = 0; multi < everyEmojiIs; multi++)
                        {
                            apples.Add(apple);
                        }
                    }
                }
            }
            return apples;
        }

        internal void Stop()
        {
            snakeMain.Canvas.Controls.Remove(apple);
        }
    }
}
