using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class ImagefileForm : Form
    {
        private BaseForm baseForm;

        internal ImagefileForm(BaseForm baseForm)
        {
            InitializeComponent();

            this.baseForm = baseForm;

            EnableButtons();
        }

        private void EnableButtons(bool upload = true, bool submit = false, bool cancel = true)
        {
            uploadButton.Enabled = upload;
            submitButton.Enabled = submit;
            cancelButton.Enabled = cancel;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false);

            ImageHandle handle = new ImageHandle();
            handle.GetPicture(uploadImageBox);

            if (uploadImageBox.Image != null)
                EnableButtons(true, true);
            else
                EnableButtons();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false);

            try
            {
                APIParseResult parseResult = await baseForm.APIManager.GetAPIRequester()
                    .RequestParseResultAsync(uploadImageBox.Image);

                baseForm.UpdateParsedData(parseResult);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Couldn't connect to the API.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
