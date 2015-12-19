namespace VideoConferenceForms
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.contentTab = new System.Windows.Forms.TabPage();
            this.groupBoxPlay = new System.Windows.Forms.GroupBox();
            this.btnStopPlay = new System.Windows.Forms.Button();
            this.btnStartPlay = new System.Windows.Forms.Button();
            this.groupBoxRecord = new System.Windows.Forms.GroupBox();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.btnStartRecord = new System.Windows.Forms.Button();
            this.connectTab = new System.Windows.Forms.TabPage();
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnStopClient = new System.Windows.Forms.Button();
            this.btnStartClient = new System.Windows.Forms.Button();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.sendingTab = new System.Windows.Forms.TabPage();
            this.groupBoxSending = new System.Windows.Forms.GroupBox();
            this.btnStopSend = new System.Windows.Forms.Button();
            this.btnStartSend = new System.Windows.Forms.Button();
            this.videoScreen1 = new VideoConferenceControls.VideoScreen();
            this.tabControl.SuspendLayout();
            this.contentTab.SuspendLayout();
            this.groupBoxPlay.SuspendLayout();
            this.groupBoxRecord.SuspendLayout();
            this.connectTab.SuspendLayout();
            this.groupBoxClient.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.sendingTab.SuspendLayout();
            this.groupBoxSending.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.contentTab);
            this.tabControl.Controls.Add(this.connectTab);
            this.tabControl.Controls.Add(this.sendingTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(307, 475);
            this.tabControl.TabIndex = 11;
            // 
            // contentTab
            // 
            this.contentTab.Controls.Add(this.groupBoxPlay);
            this.contentTab.Controls.Add(this.groupBoxRecord);
            this.contentTab.Location = new System.Drawing.Point(4, 22);
            this.contentTab.Name = "contentTab";
            this.contentTab.Padding = new System.Windows.Forms.Padding(3);
            this.contentTab.Size = new System.Drawing.Size(299, 449);
            this.contentTab.TabIndex = 0;
            this.contentTab.Text = "Контент";
            this.contentTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxPlay
            // 
            this.groupBoxPlay.Controls.Add(this.btnStopPlay);
            this.groupBoxPlay.Controls.Add(this.btnStartPlay);
            this.groupBoxPlay.Location = new System.Drawing.Point(9, 223);
            this.groupBoxPlay.Name = "groupBoxPlay";
            this.groupBoxPlay.Size = new System.Drawing.Size(284, 218);
            this.groupBoxPlay.TabIndex = 14;
            this.groupBoxPlay.TabStop = false;
            this.groupBoxPlay.Text = "Воспроизведение контента";
            // 
            // btnStopPlay
            // 
            this.btnStopPlay.Location = new System.Drawing.Point(6, 85);
            this.btnStopPlay.Name = "btnStopPlay";
            this.btnStopPlay.Size = new System.Drawing.Size(272, 60);
            this.btnStopPlay.TabIndex = 14;
            this.btnStopPlay.Text = "Остановить воспроизведение информации";
            this.btnStopPlay.UseVisualStyleBackColor = true;
            this.btnStopPlay.Click += new System.EventHandler(this.btnStopPlay_Click);
            // 
            // btnStartPlay
            // 
            this.btnStartPlay.Location = new System.Drawing.Point(6, 19);
            this.btnStartPlay.Name = "btnStartPlay";
            this.btnStartPlay.Size = new System.Drawing.Size(272, 60);
            this.btnStartPlay.TabIndex = 13;
            this.btnStartPlay.Text = "Начать воспроизведение информации";
            this.btnStartPlay.UseVisualStyleBackColor = true;
            this.btnStartPlay.Click += new System.EventHandler(this.btnStartPlay_Click);
            // 
            // groupBoxRecord
            // 
            this.groupBoxRecord.Controls.Add(this.btnStopRecord);
            this.groupBoxRecord.Controls.Add(this.btnStartRecord);
            this.groupBoxRecord.Location = new System.Drawing.Point(9, 7);
            this.groupBoxRecord.Name = "groupBoxRecord";
            this.groupBoxRecord.Size = new System.Drawing.Size(284, 209);
            this.groupBoxRecord.TabIndex = 13;
            this.groupBoxRecord.TabStop = false;
            this.groupBoxRecord.Text = "Запись контента";
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Location = new System.Drawing.Point(6, 85);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(272, 60);
            this.btnStopRecord.TabIndex = 12;
            this.btnStopRecord.Text = "Остановить запись информации";
            this.btnStopRecord.UseVisualStyleBackColor = true;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // btnStartRecord
            // 
            this.btnStartRecord.Location = new System.Drawing.Point(6, 19);
            this.btnStartRecord.Name = "btnStartRecord";
            this.btnStartRecord.Size = new System.Drawing.Size(272, 60);
            this.btnStartRecord.TabIndex = 11;
            this.btnStartRecord.Text = "Начать запись информации";
            this.btnStartRecord.UseVisualStyleBackColor = true;
            this.btnStartRecord.Click += new System.EventHandler(this.btnStartRecord_Click);
            // 
            // connectTab
            // 
            this.connectTab.Controls.Add(this.groupBoxClient);
            this.connectTab.Controls.Add(this.groupBoxServer);
            this.connectTab.Location = new System.Drawing.Point(4, 22);
            this.connectTab.Name = "connectTab";
            this.connectTab.Padding = new System.Windows.Forms.Padding(3);
            this.connectTab.Size = new System.Drawing.Size(299, 449);
            this.connectTab.TabIndex = 2;
            this.connectTab.Text = "Подключение";
            this.connectTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.textBox2);
            this.groupBoxClient.Controls.Add(this.btnStopClient);
            this.groupBoxClient.Controls.Add(this.btnStartClient);
            this.groupBoxClient.Location = new System.Drawing.Point(9, 212);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(284, 229);
            this.groupBoxClient.TabIndex = 1;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "Клиентская часть";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(7, 152);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(271, 40);
            this.textBox2.TabIndex = 17;
            // 
            // btnStopClient
            // 
            this.btnStopClient.Location = new System.Drawing.Point(6, 85);
            this.btnStopClient.Name = "btnStopClient";
            this.btnStopClient.Size = new System.Drawing.Size(272, 60);
            this.btnStopClient.TabIndex = 16;
            this.btnStopClient.Text = "Разорвать подключение";
            this.btnStopClient.UseVisualStyleBackColor = true;
            this.btnStopClient.Click += new System.EventHandler(this.btnStopClient_Click);
            // 
            // btnStartClient
            // 
            this.btnStartClient.Location = new System.Drawing.Point(6, 19);
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Size = new System.Drawing.Size(272, 60);
            this.btnStartClient.TabIndex = 15;
            this.btnStartClient.Text = "Подключиться к серверу";
            this.btnStartClient.UseVisualStyleBackColor = true;
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.textBox1);
            this.groupBoxServer.Controls.Add(this.btnStopServer);
            this.groupBoxServer.Controls.Add(this.btnStartServer);
            this.groupBoxServer.Location = new System.Drawing.Point(9, 7);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(284, 199);
            this.groupBoxServer.TabIndex = 0;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Серверная часть";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(7, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 40);
            this.textBox1.TabIndex = 14;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(6, 85);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(272, 60);
            this.btnStopServer.TabIndex = 13;
            this.btnStopServer.Text = "Остановить сервер";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(6, 19);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(272, 60);
            this.btnStartServer.TabIndex = 12;
            this.btnStartServer.Text = "Запустить сервер";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // sendingTab
            // 
            this.sendingTab.Controls.Add(this.groupBoxSending);
            this.sendingTab.Location = new System.Drawing.Point(4, 22);
            this.sendingTab.Name = "sendingTab";
            this.sendingTab.Padding = new System.Windows.Forms.Padding(3);
            this.sendingTab.Size = new System.Drawing.Size(299, 449);
            this.sendingTab.TabIndex = 1;
            this.sendingTab.Text = "Передача";
            this.sendingTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxSending
            // 
            this.groupBoxSending.Controls.Add(this.btnStopSend);
            this.groupBoxSending.Controls.Add(this.btnStartSend);
            this.groupBoxSending.Location = new System.Drawing.Point(8, 6);
            this.groupBoxSending.Name = "groupBoxSending";
            this.groupBoxSending.Size = new System.Drawing.Size(284, 209);
            this.groupBoxSending.TabIndex = 14;
            this.groupBoxSending.TabStop = false;
            this.groupBoxSending.Text = "Передача контента";
            // 
            // btnStopSend
            // 
            this.btnStopSend.Location = new System.Drawing.Point(6, 85);
            this.btnStopSend.Name = "btnStopSend";
            this.btnStopSend.Size = new System.Drawing.Size(272, 60);
            this.btnStopSend.TabIndex = 12;
            this.btnStopSend.Text = "Остановить передачу информации";
            this.btnStopSend.UseVisualStyleBackColor = true;
            this.btnStopSend.Click += new System.EventHandler(this.btnStopSend_Click);
            // 
            // btnStartSend
            // 
            this.btnStartSend.Location = new System.Drawing.Point(6, 19);
            this.btnStartSend.Name = "btnStartSend";
            this.btnStartSend.Size = new System.Drawing.Size(272, 60);
            this.btnStartSend.TabIndex = 11;
            this.btnStartSend.Text = "Начать передачу информации";
            this.btnStartSend.UseVisualStyleBackColor = true;
            this.btnStartSend.Click += new System.EventHandler(this.btnStartSend_Click);
            // 
            // videoScreen1
            // 
            this.videoScreen1.Dock = System.Windows.Forms.DockStyle.Right;
            this.videoScreen1.Location = new System.Drawing.Point(313, 0);
            this.videoScreen1.Name = "videoScreen1";
            this.videoScreen1.Size = new System.Drawing.Size(600, 475);
            this.videoScreen1.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 475);
            this.Controls.Add(this.videoScreen1);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(525, 350);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.contentTab.ResumeLayout(false);
            this.groupBoxPlay.ResumeLayout(false);
            this.groupBoxRecord.ResumeLayout(false);
            this.connectTab.ResumeLayout(false);
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.sendingTab.ResumeLayout(false);
            this.groupBoxSending.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage contentTab;
        private System.Windows.Forms.TabPage sendingTab;
        private System.Windows.Forms.Button btnStartRecord;
        private System.Windows.Forms.TabPage connectTab;
        private System.Windows.Forms.GroupBox groupBoxPlay;
        private System.Windows.Forms.Button btnStopPlay;
        private System.Windows.Forms.Button btnStartPlay;
        private System.Windows.Forms.GroupBox groupBoxRecord;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnStopClient;
        private System.Windows.Forms.Button btnStartClient;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.GroupBox groupBoxSending;
        private System.Windows.Forms.Button btnStopSend;
        private System.Windows.Forms.Button btnStartSend;
        private VideoConferenceControls.VideoScreen videoScreen1;
    }
}

