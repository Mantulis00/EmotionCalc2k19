using EmotionCalculator.EmotionCalculator.Logic.User;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    class CurrencyUpdater : IUserUpdatable
    {
        private Label coinLabel;
        private Label gemLabel;

        public CurrencyUpdater(Label coinLabel, Label gemLabel)
        {
            this.coinLabel = coinLabel;
            this.gemLabel = gemLabel;
        }

        public void Update(UserData userData)
        {
            coinLabel.Text = userData.JoyCoins.ToString();
            gemLabel.Text = userData.JoyGems.ToString();
        }
    }
}
