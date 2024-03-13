using System;
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
            if ((int)Game_Mode.playTurn != iFirstPlayTurn) // simutiouly check new turn -> if different, reset start time 
            {
                StartTime = Game_Mode.iTimePerTurn;
            }
            // update time by current turn
            if ((int)Game_Mode.playTurn == player.MySide)
            {
                StartTime--;
                lblTimeForMe.Text = StartTime.ToString();
                lblTimeForEnermy.Text = Game_Mode.iTimePerTurn.ToString();
            }
            else
            {
                StartTime--;
                lblTimeForEnermy.Text = StartTime.ToString();
                lblTimeForMe.Text = Game_Mode.iTimePerTurn.ToString();
            }

            // save current turn to check
            iFirstPlayTurn = (int)Game_Mode.playTurn;

            if (StartTime == 0) { boardData.ChangePlayerTurn(); }
        }
    }
}
