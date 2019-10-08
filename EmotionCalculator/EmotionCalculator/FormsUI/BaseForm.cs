﻿using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using EmotionCalculator.EmotionCalculator.Tools.Web;
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
        //private CalendarUpdater calendarUpdater;

        private MonthManager monthManager;

        internal BaseForm()
        {
            InitializeComponent();
            cam = new CameraHandle(webcamPictureBox);
            handle = new ImageHandle();
            faceAPIRequester = new FaceAPIRequester(FaceAPIConfig.LoadConfig());

            monthManager = new MonthManager(new MonthEmotionsIO(),
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

        private void ExitApplication()
        {
            monthManager.Save();
            cam.Stop();
            Application.Exit();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!ConnectionChecker.IsConnectedToInternet())
            {
                return;
            }
            string url = imageUrlTextBox.Text;
            if (!Tools.Web.ImageDownloader.CheckIfValidURL(url))
            {
                MessageBox.Show("Invalid URL");
                return;    
            }
            string response = await faceAPIRequester.RequestImageDataAsync(url);

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);
            UpdateParsedData(parseResult);
        }

        private void UpdateParsedData(FaceAPIParseResult parseResult)
        {
            UpdateParsedDataUI(parseResult);

            if (parseResult.Faces.Count > 0)
            {
                monthManager.SetEmotion(parseResult.Faces.First().EmotionData.GetEmotion());
            }

            //if (parseResult.Faces.Count > 0)
            //    calendarUpdater.SubmitChange(dateTimePicker.Value.Day,
            //        parseResult.Faces.First().EmotionData.GetEmotion());
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
            if (imageUploadPictureBox.Image != null)
            {
                submitUploadedImageButton.Enabled = true;
            }
        }

        private void CameraStartButton_Click(object sender, EventArgs e)
        {
            cam.Start();
            camStartButton.Enabled = false;
            camStopButton.Enabled = true;
        }

        private void CameraStopButton_Click(object sender, EventArgs e)
        {
            cam.Stop();
            camStopButton.Enabled = false;
            camStartButton.Enabled = true;
        }

        private async void SubmitWebCamButton_Click(object sender, EventArgs e)
        {
            if (!ConnectionChecker.IsConnectedToInternet())
            {
                return;
            }
            submitWebCamButton.Enabled = false;
            Image image;
            string response;
            if (cam.cameraIsRoling)
            {
                image = webcamPictureBox.Image;
                if (image == null)
                {
                    submitWebCamButton.Enabled = true;
                    return;
                }
                image = handle.ImageProcess(image);


                response = await faceAPIRequester.RequestImageDataAsync(image);
                image.Dispose();
            }
            else
            {
                 response = " ";
            }
           

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);
            UpdateParsedData(parseResult);
            submitWebCamButton.Enabled = true;
        }

        private async void SubmitUploadedImageButton_Click(object sender, EventArgs e)
        {
            if (!ConnectionChecker.IsConnectedToInternet())
            {
                return;
            }
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
