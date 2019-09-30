using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (FaceAPIConfig.ConfigExists())
            {
                (new BaseForm()).Show();
            }
            else
            {
                (new APISettingsForm()).Show();
            }

            Application.Run();
        }
    }
}
