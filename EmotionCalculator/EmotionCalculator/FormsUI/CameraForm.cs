using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class CameraForm : Form
    {
        private CameraHandle cameraHandle;
        private ImageHandle imageHandle;

        private IAPIManager apiManager;
        private MonthManager monthManager;

        internal CameraForm(IAPIManager apiManager, MonthManager monthManager)
        {
            InitializeComponent();

            cameraHandle = new CameraHandle(CameraBox);
            imageHandle = new ImageHandle();

            this.apiManager = apiManager;

            this.monthManager = monthManager;

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


        private void CameraBox_Click(object sender, EventArgs e)
        {

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

                APIParseResult parseResult = await apiManager.GetAPIRequester().RequestParseResultAsync(image);

                image.Dispose();

                BaseForm.UpdateParsedData(parseResult, monthManager);
            

            showButtons(true, true, true);
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

        }
    }
}
