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
    public partial class UrlForm : Form
    {

        BaseForm baseF;

        ImageHandle Imagehandle;
        internal UrlForm(BaseForm baseF)
        {
            InitializeComponent();

            this.baseF = baseF;
        }

        private  void UrlBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            SubmitButton.Enabled = false;

            string url = UrlBox.Text;
            if (!Tools.Web.ImageDownloader.CheckIfValidURL(url))
            {
                MessageBox.Show("Invalid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            imageBox.Image = byteArrayToImage(await Tools.Web.ImageDownloader.GetByteArrayFromUrlAsync(url));

            APIParseResult parseResult = await baseF.apiManager.GetAPIRequester().RequestParseResultAsync(url);
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


        private void ImageBox_Click(object sender, EventArgs e)
        {

        }
    }
}
