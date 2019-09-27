
using System.Drawing;
using System.Drawing.Imaging;
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

        public Image imageProcess(Image img)
        {
            img.Save("tempImg.jpg", ImageFormat.Jpeg);

            Image returnedImage = Image.FromFile("tempImg.jpg");

            return returnedImage;
        }
    }
}
