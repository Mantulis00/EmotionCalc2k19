using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.MiniGames.SpaceInvaders;
using System;
using System.Threading;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Threadings
{
    public class GameManager
    {
        public delegate string GameStatus();
        public GameStatus gameStatus;
        internal Thread AuxThread { get; set; }
        internal SpaceInvadersMain invadersManager;
        internal BaseForm baseF;
        private string gameName;

        public string InEmojiInvaders()
        {
            string status = "Emoji invaders | GameOver";

            AuxThread.Join();
            AuxThread = null;
            baseF.MainManager.SettingsManager[EmotionCalculator.Logic.Settings.SettingType.Game] = EmotionCalculator.Logic.Settings.SettingStatus.Disabled;
            baseF.MainManager.MonthManager.Refresh();


            gameName = "";

            return status;
        }

        public string NotInGame()
        {
            string status = "";

            return status;
        }

        public GameManager(BaseForm baseF)
        {
            GameStatus gameStatus = delegate ()
            {
                string status = "Game manager created | no game starded";
                return status;
            };

            this.baseF = baseF;
        }

        public void CheckInGameInput(char e)
        {
            if (AuxThread == null)
            {
                if (e == '1')
                {
                    gameName = "invaders";
                    StartInvaders();
                    gameStatus = new GameStatus(InEmojiInvaders);
                }

            }
            else if (AuxThread != null)
            {
                if (gameName == "invaders")
                {
                    invadersManager.PlayerIManager.ReadInput(e);
                }

            }
        }

        private void InvadersLauch()
        {
            invadersManager = new SpaceInvadersMain(baseF.calendarBackground, baseF);
        }

        private void StartInvaders()
        {

            if (baseF.MainManager.CurrencyManager.Purchase(CustomPurchase.GameRun) == OperationStatus.Successful)
            {
                baseF.MainManager.SettingsManager[SettingType.Game] = SettingStatus.Enabled;
                baseF.MainManager.MonthManager.Refresh();
                InvadersLauch();

                AuxThread = new Thread(
                    () =>
                    {
                        baseF.BeginInvoke((Action)delegate ()
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
