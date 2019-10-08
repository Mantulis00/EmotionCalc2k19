using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.API
{
    interface IAPIManager
    {
        Form GetSettingsForm();
        IAPIRequester GetAPIRequester();
    }
}
