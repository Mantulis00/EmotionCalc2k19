using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Tools.API;
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

        private IAPIManager apiManager;
        private MonthManager monthManager;
        internal UrlForm(IAPIManager apiManager, MonthManager monthManager)
        {
            InitializeComponent();

            this.apiManager = apiManager;

            this.monthManager = monthManager;
        }

        private  void UrlBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            string url = UrlBox.Text;
            if (!Tools.Web.ImageDownloader.CheckIfValidURL(url))
            {
                MessageBox.Show("Invalid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            APIParseResult parseResult = await apiManager.GetAPIRequester().RequestParseResultAsync(url);

            BaseForm.UpdateParsedData(parseResult, monthManager);
        }
    }
}
