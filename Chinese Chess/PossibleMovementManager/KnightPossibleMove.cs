using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class KnightPossibleMove : Possible_Move_Circle
    {
        public Pieces _piece;
        public PictureBox _ptbBoard;
        public BoardStatusData boardStatus = new BoardStatusData();
        public KnightPossibleMove(PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }

        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;

            Point CenterPoint_Up = new Point(currentXPos, currentYPos + (int)MOVE.UP_Y);
            Point CenterPoint_Down = new Point(currentXPos, currentYPos + (int)MOVE.DOWN_Y);
            Point CenterPoint_Right = new Point(currentXPos + (int)MOVE.RIGHT_X, currentYPos);
            Point CenterPoint_Left = new Point(currentXPos + (int)MOVE.LEFT_X, currentYPos);
            // right up
            if (currentXPos < (int)ChessLocationX.J && currentYPos > (int)ChessLocationY._9)
            {
                Point MovePoint1 = new Point(currentXPos + (int)MOVE.RIGHT_X * 1, currentYPos + (int)MOVE.UP_Y * 2);
                if (checkPointLegal(MovePoint1))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint1, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(CenterPoint_Up, ChessColor.RED) == false
                    && boardStatus.GetStatus_AtPosition(CenterPoint_Up, ChessColor.BLACK) == false)
                    { Create(_ptbBoard, MovePoint1); }
                }
                Point MovePoint2 = new Point(currentXPos + (int)MOVE.RIGHT_X * 2, currentYPos + (int)MOVE.UP_Y * 1);
                if (checkPointLegal(MovePoint2))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint2, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(CenterPoint_Right, ChessColor.RED) == false
                    && boardStatus.GetStatus_AtPosition(CenterPoint_Right, ChessColor.BLACK) == false)
                    { Create(_ptbBoard, MovePoint2); }
                }   
            }
            // right down
            if (currentXPos < (int)ChessLocationX.J && currentYPos < (int)ChessLocationY._0)
            {
                Point MovePoint1 = new Point(currentXPos + (int)MOVE.RIGHT_X * 1, currentYPos + (int)MOVE.DOWN_Y * 2);
                if (checkPointLegal(MovePoint1))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint1, _piece.PieceColor) == false
                    && boardStatus.GetStatus_AtPosition(CenterPoint_Down, ChessColor.RED) == false
                    && boardStatus.GetStatus_AtPosition(CenterPoint_Down, ChessColor.BLACK) == false)
                    { Create(_ptbBoard, MovePoint1); }
                }
                    
                Point MovePoint2 = new Point(currentXPos + (int)MOVE.RIGHT_X * 2, currentYPos + (int)MOVE.DOWN_Y * 1);
                if (checkPointLegal(MovePoint2))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint2, _piece.PieceColor) == false
                   && boardStatus.GetStatus_AtPosition(CenterPoint_Right, ChessColor.RED) == false
                   && boardStatus.GetStatus_AtPosition(CenterPoint_Right, ChessColor.BLACK) == false)
                    { Create(_ptbBoard, MovePoint2); }
                }    
            }
            // left up
            if (currentXPos > (int)ChessLocationX.A && currentYPos > (int)ChessLocationY._9)
            {
                Point MovePoint1 = new Point(currentXPos + (int)MOVE.LEFT_X * 1, currentYPos + (int)MOVE.UP_Y * 2);
                if (checkPointLegal(MovePoint1))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint1, _piece.PieceColor) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Up, ChessColor.RED) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Up, ChessColor.BLACK) == false)
                        { Create(_ptbBoard, MovePoint1); }
                }
                Point MovePoint2 = new Point(currentXPos + (int)MOVE.LEFT_X * 2, currentYPos + (int)MOVE.UP_Y * 1);
                if (checkPointLegal(MovePoint2))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint2, _piece.PieceColor) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Left, ChessColor.RED) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Left, ChessColor.BLACK) == false)
                        { Create(_ptbBoard, MovePoint2); }
                }      
            }
            // left down
            if (currentXPos > (int)ChessLocationX.A && currentYPos < (int)ChessLocationY._0)
            {
                Point MovePoint1 = new Point(currentXPos + (int)MOVE.LEFT_X * 1, currentYPos + (int)MOVE.DOWN_Y * 2);
                if (checkPointLegal(MovePoint1))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint1, _piece.PieceColor) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Down, ChessColor.RED) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Down, ChessColor.BLACK) == false)
                        { Create(_ptbBoard, MovePoint1); }
                }
                Point MovePoint2 = new Point(currentXPos + (int)MOVE.LEFT_X * 2, currentYPos + (int)MOVE.DOWN_Y * 1);
                if (checkPointLegal(MovePoint2))
                {
                    if (boardStatus.GetStatus_AtPosition(MovePoint2, _piece.PieceColor) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Left, ChessColor.RED) == false
                        && boardStatus.GetStatus_AtPosition(CenterPoint_Left, ChessColor.BLACK) == false)
                        { Create(_ptbBoard, MovePoint2); }  
                }
            }

        }
    }
}
