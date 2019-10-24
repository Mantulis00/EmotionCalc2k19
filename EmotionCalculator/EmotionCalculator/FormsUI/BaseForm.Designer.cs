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
            this.useCoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gemBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarBackground)).BeginInit();
            this.coinBackgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlButton
            // 
            this.urlButton.Location = new System.Drawing.Point(17, 33);
            this.urlButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.urlButton.Name = "urlButton";
            this.urlButton.Size = new System.Drawing.Size(76, 68);
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
            this.imageButton.Location = new System.Drawing.Point(101, 33);
            this.imageButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(76, 68);
            this.imageButton.TabIndex = 12;
            this.imageButton.Text = "Upload from file";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // cameraButton
            // 
            this.cameraButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cameraButton.Location = new System.Drawing.Point(185, 33);
            this.cameraButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(76, 68);
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.useCoinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureAPIKeyToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // configureAPIKeyToolStripMenuItem
            // 
            this.configureAPIKeyToolStripMenuItem.Name = "configureAPIKeyToolStripMenuItem";
            this.configureAPIKeyToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.configureAPIKeyToolStripMenuItem.Text = "Configure API key";
            this.configureAPIKeyToolStripMenuItem.Click += new System.EventHandler(this.ConfigureAPIKeyToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(185, 108);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(499, 22);
            this.dateTimePicker.TabIndex = 19;
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.leftButton.Location = new System.Drawing.Point(17, 108);
            this.leftButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(76, 25);
            this.leftButton.TabIndex = 21;
            this.leftButton.Text = "<<";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rightButton.Location = new System.Drawing.Point(101, 108);
            this.rightButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(76, 25);
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
            this.gemBackgroundPanel.Location = new System.Drawing.Point(485, 33);
            this.gemBackgroundPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gemBackgroundPanel.Name = "gemBackgroundPanel";
            this.gemBackgroundPanel.Size = new System.Drawing.Size(200, 68);
            this.gemBackgroundPanel.TabIndex = 23;
            // 
            // gemsImagePanel
            // 
            this.gemsImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.gemsImagePanel.BackgroundImage = global::EmotionCalculator.Properties.Resources.joyGem;
            this.gemsImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gemsImagePanel.Location = new System.Drawing.Point(3, 2);
            this.gemsImagePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gemsImagePanel.Name = "gemsImagePanel";
            this.gemsImagePanel.Size = new System.Drawing.Size(68, 63);
            this.gemsImagePanel.TabIndex = 1;
            // 
            // gemAmountLabel
            // 
            this.gemAmountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gemAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.gemAmountLabel.Location = new System.Drawing.Point(79, 2);
            this.gemAmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gemAmountLabel.Name = "gemAmountLabel";
            this.gemAmountLabel.Size = new System.Drawing.Size(117, 65);
            this.gemAmountLabel.TabIndex = 1;
            this.gemAmountLabel.Text = "100";
            this.gemAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calendarBackground
            // 
            this.calendarBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBackground.InitialImage = null;
            this.calendarBackground.Location = new System.Drawing.Point(16, 140);
            this.calendarBackground.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.calendarBackground.Name = "calendarBackground";
            this.calendarBackground.Size = new System.Drawing.Size(671, 481);
            this.calendarBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.calendarBackground.TabIndex = 20;
            this.calendarBackground.TabStop = false;
            this.calendarBackground.Click += new System.EventHandler(this.CalendarBackground_Click);
            // 
            // coinsImagePanel
            // 
            this.coinsImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.coinsImagePanel.BackgroundImage = global::EmotionCalculator.Properties.Resources.joyCoins;
            this.coinsImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coinsImagePanel.Location = new System.Drawing.Point(4, 2);
            this.coinsImagePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.coinsImagePanel.Name = "coinsImagePanel";
            this.coinsImagePanel.Size = new System.Drawing.Size(68, 63);
            this.coinsImagePanel.TabIndex = 0;
            // 
            // coinBackgroundPanel
            // 
            this.coinBackgroundPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.coinBackgroundPanel.Controls.Add(this.coinAmountLabel);
            this.coinBackgroundPanel.Controls.Add(this.coinsImagePanel);
            this.coinBackgroundPanel.Location = new System.Drawing.Point(277, 33);
            this.coinBackgroundPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.coinBackgroundPanel.Name = "coinBackgroundPanel";
            this.coinBackgroundPanel.Size = new System.Drawing.Size(200, 68);
            this.coinBackgroundPanel.TabIndex = 24;
            // 
            // coinAmountLabel
            // 
            this.coinAmountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coinAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.coinAmountLabel.Location = new System.Drawing.Point(79, 1);
            this.coinAmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.coinAmountLabel.Name = "coinAmountLabel";
            this.coinAmountLabel.Size = new System.Drawing.Size(117, 65);
            this.coinAmountLabel.TabIndex = 0;
            this.coinAmountLabel.Text = "10000";
            this.coinAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // useCoinToolStripMenuItem
            // 
            this.useCoinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musicToolStripMenuItem});
            this.useCoinToolStripMenuItem.Name = "useCoinToolStripMenuItem";
            this.useCoinToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.useCoinToolStripMenuItem.Text = "Use Coin";
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.musicToolStripMenuItem.Text = "Music";
            this.musicToolStripMenuItem.Click += new System.EventHandler(this.MusicToolStripMenuItem_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 638);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        internal System.Windows.Forms.DateTimePicker dateTimePicker;
        internal System.Windows.Forms.Button leftButton;
        internal System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel gemBackgroundPanel;
        private System.Windows.Forms.Panel coinsImagePanel;
        private System.Windows.Forms.Panel coinBackgroundPanel;
        private System.Windows.Forms.Panel gemsImagePanel;
        private System.Windows.Forms.Label gemAmountLabel;
        private System.Windows.Forms.Label coinAmountLabel;
        private System.Windows.Forms.ToolStripMenuItem useCoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
    }
}