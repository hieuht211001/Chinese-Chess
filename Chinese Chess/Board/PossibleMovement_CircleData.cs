using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    public class PossibleMovement_CircleData
    {
        // key: Location on Board, value: circle able
        public static Dictionary<Point, bool> BoardStatus = new Dictionary<Point, bool>();

        public void Set_Circle_Ini_Status()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Point Position = new Point((int)ChessLocationX.A + i * 70, (int)ChessLocationY._0 - j * 70);
                    BoardStatus[Position] = false;
                }
            }
        }

        public void Add_Circle_ByPos(Point point)
        {
            BoardStatus[point] = true;
        }

        public void Delete_Circle_ByPos(Point point)
        {
            BoardStatus[point] = false;
        }

        public bool GetStatus_AtPosition(Point point)
        {
            return BoardStatus[point];
        }

        public void Delete_All_Circle_Data()
        {
            Set_Circle_Ini_Status();
        }
    }
}
