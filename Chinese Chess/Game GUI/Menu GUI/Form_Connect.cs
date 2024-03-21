using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chinese_Chess
{
    public partial class Form_Connect : Form_Menu_Base
    {
        public GetSet_RealTimePosition getSet_RealTimePosition = new GetSet_RealTimePosition();
        private Form_Message form_Message_Waiting;

        int tempAvatar = 1; //default value: first select
        int tempSide = 1; //default value: first select
        private Timer timer;
        private int elapsedTimeInSeconds;



        public Form_Connect()
        {
            InitializeComponent();
            Random random = new Random();
            lbl_YourID.Text = (random.Next(10000000, 99999999)).ToString();
            Player._MyID = int.Parse(lbl_YourID.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_YourID.Text);
            lbl_IDInfor.Text = "Copied to clipboard!";
        }

        private void ptb_avatar_Cat_Click(object sender, EventArgs e)
        {
            tempAvatar = 1;
            ptb_avatar_Cat.BackColor = Color.Red;
            ptb_avatar_deer.BackColor = Color.Transparent;
            ptb_avatar_jaguar.BackColor = Color.Transparent;
            ptb_avatar_Panda.BackColor = Color.Transparent;
        }

        private void ptb_avatar_deer_Click(object sender, EventArgs e)
        {
            tempAvatar = 2;
            ptb_avatar_Cat.BackColor = Color.Transparent;
            ptb_avatar_deer.BackColor = Color.Red;
            ptb_avatar_jaguar.BackColor = Color.Transparent;
            ptb_avatar_Panda.BackColor = Color.Transparent;
        }

        private void ptb_avatar_jaguar_Click(object sender, EventArgs e)
        {
            tempAvatar = 3;
            ptb_avatar_Cat.BackColor = Color.Transparent;
            ptb_avatar_deer.BackColor = Color.Transparent;
            ptb_avatar_jaguar.BackColor = Color.Red;
            ptb_avatar_Panda.BackColor = Color.Transparent;
        }

        private void ptb_avatar_Panda_Click(object sender, EventArgs e)
        {
            tempAvatar = 4;
            ptb_avatar_Cat.BackColor = Color.Transparent;
            ptb_avatar_deer.BackColor = Color.Transparent;
            ptb_avatar_jaguar.BackColor = Color.Transparent;
            ptb_avatar_Panda.BackColor = Color.Red;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            tbx_friendID.Clear();
        }

        private void btn_RedSide_Click(object sender, EventArgs e)
        {
            tempSide = (int)ChessColor.RED;
            btn_RedSide.BackColor = Color.FromArgb(192, 64, 0);
            btn_RedSide.ForeColor = Color.FromArgb(255, 251, 242);
            btn_BlackSide.BackColor = Color.FromArgb(255, 241, 242);
            btn_BlackSide.ForeColor = Color.FromArgb(140, 122, 118);
        }

        private void btn_BlackSide_Click(object sender, EventArgs e)
        {
            tempSide = (int)ChessColor.BLACK;
            btn_RedSide.BackColor = Color.FromArgb(255, 241, 242);
            btn_RedSide.ForeColor = Color.FromArgb(192, 64, 0);
            btn_BlackSide.BackColor = Color.FromArgb(140, 122, 118);
            btn_BlackSide.ForeColor = Color.FromArgb(255, 241, 242);
        }

        public event EventHandler btn_Back_Clicked;
        private void btn_Back_Click(object sender, EventArgs e)
        {
            btn_Back_Clicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler btn_Apply_Clicked;

        private void btn_PlayWithFriend_Click(object sender, EventArgs e)
        {
            Game_Sound game_Sound = new Game_Sound();
            game_Sound.Add(SOUNDTYPE.BUTTON_SOUND);
            btn_Apply_Clicked?.Invoke(this, EventArgs.Empty);

            // check valid player ID
            string input = tbx_friendID.Text;
            int number;
            bool isValid = int.TryParse(input, out number) && input.Length == 8;
            if (isValid)
            {
                Player._FriendPlayerID = int.Parse(tbx_friendID.Text);
            }
            else
            {
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Invalid Friend's Player ID");
                form_Message.ShowMessage();
            }
            // set user's data
            Player._MyAvatar = tempAvatar;
            Player._MySide = tempSide;


            getSet_RealTimePosition.Read_EnermyMoveStep_RealTime();

            getSet_RealTimePosition.SetIniData();
            if (BoardStatusUI.EnermyMoveStep == "Connected")
            {
                if (getSet_RealTimePosition.Get_EnermySide() == Player._MySide )
                {
                    Form_Message form_Alarm = new Form_Message(MessageBoxMode.ALARM, "Please select another Side!");
                    form_Alarm.ShowMessage();
                    Game_Mode.gameStatus = GAMESTATUS.WAITING;
                    return;
                }
                else
                {
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM, "Ready to Play?");
                    form_Message.ShowMessage();
                    if (form_Message.bYesOrNoClicked == true) 
                    {
                        Game_Mode.gameStatus = GAMESTATUS.READY_TOSTART;
                        getSet_RealTimePosition.Send_MyMovement("Started!");
                    }
                    else { Game_Mode.gameStatus = GAMESTATUS.WAITING; }
                    return;
                }
            }
            else
            {
                form_Message_Waiting = new Form_Message(MessageBoxMode.WAITTING, "Waiting for Connection...");
                Game_Mode.gameStatus = GAMESTATUS.WAITING;
                form_Message_Waiting.ShowMessage();
                timer = new Timer();
                timer.Interval = 2000;
                timer.Tick += Timer_Tick;
                elapsedTimeInSeconds = 0;
                timer.Start();
            }
        }
        bool bAlarm1Time = true;
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds += 2;

            if (BoardStatusUI.EnermyMoveStep == "Connected")
            {
                Form_Message form_Alarm = new Form_Message(MessageBoxMode.WAITTING, "The opponent is changing sides");
                if (getSet_RealTimePosition.Get_EnermySide() == Player._MySide && bAlarm1Time == true)
                {
                    form_Message_Waiting.HideMessage();
                    bAlarm1Time = false;
                    form_Alarm.ShowMessage();
                    Game_Mode.gameStatus = GAMESTATUS.WAITING;
                }
                else if (getSet_RealTimePosition.Get_EnermySide() != Player._MySide)
                {
                    form_Alarm.HideMessage();
                    form_Message_Waiting.HideMessage();
                    timer.Stop();
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM, "Ready to Play?");
                    form_Message.ShowMessage();
                    if (form_Message.bYesOrNoClicked == true) 
                    { 
                        Game_Mode.gameStatus = GAMESTATUS.READY_TOSTART;
                        getSet_RealTimePosition.Send_MyMovement("Started!");
                    }
                    else { Game_Mode.gameStatus = GAMESTATUS.WAITING; }
                    return;
                }
            }

            if (elapsedTimeInSeconds >= 60)
            {
                timer.Stop(); // Dừng timer
                form_Message_Waiting.HideMessage();
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Connect Failed");
                form_Message.ShowMessage();
                return;
            }
        }
    }
}
