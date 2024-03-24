using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class KingPossibleMove: Possible_Move_Circle
    {
        Pieces _piece;
        PictureBox _ptbBoard;
        BoardStatusData BoardData = new BoardStatusData();
        public KingPossibleMove (PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }
        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;

            Point tempPoint = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos);
            if (checkPointLegal(tempPoint))
            {
                if (currentXPos < (int)ChessLocationX.F && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
            }
            tempPoint = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos);
            if (checkPointLegal (tempPoint))
            {
                if (currentXPos > (int)ChessLocationX.D && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
            }

            if (_piece.PieceColor == ChessColor.RED )
            {
                tempPoint = new Point(currentXPos, currentYPos + (int)MOVE.DOWN_Y);
                if (checkPointLegal(tempPoint))
                {
                    if (currentYPos < (int)ChessLocationY._0 && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
                }
                tempPoint = new Point(currentXPos, currentYPos + (int)MOVE.UP_Y);
                if ( checkPointLegal(tempPoint))
                {
                    if (currentYPos > (int)ChessLocationY._2 && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
                }
            }

            if (_piece.PieceColor == ChessColor.BLACK)
            {
                tempPoint = new Point(currentXPos, currentYPos + (int)MOVE.DOWN_Y);
                if (checkPointLegal(tempPoint)) 
                {
                    if (currentYPos < (int)ChessLocationY._7 && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
                }
                tempPoint = new Point(currentXPos, currentYPos + (int)MOVE.UP_Y);
                if ( checkPointLegal(tempPoint))
                {
                    if (currentYPos > (int)ChessLocationY._9 && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
                }
            }
        }
    }
}
