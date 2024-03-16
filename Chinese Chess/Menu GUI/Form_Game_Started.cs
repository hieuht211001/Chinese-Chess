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
        public Form_Game_Start()
        {
            InitializeComponent();
        }

        private void Form_Game_Start_Load(object sender, EventArgs e)
        {

            form_Game_Moves = new Form_Game_Moves();
            form_Game_Moves.TopLevel = false;
            form_Game_Moves.Parent = panel1;
            this.panel1.Controls.Add(form_Game_Moves);
            int x3 = (panel1.Width - form_Game_Moves.Width) / 2;
            int y3 = (panel1.Height - form_Game_Moves.Height) / 2;
            form_Game_Moves.Location = new Point(x3, y3);
            form_Game_Moves.Show();

            form_Game_Setting = new Form_Game_Setting();
            form_Game_Setting.TopLevel = false;
            form_Game_Setting.Parent = panel1;
            this.panel1.Controls.Add(form_Game_Setting);
            int x4 = (panel1.Width - form_Game_Setting.Width) / 2;
            int y4 = (panel1.Height - form_Game_Setting.Height) / 2;
            form_Game_Setting.Location = new Point(x4, y4);
            form_Game_Setting.Hide();
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
            if (Game_Mode.gameStatus == GAMESTATUS.READY_TOSTART && !bAvatarDisplayed)
            {
                Display_PlayerAvatar(player.MyAvatar, ptb_MyAvatar);
                Display_PlayerAvatar(getSet_RealTimePosition.Get_EnermyAvatar(), ptb_EnermyAvatar);
                bAvatarDisplayed = true;
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
            }
        }
    }
}
