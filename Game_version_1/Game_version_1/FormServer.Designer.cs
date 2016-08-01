namespace Game_version_1
{
    partial class FormServer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbServ = new System.Windows.Forms.RichTextBox();
            this.btnStartServ = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbServ);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Players";
            // 
            // rtbServ
            // 
            this.rtbServ.Location = new System.Drawing.Point(6, 19);
            this.rtbServ.Name = "rtbServ";
            this.rtbServ.Size = new System.Drawing.Size(418, 199);
            this.rtbServ.TabIndex = 0;
            this.rtbServ.Text = "";
            // 
            // btnStartServ
            // 
            this.btnStartServ.Location = new System.Drawing.Point(134, 256);
            this.btnStartServ.Name = "btnStartServ";
            this.btnStartServ.Size = new System.Drawing.Size(204, 23);
            this.btnStartServ.TabIndex = 1;
            this.btnStartServ.Text = "Start";
            this.btnStartServ.UseVisualStyleBackColor = true;
            this.btnStartServ.Click += new System.EventHandler(this.btnStartServ_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 295);
            this.Controls.Add(this.btnStartServ);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormServer";
            this.Text = "FormServer";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbServ;
        private System.Windows.Forms.Button btnStartServ;
    }
}