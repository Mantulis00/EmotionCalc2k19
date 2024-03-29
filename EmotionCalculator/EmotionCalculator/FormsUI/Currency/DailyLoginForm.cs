﻿using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Tools.Web;
using EmotionCalculator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Currency
{
    public partial class DailyLoginForm : Form
    {
        private List<Panel> panels;
        private List<Label> labels;

        private readonly int dailyStreak;
        private readonly Action claimReward;

        internal DailyLoginForm(int dailyStreak, Action claimReward)
        {
            this.dailyStreak = dailyStreak;
            this.claimReward = claimReward;

            InitializeComponent();
            InitializePanels();

            TopMost = true;
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

            for (int i = 1; i <= 7; i++)
            {
                var dailyValue = DailyLoginData.GetDailyReward(i);

                if (i > dailyStreak)
                {
                    if (dailyValue.Item1 == CurrencyType.JoyCoin)
                        panels[i - 1].BackgroundImage = Resources.joyCoins.ToImage();
                    else if (dailyValue.Item1 == CurrencyType.JoyGem)
                        panels[i - 1].BackgroundImage = Resources.joyGem.ToImage();

                    labels[i - 1].Text = dailyValue.Item2.ToString();
                }
                else
                {
                    panels[i - 1].BackgroundImage = Resources.checkmark.ToImage();

                    labels[i - 1].Text = string.Empty;
                }
            }

            labels[dailyStreak].ForeColor = Color.Gold;
        }

        private void DailyLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            claimReward.Invoke();
        }

        private void ClaimButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
