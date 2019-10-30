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
            this.panel1 = new System.Windows.Forms.Panel();
            this.surpriseEmotionCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.angryEmotionCount = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.contemptEmotionCount = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.happyEmotionCount = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.sadEmotionCount = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.fearEmotionCount = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.neutralEmotionCount = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.disgustEmotionCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gemBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarBackground)).BeginInit();
            this.coinBackgroundPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel15.SuspendLayout();
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
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
            this.dateTimePicker.Location = new System.Drawing.Point(139, 116);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(375, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.leftButton.Location = new System.Drawing.Point(13, 116);
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
            this.rightButton.Location = new System.Drawing.Point(76, 116);
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
            this.calendarBackground.Location = new System.Drawing.Point(13, 142);
            this.calendarBackground.Name = "calendarBackground";
            this.calendarBackground.Size = new System.Drawing.Size(503, 391);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.surpriseEmotionCount);
            this.panel1.Location = new System.Drawing.Point(459, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 22);
            this.panel1.TabIndex = 25;
            // 
            // surpriseEmotionCount
            // 
            this.surpriseEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.surpriseEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.surpriseEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.surpriseEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.surpriseEmotionCount.Name = "surpriseEmotionCount";
            this.surpriseEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.surpriseEmotionCount.TabIndex = 0;
            this.surpriseEmotionCount.Text = "30";
            this.surpriseEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiSurprise;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 17);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.angryEmotionCount);
            this.panel3.Location = new System.Drawing.Point(93, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(55, 22);
            this.panel3.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiAnger;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 17);
            this.panel4.TabIndex = 0;
            // 
            // angryEmotionCount
            // 
            this.angryEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.angryEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.angryEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.angryEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.angryEmotionCount.Name = "angryEmotionCount";
            this.angryEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.angryEmotionCount.TabIndex = 0;
            this.angryEmotionCount.Text = "30";
            this.angryEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.contemptEmotionCount);
            this.panel5.Location = new System.Drawing.Point(154, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(55, 22);
            this.panel5.TabIndex = 28;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiContempt;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(17, 17);
            this.panel6.TabIndex = 0;
            // 
            // contemptEmotionCount
            // 
            this.contemptEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contemptEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.contemptEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contemptEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.contemptEmotionCount.Name = "contemptEmotionCount";
            this.contemptEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.contemptEmotionCount.TabIndex = 0;
            this.contemptEmotionCount.Text = "30";
            this.contemptEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.happyEmotionCount);
            this.panel7.Location = new System.Drawing.Point(13, 88);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(74, 22);
            this.panel7.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiHappiness;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Location = new System.Drawing.Point(3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(17, 17);
            this.panel8.TabIndex = 0;
            // 
            // happyEmotionCount
            // 
            this.happyEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.happyEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.happyEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.happyEmotionCount.Location = new System.Drawing.Point(30, 0);
            this.happyEmotionCount.Name = "happyEmotionCount";
            this.happyEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.happyEmotionCount.TabIndex = 0;
            this.happyEmotionCount.Text = "30";
            this.happyEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.sadEmotionCount);
            this.panel9.Location = new System.Drawing.Point(398, 88);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(55, 22);
            this.panel9.TabIndex = 32;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiSadness;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(17, 17);
            this.panel10.TabIndex = 0;
            // 
            // sadEmotionCount
            // 
            this.sadEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sadEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.sadEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sadEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.sadEmotionCount.Name = "sadEmotionCount";
            this.sadEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.sadEmotionCount.TabIndex = 0;
            this.sadEmotionCount.Text = "30";
            this.sadEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.fearEmotionCount);
            this.panel11.Location = new System.Drawing.Point(276, 88);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(55, 22);
            this.panel11.TabIndex = 30;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiFear;
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel12.Location = new System.Drawing.Point(3, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(17, 17);
            this.panel12.TabIndex = 0;
            // 
            // fearEmotionCount
            // 
            this.fearEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fearEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.fearEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fearEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.fearEmotionCount.Name = "fearEmotionCount";
            this.fearEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.fearEmotionCount.TabIndex = 0;
            this.fearEmotionCount.Text = "30";
            this.fearEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.neutralEmotionCount);
            this.panel13.Location = new System.Drawing.Point(337, 88);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(55, 22);
            this.panel13.TabIndex = 31;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiNeutral;
            this.panel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel14.Location = new System.Drawing.Point(3, 2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(17, 17);
            this.panel14.TabIndex = 0;
            // 
            // neutralEmotionCount
            // 
            this.neutralEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.neutralEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.neutralEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.neutralEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.neutralEmotionCount.Name = "neutralEmotionCount";
            this.neutralEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.neutralEmotionCount.TabIndex = 0;
            this.neutralEmotionCount.Text = "30";
            this.neutralEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel15.Controls.Add(this.panel16);
            this.panel15.Controls.Add(this.disgustEmotionCount);
            this.panel15.Location = new System.Drawing.Point(215, 88);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(55, 22);
            this.panel15.TabIndex = 29;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Transparent;
            this.panel16.BackgroundImage = global::EmotionCalculator.Properties.Resources.emojiDisguist;
            this.panel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel16.Location = new System.Drawing.Point(3, 2);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(17, 17);
            this.panel16.TabIndex = 0;
            // 
            // disgustEmotionCount
            // 
            this.disgustEmotionCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.disgustEmotionCount.BackColor = System.Drawing.Color.Transparent;
            this.disgustEmotionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.disgustEmotionCount.Location = new System.Drawing.Point(20, 0);
            this.disgustEmotionCount.Name = "disgustEmotionCount";
            this.disgustEmotionCount.Size = new System.Drawing.Size(30, 22);
            this.disgustEmotionCount.TabIndex = 0;
            this.disgustEmotionCount.Text = "30";
            this.disgustEmotionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 545);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label surpriseEmotionCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label angryEmotionCount;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label contemptEmotionCount;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label happyEmotionCount;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label sadEmotionCount;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label fearEmotionCount;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label neutralEmotionCount;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label disgustEmotionCount;
    }
}