using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {
        private CameraHandle cameraHandle;
        private ImageHandle imageHandle;

        private MonthManager monthManager;

        private IAPIManager apiManager;

        internal BaseForm(IAPIManager apiManager)
        {
            //UI
            InitializeComponent();
            cameraHandle = new CameraHandle(webcamPictureBox);
            imageHandle = new ImageHandle();


            //API
            this.apiManager = apiManager;


            //UI <-> API
            monthManager = new MonthManager(
                new MonthEmotionsIO(),
                new CalendarUpdater(calendarBackground), dateTimePicker.Value);

            dateTimePicker.ValueChanged +=
                (o, e) =>
                {
                    monthManager.ChangeTime(dateTimePicker.Value);
                };
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApplication();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            monthManager.Save();
            cameraHandle.Stop();

            Application.Exit();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            DisableButtons();

            string url = imageUrlTextBox.Text;
            if (!Tools.Web.ImageDownloader.CheckIfValidURL(url))
            {
                MessageBox.Show("Invalid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            APIParseResult parseResult = await apiManager.GetAPIRequester().RequestParseResultAsync(url);

            UpdateParsedData(parseResult);

            EnableButtons();
        }

        private void UpdateParsedData(APIParseResult parseResult)
        {
            DisplayErrors(parseResult);

            if (parseResult.Faces.Count > 0)
            {
                monthManager.SetEmotion(parseResult.Faces.First().EmotionData.GetEmotion());
            }
        }

        private void DisplayErrors(APIParseResult parseResult)
        {
            if (parseResult.Faces.Count == 0)
            {
                MessageBox.Show("No faces found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (parseResult.Errors.Count > 0)
            {
                foreach (var error in parseResult.Errors)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            ImageHandle handle = new ImageHandle();
            handle.GetPicture(imageUploadPictureBox);
            if (imageUploadPictureBox.Image != null)
            {
                submitUploadedImageButton.Enabled = true;
            }
        }

        private void CameraStartButton_Click(object sender, EventArgs e)
        {
            cameraHandle.Start();

            camStartButton.Enabled = false;

            submitWebCamButton.Enabled = true;
            camStopButton.Enabled = true;
        }

        private void CameraStopButton_Click(object sender, EventArgs e)
        {
            cameraHandle.Stop();

            camStopButton.Enabled = false;
            submitWebCamButton.Enabled = false;

            camStartButton.Enabled = true;
        }

        private async void SubmitWebCamButton_Click(object sender, EventArgs e)
        {
            DisableButtons();

            Image image = null;

            if (cameraHandle.cameraRunning)
            {
                image = webcamPictureBox.Image;
                image = imageHandle.imageProcess(image);

                APIParseResult parseResult = await apiManager.GetAPIRequester().RequestParseResultAsync(image);

                image.Dispose();

                UpdateParsedData(parseResult);
                submitWebCamButton.Enabled = true;
            }

            EnableButtons();
        }

        private async void SubmitUploadedImageButton_Click(object sender, EventArgs e)
        {
            DisableButtons();

            APIParseResult parseResult = await apiManager.GetAPIRequester()
                .RequestParseResultAsync(imageUploadPictureBox.Image);

            UpdateParsedData(parseResult);

            EnableButtons();
        }

        private void DisableButtons()
        {
            submitButton.Enabled = false;
            submitWebCamButton.Enabled = false;
            submitUploadedImageButton.Enabled = false;
        }

        private void EnableButtons()
        {
            submitButton.Enabled = true;

            if (cameraHandle.cameraRunning)
            {
                submitWebCamButton.Enabled = true;
            }

            if (imageUploadPictureBox.Image != null)
            {
                submitUploadedImageButton.Enabled = true;
            }
        }

        private void ConfigureAPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;

            Form apiKeyForm = apiManager.GetSettingsForm();
            apiKeyForm.Show();

            apiKeyForm.FormClosed +=
                (o, ev) =>
                {
                    Enabled = true;
                };
        }

        //Calendar navigation
        private void LeftButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }
    }
}
