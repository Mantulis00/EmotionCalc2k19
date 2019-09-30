using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {
        private CameraHandle cam;
        private ImageHandle handle;
        private FaceAPIRequester faceAPIRequester;
        private CalendarGenerator calendarGenerator;

        internal BaseForm()
        {
            InitializeComponent();
            cam = new CameraHandle(webcamPictureBox);
            handle = new ImageHandle();
            faceAPIRequester = new FaceAPIRequester(FaceAPIConfig.LoadConfig());

            calendarGenerator = new CalendarGenerator(dateTimePicker, calendarBackground);
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
            UpdateUIAfterParsing(parseResult);
        }

        private void UpdateUIAfterParsing(FaceAPIParseResult parseResult)
        {
            if (parseResult.Faces.Count > 0)
            {
                operationResultLabel.Text = Logic.EmotionJudge.GetEmotion(parseResult.Faces[0].EmotionData).ToString();
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
            UpdateUIAfterParsing(parseResult);
        }

        private async void SubmitUploadedImageButton_Click(object sender, EventArgs e)
        {
            string response = await faceAPIRequester.RequestImageDataAsync(imageUploadPictureBox.Image);

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);
            UpdateUIAfterParsing(parseResult);
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
    }
}
