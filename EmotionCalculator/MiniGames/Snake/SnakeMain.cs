using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using EmotionCalculator.EmotionCalculator.FormsUI;

namespace EmotionCalculator.MiniGames.Snake
{
    class SnakeMain
    {
        private PictureBox snake;
        internal PictureBox Canvas;
        internal SnakeManager snakeManager;
        internal Timer timer = new Timer();
        internal AppleManager appleManager;
        internal BaseForm baseForm;
        private int fps = 24;

        public SnakeMain(PictureBox canvas, BaseForm baseForm)
        {
            this.baseForm = baseForm;
            timer.Interval = 1000/fps;
            timer.Tick += new EventHandler(GameTick);
            this.Canvas = canvas;
            snakeManager = new SnakeManager(this);
            appleManager = new AppleManager(this, snakeManager);
            GameStart();
        }


        private void GameStart()
        {
            timer.Start();
            appleManager.SpawnApple();
        }

        private void GameTick(object sender, EventArgs e)
        {
            if (appleManager.apple.Bounds.IntersectsWith(snakeManager.snake.Bounds))
            {
                if (!appleManager.SpawnApple())
                {
                    Stop();
                    return;
                }
                snakeManager.movementSpeed += 1;
                snakeManager.SpawnBlock();
            }
            snakeManager.Go();
        }

        public void Stop()
        {
            baseForm.snakeRunning = false;
            timer.Stop();
            appleManager.Stop();
            snakeManager.Stop();
        }
    }
}
