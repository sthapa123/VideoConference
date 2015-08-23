namespace VideoConference
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoScreen1 = new VideoConferenceControls.VideoScreen();
            this.buttonsPanel1 = new VideoConferenceControls.ButtonsPanel();
            this.SuspendLayout();
            // 
            // videoScreen1
            // 
            this.videoScreen1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoScreen1.Location = new System.Drawing.Point(7, 7);
            this.videoScreen1.MinimumSize = new System.Drawing.Size(400, 300);
            this.videoScreen1.Name = "videoScreen1";
            this.videoScreen1.Size = new System.Drawing.Size(400, 300);
            this.videoScreen1.TabIndex = 0;
            // 
            // buttonsPanel1
            // 
            this.buttonsPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsPanel1.Location = new System.Drawing.Point(408, 2);
            this.buttonsPanel1.MaximumSize = new System.Drawing.Size(100, 0);
            this.buttonsPanel1.MinimumSize = new System.Drawing.Size(100, 300);
            this.buttonsPanel1.Name = "buttonsPanel1";
            this.buttonsPanel1.Size = new System.Drawing.Size(100, 300);
            this.buttonsPanel1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 311);
            this.Controls.Add(this.buttonsPanel1);
            this.Controls.Add(this.videoScreen1);
            this.MinimumSize = new System.Drawing.Size(525, 350);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private VideoConferenceControls.VideoScreen videoScreen1;
        private VideoConferenceControls.ButtonsPanel buttonsPanel1;




    }
}

