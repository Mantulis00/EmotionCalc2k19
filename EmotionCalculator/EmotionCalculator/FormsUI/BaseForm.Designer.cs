﻿namespace EmotionCalculator.EmotionCalculator.FormsUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.imageUrlLabel = new System.Windows.Forms.Label();
            this.imageUrlTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.webcamPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.camStartButton = new System.Windows.Forms.Button();
            this.camStopButton = new System.Windows.Forms.Button();
            this.imageUploadPictureBox = new System.Windows.Forms.PictureBox();
            this.submitWebCamButton = new System.Windows.Forms.Button();
            this.submitUploadedImageButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureAPIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.calendarBackground = new System.Windows.Forms.PictureBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploadPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // imageUrlLabel
            // 
            this.imageUrlLabel.AutoSize = true;
            this.imageUrlLabel.Location = new System.Drawing.Point(9, 36);
            this.imageUrlLabel.Name = "imageUrlLabel";
            this.imageUrlLabel.Size = new System.Drawing.Size(61, 13);
            this.imageUrlLabel.TabIndex = 5;
            this.imageUrlLabel.Text = "Image URL";
            // 
            // imageUrlTextBox
            // 
            this.imageUrlTextBox.Location = new System.Drawing.Point(76, 33);
            this.imageUrlTextBox.Name = "imageUrlTextBox";
            this.imageUrlTextBox.Size = new System.Drawing.Size(291, 20);
            this.imageUrlTextBox.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(373, 31);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(95, 23);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // webcamPictureBox
            // 
            this.webcamPictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.webcamPictureBox.Location = new System.Drawing.Point(474, 269);
            this.webcamPictureBox.Name = "webcamPictureBox";
            this.webcamPictureBox.Size = new System.Drawing.Size(241, 159);
            this.webcamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webcamPictureBox.TabIndex = 11;
            this.webcamPictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.buttonUpload.Location = new System.Drawing.Point(474, 202);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(112, 61);
            this.buttonUpload.TabIndex = 12;
            this.buttonUpload.Text = "Add Image";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // camStartButton
            // 
            this.camStartButton.Font = new System.Drawing.Font("Lucida Bright", 9F);
            this.camStartButton.Location = new System.Drawing.Point(474, 434);
            this.camStartButton.Name = "camStartButton";
            this.camStartButton.Size = new System.Drawing.Size(71, 61);
            this.camStartButton.TabIndex = 13;
            this.camStartButton.Text = "Start WebCam";
            this.camStartButton.UseVisualStyleBackColor = true;
            this.camStartButton.Click += new System.EventHandler(this.CameraStartButton_Click);
            // 
            // camStopButton
            // 
            this.camStopButton.Enabled = false;
            this.camStopButton.Font = new System.Drawing.Font("Lucida Bright", 9F);
            this.camStopButton.Location = new System.Drawing.Point(551, 434);
            this.camStopButton.Name = "camStopButton";
            this.camStopButton.Size = new System.Drawing.Size(79, 61);
            this.camStopButton.TabIndex = 14;
            this.camStopButton.Text = "Stop WebCam";
            this.camStopButton.UseVisualStyleBackColor = true;
            this.camStopButton.Click += new System.EventHandler(this.CameraStopButton_Click);
            // 
            // imageUploadPictureBox
            // 
            this.imageUploadPictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.imageUploadPictureBox.Location = new System.Drawing.Point(474, 31);
            this.imageUploadPictureBox.Name = "imageUploadPictureBox";
            this.imageUploadPictureBox.Size = new System.Drawing.Size(241, 165);
            this.imageUploadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageUploadPictureBox.TabIndex = 15;
            this.imageUploadPictureBox.TabStop = false;
            // 
            // submitWebCamButton
            // 
            this.submitWebCamButton.Enabled = false;
            this.submitWebCamButton.Font = new System.Drawing.Font("Lucida Bright", 9F);
            this.submitWebCamButton.Location = new System.Drawing.Point(636, 434);
            this.submitWebCamButton.Name = "submitWebCamButton";
            this.submitWebCamButton.Size = new System.Drawing.Size(75, 61);
            this.submitWebCamButton.TabIndex = 16;
            this.submitWebCamButton.Text = "Submit";
            this.submitWebCamButton.UseVisualStyleBackColor = true;
            this.submitWebCamButton.Click += new System.EventHandler(this.SubmitWebCamButton_Click);
            // 
            // submitUploadedImageButton
            // 
            this.submitUploadedImageButton.Enabled = false;
            this.submitUploadedImageButton.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.submitUploadedImageButton.Location = new System.Drawing.Point(592, 202);
            this.submitUploadedImageButton.Name = "submitUploadedImageButton";
            this.submitUploadedImageButton.Size = new System.Drawing.Size(123, 61);
            this.submitUploadedImageButton.TabIndex = 17;
            this.submitUploadedImageButton.Text = "Submit";
            this.submitUploadedImageButton.UseVisualStyleBackColor = true;
            this.submitUploadedImageButton.Click += new System.EventHandler(this.SubmitUploadedImageButton_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
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
            this.configureAPIKeyToolStripMenuItem});
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
            this.dateTimePicker.Location = new System.Drawing.Point(139, 150);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(329, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // calendarBackground
            // 
            this.calendarBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.calendarBackground.Image = ((System.Drawing.Image)(resources.GetObject("calendarBackground.Image")));
            this.calendarBackground.InitialImage = null;
            this.calendarBackground.Location = new System.Drawing.Point(12, 176);
            this.calendarBackground.Name = "calendarBackground";
            this.calendarBackground.Size = new System.Drawing.Size(456, 319);
            this.calendarBackground.TabIndex = 20;
            this.calendarBackground.TabStop = false;
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.leftButton.Location = new System.Drawing.Point(13, 150);
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
            this.rightButton.Location = new System.Drawing.Point(76, 150);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(57, 20);
            this.rightButton.TabIndex = 22;
            this.rightButton.Text = ">>";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 507);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.calendarBackground);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.submitUploadedImageButton);
            this.Controls.Add(this.submitWebCamButton);
            this.Controls.Add(this.imageUploadPictureBox);
            this.Controls.Add(this.camStopButton);
            this.Controls.Add(this.camStartButton);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.webcamPictureBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.imageUrlLabel);
            this.Controls.Add(this.imageUrlTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BaseForm";
            this.Text = "EmotionDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploadPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label imageUrlLabel;
        private System.Windows.Forms.TextBox imageUrlTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.PictureBox webcamPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button camStartButton;
        private System.Windows.Forms.Button camStopButton;
        private System.Windows.Forms.PictureBox imageUploadPictureBox;
        private System.Windows.Forms.Button submitWebCamButton;
        private System.Windows.Forms.Button submitUploadedImageButton;
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
    }
}