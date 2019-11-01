using EmotionCalculator.EmotionCalculator.Logic.Settings;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    partial class BaseForm
    {
        public void ShowDebug()
        {
            if (MonthManager.SettingsManager[SettingType.Debug] == SettingStatus.Enabled)
            {
                leftButton.Show();
                rightButton.Show();
                dateTimePicker.Show();
            }
            else
            {
                leftButton.Hide();
                rightButton.Hide();
                dateTimePicker.Hide();
            }
        }
    }
}
