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
    public partial class Form_Menu : Form
    {
        GetSet_RealTimePosition getSet_RealTimePosition  = new GetSet_RealTimePosition();
        Form_Board form_Board;
        public Form_Menu(Form_Board form_Board)
        {
            InitializeComponent();
            this.form_Board = form_Board;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            btn_Exit.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_ExitGame_On;
            btn_Exit.BackColor = Game_Color.DEEP_RED;
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
            btn_Exit.BackgroundImage = global::Chinese_Chess.Properties.Resources.btn_ExitGame_Off;
            btn_Exit.BackColor = Game_Color.SLIGHT_PINK;
        }
        public event EventHandler btn_PlayWithFriend_Clicked;
        private void btn_PlayWithFriend_Click(object sender, EventArgs e)
        {
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            btn_PlayWithFriend_Clicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler btn_Setting_Clicked;
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            btn_Setting_Clicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler btn_PlayAlone_Clicked;
        private void btn_PlayAlone_Click(object sender, EventArgs e)
        {
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            btn_PlayAlone_Clicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler btn_PlayVsComputer_Clicked;
        private void btn_PlayVsComputer_Click(object sender, EventArgs e)
        {
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            btn_PlayVsComputer_Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
