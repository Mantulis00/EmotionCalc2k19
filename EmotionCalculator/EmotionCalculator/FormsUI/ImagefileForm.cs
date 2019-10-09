using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
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

            APIParseResult parseResult = await baseForm.APIManager.GetAPIRequester()
                .RequestParseResultAsync(uploadImageBox.Image);

            baseForm.UpdateParsedData(parseResult);

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
