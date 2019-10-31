using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
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
    }
}
