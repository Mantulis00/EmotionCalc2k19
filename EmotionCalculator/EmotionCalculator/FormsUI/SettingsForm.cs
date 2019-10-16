using EmotionCalculator.EmotionCalculator.Logic.Settings;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    public partial class SettingsForm : Form
    {
        private BaseForm baseForm;

        public SettingsForm(BaseForm baseForm)
        {
            this.baseForm = baseForm;

            InitializeComponent();
            InitializeComboBoxes();

            tabControl.DrawItem += new DrawItemEventHandler(DrawTabs);
        }

        private void InitializeComboBoxes()
        {
            themeComboBox.Items.AddRange(DesktopPack.DesktopPacks.ToArray());

            themeComboBox.SelectedItem = baseForm.SettingsManager.SelectedTheme;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            baseForm.SettingsManager.SelectedTheme = (ThemePack)themeComboBox.SelectedItem;
        }

        private void DrawTabs(Object sender, DrawItemEventArgs e)
        {
            int index = e.Index;

            Graphics g = e.Graphics;
            Brush textBrush = new SolidBrush(Color.Black); ;

            TabPage tabPage = tabControl.TabPages[index];
            Rectangle tabBounds = tabControl.GetTabRect(index);

            Font tabFont = new Font("Microsoft Sans Serif", 11f);

            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Center;
            stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(tabPage.Text, tabFont, textBrush, tabBounds, stringFlags);
        }
    }
}
