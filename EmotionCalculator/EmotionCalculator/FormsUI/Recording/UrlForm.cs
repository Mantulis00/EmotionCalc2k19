using EmotionCalculator.EmotionCalculator.Tools.API;
using System;
using System.Net.Http;
using System.Windows.Forms;
using static EmotionCalculator.EmotionCalculator.Tools.Web.ImageTools;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class UrlForm : Form
    {
        BaseForm baseForm;
        string savedUrl;

        internal UrlForm(BaseForm baseForm)
        {
            InitializeComponent();

            this.baseForm = baseForm;
            EnableButtons();
        }

        private void EnableButtons(bool cancel = true, bool upload = true, bool submit = false)
        {
            cancelButton.Enabled = cancel;
            uploadButton.Enabled = upload;
            submitButton.Enabled = submit;
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false);

            if (imageBox.Image != null && savedUrl != null)
            {
                try
                {
                    APIParseResult parseResult = await baseForm.APIManager
                        .GetAPIRequester().RequestParseResultAsync(savedUrl);

                    baseForm.UpdateParsedData(parseResult);
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Couldn't connect to the API.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false);

            Close();
        }

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            EnableButtons(false, false, false);

            string url = urlBox.Text;

            if (Tools.Web.ImageDownloader.CheckIfValidURL(url))
            {
                savedUrl = url;
                imageBox.Image = ByteArrayToImage(
                    await Tools.Web.ImageDownloader.GetByteArrayFromUrlAsync(url));

                EnableButtons(true, true, true);
            }
            else
            {
                MessageBox.Show("Invalid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                EnableButtons();
            }
        }
    }
}
