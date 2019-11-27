using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidEmotionCalculator.Elements.Adapters;
using AndroidEmotionCalculator.Tools;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using System.Linq;
using AppResources = EmotionCalculator.Properties.Resources;

namespace AndroidEmotionCalculator.Elements.Fragments
{
    class ShopFragment : Fragment
    {
        View view;
        readonly MainManager mainManager;
        ListView listView;
        ShopListViewAdapter adapter;

        public ShopFragment(MainManager mainManager) : base()
        {
            this.mainManager = mainManager;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.shop, container, false);

            SetImages();
            SetText();
            SetButtons();
            SetListView();
            FillThemePacks();

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

        private void SetListView()
        {
            listView = view.FindViewById<ListView>(Resource.Id.listViewShop);

            adapter = new ShopListViewAdapter(Activity);
            listView.Adapter = adapter;
        }

        private void SetButtons()
        {
            view.FindViewById<ImageButton>(Resource.Id.buttonShopTabThemes).Click +=
                (o, e) =>
                {
                    FillThemePacks();
                };

            view.FindViewById<ImageButton>(Resource.Id.buttonShopTabSongs).Click +=
                (o, e) =>
                {
                    FillSongPacks();
                };

            view.FindViewById<ImageButton>(Resource.Id.buttonShopTabLootBoxes).Click +=
                (o, e) =>
                {
                    FillLootBoxes();
                };

            view.FindViewById<ImageButton>(Resource.Id.buttonShopTabVanity).Click +=
                (o, e) =>
                {
                    FillOther();
                };
        }

        private void FillThemePacks()
        {
            FillTable(ItemType.Theme);
        }

        private void FillSongPacks()
        {
            FillTable(ItemType.Song);
        }

        private void FillLootBoxes()
        {
            FillTable(ItemType.LootBox);
        }

        private void FillOther()
        {
            FillTable(ItemType.Skin);
        }

        private void FillTable(ItemType itemType)
        {
            adapter.Purchases.Clear();
            adapter.Purchases.AddRange(mainManager.CurrencyManager.PersonalStore.GetPersonalPurchases()
                .Where(purchase => purchase.Available && purchase.Item.ItemType == itemType));

            adapter.NotifyDataSetChanged();
        }
    }
}