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

namespace EmotionCalculator.EmotionCalculator.FormsUI.Threadings
{
    class GameManager
    {

        internal Thread AuxThread { get; set; }

        internal SpaceInvadersMain invadersManager;

        internal BaseForm baseF;

        private string gameName;


        public GameManager(BaseForm baseF)
        {
            this.baseF = baseF;
        }

        public void CheckInGameInput(char e)
        {
            if (AuxThread == null)
            {
                if (e == '1')
                {
                    CheckGame(e);
                }
               
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

        private void CheckGame(char input)
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

             if (input == 'e')
            {
                // service
                API.CallApi ob = new API.CallApi();
                ob.LoadShop();
            }

        }



    }
}
