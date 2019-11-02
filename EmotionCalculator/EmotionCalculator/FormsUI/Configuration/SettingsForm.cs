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
        private SettingsManager settingsManager;

        public SettingsForm(BaseForm baseForm)
        {
            this.baseForm = baseForm;
            settingsManager = baseForm.MonthManager.SettingsManager;

            InitializeComponent();
            InitializeSettings();

            tabControl.DrawItem += new DrawItemEventHandler(DrawTabs);
        }

        private void InitializeSettings()
        {
            themeComboBox.Items.AddRange(baseForm.MonthManager.CurrencyManager.OwnedPacks.ToArray());

            themeComboBox.SelectedIndex = themeComboBox
                .FindStringExact(baseForm.MonthManager.SettingsManager.SelectedTheme.ToString());

            checkCheckBoxes(settingsManager);

            settingsManager.Save();
        }

        private void checkCheckBoxes(SettingsManager settingsManager)
        {
            if (settingsManager[SettingType.Emoji] == SettingStatus.Enabled)
                emojisEnabledCheckBox.Checked = true;
            else if (settingsManager[SettingType.Emoji] == SettingStatus.Disabled)
                emojisEnabledCheckBox.Checked = false;


            if (settingsManager[SettingType.Debug] == SettingStatus.Enabled)
            {
                DebugcheckBox.Checked = true;
            }
            else
            {

                DebugcheckBox.Checked = false;
            }
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            themeComboBox.SelectedIndex = themeComboBox
                .FindStringExact(baseForm.MonthManager.CurrencyManager.OwnedPacks.First().ToString());

            emojisEnabledCheckBox.Checked = false;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SettingTabSubmitions(settingsManager);
            AdminToolsSubmitions(settingsManager);

            settingsManager.Save();
            Close();
        }

        private void SettingTabSubmitions(SettingsManager settingsManager)
        {
            settingsManager.SelectedTheme = (ThemePack)themeComboBox.SelectedItem;

            settingsManager[SettingType.Emoji] = emojisEnabledCheckBox.Checked
                ? SettingStatus.Enabled : SettingStatus.Disabled;
        }

        private void AdminToolsSubmitions(SettingsManager settingsManager)
        {
            if (DebugcheckBox.Checked)
            {
                settingsManager[SettingType.Debug] = SettingStatus.Enabled;
            }
            else
            {
                settingsManager[SettingType.Debug] = SettingStatus.Disabled;
            }
        }


        private void DrawTabs(Object sender, DrawItemEventArgs e)
        {
            int index = e.Index;

            Graphics g = e.Graphics;
            Brush textBrush = new SolidBrush(Color.Black);

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
