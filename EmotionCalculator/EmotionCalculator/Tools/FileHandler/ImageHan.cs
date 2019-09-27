using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class ImageHan
    {
     private  OpenFileDialog file;
     private SaveFileDialog fileO;

       public ImageHan()
        {
            file = new OpenFileDialog();
            fileO = new SaveFileDialog();
            file.Filter = "JPG(*.JPG)|*.jpg";
        }


       public PictureBox GetPicture (PictureBox box)
        {
            Image image;

            if (file.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(file.FileName);         // cia reiktu keist
                box.Image = image;
            }

            return box;
        }

        public  Image imageProcess(Image img)
        {
            if (File.Exists("tempImg.jpg"))
            {
                File.Delete("tempImg.jpg");

            }
                img.Save("tempImg.jpg", ImageFormat.Jpeg);

                return Image.FromFile("tempImg.jpg");
        }







    }
}
