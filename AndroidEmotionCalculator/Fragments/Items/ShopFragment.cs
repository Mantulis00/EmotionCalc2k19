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
        View view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.shop, container, false);

            SetImages();

            return view;
        }

        private void SetImages()
        {
            //Main currency icons
            var coinsImage = view.FindViewById<ImageView>(Resource.Id.imageViewShopJoyCoins);
            coinsImage.SetImageBitmap(AppResources.joyCoins.ToBitmap());

            var gemsImage = view.FindViewById<ImageView>(Resource.Id.imageViewShopJoyGems);
            gemsImage.SetImageBitmap(AppResources.joyGem.ToBitmap());

            //Shop tab icons
            var themePackImage = view.FindViewById<ImageButton>(Resource.Id.buttonShopTabThemes);
            themePackImage.SetImageBitmap(AppResources.themePackIcon.ToBitmap());

            var songPackImage = view.FindViewById<ImageButton>(Resource.Id.buttonShopTabSongs);
            songPackImage.SetImageBitmap(AppResources.note.ToBitmap());

            var lootBoxImage = view.FindViewById<ImageButton>(Resource.Id.buttonShopTabLootBoxes);
            lootBoxImage.SetImageBitmap(AppResources.lootbox.ToBitmap());

            var vanityImage = view.FindViewById<ImageButton>(Resource.Id.buttonShopTabVanity);
            vanityImage.SetImageBitmap(AppResources.tophat.ToBitmap());
        }
    }
}