namespace OptimusBlueMiner
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.textBoxWorker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNvidia = new System.Windows.Forms.CheckBox();
            this.chkAMD = new System.Windows.Forms.CheckBox();
            this.chkCPU = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonStartMining = new System.Windows.Forms.Button();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.comboBoxCoin = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.minerRefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(408, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.tableLayoutPanel1.SetRowSpan(this.webBrowser1, 4);
            this.webBrowser1.Size = new System.Drawing.Size(604, 502);
            this.webBrowser1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.90148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.09852F));
            this.tableLayoutPanel1.Controls.Add(this.webBrowser1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHelpText, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.92233F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.09709F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.88189F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.448819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1015, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.textBoxWorker);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkNvidia);
            this.panel1.Controls.Add(this.chkAMD);
            this.panel1.Controls.Add(this.chkCPU);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.buttonStartMining);
            this.panel1.Controls.Add(this.textBoxAddress);
            this.panel1.Controls.Add(this.comboBoxCoin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 146);
            this.panel1.TabIndex = 3;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.buttonSettings.ForeColor = System.Drawing.Color.Black;
            this.buttonSettings.Location = new System.Drawing.Point(273, 118);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(123, 25);
            this.buttonSettings.TabIndex = 12;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // textBoxWorker
            // 
            this.textBoxWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBoxWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.textBoxWorker.Location = new System.Drawing.Point(60, 72);
            this.textBoxWorker.Name = "textBoxWorker";
            this.textBoxWorker.Size = new System.Drawing.Size(152, 21);
            this.textBoxWorker.TabIndex = 11;
            this.textBoxWorker.Text = "CN-GUI-Miner";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Worker";
            // 
            // chkNvidia
            // 
            this.chkNvidia.AutoSize = true;
            this.chkNvidia.Checked = true;
            this.chkNvidia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNvidia.Location = new System.Drawing.Point(167, 106);
            this.chkNvidia.Name = "chkNvidia";
            this.chkNvidia.Size = new System.Drawing.Size(57, 17);
            this.chkNvidia.TabIndex = 8;
            this.chkNvidia.Text = "NVidia";
            this.chkNvidia.UseVisualStyleBackColor = true;
            // 
            // chkAMD
            // 
            this.chkAMD.AutoSize = true;
            this.chkAMD.Checked = true;
            this.chkAMD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAMD.Location = new System.Drawing.Point(113, 106);
            this.chkAMD.Name = "chkAMD";
            this.chkAMD.Size = new System.Drawing.Size(50, 17);
            this.chkAMD.TabIndex = 7;
            this.chkAMD.Text = "AMD";
            this.chkAMD.UseVisualStyleBackColor = true;
            // 
            // chkCPU
            // 
            this.chkCPU.AutoSize = true;
            this.chkCPU.Checked = true;
            this.chkCPU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCPU.Location = new System.Drawing.Point(59, 106);
            this.chkCPU.Name = "chkCPU";
            this.chkCPU.Size = new System.Drawing.Size(48, 17);
            this.chkCPU.TabIndex = 6;
            this.chkCPU.Text = "CPU";
            this.chkCPU.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Coin/Pool";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(59, 132);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Auto refresh miner stats";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonStartMining
            // 
            this.buttonStartMining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.buttonStartMining.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.buttonStartMining.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartMining.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonStartMining.ForeColor = System.Drawing.Color.Black;
            this.buttonStartMining.Location = new System.Drawing.Point(273, 70);
            this.buttonStartMining.Name = "buttonStartMining";
            this.buttonStartMining.Size = new System.Drawing.Size(123, 42);
            this.buttonStartMining.TabIndex = 2;
            this.buttonStartMining.Text = "Start Mining";
            this.buttonStartMining.UseVisualStyleBackColor = false;
            this.buttonStartMining.Click += new System.EventHandler(this.buttonStartMining_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBoxAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.textBoxAddress.Location = new System.Drawing.Point(60, 41);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(336, 21);
            this.textBoxAddress.TabIndex = 1;
            // 
            // comboBoxCoin
            // 
            this.comboBoxCoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboBoxCoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.comboBoxCoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.comboBoxCoin.FormattingEnabled = true;
            this.comboBoxCoin.Location = new System.Drawing.Point(60, 9);
            this.comboBoxCoin.Name = "comboBoxCoin";
            this.comboBoxCoin.Size = new System.Drawing.Size(336, 23);
            this.comboBoxCoin.TabIndex = 0;
            this.comboBoxCoin.SelectedIndexChanged += new System.EventHandler(this.comboBoxCoin_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.textBox1.Location = new System.Drawing.Point(3, 235);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(399, 221);
            this.textBox1.TabIndex = 4;
            // 
            // lblHelpText
            // 
            this.lblHelpText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelpText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.lblHelpText.Location = new System.Drawing.Point(4, 468);
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Size = new System.Drawing.Size(396, 31);
            this.lblHelpText.TabIndex = 5;
            this.lblHelpText.Text = "Help text";
            // 
            // minerRefreshTimer
            // 
            this.minerRefreshTimer.Interval = 10000;
            this.minerRefreshTimer.Tick += new System.EventHandler(this.minerRefreshTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CN GUI Miner V2.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonStartMining;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.ComboBox comboBoxCoin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer minerRefreshTimer;
        private System.Windows.Forms.Label lblHelpText;
        private System.Windows.Forms.CheckBox chkCPU;
        private System.Windows.Forms.CheckBox chkNvidia;
        private System.Windows.Forms.CheckBox chkAMD;
        private System.Windows.Forms.TextBox textBoxWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSettings;
    }
}

