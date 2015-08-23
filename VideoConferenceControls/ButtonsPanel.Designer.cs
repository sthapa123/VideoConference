namespace VideoConferenceControls
{
    partial class ButtonsPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChoiseDevice = new System.Windows.Forms.Button();
            this.btnResolution = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChoiseDevice
            // 
            this.btnChoiseDevice.Location = new System.Drawing.Point(4, 4);
            this.btnChoiseDevice.Name = "btnChoiseDevice";
            this.btnChoiseDevice.Size = new System.Drawing.Size(93, 40);
            this.btnChoiseDevice.TabIndex = 0;
            this.btnChoiseDevice.Text = "Выбор устройства";
            this.btnChoiseDevice.UseVisualStyleBackColor = true;
            // 
            // btnResolution
            // 
            this.btnResolution.Location = new System.Drawing.Point(4, 50);
            this.btnResolution.Name = "btnResolution";
            this.btnResolution.Size = new System.Drawing.Size(93, 40);
            this.btnResolution.TabIndex = 1;
            this.btnResolution.Text = "Разрешение";
            this.btnResolution.UseVisualStyleBackColor = true;
            this.btnResolution.Click += new System.EventHandler(this.btnResolution_Click);
            // 
            // ButtonsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResolution);
            this.Controls.Add(this.btnChoiseDevice);
            this.MaximumSize = new System.Drawing.Size(100, 0);
            this.MinimumSize = new System.Drawing.Size(100, 300);
            this.Name = "ButtonsPanel";
            this.Size = new System.Drawing.Size(100, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChoiseDevice;
        private System.Windows.Forms.Button btnResolution;
    }
}
