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
            this.panelChoiseObject1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChoiseObject1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChoiseObject1.Location = new System.Drawing.Point(0, 0);
            this.panelChoiseObject1.MinimumSize = new System.Drawing.Size(130, 12);
            this.panelChoiseObject1.Name = "panelChoiseObject1";
            this.panelChoiseObject1.Size = new System.Drawing.Size(130, 80);
            this.panelChoiseObject1.TabIndex = 0;
            // 
            // PopUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(130, 81);
            this.ControlBox = false;
            this.Controls.Add(this.panelChoiseObject1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopUpWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PopUpWindow";
            this.Deactivate += new System.EventHandler(this.PopUpWindow_Deactivate);
            this.Load += new System.EventHandler(this.PopUpWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelChoiseObject panelChoiseObject1;

    }
}