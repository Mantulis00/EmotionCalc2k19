using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;


namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class ImageHan
    {
     private  OpenFileDialog file;

       public ImageHan()
        {
            file = new OpenFileDialog();
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







    }
}
