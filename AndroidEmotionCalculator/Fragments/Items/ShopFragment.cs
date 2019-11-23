using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidEmotionCalculator.Tools;
using AppResources = EmotionCalculator.Properties.Resources;

namespace AndroidEmotionCalculator.Fragments.Items
{
    class ShopFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.shop, container, false);

            var coinsImage = view.FindViewById<ImageView>(Resource.Id.imageViewShopJoyCoins);
            coinsImage.SetImageBitmap(AppResources.joyCoins.ToBitmap());

            var gemsImage = view.FindViewById<ImageView>(Resource.Id.imageViewShopJoyGems);
            gemsImage.SetImageBitmap(AppResources.joyGem.ToBitmap());

            return view;
        }
    }
}