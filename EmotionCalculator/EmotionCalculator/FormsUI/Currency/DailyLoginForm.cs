using EmotionCalculator.EmotionCalculator.Logic.Currency;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Currency
{
    public partial class DailyLoginForm : Form
    {
        public DailyLoginForm()
        {
            InitializeComponent();

            InitializePanels();
        }

        private void InitializePanels()
        {
            List<Panel> panels = new List<Panel>
            {
                imagePanel1, imagePanel2, imagePanel3, imagePanel4,
                imagePanel5, imagePanel6, imagePanel7,
            };

            List<Label> labels = new List<Label>
            {
                label1, label2, label3, label4,
                label5, label6, label7,
            };

            var dailyValues = new List<Tuple<CurrencyType, int>>();

            for (int i = 1; i <= 7; i++)
            {
                var dailyValue = DailyLoginData.GetDailyReward(i);

                if (dailyValue.Item1 == CurrencyType.JoyCoin)
                    panels[i - 1].BackgroundImage = Properties.Resources.joyCoins;
                else if (dailyValue.Item1 == CurrencyType.JoyGem)
                    panels[i - 1].BackgroundImage = Properties.Resources.joyGem;

                labels[i - 1].Text = dailyValue.Item2.ToString();
            }
        }
    }
}
