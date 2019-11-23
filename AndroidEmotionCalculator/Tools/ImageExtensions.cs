using Android.Graphics;

namespace AndroidEmotionCalculator.Tools
{
    public static class ImageExtensions
    {
        public static Bitmap ToBitmap(this byte[] array)
        {
            return BitmapFactory.DecodeByteArray(array, 0, array.Length);
        }
    }
}