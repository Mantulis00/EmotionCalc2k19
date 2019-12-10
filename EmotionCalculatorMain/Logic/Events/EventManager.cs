using EmotionCalculator.EmotionCalculator.Logic.User;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Events
{
    public class EventManager
    {
        private readonly UserData userData;

        internal EventManager(UserData userData)
        {
            this.userData = userData;
        }

        public delegate void LaunchLoginPopup(int dailyStreak, Action claimReward);

        public void RaiseLoginEvent(LaunchLoginPopup launchLoginPopup)
        {
            if (userData.LastLogin != DateTime.Today
                || userData.DailyStreak == 0)
            {
                userData.Login();

                bool claimed = false;

                launchLoginPopup?.Invoke(
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
