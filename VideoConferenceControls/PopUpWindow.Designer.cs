namespace VideoConferenceControls
{
    partial class PopUpWindow
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
            this.panelChoiseObject1 = new VideoConferenceControls.PanelChoiseObject();
            this.SuspendLayout();
            // 
            // panelChoiseObject1
            // 
            this.panelChoiseObject1.Location = new System.Drawing.Point(0, 0);
            this.panelChoiseObject1.MinimumSize = new System.Drawing.Size(150, 12);
            this.panelChoiseObject1.Name = "panelChoiseObject1";
            this.panelChoiseObject1.Size = new System.Drawing.Size(150, 80);
            this.panelChoiseObject1.TabIndex = 0;
            // 
            // PopUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 81);
            this.Controls.Add(this.panelChoiseObject1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopUpWindow";
            this.Text = "PopUpWindow";
            this.Leave += new System.EventHandler(this.PopUpWindow_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelChoiseObject panelChoiseObject1;

    }
}