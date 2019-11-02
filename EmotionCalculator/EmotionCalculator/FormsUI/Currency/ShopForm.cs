using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Linq;
using System.Windows.Forms;
using CurrencyManager = EmotionCalculator.EmotionCalculator.Logic.Currency.CurrencyManager;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Currency
{
    public partial class ShopForm : Form
    {
        private MonthManager monthManager;

        internal ShopForm(MonthManager monthManager)
        {
            this.monthManager = monthManager;

            InitializeComponent();

            InitializeListeners();

            monthManager.Refresh();

            FillStore();
        }

        private void FillStore()
        {
            listBox.Items.Clear();

            monthManager.CurrencyManager.PurchasableItems.ToList().ForEach
                (item =>
                    {
                        if (!listBox.Items.Contains(item))
                            listBox.Items.Add(item);
                    });
        }

        private void RefreshStore()
        {
            var stillPurchasable = monthManager.CurrencyManager.PurchasableItems;

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                var item = listBox.Items[i];

                if (!stillPurchasable.Any(_item => item.ToString() == _item.ToString()))
                {
                    listBox.Items.Remove(item);
                    i--;
                }
            }

            monthManager.CurrencyManager.PurchasableItems.ToList().ForEach
                (item =>
                    {
                        bool displayed = false;

                        foreach (var shopItem in listBox.Items)
                        {
                            if (shopItem.ToString() == item.ToString())
                            {
                                displayed = true;
                                break;
                            }
                        }

                        if (!displayed)
                        {
                            listBox.Items.Add(item);
                        }
                    });

        }

        private void InitializeListeners()
        {
            monthManager.CurrencyManager.CurrencyChanged +=
                (o, e) =>
                {
                    CurrencyManager manager = monthManager.CurrencyManager;

                    coinAmountLabel.Text = manager.JoyCoins.ToString();
                    gemAmountLabel.Text = manager.JoyGems.ToString();
                    angryEmotionCount.Text = manager.EmotionCount[Emotion.Anger].ToString();
                    contemptEmotionCount.Text = manager.EmotionCount[Emotion.Contempt].ToString();
                    disgustEmotionCount.Text = manager.EmotionCount[Emotion.Disgust].ToString();
                    fearEmotionCount.Text = manager.EmotionCount[Emotion.Fear].ToString();
                    happyEmotionCount.Text = manager.EmotionCount[Emotion.Happiness].ToString();
                    sadEmotionCount.Text = manager.EmotionCount[Emotion.Sadness].ToString();
                    surpriseEmotionCount.Text = manager.EmotionCount[Emotion.Surprise].ToString();
                    neutralEmotionCount.Text = manager.EmotionCount[Emotion.Neutral].ToString();
                };
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Purchase_Click(object sender, EventArgs e)
        {
            var item = listBox.SelectedItem;

            if (item != null)
            {
                monthManager.CurrencyManager.Purchase((PurchasableItem)item);
            }

            RefreshStore();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FillStore();
        }
    }
}
