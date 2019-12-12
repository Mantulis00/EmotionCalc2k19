using Android.Content;
using Android.Views;
using Android.Widget;
using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using System.Collections.Generic;

namespace AndroidEmotionCalculator.Elements.Adapters
{
    class ShopListViewAdapter : BaseAdapter<PersonalPurchase>
    {
        public List<PersonalPurchase> Purchases { get; private set; }
        private readonly Context context;

        public ShopListViewAdapter(Context context)
        {
            this.context = context;
            Purchases = new List<PersonalPurchase>();
        }

        public override PersonalPurchase this[int position] => Purchases[position];

        public override int Count => Purchases.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var newView = convertView;

            if (newView == null)
            {
                newView = LayoutInflater.From(context).Inflate(Resource.Layout.shop_item, parent, false);
            }

            var purchase = Purchases[position];

            newView.FindViewById<TextView>(Resource.Id.textViewShopItemItemTitle).Text = purchase.Item.Name;
            newView.FindViewById<TextView>(Resource.Id.textViewShopItemItemDescription).Text = purchase.Item.Description;

            var button = newView.FindViewById<Button>(Resource.Id.buttonShopItemPurchaseButton);

            button.Text =
                $"Purchase for {purchase.ItemPrice.Price} "
                + (purchase.ItemPrice.CurrencyType == CurrencyType.JoyCoin ? "Joy Coins" : "Joy Gems");

            button.Click +=
                (o, e) =>
                {
                    OperationStatus operationStatus = purchase.Purchase();
                };

            return newView;
        }
    }
}