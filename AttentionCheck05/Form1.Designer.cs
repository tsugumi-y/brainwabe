namespace AttentionCheck05
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnHeadsetConnect = new System.Windows.Forms.Button();
            this.btnHeadsetDisconnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnJudgment = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.debag = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAttention = new System.Windows.Forms.Label();
            this.lblMeditation = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.serialArduino = new System.IO.Ports.SerialPort(this.components);
            this.lblAlpha2 = new System.Windows.Forms.Label();
            this.lblBeta1 = new System.Windows.Forms.Label();
            this.lblBeta2 = new System.Windows.Forms.Label();
            this.lblGamma1 = new System.Windows.Forms.Label();
            this.lblGamma2 = new System.Windows.Forms.Label();
            this.lblDelta = new System.Windows.Forms.Label();
            this.lblTheta = new System.Windows.Forms.Label();
            this.lblAlpha1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHeadsetConnect
            // 
            this.btnHeadsetConnect.Location = new System.Drawing.Point(12, 12);
            this.btnHeadsetConnect.Name = "btnHeadsetConnect";
            this.btnHeadsetConnect.Size = new System.Drawing.Size(90, 29);
            this.btnHeadsetConnect.TabIndex = 0;
            this.btnHeadsetConnect.Text = "connect";
            this.btnHeadsetConnect.UseVisualStyleBackColor = true;
            this.btnHeadsetConnect.Click += new System.EventHandler(this.btnHeadsetConnect_Click);
            // 
            // btnHeadsetDisconnect
            // 
            this.btnHeadsetDisconnect.Location = new System.Drawing.Point(108, 12);
            this.btnHeadsetDisconnect.Name = "btnHeadsetDisconnect";
            this.btnHeadsetDisconnect.Size = new System.Drawing.Size(90, 29);
            this.btnHeadsetDisconnect.TabIndex = 1;
            this.btnHeadsetDisconnect.Text = "disconnect";
            this.btnHeadsetDisconnect.UseVisualStyleBackColor = true;
            this.btnHeadsetDisconnect.Click += new System.EventHandler(this.btnHeadsetDisconnect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(58, 57);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(58, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnJudgment
            // 
            this.btnJudgment.Location = new System.Drawing.Point(58, 140);
            this.btnJudgment.Name = "btnJudgment";
            this.btnJudgment.Size = new System.Drawing.Size(90, 29);
            this.btnJudgment.TabIndex = 4;
            this.btnJudgment.Text = "judgment";
            this.btnJudgment.UseVisualStyleBackColor = true;
            this.btnJudgment.Click += new System.EventHandler(this.btnJudgment_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(58, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // debag
            // 
            this.debag.Location = new System.Drawing.Point(637, 12);
            this.debag.Multiline = true;
            this.debag.Name = "debag";
            this.debag.Size = new System.Drawing.Size(128, 257);
            this.debag.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 225);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 19);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(78, 250);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 19);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(78, 275);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 19);
            this.textBox4.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.comboBox1.Location = new System.Drawing.Point(78, 300);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 20);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "raw";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "経過時間";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "カウント";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "COM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(206, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 315);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblAttention
            // 
            this.lblAttention.AutoSize = true;
            this.lblAttention.Location = new System.Drawing.Point(3, 3);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(64, 12);
            this.lblAttention.TabIndex = 16;
            this.lblAttention.Text = "Attention: 0";
            // 
            // lblMeditation
            // 
            this.lblMeditation.AutoSize = true;
            this.lblMeditation.Location = new System.Drawing.Point(3, 17);
            this.lblMeditation.Name = "lblMeditation";
            this.lblMeditation.Size = new System.Drawing.Size(70, 12);
            this.lblMeditation.TabIndex = 17;
            this.lblMeditation.Text = "Meditation: 0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(777, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "Copyleft(c) 2015 HAL東京";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lblAlpha2
            // 
            this.lblAlpha2.AutoSize = true;
            this.lblAlpha2.Location = new System.Drawing.Point(3, 49);
            this.lblAlpha2.Name = "lblAlpha2";
            this.lblAlpha2.Size = new System.Drawing.Size(52, 12);
            this.lblAlpha2.TabIndex = 21;
            this.lblAlpha2.Text = "Alpha2: 0";
            // 
            // lblBeta1
            // 
            this.lblBeta1.AutoSize = true;
            this.lblBeta1.Location = new System.Drawing.Point(3, 66);
            this.lblBeta1.Name = "lblBeta1";
            this.lblBeta1.Size = new System.Drawing.Size(47, 12);
            this.lblBeta1.TabIndex = 22;
            this.lblBeta1.Text = "Beta1: 0";
            // 
            // lblBeta2
            // 
            this.lblBeta2.AutoSize = true;
            this.lblBeta2.Location = new System.Drawing.Point(3, 80);
            this.lblBeta2.Name = "lblBeta2";
            this.lblBeta2.Size = new System.Drawing.Size(47, 12);
            this.lblBeta2.TabIndex = 23;
            this.lblBeta2.Text = "Beta2: 0";
            // 
            // lblGamma1
            // 
            this.lblGamma1.AutoSize = true;
            this.lblGamma1.Location = new System.Drawing.Point(3, 97);
            this.lblGamma1.Name = "lblGamma1";
            this.lblGamma1.Size = new System.Drawing.Size(61, 12);
            this.lblGamma1.TabIndex = 24;
            this.lblGamma1.Text = "Gamma1: 0";
            // 
            // lblGamma2
            // 
            this.lblGamma2.AutoSize = true;
            this.lblGamma2.Location = new System.Drawing.Point(3, 111);
            this.lblGamma2.Name = "lblGamma2";
            this.lblGamma2.Size = new System.Drawing.Size(61, 12);
            this.lblGamma2.TabIndex = 25;
            this.lblGamma2.Text = "Gamma2: 0";
            // 
            // lblDelta
            // 
            this.lblDelta.AutoSize = true;
            this.lblDelta.Location = new System.Drawing.Point(3, 127);
            this.lblDelta.Name = "lblDelta";
            this.lblDelta.Size = new System.Drawing.Size(44, 12);
            this.lblDelta.TabIndex = 26;
            this.lblDelta.Text = "Delta: 0";
            // 
            // lblTheta
            // 
            this.lblTheta.AutoSize = true;
            this.lblTheta.Location = new System.Drawing.Point(3, 145);
            this.lblTheta.Name = "lblTheta";
            this.lblTheta.Size = new System.Drawing.Size(46, 12);
            this.lblTheta.TabIndex = 27;
            this.lblTheta.Text = "Theta: 0";
            // 
            // lblAlpha1
            // 
            this.lblAlpha1.AutoSize = true;
            this.lblAlpha1.Location = new System.Drawing.Point(3, 33);
            this.lblAlpha1.Name = "lblAlpha1";
            this.lblAlpha1.Size = new System.Drawing.Size(52, 12);
            this.lblAlpha1.TabIndex = 28;
            this.lblAlpha1.Text = "Alpha1: 0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAttention);
            this.panel1.Controls.Add(this.lblTheta);
            this.panel1.Controls.Add(this.lblAlpha1);
            this.panel1.Controls.Add(this.lblDelta);
            this.panel1.Controls.Add(this.lblMeditation);
            this.panel1.Controls.Add(this.lblGamma2);
            this.panel1.Controls.Add(this.lblAlpha2);
            this.panel1.Controls.Add(this.lblGamma1);
            this.panel1.Controls.Add(this.lblBeta1);
            this.panel1.Controls.Add(this.lblBeta2);
            this.panel1.Location = new System.Drawing.Point(518, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 168);
            this.panel1.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 357);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.debag);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnJudgment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnHeadsetDisconnect);
            this.Controls.Add(this.btnHeadsetConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHeadsetConnect;
        private System.Windows.Forms.Button btnHeadsetDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnJudgment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox debag;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.Label lblMeditation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.IO.Ports.SerialPort serialArduino;
        private System.Windows.Forms.Label lblAlpha2;
        private System.Windows.Forms.Label lblBeta1;
        private System.Windows.Forms.Label lblBeta2;
        private System.Windows.Forms.Label lblGamma1;
        private System.Windows.Forms.Label lblGamma2;
        private System.Windows.Forms.Label lblDelta;
        private System.Windows.Forms.Label lblTheta;
        private System.Windows.Forms.Label lblAlpha1;
        private System.Windows.Forms.Panel panel1;
    }
}

