﻿using EmotionCalculator.EmotionCalculator.Logic;
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


        private void UrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            baseF.showButtons(true, true, true);
        }

    }
}
