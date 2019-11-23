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
            BaseForm baseForm = new BaseForm(apiManager);
            baseForm.Show();

            if (!FaceAPIConfig.ConfigExists())
            {
                baseForm.Enabled = false;

                Form settingsWindow = new SettingsForm(baseForm);
                settingsWindow.BringToFront();
                settingsWindow.Show();

                settingsWindow.FormClosed += (o, ev) =>
                {
                    baseForm.Enabled = true;
                };
            }

            Application.Run(baseForm);
        }
    }
}
