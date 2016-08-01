namespace Game_version_1
{
    partial class Game1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2_score = new System.Windows.Forms.Label();
            this.lblscore = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.racket1 = new System.Windows.Forms.PictureBox();
            this.racket2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.подключитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl2_score);
            this.panel1.Controls.Add(this.lblscore);
            this.panel1.Controls.Add(this.lblEnd);
            this.panel1.Controls.Add(this.ball);
            this.panel1.Controls.Add(this.racket1);
            this.panel1.Controls.Add(this.racket2);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 359);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(429, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Player_2: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(220, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player_1: ";
            // 
            // lbl2_score
            // 
            this.lbl2_score.AutoSize = true;
            this.lbl2_score.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2_score.Location = new System.Drawing.Point(502, 4);
            this.lbl2_score.Name = "lbl2_score";
            this.lbl2_score.Size = new System.Drawing.Size(25, 29);
            this.lbl2_score.TabIndex = 5;
            this.lbl2_score.Text = "0";
            // 
            // lblscore
            // 
            this.lblscore.AutoSize = true;
            this.lblscore.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblscore.Location = new System.Drawing.Point(293, 4);
            this.lblscore.Name = "lblscore";
            this.lblscore.Size = new System.Drawing.Size(25, 29);
            this.lblscore.TabIndex = 4;
            this.lblscore.Text = "0";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblEnd.Location = new System.Drawing.Point(256, 208);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(0, 32);
            this.lblEnd.TabIndex = 3;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Blue;
            this.ball.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball.BackgroundImage")));
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ball.Image = ((System.Drawing.Image)(resources.GetObject("ball.Image")));
            this.ball.Location = new System.Drawing.Point(537, 62);
            this.ball.MaximumSize = new System.Drawing.Size(50, 50);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // racket1
            // 
            this.racket1.BackColor = System.Drawing.Color.Firebrick;
            this.racket1.Location = new System.Drawing.Point(12, 27);
            this.racket1.Name = "racket1";
            this.racket1.Size = new System.Drawing.Size(15, 74);
            this.racket1.TabIndex = 1;
            this.racket1.TabStop = false;
            // 
            // racket2
            // 
            this.racket2.BackColor = System.Drawing.Color.Orange;
            this.racket2.Location = new System.Drawing.Point(757, 27);
            this.racket2.Name = "racket2";
            this.racket2.Size = new System.Drawing.Size(15, 74);
            this.racket2.TabIndex = 0;
            this.racket2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьсяToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // подключитьсяToolStripMenuItem
            // 
            this.подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            this.подключитьсяToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.подключитьсяToolStripMenuItem.Text = "подключиться";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Game1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 359);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game1";
            this.Text = "Game1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox racket1;
        private System.Windows.Forms.PictureBox racket2;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lbl2_score;
        private System.Windows.Forms.Label lblscore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяToolStripMenuItem;
    }
}