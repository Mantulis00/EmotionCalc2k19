using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    class CurrencyUpdater : IUserUpdatable
    {
        private Label coinLabel;
        private Label gemLabel;
        private Label angerLabel;
        private Label contemptLabel;
        private Label disgustLabel;
        private Label fearLabel;
        private Label happinessLabel;
        private Label neutralLabel;
        private Label sadnessLabel;
        private Label surpriseLabel;

        public CurrencyUpdater(Label coinLabel, Label gemLabel,
            Label angerLabel, Label contemptLabel,
            Label disgustLabel, Label fearLabel,
            Label happinessLabel, Label neutralLabel,
            Label sadnessLabel, Label surpriseLabel)
        {
            this.coinLabel = coinLabel;
            this.gemLabel = gemLabel;
            this.angerLabel = angerLabel;
            this.contemptLabel = contemptLabel;
            this.disgustLabel = disgustLabel;
            this.fearLabel = fearLabel;
            this.happinessLabel = happinessLabel;
            this.neutralLabel = neutralLabel;
            this.sadnessLabel = sadnessLabel;
            this.surpriseLabel = surpriseLabel;
        }

        public void Update(UserData userData)
        {
            coinLabel.Text = userData.JoyCoins.ToString();
            gemLabel.Text = userData.JoyGems.ToString();

            angerLabel.Text = userData.EmotionCount[Emotion.Anger].ToString();
            contemptLabel.Text = userData.EmotionCount[Emotion.Contempt].ToString();
            disgustLabel.Text = userData.EmotionCount[Emotion.Disgust].ToString();
            fearLabel.Text = userData.EmotionCount[Emotion.Fear].ToString();
            happinessLabel.Text = userData.EmotionCount[Emotion.Happiness].ToString();
            neutralLabel.Text = userData.EmotionCount[Emotion.Neutral].ToString();
            sadnessLabel.Text = userData.EmotionCount[Emotion.Sadness].ToString();
            surpriseLabel.Text = userData.EmotionCount[Emotion.Surprise].ToString();
        }
    }
}
