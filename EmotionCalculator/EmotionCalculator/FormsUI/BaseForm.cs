﻿using EmotionCalculator.EmotionCalculator.FormsUI.Currency;
using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmotionCalculator.MiniGames.SpaceInvaders;
using System.Threading;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {
        internal MainManager MainManager { get; private set; }
        internal Thread AuxThread { get; set; }
        internal IAPIManager APIManager { get; private set; }



        internal SpaceInvadersMain invadersManager;


        internal BaseForm(IAPIManager apiManager)
        {
            this.KeyPreview = true;

            //UI
            InitializeComponent();

            //API
            APIManager = apiManager;

            //UI <-> API
            SetupMonth();
            SetupListeners();
            MainManager.Refresh();

            //Update UI
            RefreshUI();

            //Daily login
            MainManager.EventManager.RaiseLoginEvent(
                (dailyStreak, claimReward) =>
                {
                    OpenSecondaryWindow(new DailyLoginForm(dailyStreak, claimReward));
                });
        }

        private void RefreshUI()
        {
            ShowDebug();
        }


        private void SetupMonth()
        {
            MainManager = new MainManager(
                new MonthEmotionsIO(),
                new UserLoader(),
                new SettingsLogger());

            CalendarUpdater calendarUpdater = new CalendarUpdater(calendarBackground, MainManager.SettingsManager);

            MainManager.MonthManager.StatusChanged +=
                (o, e) =>
                {
                    calendarUpdater.Update(e.MonthEmotions, e.SelectedTime);
                };

            dateTimePicker.ValueChanged +=
                (o, e) =>
                {
                    MainManager.MonthManager.ChangeTime(dateTimePicker.Value);
                };
        }

        private void SetupListeners()
        {
            MainManager.ReadOnlyUserData.CurrencyChanged +=
                (o, e) =>
                {
                    ReadOnlyUserData readOnly = MainManager.ReadOnlyUserData;

                    coinAmountLabel.Text = readOnly.JoyCoins.ToString();
                    gemAmountLabel.Text = readOnly.JoyGems.ToString();
                    angryEmotionCount.Text = readOnly.EmotionCount[Emotion.Anger].ToString();
                    contemptEmotionCount.Text = readOnly.EmotionCount[Emotion.Contempt].ToString();
                    disgustEmotionCount.Text = readOnly.EmotionCount[Emotion.Disgust].ToString();
                    fearEmotionCount.Text = readOnly.EmotionCount[Emotion.Fear].ToString();
                    happyEmotionCount.Text = readOnly.EmotionCount[Emotion.Happiness].ToString();
                    neutralEmotionCount.Text = readOnly.EmotionCount[Emotion.Neutral].ToString();
                    sadEmotionCount.Text = readOnly.EmotionCount[Emotion.Sadness].ToString();
                    surpriseEmotionCount.Text = readOnly.EmotionCount[Emotion.Surprise].ToString();
                };
        }

        internal void UpdateParsedData(APIParseResult parseResult)
        {
            DisplayErrors(parseResult);

            if (parseResult.Faces.Count > 0)
            {
                MainManager.MonthManager.SetEmotion(parseResult.Faces.First().EmotionData.GetEmotion());
            }
        }

        internal static void DisplayErrors(APIParseResult parseResult)
        {
            if (parseResult.Faces.Count == 0)
            {
                MessageBox.Show("No faces found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (parseResult.Errors.Count > 0)
            {
                foreach (var error in parseResult.Errors)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApplication();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            MainManager.Save();
            SettingsManager[SettingType.Game] = Logic.Settings.SettingStatus.Enabled;
            Application.Exit();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSecondaryWindow(new SettingsForm(this));
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            OpenSecondaryWindow(new UrlForm(this));
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenSecondaryWindow(new ImagefileForm(this));
        }

        private void CameraStartButton_Click(object sender, EventArgs e)
        {
            OpenSecondaryWindow(new CameraForm(this));
        }

        private void ConfigureAPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSecondaryWindow(APIManager.GetSettingsForm());
        }

        private void ShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSecondaryWindow(new ShopForm(MainManager));
        }

        private void MusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainManager.ReadOnlyUserData.OwnedItems.ThemePacks.Count() > 0)
                OpenSecondaryWindow(new Coin_Use.MusicForm(MainManager));
            else
                MessageBox.Show("No songs found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void OpenSecondaryWindow(Form secondaryWindow)
        {
            Enabled = false;


            secondaryWindow.Show();

            secondaryWindow.FormClosed +=
                (o, ev) =>
                {
                    Enabled = true;
                    MainManager.Refresh();
                    RefreshUI();
                    BaseFormManagerUI.ShowDebug(this);
                };
        }

        private void LightsOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainManager.CurrencyManager.Purchase(CustomPurchase.LightsOff) == OperationStatus.Successful)
            {
                lightsOnToolStripMenuItem.Enabled = true;
                lightsOffToolStripMenuItem.Enabled = false;

                BackColor = Color.Black;
            }
        }

        private void LightsOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainManager.CurrencyManager.Purchase(CustomPurchase.LightsOn) == OperationStatus.Successful)
            {
                lightsOffToolStripMenuItem.Enabled = true;
                lightsOnToolStripMenuItem.Enabled = false;

                BackColor = SystemColors.Control;
            }
        }

        private void GetCoins10JoyCoinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainManager.CurrencyManager.TemporaryCurrencyEntryPoint(CurrencyType.JoyCoin, 10);
        }


        private void MusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            var rand = new Random();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\" + rand.Next(1, 13).ToString() + ".wav";
            player.Play();
        }


        private void InvadersLauch()
        {
            invadersManager = new SpaceInvadersMain(calendarBackground, this);
        }

        //Calendar navigation
        private void LeftButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (AuxThread == null)
            {
                StartGame(e.KeyChar);
            }

            else if (AuxThread != null)
            {
                invadersManager.playerIManager.ReadInput(e.KeyChar);
            }

        }

        private void StartGame(char input)
        {
            if (input == 'u') // u for emoji invaders
            {
                SettingsManager[SettingType.Game] = Logic.Settings.SettingStatus.Enabled;
                MonthManager.Refresh();
                InvadersLauch();

                AuxThread = new Thread(
                    () =>
                    {
                        this.BeginInvoke((Action)delegate ()
                        {
                            invadersManager.StartAnimation();
                        });
                    }
                );
                AuxThread.Start();
            }


        }
    }
}
