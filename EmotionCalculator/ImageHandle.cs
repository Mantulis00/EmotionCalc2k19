﻿
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class ImageHandle
    {
        private readonly OpenFileDialog file;

        public ImageHandle()
        {
            file = new OpenFileDialog
            {
                Filter = "JPG(*.JPG)|*.jpg"
            };
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

        public static Image ProcessImage(Image img)
        {
            string fileName = "tempImg.jpg";

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    img.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

            Image returnedImage = Image.FromFile(fileName);

            return returnedImage;
        }
    }
}
