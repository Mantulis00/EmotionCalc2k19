using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Tools.Web
{
    class ImageTools
    {
        public static Image ByteArrayToImage(byte[] bytesArr)
        {
            using (var memStr = new System.IO.MemoryStream(bytesArr))
            {
                return Image.FromStream(memStr);
            }
        }

        public static byte[] ImageToByteArray(Image imgIn)
        {
            using (var imgOut = new System.IO.MemoryStream())
            {
                imgIn.Save(imgOut, imgIn.RawFormat);
                return imgOut.ToArray();
            }
        }
    }
}
