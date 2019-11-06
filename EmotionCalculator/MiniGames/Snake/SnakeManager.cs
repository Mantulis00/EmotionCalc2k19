using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.Snake
{
    class SnakeManager
    {
        internal PictureBox snake;
        private SnakeDirection direction;
        internal int movementSpeed;
        private SnakeMain snakeMain;
        private List<PictureBox> snakeBlocks;
        private List<Point> headHistory;
        private int snakeDimensions = 20;

        public SnakeManager(SnakeMain snakeMain)
        {
            snakeBlocks = new List<PictureBox>();
            headHistory = new List<Point>();
            this.snakeMain = snakeMain;
            direction = SnakeDirection.UP;
            movementSpeed = 5;
            snake = CreateSnakeBlock(snakeMain.Canvas, new Point(snakeMain.Canvas.Width / 2, snakeMain.Canvas.Height / 2));
        }
        internal PictureBox CreateSnakeBlock(PictureBox canvas, Point location)
        {
            PictureBox snakeBlock = new PictureBox();
            snakeBlock.Size = new Size(snakeDimensions, snakeDimensions);
            snakeBlock.Location = location;

            snakeBlock.SizeMode = canvas.SizeMode;
            snakeBlock.Image = Properties.Resources.snakeEmoji;
            snakeBlock.BackColor = Color.Transparent;

            snakeBlock.BringToFront();
            snakeBlock.Visible = true;

            canvas.Controls.Add(snakeBlock);
            return snakeBlock;
        }

        internal void SpawnBlock()
        {
            Point location = headHistory[headHistory.Count - 1 - snakeBlocks.Count];
            PictureBox snakeBlock = CreateSnakeBlock(snakeMain.Canvas, location);
            snakeBlocks.Add(snakeBlock);
        }

        public void ReadInput(char e)
        {
            ChangeDirection(e);
        }

        private void ChangeDirection(char e)
        {
            switch (e)
            {
                case 'a':
                    if (direction == SnakeDirection.RIGHT)
                    {
                        return;
                    }
                    direction = SnakeDirection.LEFT;
                    break;
                case 'w':
                    if (direction == SnakeDirection.DOWN)
                    {
                        return;
                    }
                    direction = SnakeDirection.UP;
                    break;
                case 's':
                    if (direction == SnakeDirection.UP)
                    {
                        return;
                    }
                    direction = SnakeDirection.DOWN;
                    break;
                case 'd':
                    if (direction == SnakeDirection.LEFT)
                    {
                        return;
                    }
                    direction = SnakeDirection.RIGHT;
                    break;
                case 'q':
                    snakeMain.Stop();
                    snakeMain.baseForm.snakeRunning = false;
                    break;
            }
        }

        public void Go()
        {
            if (headHistory.Count > 100)
            {
                headHistory.RemoveAt(0);
            }
            Point lastHeadLocation = new Point();
            switch (direction)
            {
                case SnakeDirection.UP:
                    snake.Location = new Point(snake.Location.X, snake.Location.Y - movementSpeed);
                    lastHeadLocation.X = snake.Location.X;
                    lastHeadLocation.Y = snake.Location.Y + snakeDimensions;
                    break;
                case SnakeDirection.DOWN:
                    snake.Location = new System.Drawing.Point(snake.Location.X, snake.Location.Y + movementSpeed);
                    lastHeadLocation.X = snake.Location.X;
                    lastHeadLocation.Y = snake.Location.Y - snakeDimensions;
                    break;
                case SnakeDirection.LEFT:
                    snake.Location = new System.Drawing.Point(snake.Location.X - movementSpeed, snake.Location.Y);
                    lastHeadLocation.X = snake.Location.X + snakeDimensions;
                    lastHeadLocation.Y = snake.Location.Y;
                    break;
                case SnakeDirection.RIGHT:
                    snake.Location = new System.Drawing.Point(snake.Location.X + movementSpeed, snake.Location.Y);
                    lastHeadLocation.X = snake.Location.X - snakeDimensions;
                    lastHeadLocation.Y = snake.Location.Y;
                    break;
            }
            int index = 0;
            int magicNumber = 4;
            foreach (var snakeBlock in snakeBlocks)
            {
                Point snakeBlockLocation = headHistory[headHistory.Count - 1 - magicNumber*index++];
                snakeBlock.Location = snakeBlockLocation;
                if (snakeBlock.Bounds.IntersectsWith(snake.Bounds))
                {
                    snakeMain.Stop(); 
                }
            }
            headHistory.Add(lastHeadLocation);
            if (snake.Location.X > snakeMain.Canvas.Width - snakeDimensions || snake.Location.X < 0 ||
                snake.Location.Y > snakeMain.Canvas.Height - snakeDimensions || snake.Location.Y < 0)
            {
                snakeMain.Stop();
            }
        }
        internal void Stop()
        {
            snakeMain.Canvas.Controls.Remove(snake);
            foreach (var snakeBlock in snakeBlocks)
            {
                snakeMain.Canvas.Controls.Remove(snakeBlock);
            }
        }
    }

}
