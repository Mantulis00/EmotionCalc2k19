namespace EmotionCalculator.EmotionCalculator.FormsUI.Coin_Use
{
    partial class MusicForm
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
            this.backMusicButton = new System.Windows.Forms.Button();
            this.nextMusicButton = new System.Windows.Forms.Button();
            this.playButtonMusic = new System.Windows.Forms.Button();
            this.pauseButtonMusic = new System.Windows.Forms.Button();
            this.musiclabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backMusicButton
            // 
            this.backMusicButton.Location = new System.Drawing.Point(22, 34);
            this.backMusicButton.Name = "backMusicButton";
            this.backMusicButton.Size = new System.Drawing.Size(95, 29);
            this.backMusicButton.TabIndex = 1;
            this.backMusicButton.Text = "Back";
            this.backMusicButton.UseVisualStyleBackColor = true;
            this.backMusicButton.Click += new System.EventHandler(this.BackMusicButton_Click);
            // 
            // nextMusicButton
            // 
            this.nextMusicButton.Location = new System.Drawing.Point(680, 34);
            this.nextMusicButton.Name = "nextMusicButton";
            this.nextMusicButton.Size = new System.Drawing.Size(98, 29);
            this.nextMusicButton.TabIndex = 2;
            this.nextMusicButton.Text = "Next";
            this.nextMusicButton.UseVisualStyleBackColor = true;
            this.nextMusicButton.Click += new System.EventHandler(this.NextMusicButton_Click);
            // 
            // playButtonMusic
            // 
            this.playButtonMusic.Location = new System.Drawing.Point(487, 119);
            this.playButtonMusic.Name = "playButtonMusic";
            this.playButtonMusic.Size = new System.Drawing.Size(181, 53);
            this.playButtonMusic.TabIndex = 4;
            this.playButtonMusic.Text = "Play";
            this.playButtonMusic.UseVisualStyleBackColor = true;
            this.playButtonMusic.Click += new System.EventHandler(this.PlayButtonMusic_Click);
            // 
            // pauseButtonMusic
            // 
            this.pauseButtonMusic.Location = new System.Drawing.Point(154, 119);
            this.pauseButtonMusic.Name = "pauseButtonMusic";
            this.pauseButtonMusic.Size = new System.Drawing.Size(181, 53);
            this.pauseButtonMusic.TabIndex = 5;
            this.pauseButtonMusic.Text = "Pause";
            this.pauseButtonMusic.UseVisualStyleBackColor = true;
            this.pauseButtonMusic.Click += new System.EventHandler(this.PauseButtonMusic_Click);
            // 
            // musiclabel
            // 
            this.musiclabel.AutoSize = true;
            this.musiclabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musiclabel.Location = new System.Drawing.Point(269, 25);
            this.musiclabel.Name = "musiclabel";
            this.musiclabel.Size = new System.Drawing.Size(0, 38);
            this.musiclabel.TabIndex = 6;
            // 
            // MusicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 202);
            this.Controls.Add(this.musiclabel);
            this.Controls.Add(this.pauseButtonMusic);
            this.Controls.Add(this.playButtonMusic);
            this.Controls.Add(this.nextMusicButton);
            this.Controls.Add(this.backMusicButton);
            this.Name = "MusicForm";
            this.Text = "Music Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backMusicButton;
        private System.Windows.Forms.Button nextMusicButton;
        private System.Windows.Forms.Button playButtonMusic;
        private System.Windows.Forms.Button pauseButtonMusic;
        private System.Windows.Forms.Label musiclabel;
    }
}