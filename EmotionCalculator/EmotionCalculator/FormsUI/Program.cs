using EmotionCalculator.EmotionCalculator.Tools.API;
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

            IAPIManager apiManager = new FaceAPIManager();
            Form baseWindow = new BaseForm(apiManager);
            baseWindow.Show();

            if (!FaceAPIConfig.ConfigExists())
            {
                baseWindow.Enabled = false;

                Form settingsWindow = apiManager.GetSettingsForm();
                settingsWindow.BringToFront();
                settingsWindow.Show();

                settingsWindow.FormClosed += (o, ev) =>
                {
                    baseWindow.Enabled = true;
                };
            }

            Application.Run(baseWindow);
        }
    }
}
