namespace Game_version_1
{
    partial class FormUnderMenu
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
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbl_nickname = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(99, 48);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(149, 20);
            this.tbPort.TabIndex = 0;
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(99, 11);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(149, 20);
            this.tbIp.TabIndex = 1;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(13, 18);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(16, 13);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "Ip";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(13, 55);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(67, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save and start";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbl_nickname
            // 
            this.lbl_nickname.AutoSize = true;
            this.lbl_nickname.Location = new System.Drawing.Point(13, 91);
            this.lbl_nickname.Name = "lbl_nickname";
            this.lbl_nickname.Size = new System.Drawing.Size(59, 13);
            this.lbl_nickname.TabIndex = 5;
            this.lbl_nickname.Text = "nick_name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 6;
            // 
            // FormUnderMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 154);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_nickname);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.tbPort);
            this.Name = "FormUnderMenu";
            this.Text = "FormUnderMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbl_nickname;
        private System.Windows.Forms.TextBox textBox1;
    }
}