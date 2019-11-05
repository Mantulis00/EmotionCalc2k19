using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Currency
{
    public partial class ShopForm : Form
    {
        private static readonly string BaseInformationMessage = "Buy something!";

        private readonly MainManager monthManager;

        internal ShopForm(MainManager monthManager)
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

            monthManager.CurrencyManager.PersonalStore.GetPersonalPurchases()
                .Where(p => p.Available).ToList().ForEach
                (item =>
                    {
                        if (!listBox.Items.Contains(item))
                            listBox.Items.Add(item);
                    });
        }

        private void RefreshStore()
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                var item = (PersonalPurchase)listBox.Items[i];

                if (!item.Available)
                    listBox.Items.Remove(item);
            }
        }

        private void InitializeListeners()
        {
            monthManager.ReadOnlyUserData.CurrencyChanged +=
                (o, e) =>
                {
                    ReadOnlyUserData readOnly = monthManager.ReadOnlyUserData;

                    coinAmountLabel.Text = readOnly.JoyCoins.ToString();
                    gemAmountLabel.Text = readOnly.JoyGems.ToString();
                    angryEmotionCount.Text = readOnly.EmotionCount[Emotion.Anger].ToString();
                    contemptEmotionCount.Text = readOnly.EmotionCount[Emotion.Contempt].ToString();
                    disgustEmotionCount.Text = readOnly.EmotionCount[Emotion.Disgust].ToString();
                    fearEmotionCount.Text = readOnly.EmotionCount[Emotion.Fear].ToString();
                    happyEmotionCount.Text = readOnly.EmotionCount[Emotion.Happiness].ToString();
                    sadEmotionCount.Text = readOnly.EmotionCount[Emotion.Sadness].ToString();
                    surpriseEmotionCount.Text = readOnly.EmotionCount[Emotion.Surprise].ToString();
                    neutralEmotionCount.Text = readOnly.EmotionCount[Emotion.Neutral].ToString();
                };

            monthManager.ReadOnlyUserData.OwnedItems.ConsumablesChanged +=
                (o, e) =>
                {
                    ReadOnlyUserData readOnly = monthManager.ReadOnlyUserData;

                    var cons = ConsumableManager.GetItemByType(ConsumableType.BasicLootBox);

                    lootBoxAmount.Text = readOnly.OwnedItems[cons].ToString();

                    cons = ConsumableManager.GetItemByType(ConsumableType.PremiumLootBox);

                    premiumLootBoxAmount.Text = readOnly.OwnedItems[cons].ToString();
                };

            listBox.SelectedValueChanged +=
                (o, e) =>
                {
                    if (listBox.SelectedItem != null)
                    {
                        var selectedItem = (PersonalPurchase)listBox.SelectedItem;

                        informationLabel.Text = selectedItem.Item.Description;

                        if (selectedItem.Available)
                        {
                            purchaseButton.Enabled = true;
                            ChangeErrorText(string.Empty, false);
                        }
                        else
                        {
                            purchaseButton.Enabled = false;
                            ChangeErrorText("The item is unavailable.", false);
                        }
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
                switch (((PersonalPurchase)item).Purchase())
                {
                    case OperationStatus.Successful:
                        ChangeErrorText("Purchase succesful!", true);
                        break;
                    case OperationStatus.Unsuccessful:
                        ChangeErrorText("Purchase unsuccesful.", false);
                        break;
                    case OperationStatus.Unavailable:
                        ChangeErrorText("The item is unavailable.", false);
                        break;
                }
            }

            RefreshStore();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FillStore();
        }

        private void OpenLootBoxButton_Click(object sender, EventArgs e)
        {
            RequestLootBox(premium: false);
            ClearSelection();
        }

        private void OpenPremiumLootBoxButton_Click(object sender, EventArgs e)
        {
            RequestLootBox(premium: true);
            ClearSelection();
        }

        private void ClearSelection()
        {
            listBox.ClearSelected();
            purchaseButton.Enabled = true;
        }

        private void RequestLootBox(bool premium)
        {
            string rewardString;
            OperationStatus operationStatus;

            if (premium)
            {
                operationStatus = monthManager.CurrencyManager
                    .Consume(ConsumableType.PremiumLootBox, out rewardString);
            }
            else
            {
                operationStatus = monthManager.CurrencyManager
                    .Consume(ConsumableType.BasicLootBox, out rewardString);
            }

            switch (operationStatus)
            {
                case OperationStatus.Unavailable:
                    informationLabel.Text = string.Empty;
                    ChangeErrorText("Operation unavailable", false);
                    break;
                case OperationStatus.Successful:
                    informationLabel.Text = rewardString;
                    ChangeErrorText(string.Empty, true);
                    RefreshStore();
                    break;
                case OperationStatus.Unsuccessful:
                    informationLabel.Text = string.Empty;
                    ChangeErrorText("Operation unsuccessful", false);
                    break;
            }
        }

        private void ChangeErrorText(string errorMessage, bool successful)
        {
            errorText.Text = errorMessage;

            if (successful)
                errorText.ForeColor = Color.Green;
            else
                errorText.ForeColor = Color.Red;
        }
    }
}
