using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class APISettingsForm : Form
    {
        private bool calledFromMain;

        internal APISettingsForm()
        {
            InitializeComponent();

            calledFromMain = false;
        }

        internal APISettingsForm(FaceAPIKey apiKey)
        {
            InitializeComponent();

            subscriptionKeyTextBox.Text = apiKey.SubscriptionKey;
            apiEndpointTextBox.Text = apiKey.APIEndpoint;

            calledFromMain = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (!calledFromMain)
            {
                Application.Exit();
            }
            else
            {
                Close();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            FaceAPIConfig.SaveConfig(
                new FaceAPIKey(subscriptionKeyTextBox.Text, apiEndpointTextBox.Text));

            if (!calledFromMain)
            {
                Form newForm = new BaseForm();
                newForm.Show();
            }

            Close();
        }
    }
}
