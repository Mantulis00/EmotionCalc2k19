using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using EmotionCalculator.EmotionCalculator.Tools.Web;
using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class CameraForm : Form
    {
        private CameraHandle cameraHandle;

        BaseForm baseForm;

        internal CameraForm(BaseForm baseForm)
        {
            InitializeComponent();

            cameraHandle = new CameraHandle(cameraBox);

            this.baseForm = baseForm;

            EnableButtons();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraHandle.Stop();
        }


        private void EnableButtons(bool start = true, bool stop = false,
            bool submit = false, bool cancel = true)
        {
            startButton.Enabled = start;
            stopButton.Enabled = stop;
            submitButton.Enabled = submit;
            cancelButton.Enabled = cancel;
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false, false);

            cameraHandle.Start();

            EnableButtons(false, true, true, true);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false, false);

            cameraHandle.Stop();

            EnableButtons();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false, false);

            if (cameraBox.Image != null)
            {
                Image image = cameraBox.Image;
                image = ImageHandle.ProcessImage(image);

                try
                {
                    APIParseResult parseResult = await baseForm.APIManager
                        .GetAPIRequester().RequestParseResultAsync(image.ToBytes());

                    baseForm.UpdateParsedData(parseResult);
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Couldn't connect to the API.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                image.Dispose();
            }

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
