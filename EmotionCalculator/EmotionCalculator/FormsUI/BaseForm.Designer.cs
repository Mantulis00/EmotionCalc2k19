namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            this.urlButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageButton = new System.Windows.Forms.Button();
            this.cameraButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureAPIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.gemBackgroundPanel = new System.Windows.Forms.Panel();
            this.gemsImagePanel = new System.Windows.Forms.Panel();
            this.gemAmountLabel = new System.Windows.Forms.Label();
            this.calendarBackground = new System.Windows.Forms.PictureBox();
            this.coinsImagePanel = new System.Windows.Forms.Panel();
            this.coinBackgroundPanel = new System.Windows.Forms.Panel();
            this.coinAmountLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gemBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarBackground)).BeginInit();
            this.coinBackgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlButton
            // 
            this.urlButton.Location = new System.Drawing.Point(13, 27);
            this.urlButton.Name = "urlButton";
            this.urlButton.Size = new System.Drawing.Size(57, 55);
            this.urlButton.TabIndex = 6;
            this.urlButton.Text = "Upload from URL";
            this.urlButton.UseVisualStyleBackColor = true;
            this.urlButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageButton
            // 
            this.imageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.imageButton.Location = new System.Drawing.Point(76, 27);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(57, 55);
            this.imageButton.TabIndex = 12;
            this.imageButton.Text = "Upload from file";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // cameraButton
            // 
            this.cameraButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cameraButton.Location = new System.Drawing.Point(139, 27);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(57, 55);
            this.cameraButton.TabIndex = 13;
            this.cameraButton.Text = "Upload from webcam";
            this.cameraButton.UseVisualStyleBackColor = true;
            this.cameraButton.Click += new System.EventHandler(this.CameraStartButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureAPIKeyToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // configureAPIKeyToolStripMenuItem
            // 
            this.configureAPIKeyToolStripMenuItem.Name = "configureAPIKeyToolStripMenuItem";
            this.configureAPIKeyToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.configureAPIKeyToolStripMenuItem.Text = "Configure API key";
            this.configureAPIKeyToolStripMenuItem.Click += new System.EventHandler(this.ConfigureAPIKeyToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(139, 88);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(375, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // calendarBackground
            // 
            this.calendarBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBackground.InitialImage = null;
            this.calendarBackground.Location = new System.Drawing.Point(12, 82);
            this.calendarBackground.Name = "calendarBackground";
            this.calendarBackground.Size = new System.Drawing.Size(503, 391);
            this.calendarBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.calendarBackground.TabIndex = 20;
            this.calendarBackground.TabStop = false;
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.leftButton.Location = new System.Drawing.Point(13, 88);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(57, 20);
            this.leftButton.TabIndex = 21;
            this.leftButton.Text = "<<";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rightButton.Location = new System.Drawing.Point(76, 88);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(57, 20);
            this.rightButton.TabIndex = 22;
            this.rightButton.Text = ">>";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // gemBackgroundPanel
            // 
            this.gemBackgroundPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gemBackgroundPanel.Controls.Add(this.gemsImagePanel);
            this.gemBackgroundPanel.Controls.Add(this.gemAmountLabel);
            this.gemBackgroundPanel.Location = new System.Drawing.Point(364, 27);
            this.gemBackgroundPanel.Name = "gemBackgroundPanel";
            this.gemBackgroundPanel.Size = new System.Drawing.Size(150, 55);
            this.gemBackgroundPanel.TabIndex = 23;
            // 
            // gemsImagePanel
            // 
            this.gemsImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.gemsImagePanel.BackgroundImage = global::EmotionCalculator.Properties.Resources.joyGem;
            this.gemsImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gemsImagePanel.Location = new System.Drawing.Point(2, 2);
            this.gemsImagePanel.Name = "gemsImagePanel";
            this.gemsImagePanel.Size = new System.Drawing.Size(51, 51);
            this.gemsImagePanel.TabIndex = 1;
            // 
            // gemAmountLabel
            // 
            this.gemAmountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gemAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.gemAmountLabel.Location = new System.Drawing.Point(59, 2);
            this.gemAmountLabel.Name = "gemAmountLabel";
            this.gemAmountLabel.Size = new System.Drawing.Size(88, 53);
            this.gemAmountLabel.TabIndex = 1;
            this.gemAmountLabel.Text = "100";
            this.gemAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calendarBackground
            // 
            this.calendarBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBackground.InitialImage = null;
            this.calendarBackground.Location = new System.Drawing.Point(12, 114);
            this.calendarBackground.Name = "calendarBackground";
            this.calendarBackground.Size = new System.Drawing.Size(503, 391);
            this.calendarBackground.TabIndex = 20;
            this.calendarBackground.TabStop = false;
            // 
            // coinsImagePanel
            // 
            this.coinsImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.coinsImagePanel.BackgroundImage = global::EmotionCalculator.Properties.Resources.joyCoins;
            this.coinsImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coinsImagePanel.Location = new System.Drawing.Point(3, 2);
            this.coinsImagePanel.Name = "coinsImagePanel";
            this.coinsImagePanel.Size = new System.Drawing.Size(51, 51);
            this.coinsImagePanel.TabIndex = 0;
            // 
            // coinBackgroundPanel
            // 
            this.coinBackgroundPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.coinBackgroundPanel.Controls.Add(this.coinAmountLabel);
            this.coinBackgroundPanel.Controls.Add(this.coinsImagePanel);
            this.coinBackgroundPanel.Location = new System.Drawing.Point(208, 27);
            this.coinBackgroundPanel.Name = "coinBackgroundPanel";
            this.coinBackgroundPanel.Size = new System.Drawing.Size(150, 55);
            this.coinBackgroundPanel.TabIndex = 24;
            // 
            // coinAmountLabel
            // 
            this.coinAmountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coinAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.coinAmountLabel.Location = new System.Drawing.Point(59, 1);
            this.coinAmountLabel.Name = "coinAmountLabel";
            this.coinAmountLabel.Size = new System.Drawing.Size(88, 53);
            this.coinAmountLabel.TabIndex = 0;
            this.coinAmountLabel.Text = "10000";
            this.coinAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 518);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.coinBackgroundPanel);
            this.Controls.Add(this.gemBackgroundPanel);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.calendarBackground);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.cameraButton);
            this.Controls.Add(this.urlButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BaseForm";
            this.Text = "EmotionDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gemBackgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calendarBackground)).EndInit();
            this.coinBackgroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button urlButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.Button cameraButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureAPIKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox calendarBackground;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel gemBackgroundPanel;
        private System.Windows.Forms.Panel coinsImagePanel;
        private System.Windows.Forms.Panel coinBackgroundPanel;
        private System.Windows.Forms.Panel gemsImagePanel;
        private System.Windows.Forms.Label gemAmountLabel;
        private System.Windows.Forms.Label coinAmountLabel;
    }
}