using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public partial class Form_Game_Start : Form_Menu_Base
    {
        public Form_Game_Moves form_Game_Moves = null;
        public Form_Game_Setting form_Game_Setting = null;
        Player player = new Player();
        Play_Time play_Time = new Play_Time();
        GetSet_RealTimePosition getSet_RealTimePosition = new GetSet_RealTimePosition();
        Form_Board formBoard;
        PictureBox ptb_chessBoard;
        public Form_Game_Start(Form_Board _formBoard, PictureBox _ptb_chessBoard)
        {
            InitializeComponent();
            this.formBoard = _formBoard;
            this.ptb_chessBoard = _ptb_chessBoard;
        }

        public void Display_PlayerAvatar(int playerAvatar, PictureBox Displayptb)
        {
            if (playerAvatar == 1) { Displayptb.Image = global::Chinese_Chess.Properties.Resources.cat; }
            else if (playerAvatar == 2) { Displayptb.Image = global::Chinese_Chess.Properties.Resources.deer; }
            else if (playerAvatar == 3) { Displayptb.Image = global::Chinese_Chess.Properties.Resources.jaguar; }
            else { Displayptb.Image = global::Chinese_Chess.Properties.Resources.panda; }
        }

        bool bAvatarDisplayed = false;

        public void Refresh_PlayerAvatar()
        {
            if (Game_Mode.gameStatus == GAMESTATUS.READY_TOSTART )
            {
                if (!bAvatarDisplayed && Game_Mode.gameStyle == GAMESTYLE.WITH_FRIEND )
                {
                    Display_PlayerAvatar(player.MyAvatar, ptb_MyAvatar);
                    Display_PlayerAvatar(getSet_RealTimePosition.Get_EnermyAvatar(), ptb_EnermyAvatar);
                    bAvatarDisplayed = true;
                }
                else if ((!bAvatarDisplayed && Game_Mode.gameStyle != GAMESTYLE.WITH_FRIEND))
                {
                    Display_PlayerAvatar(2, ptb_MyAvatar);
                    Display_PlayerAvatar(2, ptb_EnermyAvatar);
                    bAvatarDisplayed = true;
                }

                if ((int)Game_Mode.playTurn == player.MySide)
                {
                    this.ptb_MyAvatar.BackColor = Color.LimeGreen;
                    this.ptb_EnermyAvatar.BackColor = Color.Transparent;
                }
                else
                {
                    this.ptb_EnermyAvatar.BackColor = Color.LimeGreen;
                    this.ptb_MyAvatar.BackColor = Color.Transparent;
                }
            }
        }

        int iCountDownTime = Game_Mode.iTimePerTurn;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh_PlayerAvatar();
            // start when 2 player connect together
            if (Game_Mode.gameStatus == GAMESTATUS.READY_TOSTART && BoardStatusUI.EnermyMoveStep != "Connected")
            {
                play_Time.Display_Countdown_Time(this.lbl_My_Coundown, this.lbl_Enermy_Coundown, ref iCountDownTime);
                play_Time.Display_TotalTime(this.lbl_MyTotalTime, this.lbl_EnermyTotalTime);

                if (CheckMate_Rule.CheckMateStatus_Me == true) { Display_CheckMateIcon(ptb_CheckMate_Me, null); }
                else { Hide_CheckMateIcon(ptb_CheckMate_Me, null); }

                if (CheckMate_Rule.CheckMateStatus_Enermy == true) { Display_CheckMateIcon(null, ptb_CheckMate_Enermy); }
                else { Hide_CheckMateIcon(null, ptb_CheckMate_Enermy); }
            }
        }

        private void Form_Game_Start_Load_1(object sender, EventArgs e)
        {
            form_Game_Moves = new Form_Game_Moves();
            form_Game_Moves.TopLevel = false;
            form_Game_Moves.Parent = panel1;
            this.panel1.Controls.Add(form_Game_Moves);
            int x3 = (panel1.Width - form_Game_Moves.Width) / 2;
            int y3 = (panel1.Height - form_Game_Moves.Height) / 2;
            form_Game_Moves.Location = new Point(x3, y3);
            form_Game_Moves.Show();

            form_Game_Setting = new Form_Game_Setting(formBoard, ptb_chessBoard);
            form_Game_Setting.TopLevel = false;
            form_Game_Setting.Parent = panel1;
            this.panel1.Controls.Add(form_Game_Setting);
            int x4 = (panel1.Width - form_Game_Setting.Width) / 2;
            int y4 = (panel1.Height - form_Game_Setting.Height) / 2;
            form_Game_Setting.Location = new Point(x4, y4);
            form_Game_Setting.btn_BacktoMenu_Clicked += Form_Game_Setting_btn_BacktoMenu_Clicked;
            form_Game_Setting.Hide();
        }

        public event EventHandler btn_Setting_BacktoMenu_Clicked;
        private void Form_Game_Setting_btn_BacktoMenu_Clicked(object sender, EventArgs e)
        {
            btn_Setting_BacktoMenu_Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void Display_CheckMateIcon(PictureBox ptb_CheckMate_Me, PictureBox ptb_CheckMate_Enermy)
        {
            if (ptb_CheckMate_Me != null)
            {
                if (player.MySide == (int)ChessColor.RED) { ptb_CheckMate_Me.Image = global::Chinese_Chess.Properties.Resources.checkmate_Red1; }
                else { ptb_CheckMate_Me.Image = global::Chinese_Chess.Properties.Resources.checkmate_Black1; }
                ptb_CheckMate_Me.Show();
            }

            if (ptb_CheckMate_Enermy != null)
            {
                if (player.MySide == (int)ChessColor.RED) { ptb_CheckMate_Enermy.Image = global::Chinese_Chess.Properties.Resources.checkmate_Black1; }
                else { ptb_CheckMate_Enermy.Image = global::Chinese_Chess.Properties.Resources.checkmate_Red1; }
                ptb_CheckMate_Enermy.Show();
            }
        }

        private void Hide_CheckMateIcon(PictureBox ptb_CheckMate_Me, PictureBox ptb_CheckMate_Enermy)
        {
            if (ptb_CheckMate_Me != null) { ptb_CheckMate_Me.Hide(); }
            if (ptb_CheckMate_Enermy != null) { ptb_CheckMate_Enermy.Hide(); }
        }

        private void lbl_Moves_Click(object sender, EventArgs e)
        {
            form_Game_Moves.Visible = true;
            form_Game_Setting.Visible = false;
            label3.BackColor = Color.FromArgb(255, 187, 92);
            lbl_Moves.BackColor = Game_Color.WHITE;
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            form_Game_Moves.Visible = false;
            form_Game_Setting.Visible = true;
            lbl_Moves.BackColor = Color.FromArgb(255, 187, 92);
            label3.BackColor = Game_Color.WHITE;
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
        }

        private void Form_Game_Start_VisibleChanged(object sender, EventArgs e)
        {
            form_Game_Moves.Visible = true;
            form_Game_Setting.Visible = false;
        }
    }
}
