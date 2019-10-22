namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.emojisEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.emojisEnabledLabel = new System.Windows.Forms.Label();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.selectedThemeLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new System.Drawing.Size(40, 100);
            this.tabControl.Location = new System.Drawing.Point(-3, -1);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(517, 205);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.emojisEnabledCheckBox);
            this.tabPage1.Controls.Add(this.emojisEnabledLabel);
            this.tabPage1.Controls.Add(this.themeComboBox);
            this.tabPage1.Controls.Add(this.selectedThemeLabel);
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visual";
            // 
            // emojisEnabledCheckBox
            // 
            this.emojisEnabledCheckBox.AutoSize = true;
            this.emojisEnabledCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.emojisEnabledCheckBox.Location = new System.Drawing.Point(118, 54);
            this.emojisEnabledCheckBox.Name = "emojisEnabledCheckBox";
            this.emojisEnabledCheckBox.Size = new System.Drawing.Size(15, 14);
            this.emojisEnabledCheckBox.TabIndex = 3;
            this.emojisEnabledCheckBox.UseVisualStyleBackColor = true;
            this.emojisEnabledCheckBox.CheckedChanged += new System.EventHandler(this.EmojisEnabledCheckBox_CheckedChanged);
            // 
            // emojisEnabledLabel
            // 
            this.emojisEnabledLabel.AutoSize = true;
            this.emojisEnabledLabel.Location = new System.Drawing.Point(6, 54);
            this.emojisEnabledLabel.Name = "emojisEnabledLabel";
            this.emojisEnabledLabel.Size = new System.Drawing.Size(81, 13);
            this.emojisEnabledLabel.TabIndex = 2;
            this.emojisEnabledLabel.Text = "Emojis enabled:";
            // 
            // themeComboBox
            // 
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Location = new System.Drawing.Point(118, 18);
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(141, 21);
            this.themeComboBox.TabIndex = 1;
            // 
            // selectedThemeLabel
            // 
            this.selectedThemeLabel.AutoSize = true;
            this.selectedThemeLabel.Location = new System.Drawing.Point(6, 21);
            this.selectedThemeLabel.Name = "selectedThemeLabel";
            this.selectedThemeLabel.Size = new System.Drawing.Size(84, 13);
            this.selectedThemeLabel.TabIndex = 0;
            this.selectedThemeLabel.Text = "Selected theme:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(409, 197);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Blank";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(409, 197);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Blank";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(104, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(409, 197);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Blank";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(425, 220);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 26);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 26);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(93, 220);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(134, 26);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset to Default";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 258);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.tabControl);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label emojisEnabledLabel;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label selectedThemeLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.CheckBox emojisEnabledCheckBox;
    }
}