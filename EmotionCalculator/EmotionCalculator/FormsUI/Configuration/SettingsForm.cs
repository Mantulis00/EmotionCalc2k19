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
            InitializeSettings();

            tabControl.DrawItem += new DrawItemEventHandler(DrawTabs);
        }

        private void InitializeSettings()
        {
            themeComboBox.Items.AddRange(DesktopPack.DesktopPacks.ToArray());

            themeComboBox.SelectedIndex = themeComboBox
                .FindStringExact(baseForm.SettingsManager.SelectedTheme.ToString());

            SettingsManager settingsManager = baseForm.SettingsManager;

            if (settingsManager[SettingType.Emoji] == SettingStatus.Enabled)
            {
                emojisEnabledCheckBox.Checked = true;
            }
            else if (settingsManager[SettingType.Emoji] == SettingStatus.Disabled)
            {
                emojisEnabledCheckBox.Checked = false;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            themeComboBox.SelectedIndex = themeComboBox
                .FindStringExact(DesktopPack.DesktopPacks.ToList().First().ToString());

            emojisEnabledCheckBox.Checked = false;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SettingsManager settingsManager = baseForm.SettingsManager;

            settingsManager.SelectedTheme = (ThemePack)themeComboBox.SelectedItem;

            settingsManager[SettingType.Emoji] = emojisEnabledCheckBox.Checked
                ? SettingStatus.Enabled : SettingStatus.Disabled;

            settingsManager.Save();
            Close();
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
