namespace Chinese_Chess
{
    partial class Form_Game_Start
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Moves = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ptb_MyAvatar = new Chinese_Chess.OvalPictureBox();
            this.ptb_EnermyAvatar = new Chinese_Chess.OvalPictureBox();
            this.lbl_Enermy_Coundown = new System.Windows.Forms.Label();
            this.lbl_My_Coundown = new System.Windows.Forms.Label();
            this.lbl_EnermyTotalTime = new System.Windows.Forms.Label();
            this.lbl_MyTotalTime = new System.Windows.Forms.Label();
            this.ptb_CheckMate_Enermy = new System.Windows.Forms.PictureBox();
            this.ptb_CheckMate_Me = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_MyAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_EnermyAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_CheckMate_Enermy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_CheckMate_Me)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(-1, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 7);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(-1, 685);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 7);
            this.label1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(8, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 555);
            this.panel1.TabIndex = 14;
            // 
            // lbl_Moves
            // 
            this.lbl_Moves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Moves.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Moves.Location = new System.Drawing.Point(-8, 70);
            this.lbl_Moves.Name = "lbl_Moves";
            this.lbl_Moves.Size = new System.Drawing.Size(180, 59);
            this.lbl_Moves.TabIndex = 15;
            this.lbl_Moves.Text = "Moves";
            this.lbl_Moves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Moves.Click += new System.EventHandler(this.lbl_Moves_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(92)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(170, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 59);
            this.label3.TabIndex = 16;
            this.label3.Text = "Setting";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ptb_MyAvatar
            // 
            this.ptb_MyAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.ptb_MyAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_MyAvatar.Image = global::Chinese_Chess.Properties.Resources.deer;
            this.ptb_MyAvatar.Location = new System.Drawing.Point(271, 695);
            this.ptb_MyAvatar.Name = "ptb_MyAvatar";
            this.ptb_MyAvatar.Padding = new System.Windows.Forms.Padding(3);
            this.ptb_MyAvatar.Size = new System.Drawing.Size(60, 60);
            this.ptb_MyAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_MyAvatar.TabIndex = 17;
            this.ptb_MyAvatar.TabStop = false;
            // 
            // ptb_EnermyAvatar
            // 
            this.ptb_EnermyAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.ptb_EnermyAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_EnermyAvatar.Image = global::Chinese_Chess.Properties.Resources.deer;
            this.ptb_EnermyAvatar.Location = new System.Drawing.Point(271, 0);
            this.ptb_EnermyAvatar.Name = "ptb_EnermyAvatar";
            this.ptb_EnermyAvatar.Padding = new System.Windows.Forms.Padding(3);
            this.ptb_EnermyAvatar.Size = new System.Drawing.Size(60, 60);
            this.ptb_EnermyAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_EnermyAvatar.TabIndex = 18;
            this.ptb_EnermyAvatar.TabStop = false;
            // 
            // lbl_Enermy_Coundown
            // 
            this.lbl_Enermy_Coundown.BackColor = System.Drawing.Color.LimeGreen;
            this.lbl_Enermy_Coundown.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Enermy_Coundown.ForeColor = System.Drawing.Color.White;
            this.lbl_Enermy_Coundown.Location = new System.Drawing.Point(8, 5);
            this.lbl_Enermy_Coundown.Name = "lbl_Enermy_Coundown";
            this.lbl_Enermy_Coundown.Size = new System.Drawing.Size(51, 51);
            this.lbl_Enermy_Coundown.TabIndex = 19;
            this.lbl_Enermy_Coundown.Text = "60";
            this.lbl_Enermy_Coundown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_My_Coundown
            // 
            this.lbl_My_Coundown.BackColor = System.Drawing.Color.LimeGreen;
            this.lbl_My_Coundown.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_My_Coundown.ForeColor = System.Drawing.Color.White;
            this.lbl_My_Coundown.Location = new System.Drawing.Point(8, 701);
            this.lbl_My_Coundown.Name = "lbl_My_Coundown";
            this.lbl_My_Coundown.Size = new System.Drawing.Size(51, 51);
            this.lbl_My_Coundown.TabIndex = 20;
            this.lbl_My_Coundown.Text = "60";
            this.lbl_My_Coundown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_EnermyTotalTime
            // 
            this.lbl_EnermyTotalTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(92)))));
            this.lbl_EnermyTotalTime.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EnermyTotalTime.Location = new System.Drawing.Point(67, 5);
            this.lbl_EnermyTotalTime.Name = "lbl_EnermyTotalTime";
            this.lbl_EnermyTotalTime.Size = new System.Drawing.Size(76, 51);
            this.lbl_EnermyTotalTime.TabIndex = 21;
            this.lbl_EnermyTotalTime.Text = "00:00";
            this.lbl_EnermyTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MyTotalTime
            // 
            this.lbl_MyTotalTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(92)))));
            this.lbl_MyTotalTime.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MyTotalTime.Location = new System.Drawing.Point(67, 701);
            this.lbl_MyTotalTime.Name = "lbl_MyTotalTime";
            this.lbl_MyTotalTime.Size = new System.Drawing.Size(76, 51);
            this.lbl_MyTotalTime.TabIndex = 22;
            this.lbl_MyTotalTime.Text = "00:00";
            this.lbl_MyTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb_CheckMate_Enermy
            // 
            this.ptb_CheckMate_Enermy.Image = global::Chinese_Chess.Properties.Resources.checkmate_Black1;
            this.ptb_CheckMate_Enermy.Location = new System.Drawing.Point(151, 5);
            this.ptb_CheckMate_Enermy.Name = "ptb_CheckMate_Enermy";
            this.ptb_CheckMate_Enermy.Size = new System.Drawing.Size(51, 51);
            this.ptb_CheckMate_Enermy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_CheckMate_Enermy.TabIndex = 0;
            this.ptb_CheckMate_Enermy.TabStop = false;
            this.ptb_CheckMate_Enermy.Visible = false;
            // 
            // ptb_CheckMate_Me
            // 
            this.ptb_CheckMate_Me.Image = global::Chinese_Chess.Properties.Resources.checkmate_Red1;
            this.ptb_CheckMate_Me.Location = new System.Drawing.Point(151, 701);
            this.ptb_CheckMate_Me.Name = "ptb_CheckMate_Me";
            this.ptb_CheckMate_Me.Size = new System.Drawing.Size(51, 51);
            this.ptb_CheckMate_Me.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_CheckMate_Me.TabIndex = 23;
            this.ptb_CheckMate_Me.TabStop = false;
            this.ptb_CheckMate_Me.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Game_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(343, 760);
            this.Controls.Add(this.ptb_CheckMate_Me);
            this.Controls.Add(this.ptb_CheckMate_Enermy);
            this.Controls.Add(this.lbl_MyTotalTime);
            this.Controls.Add(this.lbl_EnermyTotalTime);
            this.Controls.Add(this.lbl_My_Coundown);
            this.Controls.Add(this.lbl_Enermy_Coundown);
            this.Controls.Add(this.ptb_EnermyAvatar);
            this.Controls.Add(this.ptb_MyAvatar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Moves);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form_Game_Start";
            this.Text = "Form_Game_Start";
            this.Load += new System.EventHandler(this.Form_Game_Start_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_MyAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_EnermyAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_CheckMate_Enermy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_CheckMate_Me)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Moves;
        private System.Windows.Forms.Label label3;
        private OvalPictureBox ptb_MyAvatar;
        private OvalPictureBox ptb_EnermyAvatar;
        private System.Windows.Forms.Label lbl_Enermy_Coundown;
        private System.Windows.Forms.Label lbl_My_Coundown;
        private System.Windows.Forms.Label lbl_EnermyTotalTime;
        private System.Windows.Forms.Label lbl_MyTotalTime;
        private System.Windows.Forms.PictureBox ptb_CheckMate_Enermy;
        private System.Windows.Forms.PictureBox ptb_CheckMate_Me;
        private System.Windows.Forms.Timer timer1;
    }
}