﻿using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            FaceAPIKey faceApiKey = new FaceAPIKey(subscriptionKeyTextBox.Text, apiEndpointTextBox.Text);

            Console.WriteLine(faceApiKey.SubscriptionKey + " " + faceApiKey.APIEndpoint);

            FaceAPIRequester faceAPIRequester = new FaceAPIRequester(faceApiKey);

            string url = imageUrlTextBox.Text;

            string response = Task.Run(async () => await faceAPIRequester.RequestImageDataAsync(url)).Result;

            FaceAPIParseResult parseResult = FaceAPIParser.ParseJSON(response);

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
    }
}
