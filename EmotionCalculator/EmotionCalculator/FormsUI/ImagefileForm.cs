using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class ImagefileForm : Form
    {


        private BaseForm baseF;

        internal ImagefileForm(BaseForm baseF)
        {
            InitializeComponent();

            this.baseF = baseF;

            showButtons();
        }


        private void showButtons(bool upload = true, bool submit = false)
        {
            uploadButton.Enabled = upload;
            submitButton.Enabled = submit;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            showButtons(false, false);

            ImageHandle handle = new ImageHandle();
            handle.GetPicture(uploadImageBox);

            if (uploadImageBox.Image != null)
                showButtons(true, true);
            else
                showButtons();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            showButtons(false, false);

            APIParseResult parseResult = await baseF.APIManager.GetAPIRequester()
                .RequestParseResultAsync(uploadImageBox.Image);

            baseF.UpdateParsedData(parseResult);

            showButtons(true, true);
        }

    }
}
