using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using EmotionCalculator.Properties;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Coin_Use
{
    public partial class MusicForm : Form
    {
        SoundPlayer player = new SoundPlayer();
        int number = 1;
        public MusicForm()
        {
            InitializeComponent();
            musiclabel.Text = "MineCraft song " + number;
            Image myimage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\MineCraftPhotos\\"+ number.ToString()+".jpg");
            this.BackgroundImage = myimage; 
        }

        private void PlayButtonMusic_Click(object sender, EventArgs e)
        {
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\" + number.ToString() + ".wav";
            player.Play();
        }

        private void PauseButtonMusic_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void NextMusicButton_Click(object sender, EventArgs e)
        {
            number++;
            if(number==13)
            {
                number = 1;
            }
            musiclabel.Text = "MineCraft song " + number;
            Image myimage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\MineCraftPhotos\\" + number.ToString() + ".jpg");
            this.BackgroundImage = myimage;
        }

        private void BackMusicButton_Click(object sender, EventArgs e)
        {
            number--;
            if (number==0)
            {
                number = 12;
            }
            musiclabel.Text = "MineCraft song " + number;
            Image myimage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\MineCraftPhotos\\" + number.ToString() + ".jpg");
            this.BackgroundImage = myimage;
        }
    }
}
