using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EmotionCalculator.EmotionCalculator.Tools.Web.ImageDownloader;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;


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
            LoadWebCam();
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
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;

        private void Button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();

        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"D:\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }
        private void LoadWebCam()
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
