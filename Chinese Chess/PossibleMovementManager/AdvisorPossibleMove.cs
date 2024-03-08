using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class AdvisorPossibleMove: Possible_Move_Circle
    {
        public Pieces _piece;
        public PictureBox _ptbBoard;
        BoardStatusData BoardData = new BoardStatusData();
        public AdvisorPossibleMove(PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }
        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;

            int YCondition1, YCondition2;

            if (_piece.PieceColor == ChessColor.RED) { YCondition1 = (int)ChessLocationY._2; YCondition2 = (int)ChessLocationY._0; }
            else { YCondition1 = (int)ChessLocationY._9; YCondition2 = (int)ChessLocationY._7; }

            // right up
            if (currentXPos < (int)ChessLocationX.F && currentYPos > YCondition1)
            {
                Point tempPoint = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos + (int)MOVE.UP_Y);
                if (!BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor))
                { Create(_ptbBoard, tempPoint); }
            }
            // left up
            if (currentXPos > (int)ChessLocationX.D && currentYPos > YCondition1)
            {
                Point tempPoint = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos + (int)MOVE.UP_Y);
                if (!BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor))
                { Create(_ptbBoard, tempPoint); }
            }
            // left down
            if (currentXPos > (int)ChessLocationX.D && currentYPos < YCondition2)
            {
                Point tempPoint = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos + (int)MOVE.DOWN_Y);
                if (!BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor))
                { Create(_ptbBoard, tempPoint); }
            }
            //right down
            if (currentXPos < (int)ChessLocationX.F && currentYPos < YCondition2)
            {
                Point tempPoint = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos + (int)MOVE.DOWN_Y);
                if (!BoardData.GetStatus_AtPosition(tempPoint, _piece.PieceColor))
                { Create(_ptbBoard, tempPoint); }
            }
        }
    }
}
