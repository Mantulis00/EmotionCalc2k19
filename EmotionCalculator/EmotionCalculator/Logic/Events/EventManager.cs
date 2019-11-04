using EmotionCalculator.EmotionCalculator.Logic.User;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Events
{
    class EventManager
    {
        private readonly UserData userData;

        internal EventManager(UserData userData)
        {
            this.userData = userData;
        }

        internal delegate void LaunchLoginPopup(int dailyStreak, Action claimReward);

        internal void RaiseLoginEvent(LaunchLoginPopup launchLoginPopup)
        {
            if (userData.LastLogin != DateTime.Today
                || userData.DailyStreak == 0)
            {
                userData.Login();

                bool claimed = false;

                launchLoginPopup.Invoke(
                    userData.DailyStreak,
                    () =>
                    {
                        if (!claimed)
                        {
                            userData.ClaimDaily();
                            claimed = true;
                        }
                    });
            }
        }
    }
}
