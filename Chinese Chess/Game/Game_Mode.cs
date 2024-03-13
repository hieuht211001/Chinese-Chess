using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    public enum GAMESTATUS
    {
        WAITING,
        READY_TOSTART,
        DEFEAT,
        VICTORY,
        OVER
    }
    public class Game_Mode
    {
        public static GAMESTATUS gameStatus;
        public static ChessColor playTurn = ChessColor.RED; //by default, Red play first turn
    }
}
