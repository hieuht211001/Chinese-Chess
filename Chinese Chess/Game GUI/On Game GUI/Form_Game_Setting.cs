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
    public partial class Form_Game_Setting : Form
    {
        Form_Board formBoard;
        PictureBox ptb_chessBoard;
        public static bool bRestartRequest = false;
        public Form_Game_Setting(Form_Board _formBoard, PictureBox _ptb_chessBoard)
        {
            InitializeComponent();
            this.formBoard = _formBoard;
            this.ptb_chessBoard = _ptb_chessBoard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn_Restart.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_Restart_On;
            Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM, "Do you want to restart?");
            form_Message.ShowMessage();
            if (form_Message.bYesOrNoClicked == true)
            {
                bRestartRequest = true; // request clear move history
                btn_Restart.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_Restart_Off;
                Game_Mode.playTurn = ChessColor.RED;    // reset turn to default
                formBoard.Reset();
            }
            else { btn_Restart.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_Restart_Off; return; }
        }

        private void btn_AutoLocate_Click(object sender, EventArgs e)
        {
            if (Game_General_Setting.bAutoLocate == false)
            {
                Game_General_Setting.bAutoLocate = true;
                btn_AutoLocate.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_autoLocate_On;
            }
            else
            {
                Game_General_Setting.bAutoLocate = false;
                btn_AutoLocate.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_autoLocate_Off;
            }
        }

        private void btn_draw_request_Click(object sender, EventArgs e)
        {

        }

        private void btn_Sound_Click(object sender, EventArgs e)
        {
            if (Game_Sound.bSoundEnable == false)
            {
                Game_Sound.bSoundEnable = true;
                btn_Sound.BackgroundImage = global::Chinese_Chess.Properties.Resources.setting_button_soundOn;
            }
            else       // default on
            {
                Game_Sound.bSoundEnable = false;
                btn_Sound.BackgroundImage = global::Chinese_Chess.Properties.Resources.setting_button_soundOff;
            }
        }

        private void btn_QuitGame_Click(object sender, EventArgs e)
        {
            btn_QuitGame.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_ExitGame_On;
            GetSet_RealTimePosition getSet_RealTimePosition = new GetSet_RealTimePosition();
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM, "Do you want to exit game?");
            form_Message.ShowMessage();
            if (form_Message.bYesOrNoClicked == true)
            {
                getSet_RealTimePosition.Delete_MyGameInfo();
                Application.Exit();
            }
            btn_QuitGame.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_ExitGame_Off;
        }

        Game_Function_Redo game_Function_Redo;
        private async void btn_Redo_Click(object sender, EventArgs e)
        {
            game_Function_Redo = new Game_Function_Redo(ptb_chessBoard, formBoard);
            game_Function_Redo.Redo_AloneMode();
        }

        public event EventHandler btn_BacktoMenu_Clicked;
        private void btn_backToMenu_Click(object sender, EventArgs e)
        {
            btn_backToMenu.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_BackToMenu_On;
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM, "Do you want to back?");
            form_Message.ShowMessage();
            if (form_Message.bYesOrNoClicked == true)
            {
                // back to menu ui
                btn_BacktoMenu_Clicked?.Invoke(this, EventArgs.Empty);

                //reset board
                Game_Mode.gameStatus = GAMESTATUS.WAITING;
                Game_Mode.playTurn = ChessColor.RED;    // reset turn to default
                formBoard.Reset();
                // disbale all pieces
                foreach (Control control in ptb_chessBoard.Controls)
                {
                    if (control is Pieces piece) { piece.Enabled = false; }
                }
            }
            btn_backToMenu.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_BackToMenu_Off;
        }

        private void Form_Game_Setting_Load(object sender, EventArgs e)
        { 
        }

        private void btn_EasyOrHard_Click(object sender, EventArgs e)
        {
            if (AutoPlay_ComputerAlgrithm.iComputerLevel == 0) 
            {
                AutoPlay_ComputerAlgrithm.iComputerLevel = 1;
                btn_EasyOrHard.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_hard;
            }
            else
            {
                AutoPlay_ComputerAlgrithm.iComputerLevel = 0;
                btn_EasyOrHard.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_easy;
            }
        }

        private void Form_Game_Setting_VisibleChanged(object sender, EventArgs e)
        {
            if (Game_Mode.gameStyle == GAMESTYLE.ALONE) { btn_draw_request.Enabled = false; btn_surrender.Enabled = false; btn_EasyOrHard.Enabled = false; }
            else if (Game_Mode.gameStyle == GAMESTYLE.WITH_FRIEND) { btn_draw_request.Enabled = true; btn_surrender.Enabled = true; btn_EasyOrHard.Enabled = false; }
            else if (Game_Mode.gameStyle == GAMESTYLE.VS_COMPUTER)
            {
                btn_draw_request.Enabled = true;
                btn_surrender.Enabled = true;
                btn_EasyOrHard.Enabled = true;
            }
        }
    }
}
