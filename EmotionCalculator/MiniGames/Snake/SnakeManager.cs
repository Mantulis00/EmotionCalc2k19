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
        private PictureBox snake;
        private SnakeDirection direction;
        private int movementSpeed;
        private SnakeMain snakeMain;
        private List<PictureBox> snakeBlocks;
        private PictureBox apple;

        public SnakeManager(PictureBox snake, SnakeMain snakeMain)
        {
            this.snake = snake;
            this.snakeMain = snakeMain;
            direction = SnakeDirection.UP;
            movementSpeed = 5;
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
                    break;
            }
        }

        public void Go()
        {
            switch (direction)
            {
                case SnakeDirection.UP:
                    snake.Location = new System.Drawing.Point(snake.Location.X, snake.Location.Y - movementSpeed);
                    break;
                case SnakeDirection.DOWN:
                    snake.Location = new System.Drawing.Point(snake.Location.X, snake.Location.Y + movementSpeed);
                    break;
                case SnakeDirection.LEFT:
                    snake.Location = new System.Drawing.Point(snake.Location.X - movementSpeed, snake.Location.Y);
                    break;
                case SnakeDirection.RIGHT:
                    snake.Location = new System.Drawing.Point(snake.Location.X + movementSpeed, snake.Location.Y);
                    break;
            }
        }

    }
}
