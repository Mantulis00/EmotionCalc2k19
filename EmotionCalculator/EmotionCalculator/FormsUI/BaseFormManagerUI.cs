using EmotionCalculator.EmotionCalculator.Logic.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    static class BaseFormManagerUI
    {

        public static void ShowDebug(BaseForm baseForm)
        {
            if (baseForm.SettingsManager[SettingType.Debug] == SettingStatus.Enabled)
            {
                baseForm.leftButton.Show();
                baseForm.rightButton.Show();
                baseForm.dateTimePicker.Show();
            }
            else
            {
                baseForm.leftButton.Hide();
                baseForm.rightButton.Hide();
                baseForm.dateTimePicker.Hide();
            }

        }


    }
}
