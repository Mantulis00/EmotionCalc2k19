using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class ImagefileForm : Form
    {

        private ImageHandle imageHandle;

        private IAPIManager apiManager;
        private MonthManager monthManager;

        internal ImagefileForm(IAPIManager apiManager, MonthManager monthManager)
        {
            InitializeComponent();

            imageHandle = new ImageHandle();

            this.apiManager = apiManager;

            this.monthManager = monthManager;

            showButtons();
        }

        private void CameraBox_Click(object sender, EventArgs e)
        {

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

            APIParseResult parseResult = await apiManager.GetAPIRequester()
                .RequestParseResultAsync(uploadImageBox.Image);

            BaseForm.UpdateParsedData(parseResult, monthManager);

            showButtons(true, true);
        }


        private void ImagefileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
