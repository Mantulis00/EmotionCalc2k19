using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidEmotionCalculator.Tools;
using EmotionCalculator.EmotionCalculator.Logic;
using AppResources = EmotionCalculator.Properties.Resources;

namespace AndroidEmotionCalculator.Fragments.Items
{
    class ShopFragment : Fragment
    {
        View view;
        readonly MainManager mainManager;

        public ShopFragment(MainManager mainManager) : base()
        {
            this.mainManager = mainManager;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.shop, container, false);

            SetImages();
            SetText();

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

        private void SetText()
        {
            //Main currency text
            var coinText = view.FindViewById<TextView>(Resource.Id.textViewShopJoyCoins);
            coinText.Text = mainManager.ReadOnlyUserData.JoyCoins.ToString();

            var gemText = view.FindViewById<TextView>(Resource.Id.textViewShopJoyGems);
            gemText.Text = mainManager.ReadOnlyUserData.JoyGems.ToString();
        }
    }
}