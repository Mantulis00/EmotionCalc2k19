using EmotionCalculator.EmotionCalculator.Tools.API;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class UrlForm : Form
    {

        BaseForm baseF;

        internal UrlForm(BaseForm baseF)
        {
            InitializeComponent();

            this.baseF = baseF;
        }



        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            SubmitButton.Enabled = false;

            string url = UrlBox.Text;
            if (!Tools.Web.ImageDownloader.CheckIfValidURL(url))
            {
                MessageBox.Show("Invalid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SubmitButton.Enabled = true;
                return;
            }
            imageBox.Image = byteArrayToImage(await Tools.Web.ImageDownloader.GetByteArrayFromUrlAsync(url));

            APIParseResult parseResult = await baseF.APIManager.GetAPIRequester().RequestParseResultAsync(url);
            baseF.UpdateParsedData(parseResult);

            SubmitButton.Enabled = true;
        }

        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
    }
}
