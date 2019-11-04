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
        //private string mode;

        public SettingsForm(BaseForm baseForm)
        {
            this.baseForm = baseForm;
          //  this.mode = "Normal";

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

            checkCheckBoxes(settingsManager);

            settingsManager.Save();
        }

        private  void checkCheckBoxes(SettingsManager settingsManager)
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

            if (settingsManager[SettingType.Game] == SettingStatus.Enabled)
            {
                GameModeBox.Checked = true;
            }
            else
            {
                GameModeBox.Checked = false;
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

            if (GameModeBox.Checked)
            {
                settingsManager[SettingType.Game] = SettingStatus.Enabled;
            }
            else
            {
                settingsManager[SettingType.Game] = SettingStatus.Disabled;
            }


        }



        private void DrawTabs(Object sender, DrawItemEventArgs e)
        {
            int index = e.Index;

            Graphics g = e.Graphics;
            Brush textBrush = new SolidBrush(Color.Black) ;

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
