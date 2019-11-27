using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Tools.Web
{
    static class ImageTools
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

        public static Image ToImage(this byte[] byteArray)
        {
            return ByteArrayToImage(byteArray);
        }

        public static byte[] ToBytes(this Image image)
        {
            return ImageToByteArray(image);
        }
    }
}
