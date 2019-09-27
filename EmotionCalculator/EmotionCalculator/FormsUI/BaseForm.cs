using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {

        /// <summary>
        /// Bugless patch is Bestest patch
        /// </summary>


        public BaseForm()
        {
            InitializeComponent();
            cam = new CamHandle(webcamPictureBox);
            handler = new Tools.FileHandler.ImageHan();

            img = null;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cam.Stop();
        }


        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        Image img;

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            FaceAPIKey faceApiKey = new FaceAPIKey(subscriptionKeyTextBox.Text , "https://" + apiEndpointTextBox.Text + ".cognitiveservices.azure.com/face/v1.0");

            FaceAPIRequester faceAPIRequester = new FaceAPIRequester(faceApiKey);

            string url = imageUrlTextBox.Text;

            ///

            string response;

          

            if (url.Length >= 5)
            {
                 response = Task.Run(async () => await faceAPIRequester.RequestImageDataAsync(url)).Result;
            }
            else if (cam.cameraIsRoling && webcamPictureBox.Image != null)
            {
                img = webcamPictureBox.Image;
                img = handler.imageProcess(img);

                response = Task.Run(async () => await faceAPIRequester.RequestImageDataAsync(img)).Result;

                img.Dispose();

            }
            else if (imageUploadPictureBox.Image != null)
            {
                
                response = Task.Run(async () => await faceAPIRequester.RequestImageDataAsync(imageUploadPictureBox.Image)).Result;
            }
            else
            {
                 response = "";
            }


            // 


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

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        Tools.FileHandler.ImageHan handler;
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            ///
            handler.GetPicture(imageUploadPictureBox);
            ///
        }

        /// 

        private CamHandle cam;

        private void CamButton_Click(object sender, EventArgs e)
        {
            cam.Start();
        }

        private void CamButton2_Click(object sender, EventArgs e)
        {
            cam.Stop();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void WebcamPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ImageUploadPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void SubmitWebCamButton_Click(object sender, EventArgs e)
        {

        }

        private void ApiEndpointTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        ///


    }
}
