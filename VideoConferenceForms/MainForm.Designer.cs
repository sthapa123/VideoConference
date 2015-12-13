using VideoConferenceControls;

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
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.peersColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new AForge.Controls.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(796, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.peersColumn});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.Location = new System.Drawing.Point(633, 23);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(163, 373);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // peersColumn
            // 
            this.peersColumn.Text = "Peers";
            this.peersColumn.Width = 159;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 53);
            this.button2.TabIndex = 4;
            this.button2.Text = "Начать запись";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 53);
            this.button3.TabIndex = 5;
            this.button3.Text = "Начать передачу";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 53);
            this.button4.TabIndex = 6;
            this.button4.Text = "Остановить запись и передачу";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Image = null;
            this.pictureBox1.Location = new System.Drawing.Point(138, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(489, 354);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 268);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 53);
            this.button5.TabIndex = 8;
            this.button5.Text = "Запустить сервер";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(13, 327);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(119, 53);
            this.button6.TabIndex = 9;
            this.button6.Text = "Подключиться к серверу";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "192.168.0.103";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 396);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(525, 350);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader peersColumn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private AForge.Controls.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;





    }
}

