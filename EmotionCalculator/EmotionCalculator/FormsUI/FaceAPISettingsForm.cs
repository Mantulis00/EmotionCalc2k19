using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class FaceAPISettingsForm : Form
    {
        private FaceAPIRequester faceAPIRequester;

        internal FaceAPISettingsForm(FaceAPIRequester faceAPIRequester)
        {
            this.faceAPIRequester = faceAPIRequester;

            InitializeComponent();

            try
            {
                FaceAPIKey apiKey = FaceAPIConfig.LoadConfig();

                subscriptionKeyTextBox.Text = apiKey.SubscriptionKey;
                apiEndpointTextBox.Text = apiKey.APIEndpoint;
            }
            catch
            {
                //
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            FaceAPIKey updatedKey = new FaceAPIKey(subscriptionKeyTextBox.Text, apiEndpointTextBox.Text);

            faceAPIRequester.apiKey = updatedKey;
            FaceAPIConfig.SaveConfig(updatedKey);

            Close();
        }

        private void FaceAPISettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void ApiEndpointTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubscriptionKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
