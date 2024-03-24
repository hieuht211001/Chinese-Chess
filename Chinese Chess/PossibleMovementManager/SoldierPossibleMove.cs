using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class SoldierPossibleMove : Possible_Move_Circle
    {
        Pieces _piece;
        PictureBox _ptbBoard;
        BoardStatusData BoardData = new BoardStatusData();
        public SoldierPossibleMove(PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }
        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;

            if (_piece.PieceColor == ChessColor.RED)
            {
                // up way
                Point tempPoint = new Point(currentXPos, currentYPos + (int)MOVE.UP_Y);
                if (checkPointLegal(tempPoint))
                {
                    if (currentYPos > (int)ChessLocationY._9 && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
                }
                Point leftPoint = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos);
                if (checkPointLegal(leftPoint))
                {
                    if (currentYPos < (int)ChessLocationY._4 && !BoardData.GetStatus_AtPosition(leftPoint, _piece.PieceColor)) { Create(_ptbBoard, leftPoint); }
                }
                Point rightPoint = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos);
                if (checkPointLegal(rightPoint))
                {
                    if (currentYPos < (int)ChessLocationY._4 && !BoardData.GetStatus_AtPosition(rightPoint, _piece.PieceColor)) { Create(_ptbBoard, rightPoint); }
                }
            }
            else
            {
                // up way
                Point tempPoint = new Point(currentXPos, currentYPos + (int)MOVE.DOWN_Y);
                if (checkPointLegal(tempPoint))
                {
                    if (currentYPos < (int)ChessLocationY._0 && !BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor)) { Create(_ptbBoard, tempPoint); }
                }
                Point leftPoint = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos);
                if (checkPointLegal(leftPoint))
                {
                    if (currentYPos > (int)ChessLocationY._5 && !BoardData.GetStatus_AtPosition(leftPoint, _piece.PieceColor)) { Create(_ptbBoard, leftPoint); }
                }
                Point rightPoint = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos);
                if (checkPointLegal(rightPoint))
                {
                    if (currentYPos > (int)ChessLocationY._5 && !BoardData.GetStatus_AtPosition(rightPoint, _piece.PieceColor)) { Create(_ptbBoard, rightPoint); }
                }
            }
        }
    }
}
