using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class CameraForm : Form
    {
        private CameraHandle cameraHandle;
        private ImageHandle imageHandle;

        BaseForm baseF;

        internal CameraForm(BaseForm baseF)
        {
            InitializeComponent();

            cameraHandle = new CameraHandle(CameraBox);
            imageHandle = new ImageHandle();

            this.baseF = baseF;

            showButtons();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraHandle.Stop();
        }


        private void showButtons(bool start = true, bool stop = false, bool submit = false)
        {
            startButton.Enabled = start;
            stopButton.Enabled = stop;
            submitButton.Enabled = submit;
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            cameraHandle.Start();
            showButtons(false, true, true);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            cameraHandle.Stop();
            showButtons();

        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            showButtons(false, false, false);

            Image image = null;


            image = CameraBox.Image;
            image = imageHandle.imageProcess(image);

            APIParseResult parseResult = await baseF.APIManager.GetAPIRequester().RequestParseResultAsync(image);

            image.Dispose();

            baseF.UpdateParsedData(parseResult);


            showButtons(true, true, true);
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

        }
    }
}
