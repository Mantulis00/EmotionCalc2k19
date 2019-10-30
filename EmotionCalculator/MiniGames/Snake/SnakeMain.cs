using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.Snake
{
    class SnakeMain
    {
        private PictureBox snake;
        internal PictureBox Canvas;
        internal SnakeManager snakeManager;
        internal Timer timer = new Timer();
        private Image calendarBackgroundCopy;
        internal AppleManager appleManager;

        public SnakeMain(PictureBox canvas)
        {
            timer.Interval = 1000/24;
            timer.Tick += new EventHandler(GameTick);
            this.Canvas = canvas;
            calendarBackgroundCopy = canvas.Image;
            SetupBackGround(canvas);
            SetupSnake(canvas);
            appleManager = new AppleManager(this, snakeManager);
        }
        private void SetupBackGround(PictureBox canvas)
        {
            this.Canvas.BackColor = Color.Black;
            this.Canvas.Image = null;
            //this.Canvas.Size = new Size(canvas.Size.Width, canvas.Size.Height);
            //this.Canvas.SizeMode = PictureBoxSizeMode.StretchImage;
            //Canvas.BringToFront();
        }

        public void SetupSnake(PictureBox canvas)
        {
            snake = new PictureBox();
            snake.Size = new System.Drawing.Size(10, 10);
            snake.Location = new System.Drawing.Point(canvas.Width / 2, canvas.Height / 2);

            snake.SizeMode = canvas.SizeMode;
            //snake.Image = canvas.Image;
            snake.BackColor = System.Drawing.Color.Red;

            snake.BringToFront();
            snake.Visible = true;

            canvas.Controls.Add(snake);
            snakeManager = new SnakeManager(snake, this);
            gameStart();
            //GrapX.Controls.Add(snake);
        }

        private void gameStart()
        {
            timer.Start();
            appleManager.SpawnApple();
        }

        private void GameTick(object sender, EventArgs e)
        {
            snakeManager.Go();
        }

        public void Stop()
        {
            timer.Stop();
            snake.Hide();
            Canvas.Image = calendarBackgroundCopy;
        }
    }
}
