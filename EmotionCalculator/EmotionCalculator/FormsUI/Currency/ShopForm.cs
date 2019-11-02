using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CurrencyManager = EmotionCalculator.EmotionCalculator.Logic.Currency.CurrencyManager;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Currency
{
    public partial class ShopForm : Form
    {
        private static readonly string BaseInformationMessage = "Buy something!";

        private MonthManager monthManager;

        internal ShopForm(MonthManager monthManager)
        {
            this.monthManager = monthManager;

            //UI
            InitializeComponent();
            informationLabel.Text = BaseInformationMessage;

            //Currency
            InitializeListeners();

            //Items
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
                var item = (PurchasableItem)listBox.Items[i];

                if (!stillPurchasable.Contains(item))
                {
                    listBox.Items.Remove(item);
                    i--;
                }
            }
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

            monthManager.CurrencyManager.ConsumablesChanged +=
                (o, e) =>
                {
                    CurrencyManager manager = monthManager.CurrencyManager;

                    lootBoxAmount.Text = manager.LootboxAmount.ToString();
                    premiumLootBoxAmount.Text = manager.PremiumLootboxAmount.ToString();
                };

            listBox.SelectedValueChanged +=
                (o, e) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        informationLabel.Text = ((PurchasableItem)listBox.SelectedItem).Description;

                        if (((PurchasableItem)listBox.SelectedItem).IsAvailable.Invoke())
                        {
                            purchaseButton.Enabled = true;
                            errorText.Text = string.Empty;
                        }
                        else
                        {
                            purchaseButton.Enabled = false;
                            errorText.ForeColor = Color.Red;
                            errorText.Text = "The item is unavailable.";
                        }
                    }
                    else
                    {
                        informationLabel.Text = BaseInformationMessage;
                    }
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
                switch (monthManager.CurrencyManager.Purchase((PurchasableItem)item))
                {
                    case PurchaseStatus.Successful:
                        errorText.ForeColor = Color.Green;
                        errorText.Text = "Purchase succesful!";
                        break;
                    case PurchaseStatus.Unsucessful:
                        errorText.ForeColor = Color.Red;
                        errorText.Text = "Purchase unsuccesful.";
                        break;
                    case PurchaseStatus.Unavailable:
                        errorText.ForeColor = Color.Red;
                        errorText.Text = "The item is unavailable.";
                        break;
                }
            }

            RefreshStore();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FillStore();
        }
    }
}
