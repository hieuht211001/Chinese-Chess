using System;
using System.Collections.Generic;
using System.Drawing;
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

    public enum GAMESTYLE
    {
        WITH_FRIEND,
        VS_COMPUTER,
        ALONE,
        CUSTOM
    }

    public class Game_Mode
    {
        public static GAMESTATUS gameStatus;
        public static ChessColor playTurn = ChessColor.RED; //by default, Red play first turn
        public static int iTimePerTurn = 60; // be default, per turn maximum time is 60s
        public static GAMESTYLE gameStyle = GAMESTYLE.WITH_FRIEND;
    }

    public class Game_Color
    {
        public static Color DEEP_RED = Color.FromArgb(192, 64, 0);
        public static Color SLIGHT_PINK = Color.FromArgb(255, 241, 242);
        public static Color WHITE = Color.FromArgb(255, 251, 242);
    }
}
