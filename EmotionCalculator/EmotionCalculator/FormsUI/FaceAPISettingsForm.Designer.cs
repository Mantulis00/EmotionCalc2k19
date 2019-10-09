namespace EmotionCalculator.EmotionCalculator.FormsUI
{
    partial class FaceAPISettingsForm
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
            this.apiEndpointLabel = new System.Windows.Forms.Label();
            this.subscriptionKeyLabel = new System.Windows.Forms.Label();
            this.apiEndpointTextBox = new System.Windows.Forms.TextBox();
            this.subscriptionKeyTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // apiEndpointLabel
            // 
            this.apiEndpointLabel.AutoSize = true;
            this.apiEndpointLabel.Location = new System.Drawing.Point(6, 15);
            this.apiEndpointLabel.Name = "apiEndpointLabel";
            this.apiEndpointLabel.Size = new System.Drawing.Size(98, 13);
            this.apiEndpointLabel.TabIndex = 0;
            this.apiEndpointLabel.Text = "Face API endpoint:";
            this.apiEndpointLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subscriptionKeyLabel
            // 
            this.subscriptionKeyLabel.AutoSize = true;
            this.subscriptionKeyLabel.Location = new System.Drawing.Point(16, 47);
            this.subscriptionKeyLabel.Name = "subscriptionKeyLabel";
            this.subscriptionKeyLabel.Size = new System.Drawing.Size(88, 13);
            this.subscriptionKeyLabel.TabIndex = 1;
            this.subscriptionKeyLabel.Text = "Subscription key:";
            this.subscriptionKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apiEndpointTextBox
            // 
            this.apiEndpointTextBox.Location = new System.Drawing.Point(110, 12);
            this.apiEndpointTextBox.Name = "apiEndpointTextBox";
            this.apiEndpointTextBox.Size = new System.Drawing.Size(374, 20);
            this.apiEndpointTextBox.TabIndex = 2;
            // 
            // subscriptionKeyTextBox
            // 
            this.subscriptionKeyTextBox.Location = new System.Drawing.Point(110, 44);
            this.subscriptionKeyTextBox.Name = "subscriptionKeyTextBox";
            this.subscriptionKeyTextBox.PasswordChar = '*';
            this.subscriptionKeyTextBox.Size = new System.Drawing.Size(374, 20);
            this.subscriptionKeyTextBox.TabIndex = 3;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(414, 78);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(70, 30);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(322, 78);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 30);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FaceAPISettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 120);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.subscriptionKeyTextBox);
            this.Controls.Add(this.apiEndpointTextBox);
            this.Controls.Add(this.subscriptionKeyLabel);
            this.Controls.Add(this.apiEndpointLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FaceAPISettingsForm";
            this.Text = "Configure faceapi.config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label apiEndpointLabel;
        private System.Windows.Forms.Label subscriptionKeyLabel;
        private System.Windows.Forms.TextBox apiEndpointTextBox;
        private System.Windows.Forms.TextBox subscriptionKeyTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
    }
}