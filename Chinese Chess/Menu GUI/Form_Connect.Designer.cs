namespace Chinese_Chess
{
    partial class Form_Connect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Connect));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbx_friendID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_YourID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_IDInfor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ptb_avatar_Cat = new Chinese_Chess.OvalPictureBox();
            this.ptb_avatar_deer = new Chinese_Chess.OvalPictureBox();
            this.ptb_avatar_jaguar = new Chinese_Chess.OvalPictureBox();
            this.ptb_avatar_Panda = new Chinese_Chess.OvalPictureBox();
            this.btn_PlayWithFriend = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_RedSide = new System.Windows.Forms.Button();
            this.btn_BlackSide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_Cat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_deer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_jaguar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_Panda)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(92)))));
            this.label1.Font = new System.Drawing.Font("210 OmniGothic 050", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(116, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connect";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(92)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tbx_friendID
            // 
            this.tbx_friendID.Font = new System.Drawing.Font("210 OmniGothic 050", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_friendID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tbx_friendID.Location = new System.Drawing.Point(26, 237);
            this.tbx_friendID.Name = "tbx_friendID";
            this.tbx_friendID.Size = new System.Drawing.Size(291, 29);
            this.tbx_friendID.TabIndex = 7;
            this.tbx_friendID.Text = "Input here";
            this.tbx_friendID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_friendID.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(58, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Your ID:";
            // 
            // lbl_YourID
            // 
            this.lbl_YourID.AutoSize = true;
            this.lbl_YourID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_YourID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_YourID.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_YourID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.lbl_YourID.Location = new System.Drawing.Point(165, 89);
            this.lbl_YourID.Name = "lbl_YourID";
            this.lbl_YourID.Size = new System.Drawing.Size(124, 24);
            this.lbl_YourID.TabIndex = 10;
            this.lbl_YourID.Text = "12082051";
            this.lbl_YourID.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(92)))));
            this.label2.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(0, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 61);
            this.label2.TabIndex = 11;
            // 
            // lbl_IDInfor
            // 
            this.lbl_IDInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_IDInfor.AutoSize = true;
            this.lbl_IDInfor.Font = new System.Drawing.Font("210 OmniGothic 050", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IDInfor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_IDInfor.Location = new System.Drawing.Point(100, 128);
            this.lbl_IDInfor.Name = "lbl_IDInfor";
            this.lbl_IDInfor.Size = new System.Drawing.Size(151, 15);
            this.lbl_IDInfor.TabIndex = 12;
            this.lbl_IDInfor.Text = "Click your ID to copy!";
            this.lbl_IDInfor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(22, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Enter friend\'s ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(22, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Select Avatar";
            // 
            // ptb_avatar_Cat
            // 
            this.ptb_avatar_Cat.BackColor = System.Drawing.Color.Red;
            this.ptb_avatar_Cat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_avatar_Cat.Image = global::Chinese_Chess.Properties.Resources.cat;
            this.ptb_avatar_Cat.Location = new System.Drawing.Point(26, 356);
            this.ptb_avatar_Cat.Name = "ptb_avatar_Cat";
            this.ptb_avatar_Cat.Padding = new System.Windows.Forms.Padding(3);
            this.ptb_avatar_Cat.Size = new System.Drawing.Size(60, 60);
            this.ptb_avatar_Cat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar_Cat.TabIndex = 15;
            this.ptb_avatar_Cat.TabStop = false;
            this.ptb_avatar_Cat.Click += new System.EventHandler(this.ptb_avatar_Cat_Click);
            // 
            // ptb_avatar_deer
            // 
            this.ptb_avatar_deer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.ptb_avatar_deer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_avatar_deer.Image = global::Chinese_Chess.Properties.Resources.deer;
            this.ptb_avatar_deer.Location = new System.Drawing.Point(105, 356);
            this.ptb_avatar_deer.Name = "ptb_avatar_deer";
            this.ptb_avatar_deer.Padding = new System.Windows.Forms.Padding(3);
            this.ptb_avatar_deer.Size = new System.Drawing.Size(60, 60);
            this.ptb_avatar_deer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar_deer.TabIndex = 16;
            this.ptb_avatar_deer.TabStop = false;
            this.ptb_avatar_deer.Click += new System.EventHandler(this.ptb_avatar_deer_Click);
            // 
            // ptb_avatar_jaguar
            // 
            this.ptb_avatar_jaguar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.ptb_avatar_jaguar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_avatar_jaguar.Image = global::Chinese_Chess.Properties.Resources.jaguar;
            this.ptb_avatar_jaguar.Location = new System.Drawing.Point(183, 356);
            this.ptb_avatar_jaguar.Name = "ptb_avatar_jaguar";
            this.ptb_avatar_jaguar.Padding = new System.Windows.Forms.Padding(3);
            this.ptb_avatar_jaguar.Size = new System.Drawing.Size(60, 60);
            this.ptb_avatar_jaguar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar_jaguar.TabIndex = 17;
            this.ptb_avatar_jaguar.TabStop = false;
            this.ptb_avatar_jaguar.Click += new System.EventHandler(this.ptb_avatar_jaguar_Click);
            // 
            // ptb_avatar_Panda
            // 
            this.ptb_avatar_Panda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.ptb_avatar_Panda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_avatar_Panda.Image = global::Chinese_Chess.Properties.Resources.panda;
            this.ptb_avatar_Panda.Location = new System.Drawing.Point(261, 356);
            this.ptb_avatar_Panda.Name = "ptb_avatar_Panda";
            this.ptb_avatar_Panda.Padding = new System.Windows.Forms.Padding(3);
            this.ptb_avatar_Panda.Size = new System.Drawing.Size(60, 60);
            this.ptb_avatar_Panda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar_Panda.TabIndex = 18;
            this.ptb_avatar_Panda.TabStop = false;
            this.ptb_avatar_Panda.Click += new System.EventHandler(this.ptb_avatar_Panda_Click);
            // 
            // btn_PlayWithFriend
            // 
            this.btn_PlayWithFriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_PlayWithFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PlayWithFriend.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlayWithFriend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.btn_PlayWithFriend.Location = new System.Drawing.Point(26, 626);
            this.btn_PlayWithFriend.Name = "btn_PlayWithFriend";
            this.btn_PlayWithFriend.Size = new System.Drawing.Size(291, 49);
            this.btn_PlayWithFriend.TabIndex = 19;
            this.btn_PlayWithFriend.Text = "Apply";
            this.btn_PlayWithFriend.UseVisualStyleBackColor = false;
            this.btn_PlayWithFriend.Click += new System.EventHandler(this.btn_PlayWithFriend_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Back.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Back.Location = new System.Drawing.Point(26, 682);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(291, 49);
            this.btn_Back.TabIndex = 20;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(22, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Choose Side";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.label7.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.label7.Location = new System.Drawing.Point(26, 513);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 61);
            this.label7.TabIndex = 22;
            // 
            // btn_RedSide
            // 
            this.btn_RedSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_RedSide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RedSide.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RedSide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.btn_RedSide.Location = new System.Drawing.Point(37, 518);
            this.btn_RedSide.Name = "btn_RedSide";
            this.btn_RedSide.Size = new System.Drawing.Size(130, 49);
            this.btn_RedSide.TabIndex = 23;
            this.btn_RedSide.Text = "Red";
            this.btn_RedSide.UseVisualStyleBackColor = false;
            this.btn_RedSide.Click += new System.EventHandler(this.btn_RedSide_Click);
            // 
            // btn_BlackSide
            // 
            this.btn_BlackSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_BlackSide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BlackSide.Font = new System.Drawing.Font("210 OmniGothic 050", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BlackSide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(118)))));
            this.btn_BlackSide.Location = new System.Drawing.Point(173, 518);
            this.btn_BlackSide.Name = "btn_BlackSide";
            this.btn_BlackSide.Size = new System.Drawing.Size(130, 49);
            this.btn_BlackSide.TabIndex = 24;
            this.btn_BlackSide.Text = "Black";
            this.btn_BlackSide.UseVisualStyleBackColor = false;
            this.btn_BlackSide.Click += new System.EventHandler(this.btn_BlackSide_Click);
            // 
            // Form_Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(343, 760);
            this.Controls.Add(this.btn_BlackSide);
            this.Controls.Add(this.btn_RedSide);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_PlayWithFriend);
            this.Controls.Add(this.ptb_avatar_Panda);
            this.Controls.Add(this.ptb_avatar_jaguar);
            this.Controls.Add(this.ptb_avatar_deer);
            this.Controls.Add(this.ptb_avatar_Cat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_IDInfor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_YourID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_friendID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form_Connect";
            this.Text = "Form_Setting";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_Cat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_deer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_jaguar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar_Panda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbx_friendID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_YourID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_IDInfor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private OvalPictureBox ptb_avatar_Cat;
        private OvalPictureBox ptb_avatar_deer;
        private OvalPictureBox ptb_avatar_jaguar;
        private OvalPictureBox ptb_avatar_Panda;
        private System.Windows.Forms.Button btn_PlayWithFriend;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_RedSide;
        private System.Windows.Forms.Button btn_BlackSide;
    }
}