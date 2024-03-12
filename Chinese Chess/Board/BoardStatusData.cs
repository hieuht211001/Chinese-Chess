using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class BoardStatusData
    {
        // key: Location on Board, value1: Red Able, value2: Black Able
        public static Dictionary< Point, (bool, bool)> BoardStatus = new Dictionary<Point, (bool, bool)>();

        public void Set_Board_Ini_Status()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Point Position = new Point((int)ChessLocationX.A + i * 70, (int)ChessLocationY._0 - j * 70);
                    BoardStatus[Position] = (false, false);
                }
            }
        }

        public void Add_Board_Status(Pieces PieceChange, bool bValue)
        {
            Point PiecePos = new Point(PieceChange.Location.X, PieceChange.Location.Y);
            var value = BoardStatus[PiecePos];
            if (PieceChange.PieceColor == ChessColor.RED)
            {
                BoardStatus[PiecePos] = (bValue, value.Item2);
            }
            else
            {
                BoardStatus[PiecePos] = (value.Item1, bValue);
            }
        }

        public void ChangeDataStatus_AfterMove(Pieces PieceChange, Point BeforePos, Point AfterPos)
        {
            BoardStatus[BeforePos] = (false, false);
            if (PieceChange.PieceColor == ChessColor.RED)
            {
                BoardStatus[AfterPos] = (true, false);
            }
            else
            {
                BoardStatus[AfterPos] = (false, true);
            }
        }

        public bool GetStatus_AtPosition(Point pPosition, ChessColor returnColor)
        {
            if (!IsThisPosition_Exit(pPosition)) { return false; }
            if (returnColor == ChessColor.RED) { return BoardStatus[pPosition].Item1; }
            else { return BoardStatus[pPosition].Item2; }
        }

        public bool IsThisPosition_Exit(Point pPosition)
        {
            if (pPosition.X <= (int)ChessLocationX.J && pPosition.X >= (int)ChessLocationX.A
                && pPosition.Y <= (int)ChessLocationY._0 && pPosition.Y >= (int)ChessLocationY._9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
