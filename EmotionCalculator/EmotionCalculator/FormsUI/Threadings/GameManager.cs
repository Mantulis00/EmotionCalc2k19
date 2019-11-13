using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.MiniGames.SpaceInvaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


internal delegate string GameStatus();


namespace EmotionCalculator.EmotionCalculator.FormsUI.Threadings
{
    class GameManager
    {
      
        public GameStatus gameStatus;

        public string InEmojiInvaders()
        {
            string status = "";

            AuxThread = null;
            baseF.MainManager.SettingsManager[EmotionCalculator.Logic.Settings.SettingType.Game] = EmotionCalculator.Logic.Settings.SettingStatus.Disabled;
            baseF.MainManager.MonthManager.Refresh();

            return status;
        }

        public string NotInGame()
        {
            string status = "";

            return status;
        }


        internal Thread AuxThread { get; set; }

        internal SpaceInvadersMain invadersManager;

        internal BaseForm baseF;

        private string gameName;


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
                    StartInvaders();
                    gameStatus = new GameStatus(InEmojiInvaders);
                }
               
            }

            if (e == 'e')
            {
                // service
                API.CallApi ob = new API.CallApi();
                ob.LoadShop();
            }


            else if (AuxThread != null )
            {
                if (gameName == "invaders")
                {
                    invadersManager.playerIManager.ReadInput(e);
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
                    gameName = "invaders";
                    AuxThread.Start();
                
            }

            

        }





    }
}
