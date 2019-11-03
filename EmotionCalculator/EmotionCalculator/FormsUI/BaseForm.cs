using EmotionCalculator.EmotionCalculator.FormsUI.Currency;
using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Tools.API;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using EmotionCalculator.MiniGames.SpaceInvaders;
using System.Threading;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {
        Thread thread2 = null;

        internal MonthManager MonthManager { get; private set; }

        internal IAPIManager APIManager { get; private set; }

        internal SettingsManager SettingsManager { get; private set; }
        public object SettingStatus { get; internal set; } // not used ?


        // kodas123
        internal SpaceInvadersMain invadersManager;


        internal BaseForm(IAPIManager apiManager)
        {


            //Settings
            this.KeyPreview = true;
            SettingsManager = DesktopPack.GetSettings();

            //UI
            InitializeComponent();
            StartupUI();

            //API
            APIManager = apiManager;

            //UI <-> API
            SetupMonth();

            //Daily login
            MonthManager.RaiseLoginEvent(
                (dailyStreak, claimReward) =>
                {
                    OpenSecondaryWindow(new DailyLoginForm(dailyStreak, claimReward));
                });

            //kodas123

        }

        private void StartupUI()
        {
                BaseFormManagerUI.ShowDebug(this);
        }


        private void SetupMonth()
        {
            MonthManager = new MonthManager(
               new MonthEmotionsIO(),
               new CalendarUpdater(calendarBackground, SettingsManager),
               dateTimePicker.Value,
               new UserLoader(),
               new CurrencyUpdater(coinAmountLabel, gemAmountLabel));

            dateTimePicker.ValueChanged +=
                (o, e) =>
                {
                    MonthManager.ChangeTime(dateTimePicker.Value);
                };


            MonthManager.Refresh();
        }

        internal void UpdateParsedData(APIParseResult parseResult)
        {
            DisplayErrors(parseResult);

            if (parseResult.Faces.Count > 0)
            {
                MonthManager.SetEmotion(parseResult.Faces.First().EmotionData.GetEmotion());
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
            MonthManager.Save();

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



        private void OpenSecondaryWindow(Form secondaryWindow)
        {
            Enabled = false;


            secondaryWindow.Show();

            secondaryWindow.FormClosed +=
                (o, ev) =>
                {

                    Enabled = true;
                    MonthManager.Refresh();
                    BaseFormManagerUI.ShowDebug(this);
                };
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


        private void MusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            var rand = new Random();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\" + rand.Next(1, 13).ToString() + ".wav";
            player.Play();
        }


        private void InvadersLauch()
        {
            invadersManager = new SpaceInvadersMain(calendarBackground);
        }

        //kodas123

            private void SetText()
        {
            Console.WriteLine("pov");
        }


        private void BaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 'e')
            {
                InvadersLauch();

                thread2 = new Thread(
                    () =>
                    {
                    this.BeginInvoke((Action)delegate ()
                     {
                       invadersManager.StartTimer();
                     });
                    }
                );
                thread2.Start();

                
            }

            if (e.KeyChar == 'u')
            {
                SettingsManager[SettingType.Game] = Logic.Settings.SettingStatus.Enabled;
                MonthManager.Refresh();
                InvadersLauch();


                thread2 = new Thread(
                    () =>
                    {
                        this.BeginInvoke((Action)delegate ()
                        {
                            invadersManager.StartAnimation();
                        });
                    }
                );
                thread2.Start();
            }
            
           
            else
                invadersManager.playerIManager.ReadInput(e.KeyChar);
                
        }

        private void BeginInvoke()
        {
            throw new NotImplementedException();
        }
    }
}
