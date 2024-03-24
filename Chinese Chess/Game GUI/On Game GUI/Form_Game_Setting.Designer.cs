namespace Chinese_Chess
{
    partial class Form_Game_Setting
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
            this.btn_Restart = new System.Windows.Forms.Button();
            this.btn_AutoLocate = new System.Windows.Forms.Button();
            this.btn_draw_request = new System.Windows.Forms.Button();
            this.btn_Redo = new System.Windows.Forms.Button();
            this.btn_Sound = new System.Windows.Forms.Button();
            this.btn_surrender = new System.Windows.Forms.Button();
            this.btn_QuitGame = new System.Windows.Forms.Button();
            this.btn_backToMenu = new System.Windows.Forms.Button();
            this.btn_EasyOrHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Restart
            // 
            this.btn_Restart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_Restart.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_Restart_Off;
            this.btn_Restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Restart.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Restart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Restart.Location = new System.Drawing.Point(24, 195);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.Size = new System.Drawing.Size(291, 56);
            this.btn_Restart.TabIndex = 23;
            this.btn_Restart.UseVisualStyleBackColor = false;
            this.btn_Restart.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_AutoLocate
            // 
            this.btn_AutoLocate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_AutoLocate.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_autoLocate_Off;
            this.btn_AutoLocate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_AutoLocate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AutoLocate.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AutoLocate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_AutoLocate.Location = new System.Drawing.Point(24, 277);
            this.btn_AutoLocate.Name = "btn_AutoLocate";
            this.btn_AutoLocate.Size = new System.Drawing.Size(291, 56);
            this.btn_AutoLocate.TabIndex = 22;
            this.btn_AutoLocate.UseVisualStyleBackColor = false;
            this.btn_AutoLocate.Click += new System.EventHandler(this.btn_AutoLocate_Click);
            // 
            // btn_draw_request
            // 
            this.btn_draw_request.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_draw_request.BackgroundImage = global::Chinese_Chess.Properties.Resources.setting_button_draw;
            this.btn_draw_request.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_draw_request.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_draw_request.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_draw_request.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_draw_request.Location = new System.Drawing.Point(174, 32);
            this.btn_draw_request.Name = "btn_draw_request";
            this.btn_draw_request.Padding = new System.Windows.Forms.Padding(7);
            this.btn_draw_request.Size = new System.Drawing.Size(66, 56);
            this.btn_draw_request.TabIndex = 25;
            this.btn_draw_request.UseVisualStyleBackColor = false;
            this.btn_draw_request.Click += new System.EventHandler(this.btn_draw_request_Click);
            // 
            // btn_Redo
            // 
            this.btn_Redo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Redo.BackgroundImage = global::Chinese_Chess.Properties.Resources.setting_button_redo;
            this.btn_Redo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Redo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Redo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Redo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Redo.Location = new System.Drawing.Point(24, 32);
            this.btn_Redo.Name = "btn_Redo";
            this.btn_Redo.Padding = new System.Windows.Forms.Padding(7);
            this.btn_Redo.Size = new System.Drawing.Size(66, 56);
            this.btn_Redo.TabIndex = 26;
            this.btn_Redo.UseVisualStyleBackColor = false;
            this.btn_Redo.Click += new System.EventHandler(this.btn_Redo_Click);
            // 
            // btn_Sound
            // 
            this.btn_Sound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Sound.BackgroundImage = global::Chinese_Chess.Properties.Resources.setting_button_soundOn;
            this.btn_Sound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Sound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sound.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Sound.Location = new System.Drawing.Point(249, 32);
            this.btn_Sound.Name = "btn_Sound";
            this.btn_Sound.Padding = new System.Windows.Forms.Padding(7);
            this.btn_Sound.Size = new System.Drawing.Size(66, 56);
            this.btn_Sound.TabIndex = 27;
            this.btn_Sound.UseVisualStyleBackColor = false;
            this.btn_Sound.Click += new System.EventHandler(this.btn_Sound_Click);
            // 
            // btn_surrender
            // 
            this.btn_surrender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_surrender.BackgroundImage = global::Chinese_Chess.Properties.Resources.setting_button_surrender;
            this.btn_surrender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_surrender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_surrender.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_surrender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_surrender.Location = new System.Drawing.Point(99, 32);
            this.btn_surrender.Name = "btn_surrender";
            this.btn_surrender.Padding = new System.Windows.Forms.Padding(7);
            this.btn_surrender.Size = new System.Drawing.Size(66, 56);
            this.btn_surrender.TabIndex = 28;
            this.btn_surrender.UseVisualStyleBackColor = false;
            // 
            // btn_QuitGame
            // 
            this.btn_QuitGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_QuitGame.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_ExitGame_Off;
            this.btn_QuitGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QuitGame.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuitGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_QuitGame.Location = new System.Drawing.Point(24, 442);
            this.btn_QuitGame.Name = "btn_QuitGame";
            this.btn_QuitGame.Size = new System.Drawing.Size(291, 56);
            this.btn_QuitGame.TabIndex = 29;
            this.btn_QuitGame.UseVisualStyleBackColor = false;
            this.btn_QuitGame.Click += new System.EventHandler(this.btn_QuitGame_Click);
            // 
            // btn_backToMenu
            // 
            this.btn_backToMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_backToMenu.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_BackToMenu_Off;
            this.btn_backToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_backToMenu.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backToMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_backToMenu.Location = new System.Drawing.Point(24, 360);
            this.btn_backToMenu.Name = "btn_backToMenu";
            this.btn_backToMenu.Size = new System.Drawing.Size(291, 56);
            this.btn_backToMenu.TabIndex = 30;
            this.btn_backToMenu.UseVisualStyleBackColor = false;
            this.btn_backToMenu.Click += new System.EventHandler(this.btn_backToMenu_Click);
            // 
            // btn_EasyOrHard
            // 
            this.btn_EasyOrHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.btn_EasyOrHard.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_easy;
            this.btn_EasyOrHard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_EasyOrHard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EasyOrHard.Enabled = false;
            this.btn_EasyOrHard.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EasyOrHard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_EasyOrHard.Location = new System.Drawing.Point(24, 113);
            this.btn_EasyOrHard.Name = "btn_EasyOrHard";
            this.btn_EasyOrHard.Size = new System.Drawing.Size(291, 56);
            this.btn_EasyOrHard.TabIndex = 31;
            this.btn_EasyOrHard.UseVisualStyleBackColor = false;
            this.btn_EasyOrHard.Click += new System.EventHandler(this.btn_EasyOrHard_Click);
            // 
            // Form_Game_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(344, 555);
            this.Controls.Add(this.btn_EasyOrHard);
            this.Controls.Add(this.btn_backToMenu);
            this.Controls.Add(this.btn_QuitGame);
            this.Controls.Add(this.btn_surrender);
            this.Controls.Add(this.btn_Sound);
            this.Controls.Add(this.btn_Redo);
            this.Controls.Add(this.btn_draw_request);
            this.Controls.Add(this.btn_Restart);
            this.Controls.Add(this.btn_AutoLocate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Game_Setting";
            this.Text = "Form_Game_Setting";
            this.Load += new System.EventHandler(this.Form_Game_Setting_Load);
            this.VisibleChanged += new System.EventHandler(this.Form_Game_Setting_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Restart;
        private System.Windows.Forms.Button btn_AutoLocate;
        private System.Windows.Forms.Button btn_draw_request;
        private System.Windows.Forms.Button btn_Redo;
        private System.Windows.Forms.Button btn_Sound;
        private System.Windows.Forms.Button btn_surrender;
        private System.Windows.Forms.Button btn_QuitGame;
        private System.Windows.Forms.Button btn_backToMenu;
        private System.Windows.Forms.Button btn_EasyOrHard;
    }
}