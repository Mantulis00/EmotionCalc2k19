using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Currency
{
    public partial class DailyLoginForm : Form
    {
        private BaseForm baseForm;

        private List<Panel> panels;
        private List<Label> labels;
        private List<Tuple<CurrencyType, int>> dailyValues;

        public DailyLoginForm(BaseForm baseForm)
        {
            this.baseForm = baseForm;
            baseForm.MonthManager.UserData.Login();

            InitializeComponent();
            InitializePanels();
        }

        private void InitializePanels()
        {
            panels = new List<Panel>
            {
                imagePanel1, imagePanel2, imagePanel3, imagePanel4,
                imagePanel5, imagePanel6, imagePanel7,
            };

            labels = new List<Label>
            {
                label1, label2, label3, label4,
                label5, label6, label7,
            };

            dailyValues = new List<Tuple<CurrencyType, int>>();

            for (int i = 1; i <= 7; i++)
            {
                var dailyValue = DailyLoginData.GetDailyReward(i);
                dailyValues.Add(dailyValue);

                if (i > baseForm.MonthManager.UserData.DailyLoginStreak)
                {
                    if (dailyValue.Item1 == CurrencyType.JoyCoin)
                        panels[i - 1].BackgroundImage = Properties.Resources.joyCoins;
                    else if (dailyValue.Item1 == CurrencyType.JoyGem)
                        panels[i - 1].BackgroundImage = Properties.Resources.joyGem;

                    labels[i - 1].Text = dailyValue.Item2.ToString();
                }
                else
                {
                    panels[i - 1].BackgroundImage = Properties.Resources.checkmark;

                    labels[i - 1].Text = string.Empty;
                }
            }

            labels[baseForm.MonthManager.UserData.DailyLoginStreak].ForeColor = Color.Gold;
        }

        private void ClaimButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DailyLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserData userData = baseForm.MonthManager.UserData;

            var reward = dailyValues[userData.DailyLoginStreak];

            if (reward.Item1 == CurrencyType.JoyCoin)
            {
                userData.JoyCoins += reward.Item2;
            }
            else if (reward.Item1 == CurrencyType.JoyGem)
            {
                userData.JoyGems += reward.Item2;
            }

            userData.ClaimDaily();
        }
    }
}
