
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
            this.ovalPictureBox1 = new Chinese_Chess.OvalPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_ChessBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_ChessBoard
            // 
            this.ptb_ChessBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptb_ChessBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(203)))), ((int)(((byte)(157)))));
            this.ptb_ChessBoard.Image = ((System.Drawing.Image)(resources.GetObject("ptb_ChessBoard.Image")));
            this.ptb_ChessBoard.Location = new System.Drawing.Point(0, 0);
            this.ptb_ChessBoard.Margin = new System.Windows.Forms.Padding(0);
            this.ptb_ChessBoard.Name = "ptb_ChessBoard";
            this.ptb_ChessBoard.Padding = new System.Windows.Forms.Padding(10);
            this.ptb_ChessBoard.Size = new System.Drawing.Size(640, 710);
            this.ptb_ChessBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_ChessBoard.TabIndex = 0;
            this.ptb_ChessBoard.TabStop = false;
            // 
            // ovalPictureBox1
            // 
            this.ovalPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ovalPictureBox1.Image = global::Chinese_Chess.Properties.Resources.advisorBlack1;
            this.ovalPictureBox1.Location = new System.Drawing.Point(56, 104);
            this.ovalPictureBox1.Name = "ovalPictureBox1";
            this.ovalPictureBox1.Padding = new System.Windows.Forms.Padding(4);
            this.ovalPictureBox1.Size = new System.Drawing.Size(73, 73);
            this.ovalPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ovalPictureBox1.TabIndex = 1;
            this.ovalPictureBox1.TabStop = false;
            // 
            // Form_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(203)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(640, 710);
            this.Controls.Add(this.ovalPictureBox1);
            this.Controls.Add(this.ptb_ChessBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Board";
            this.Text = "Form_Board";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_ChessBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_ChessBoard;
        private OvalPictureBox ovalPictureBox1;
    }
}

