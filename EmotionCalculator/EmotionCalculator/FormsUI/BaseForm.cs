using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EmotionCalculator.EmotionCalculator.Tools.Web.ImageDownloader;

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

            operationResultLabel.Text = response;
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ///
            Tools.FileHandler.ImageHan handler = new Tools.FileHandler.ImageHan();
            handler.GetPicture(pictureBox1);
            ///
        }
    }
}
