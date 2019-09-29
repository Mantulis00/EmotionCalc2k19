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
            this.imageUrlLabel = new System.Windows.Forms.Label();
            this.imageUrlTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.operationResultLabel = new System.Windows.Forms.Label();
            this.errorTextLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.webcamPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.faceCountTextLabel = new System.Windows.Forms.Label();
            this.faceCountLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploadPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(38, 68);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(40, 13);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.Text = "Result:";
            // 
            // operationResultLabel
            // 
            this.operationResultLabel.AutoSize = true;
            this.operationResultLabel.Location = new System.Drawing.Point(84, 68);
            this.operationResultLabel.Name = "operationResultLabel";
            this.operationResultLabel.Size = new System.Drawing.Size(40, 13);
            this.operationResultLabel.TabIndex = 8;
            this.operationResultLabel.Text = "< . . . >";
            // 
            // errorTextLabel
            // 
            this.errorTextLabel.AutoSize = true;
            this.errorTextLabel.Location = new System.Drawing.Point(84, 92);
            this.errorTextLabel.Name = "errorTextLabel";
            this.errorTextLabel.Size = new System.Drawing.Size(40, 13);
            this.errorTextLabel.TabIndex = 10;
            this.errorTextLabel.Text = "< . . . >";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(46, 92);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(32, 13);
            this.errorLabel.TabIndex = 9;
            this.errorLabel.Text = "Error:";
            // 
            // webcamPictureBox
            // 
            this.webcamPictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.webcamPictureBox.Location = new System.Drawing.Point(474, 269);
            this.webcamPictureBox.Name = "webcamPictureBox";
            this.webcamPictureBox.Size = new System.Drawing.Size(241, 165);
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
            // faceCountTextLabel
            // 
            this.faceCountTextLabel.AutoSize = true;
            this.faceCountTextLabel.Location = new System.Drawing.Point(84, 116);
            this.faceCountTextLabel.Name = "faceCountTextLabel";
            this.faceCountTextLabel.Size = new System.Drawing.Size(40, 13);
            this.faceCountTextLabel.TabIndex = 12;
            this.faceCountTextLabel.Text = "< . . . >";
            // 
            // faceCountLabel
            // 
            this.faceCountLabel.AutoSize = true;
            this.faceCountLabel.Location = new System.Drawing.Point(10, 116);
            this.faceCountLabel.Name = "faceCountLabel";
            this.faceCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.faceCountLabel.Size = new System.Drawing.Size(69, 13);
            this.faceCountLabel.TabIndex = 11;
            this.faceCountLabel.Text = "Faces found:";
            // 
            // camStartButton
            // 
            this.camStartButton.Font = new System.Drawing.Font("Lucida Bright", 9F);
            this.camStartButton.Location = new System.Drawing.Point(474, 440);
            this.camStartButton.Name = "camStartButton";
            this.camStartButton.Size = new System.Drawing.Size(71, 61);
            this.camStartButton.TabIndex = 13;
            this.camStartButton.Text = "Start WebCam";
            this.camStartButton.UseVisualStyleBackColor = true;
            this.camStartButton.Click += new System.EventHandler(this.CameraStartButton_Click);
            // 
            // camStopButton
            // 
            this.camStopButton.Font = new System.Drawing.Font("Lucida Bright", 9F);
            this.camStopButton.Location = new System.Drawing.Point(551, 440);
            this.camStopButton.Name = "camStopButton";
            this.camStopButton.Size = new System.Drawing.Size(83, 61);
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
            this.submitWebCamButton.Font = new System.Drawing.Font("Lucida Bright", 9F);
            this.submitWebCamButton.Location = new System.Drawing.Point(640, 440);
            this.submitWebCamButton.Name = "submitWebCamButton";
            this.submitWebCamButton.Size = new System.Drawing.Size(75, 61);
            this.submitWebCamButton.TabIndex = 16;
            this.submitWebCamButton.Text = "Submit";
            this.submitWebCamButton.UseVisualStyleBackColor = true;
            this.submitWebCamButton.Click += new System.EventHandler(this.SubmitWebCamButton_Click);
            // 
            // submitUploadedImageButton
            // 
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
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 507);
            this.Controls.Add(this.submitUploadedImageButton);
            this.Controls.Add(this.submitWebCamButton);
            this.Controls.Add(this.imageUploadPictureBox);
            this.Controls.Add(this.camStopButton);
            this.Controls.Add(this.camStartButton);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.webcamPictureBox);
            this.Controls.Add(this.faceCountTextLabel);
            this.Controls.Add(this.faceCountLabel);
            this.Controls.Add(this.errorTextLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.operationResultLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.imageUrlLabel);
            this.Controls.Add(this.imageUrlTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseForm";
            this.Text = "EmotionDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploadPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label imageUrlLabel;
        private System.Windows.Forms.TextBox imageUrlTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label operationResultLabel;
        private System.Windows.Forms.Label errorTextLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.PictureBox webcamPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Label faceCountTextLabel;
        private System.Windows.Forms.Label faceCountLabel;
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
    }
}