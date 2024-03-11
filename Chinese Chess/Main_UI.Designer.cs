namespace Chinese_Chess
{
    partial class Main_UI
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
            this.panelForBoard = new System.Windows.Forms.Panel();
            this.panelForMenu = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelForBoard
            // 
            this.panelForBoard.BackColor = System.Drawing.Color.Transparent;
            this.panelForBoard.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelForBoard.Location = new System.Drawing.Point(26, 20);
            this.panelForBoard.Name = "panelForBoard";
            this.panelForBoard.Size = new System.Drawing.Size(855, 760);
            this.panelForBoard.TabIndex = 0;
            // 
            // panelForMenu
            // 
            this.panelForMenu.Location = new System.Drawing.Point(908, 20);
            this.panelForMenu.Name = "panelForMenu";
            this.panelForMenu.Size = new System.Drawing.Size(343, 760);
            this.panelForMenu.TabIndex = 1;
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelForMenu);
            this.Controls.Add(this.panelForBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Chinese_Chess.Properties.Resources.game_icon_final;
            this.Name = "Main_UI";
            this.Text = "Main_UI";
            this.Load += new System.EventHandler(this.Main_UI_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_UI_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_UI_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_UI_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForBoard;
        private System.Windows.Forms.Panel panelForMenu;
    }
}