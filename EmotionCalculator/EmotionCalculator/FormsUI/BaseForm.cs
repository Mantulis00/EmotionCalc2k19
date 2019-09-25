using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
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
            cam = new CamHan(pictureBox1);
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

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            ///
            Tools.FileHandler.ImageHan handler = new Tools.FileHandler.ImageHan();
            handler.GetPicture(pictureBox1);
            ///
        }

        /// 

        private CamHan cam;

        private void CamButton_Click(object sender, EventArgs e)
        {
            cam.Start();
        }

        private void CamButton2_Click(object sender, EventArgs e)
        {
            cam.Stop();
                
        }

        ///


    }
}
