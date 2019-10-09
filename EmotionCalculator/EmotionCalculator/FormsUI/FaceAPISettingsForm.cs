using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            Regex regexmach = new Regex("cognitiveservices.azure.com/face/v1.0");
            if (regexmach.IsMatch(apiEndpointTextBox.Text))
            {
                FaceAPIKey updatedKey = new FaceAPIKey(subscriptionKeyTextBox.Text, apiEndpointTextBox.Text);

                faceAPIRequester.apiKey = updatedKey;
                FaceAPIConfig.SaveConfig(updatedKey);

                 Close();

            }
            else
            {
                MessageBox.Show("Add valid API Endpoint");
            }
            
        }
    }
}
