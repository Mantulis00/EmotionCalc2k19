
using System.Drawing;
using System.Windows.Forms;


namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class ImageHandle
    {
        private OpenFileDialog file;

        public ImageHandle()
        {
            file = new OpenFileDialog();
            file.Filter = "JPG(*.JPG)|*.jpg";
        }

        public PictureBox GetPicture(PictureBox box)
        {
            Image image;

            if (file.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(file.FileName);         // cia reiktu keist
                box.Image = image;
            }

            return box;
        }
    }
}
