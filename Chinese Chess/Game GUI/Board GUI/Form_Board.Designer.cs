
namespace Chinese_Chess
{
    partial class Form_Board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Board));
            this.ptb_ChessBoard = new System.Windows.Forms.PictureBox();
            this.ptbQueueBlack = new System.Windows.Forms.PictureBox();
            this.ptbQueueRed = new System.Windows.Forms.PictureBox();
            this.ovalPictureBox1 = new Chinese_Chess.OvalPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_ChessBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQueueBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQueueRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_ChessBoard
            // 
            this.ptb_ChessBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(203)))), ((int)(((byte)(157)))));
            this.ptb_ChessBoard.Image = ((System.Drawing.Image)(resources.GetObject("ptb_ChessBoard.Image")));
            this.ptb_ChessBoard.Location = new System.Drawing.Point(110, 50);
            this.ptb_ChessBoard.Margin = new System.Windows.Forms.Padding(0);
            this.ptb_ChessBoard.Name = "ptb_ChessBoard";
            this.ptb_ChessBoard.Size = new System.Drawing.Size(630, 700);
            this.ptb_ChessBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_ChessBoard.TabIndex = 0;
            this.ptb_ChessBoard.TabStop = false;
            // 
            // ptbQueueBlack
            // 
            this.ptbQueueBlack.BackColor = System.Drawing.Color.DarkSalmon;
            this.ptbQueueBlack.Location = new System.Drawing.Point(94, 50);
            this.ptbQueueBlack.Name = "ptbQueueBlack";
            this.ptbQueueBlack.Size = new System.Drawing.Size(5, 0);
            this.ptbQueueBlack.TabIndex = 3;
            this.ptbQueueBlack.TabStop = false;
            // 
            // ptbQueueRed
            // 
            this.ptbQueueRed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ptbQueueRed.BackColor = System.Drawing.Color.DarkSalmon;
            this.ptbQueueRed.Location = new System.Drawing.Point(751, 50);
            this.ptbQueueRed.Name = "ptbQueueRed";
            this.ptbQueueRed.Size = new System.Drawing.Size(5, 0);
            this.ptbQueueRed.TabIndex = 4;
            this.ptbQueueRed.TabStop = false;
            // 
            // ovalPictureBox1
            // 
            this.ovalPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ovalPictureBox1.Image = global::Chinese_Chess.Properties.Resources.advisorBlack1;
            this.ovalPictureBox1.Location = new System.Drawing.Point(768, 832);
            this.ovalPictureBox1.Margin = new System.Windows.Forms.Padding(41, 24, 41, 24);
            this.ovalPictureBox1.Name = "ovalPictureBox1";
            this.ovalPictureBox1.Padding = new System.Windows.Forms.Padding(55, 32, 55, 32);
            this.ovalPictureBox1.Size = new System.Drawing.Size(1001, 584);
            this.ovalPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ovalPictureBox1.TabIndex = 1;
            this.ovalPictureBox1.TabStop = false;
            // 
            // Form_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(203)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(850, 800);
            this.Controls.Add(this.ptbQueueRed);
            this.Controls.Add(this.ptbQueueBlack);
            this.Controls.Add(this.ovalPictureBox1);
            this.Controls.Add(this.ptb_ChessBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(41, 24, 41, 24);
            this.Name = "Form_Board";
            this.Text = "Form_Board";
            this.Load += new System.EventHandler(this.Form_Board_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_ChessBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQueueBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQueueRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private OvalPictureBox ovalPictureBox1;
        public System.Windows.Forms.PictureBox ptbQueueBlack;
        public System.Windows.Forms.PictureBox ptbQueueRed;
        public System.Windows.Forms.PictureBox ptb_ChessBoard;
    }
}

