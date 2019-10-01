using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {
        private CameraHandle cam;
        private ImageHandle handle;
        private FaceAPIRequester faceAPIRequester;
        private CalendarUpdater calendarUpdater;

        internal BaseForm()
        {
            InitializeComponent();
            cam = new CameraHandle(webcamPictureBox);
            handle = new ImageHandle();
            faceAPIRequester = new FaceAPIRequester(FaceAPIConfig.LoadConfig());

            calendarUpdater = new CalendarUpdater(dateTimePicker, calendarBackground);
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            cam.Stop();
            Application.Exit();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            string url = imageUrlTextBox.Text;

            string response = await faceAPIRequester.RequestImageDataAsync(url);

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);
            UpdateParsedData(parseResult);
        }

        private void UpdateParsedData(FaceAPIParseResult parseResult)
        {
            UpdateParsedDataUI(parseResult);

            if (parseResult.Faces.Count > 0)
                calendarUpdater.SubmitChange(dateTimePicker.Value.Day,
                    parseResult.Faces.First().EmotionData.GetEmotion());
        }

        private void UpdateParsedDataUI(FaceAPIParseResult parseResult)
        {
            if (parseResult.Faces.Count > 0)
            {
                operationResultLabel.Text = parseResult.Faces[0].EmotionData.GetEmotion().ToString();
            }
            else
            {
                operationResultLabel.Text = "< . . . >";
            }

            faceCountTextLabel.Text = parseResult.Faces.Count.ToString();

            if (parseResult.Errors.Count > 0)
            {
                errorTextLabel.Text = parseResult.Errors[0].Message;
            }
            else
            {
                errorTextLabel.Text = "< . . . >";
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            ImageHandle handle = new ImageHandle();
            handle.GetPicture(imageUploadPictureBox);
        }

        private void CameraStartButton_Click(object sender, EventArgs e)
        {
            cam.Start();
        }

        private void CameraStopButton_Click(object sender, EventArgs e)
        {
            cam.Stop();
        }

        private async void SubmitWebCamButton_Click(object sender, EventArgs e)
        {
            Image image;

            image = webcamPictureBox.Image;
            image = handle.imageProcess(image);

            string response = await faceAPIRequester.RequestImageDataAsync(image);

            image.Dispose();

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);
            UpdateParsedData(parseResult);
        }

        private async void SubmitUploadedImageButton_Click(object sender, EventArgs e)
        {
            string response = await faceAPIRequester.RequestImageDataAsync(imageUploadPictureBox.Image);

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);
            UpdateParsedData(parseResult);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ConfigureAPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;

            Form apiForm = new APISettingsForm(FaceAPIConfig.LoadConfig());
            apiForm.Show();

            apiForm.FormClosed +=
                (o, ev) =>
                {
                    Enabled = true;
                    faceAPIRequester = new FaceAPIRequester(FaceAPIConfig.LoadConfig());
                };
        }

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
