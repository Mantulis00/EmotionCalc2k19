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
            this.apiEndpointTextBox = new System.Windows.Forms.TextBox();
            this.apiEndpointLabel = new System.Windows.Forms.Label();
            this.susbcriptionKeyLabel = new System.Windows.Forms.Label();
            this.subscriptionKeyTextBox = new System.Windows.Forms.TextBox();
            this.imageUrlLabel = new System.Windows.Forms.Label();
            this.imageUrlTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.operationResultLabel = new System.Windows.Forms.Label();
            this.errorTextLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // apiEndpointTextBox
            // 
            this.apiEndpointTextBox.Location = new System.Drawing.Point(118, 28);
            this.apiEndpointTextBox.Name = "apiEndpointTextBox";
            this.apiEndpointTextBox.Size = new System.Drawing.Size(351, 20);
            this.apiEndpointTextBox.TabIndex = 0;
            // 
            // apiEndpointLabel
            // 
            this.apiEndpointLabel.AutoSize = true;
            this.apiEndpointLabel.Location = new System.Drawing.Point(44, 31);
            this.apiEndpointLabel.Name = "apiEndpointLabel";
            this.apiEndpointLabel.Size = new System.Drawing.Size(68, 13);
            this.apiEndpointLabel.TabIndex = 1;
            this.apiEndpointLabel.Text = "API endpoint";
            this.apiEndpointLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // susbcriptionKeyLabel
            // 
            this.susbcriptionKeyLabel.AutoSize = true;
            this.susbcriptionKeyLabel.Location = new System.Drawing.Point(26, 57);
            this.susbcriptionKeyLabel.Name = "susbcriptionKeyLabel";
            this.susbcriptionKeyLabel.Size = new System.Drawing.Size(86, 13);
            this.susbcriptionKeyLabel.TabIndex = 3;
            this.susbcriptionKeyLabel.Text = "Subscription Key";
            // 
            // subscriptionKeyTextBox
            // 
            this.subscriptionKeyTextBox.Location = new System.Drawing.Point(118, 54);
            this.subscriptionKeyTextBox.Name = "subscriptionKeyTextBox";
            this.subscriptionKeyTextBox.Size = new System.Drawing.Size(351, 20);
            this.subscriptionKeyTextBox.TabIndex = 2;
            // 
            // imageUrlLabel
            // 
            this.imageUrlLabel.AutoSize = true;
            this.imageUrlLabel.Location = new System.Drawing.Point(44, 83);
            this.imageUrlLabel.Name = "imageUrlLabel";
            this.imageUrlLabel.Size = new System.Drawing.Size(61, 13);
            this.imageUrlLabel.TabIndex = 5;
            this.imageUrlLabel.Text = "Image URL";
            // 
            // imageUrlTextBox
            // 
            this.imageUrlTextBox.Location = new System.Drawing.Point(118, 80);
            this.imageUrlTextBox.Name = "imageUrlTextBox";
            this.imageUrlTextBox.Size = new System.Drawing.Size(351, 20);
            this.imageUrlTextBox.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(475, 78);
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
            this.resultLabel.Location = new System.Drawing.Point(72, 124);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(40, 13);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.Text = "Result:";
            // 
            // operationResultLabel
            // 
            this.operationResultLabel.AutoSize = true;
            this.operationResultLabel.Location = new System.Drawing.Point(118, 124);
            this.operationResultLabel.Name = "operationResultLabel";
            this.operationResultLabel.Size = new System.Drawing.Size(40, 13);
            this.operationResultLabel.TabIndex = 8;
            this.operationResultLabel.Text = "< . . . >";
            // 
            // errorTextLabel
            // 
            this.errorTextLabel.AutoSize = true;
            this.errorTextLabel.Location = new System.Drawing.Point(118, 148);
            this.errorTextLabel.Name = "errorTextLabel";
            this.errorTextLabel.Size = new System.Drawing.Size(40, 13);
            this.errorTextLabel.TabIndex = 10;
            this.errorTextLabel.Text = "< . . . >";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(80, 148);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(32, 13);
            this.errorLabel.TabIndex = 9;
            this.errorLabel.Text = "Error:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(142, 242);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 41);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 454);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorTextLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.operationResultLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.imageUrlLabel);
            this.Controls.Add(this.imageUrlTextBox);
            this.Controls.Add(this.susbcriptionKeyLabel);
            this.Controls.Add(this.subscriptionKeyTextBox);
            this.Controls.Add(this.apiEndpointLabel);
            this.Controls.Add(this.apiEndpointTextBox);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox apiEndpointTextBox;
        private System.Windows.Forms.Label apiEndpointLabel;
        private System.Windows.Forms.Label susbcriptionKeyLabel;
        private System.Windows.Forms.TextBox subscriptionKeyTextBox;
        private System.Windows.Forms.Label imageUrlLabel;
        private System.Windows.Forms.TextBox imageUrlTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label operationResultLabel;
        private System.Windows.Forms.Label errorTextLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}