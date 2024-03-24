using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class ElephantPossibleMove: Possible_Move_Circle
    {
        public Pieces _piece;
        public PictureBox _ptbBoard;
        public BoardStatusData boardStatus = new BoardStatusData();
        public ElephantPossibleMove(PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }
        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;

            int YCondition1, YCondition2;
            ChessColor enermyPieceColor;
            if (_piece.PieceColor == ChessColor.RED) { YCondition1 = (int)ChessLocationY._3; YCondition2 = (int)ChessLocationY._0; enermyPieceColor = ChessColor.BLACK; }
            else { YCondition1 = (int)ChessLocationY._9; YCondition2 = (int)ChessLocationY._6; enermyPieceColor = ChessColor.RED; }

            // right up
            if (currentXPos < (int)ChessLocationX.J && currentYPos > YCondition1)
            {
                Point Step1 = new Point(currentXPos + (int)MOVE.RIGHT_X * 2, currentYPos + (int)MOVE.UP_Y * 2);
                Point Step2 = new Point(currentXPos + (int)MOVE.RIGHT_X , currentYPos + (int)MOVE.UP_Y);
                if (checkPointLegal(Step1) && checkPointLegal(Step2))
                {
                    if (boardStatus.GetStatus_AtPosition(Step1, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(Step2, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(Step2, enermyPieceColor) == false)
                    { Create(_ptbBoard, Step1); }
                }   
            }
            // left up
            if (currentXPos > (int)ChessLocationX.A && currentYPos > YCondition1)
            {
                Point Step1 = new Point(currentXPos + (int)MOVE.LEFT_X * 2, currentYPos + (int)MOVE.UP_Y * 2);
                Point Step2 = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos + (int)MOVE.UP_Y);
                if (checkPointLegal(Step1) && checkPointLegal(Step2))
                {
                    if (boardStatus.GetStatus_AtPosition(Step1, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(Step2, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(Step2, enermyPieceColor) == false)
                    { Create(_ptbBoard, Step1); }
                }      
            }
            // left down
            if (currentXPos > (int)ChessLocationX.A && currentYPos < YCondition2)
            {
                Point Step1 = new Point(currentXPos + (int)MOVE.LEFT_X * 2, currentYPos + (int)MOVE.DOWN_Y * 2);
                Point Step2 = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos + (int)MOVE.DOWN_Y);
                if (checkPointLegal(Step1) && checkPointLegal(Step2))
                {
                    if (boardStatus.GetStatus_AtPosition(Step1, _piece.PieceColor) == false
                   && boardStatus.GetStatus_AtPosition(Step2, _piece.PieceColor) == false
                   && boardStatus.GetStatus_AtPosition(Step2, enermyPieceColor) == false)
                    { Create(_ptbBoard, Step1); }
                }
            }
            //right down
            if (currentXPos < (int)ChessLocationX.J && currentYPos < YCondition2)
            {
                Point Step1 = new Point(currentXPos + (int)MOVE.RIGHT_X * 2, currentYPos + (int)MOVE.DOWN_Y * 2);
                Point Step2 = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos + (int)MOVE.DOWN_Y);
                if (checkPointLegal(Step1) && checkPointLegal(Step2))
                {
                    if (boardStatus.GetStatus_AtPosition(Step1, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(Step2, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(Step2, enermyPieceColor) == false)
                    { Create(_ptbBoard, Step1); }
                }    
            }
        }
    }
}
