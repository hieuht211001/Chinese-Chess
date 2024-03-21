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
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM,"Do you want to exit game?");
            form_Message.ShowMessage();
            if (form_Message.bYesOrNoClicked == true) 
            {
                getSet_RealTimePosition.Delete_MyGameInfo();
                Application.Exit(); 
            }
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
    }
}
