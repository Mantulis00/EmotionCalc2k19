using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AppResources = EmotionCalculator.Properties.Resources;

namespace AndroidEmotionCalculator.Fragments.Items
{
    class ShopFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.shop, container, false);

            var image = view.FindViewById<ImageView>(Resource.Id.joyCoins);

            var array = AppResources.joyCoins;

            image.SetImageBitmap(BitmapFactory.DecodeByteArray(array, 0, array.Length));

            return view;
        }
    }
}