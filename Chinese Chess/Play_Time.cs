﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class Play_Time
    {
        BoardStatusData boardData = new BoardStatusData();
        Player player = new Player();
        int iFirstPlayTurn = (int)Game_Mode.playTurn;
        public void Display_Countdown_Time(Label lblTimeForMe, Label lblTimeForEnermy, ref int StartTime)
        {
            if ((int)Game_Mode.playTurn != iFirstPlayTurn || (Game_Mode.gameStyle == GAMESTYLE.VS_COMPUTER && AutoPlay_ComputerAlgrithm.iTimeFor1Move != TimeSpan.Zero)) // simutiouly check new turn -> if different, reset start time 
            {
                StartTime = Game_Mode.iTimePerTurn;
            }
            // update time by current turn
            if ((int)Game_Mode.playTurn == player.MySide)
            {
                StartTime--;
                lblTimeForMe.Text = StartTime.ToString();
                changeColor_CountdownTime(StartTime, lblTimeForMe);
                if (Game_Mode.gameStyle == GAMESTYLE.VS_COMPUTER)
                {
                    lblTimeForEnermy.Text = "Computer";
                    if (AutoPlay_ComputerAlgrithm.iTimeFor1Move != TimeSpan.Zero) { AutoPlay_ComputerAlgrithm.iTimeFor1Move = TimeSpan.Zero; }
                }
                else
                {
                    lblTimeForEnermy.Text = Game_Mode.iTimePerTurn.ToString();
                }
                lblTimeForEnermy.BackColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                StartTime--;
                lblTimeForEnermy.Text = StartTime.ToString();
                changeColor_CountdownTime(StartTime, lblTimeForEnermy);
                lblTimeForMe.Text = Game_Mode.iTimePerTurn.ToString();
                lblTimeForMe.BackColor = System.Drawing.Color.LimeGreen;
            }

            // save current turn to check
            iFirstPlayTurn = (int)Game_Mode.playTurn;

            if (StartTime == 0) { boardData.ChangePlayerTurn(); }
        }
        public void changeColor_CountdownTime(int StartTime, Label lbl_CountDownTime)
        {
            if (StartTime > Game_Mode.iTimePerTurn / 2) { lbl_CountDownTime.BackColor = System.Drawing.Color.LimeGreen;}
            else if (StartTime > Game_Mode.iTimePerTurn / 6) { lbl_CountDownTime.BackColor = System.Drawing.Color.Orange; }
            else { lbl_CountDownTime.BackColor = Game_Color.DEEP_RED; }
        }

        public static TimeSpan MyTotalTime = TimeSpan.Zero;
        public static TimeSpan EnermyTotalTime = TimeSpan.Zero;
        public void Display_TotalTime(Label lblTotalTimeForMe, Label lblTotalTimeForEnermy)
        {
            if ((int)Game_Mode.playTurn == player.MySide)
            {
                MyTotalTime = MyTotalTime.Add(TimeSpan.FromSeconds(1));
                lblTotalTimeForMe.Text = MyTotalTime.ToString(@"mm\:ss");
            }
            else
            {
                EnermyTotalTime = EnermyTotalTime.Add(TimeSpan.FromSeconds(1));
                lblTotalTimeForEnermy.Text = EnermyTotalTime.ToString(@"mm\:ss");
            }
        }
    }
}
