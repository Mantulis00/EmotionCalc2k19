using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Tools.API;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class BaseForm : Form
    {

        internal MonthManager monthManager { get; set; }

        internal IAPIManager apiManager { get; set; }

        internal BaseForm(IAPIManager apiManager)
        {
            //UI
            InitializeComponent();

            //API
            this.apiManager = apiManager;

            //UI <-> API
            setupMonth();

        }

        private void setupMonth()
        {
            monthManager = new MonthManager(
               new MonthEmotionsIO(),
               new CalendarUpdater(calendarBackground), dateTimePicker.Value);

            dateTimePicker.ValueChanged +=
                (o, e) =>
                {
                    monthManager.ChangeTime(dateTimePicker.Value);
                };
        }

        internal  void UpdateParsedData(APIParseResult parseResult)
        {
            DisplayErrors(parseResult);

            if (parseResult.Faces.Count > 0)
            {
                monthManager.SetEmotion(parseResult.Faces.First().EmotionData.GetEmotion());
            }
        }

        internal static void DisplayErrors(APIParseResult parseResult)
        {
            if (parseResult.Faces.Count == 0)
            {
                MessageBox.Show("No faces found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (parseResult.Errors.Count > 0)
            {
                foreach (var error in parseResult.Errors)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApplication();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            monthManager.Save();

            Application.Exit();
        }

        private  void SubmitButton_Click(object sender, EventArgs e)
        {
            showButtons();
            Form url =  new UrlForm(this);
            url.Show();
        }



        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            showButtons();
            Form img = new ImagefileForm(this);
            img.Show();

        }

        private void CameraStartButton_Click(object sender, EventArgs e)
        {
            showButtons();
            Form cam = new CameraForm(this);
            cam.Show();
        }


        private void ConfigureAPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;

            Form apiKeyForm = apiManager.GetSettingsForm();
            apiKeyForm.Show();

            apiKeyForm.FormClosed +=
                (o, ev) =>
                {
                    Enabled = true;
                };
        }

        //Calendar navigation
        private void LeftButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        public void showButtons(bool url = false, bool img = false, bool cam = false)
        {
            urlButton.Enabled = url;
            imageButton.Enabled = img;
            cameraButton.Enabled = cam;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
