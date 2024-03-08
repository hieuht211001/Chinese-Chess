using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class ChariotPossibleMove : Possible_Move_Circle
    {
        public Pieces _piece;
        public PictureBox _ptbBoard;
        public BoardStatusData boardStatus = new BoardStatusData();
        public ChariotPossibleMove(PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }

        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;

            // right
           while (currentXPos < (int)ChessLocationX.J)
            {
                currentXPos += (int)MOVE.RIGHT_X;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                    && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    Create(_ptbBoard, PossiblePoint);
                }
                if (_piece.PieceColor == ChessColor.RED)
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        currentXPos = (int)ChessLocationX.J;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentXPos = (int)ChessLocationX.J;
                    }
                }
                else
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        currentXPos = (int)ChessLocationX.J;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentXPos = (int)ChessLocationX.J;
                    }
                }
            }
            // reset var
            currentXPos = _piece.Location.X;
            currentYPos = _piece.Location.Y;
            // left
            while (currentXPos > (int)ChessLocationX.A)
            {
                currentXPos += (int)MOVE.LEFT_X;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                    && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    Create(_ptbBoard, PossiblePoint);
                }
                if (_piece.PieceColor == ChessColor.RED)
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        currentXPos = (int)ChessLocationX.A;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentXPos = (int)ChessLocationX.A;
                    }
                }
                else
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        currentXPos = (int)ChessLocationX.A;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentXPos = (int)ChessLocationX.A;
                    }
                }
            }
            // reset var
            currentXPos = _piece.Location.X;
            currentYPos = _piece.Location.Y;
            // up
            while (currentYPos > (int)ChessLocationY._9)
            {
                currentYPos += (int)MOVE.UP_Y;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                        && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    Create(_ptbBoard, PossiblePoint);
                }
                if (_piece.PieceColor == ChessColor.RED)
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        currentYPos = (int)ChessLocationY._9;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentYPos = (int)ChessLocationY._9;
                    }
                }
                else
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        currentYPos = (int)ChessLocationY._9;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentYPos = (int)ChessLocationY._9;
                    }
                }
            }
            // reset var
            currentXPos = _piece.Location.X;
            currentYPos = _piece.Location.Y;
            // up
            while (currentYPos < (int)ChessLocationY._0)
            {
                currentYPos += (int)MOVE.DOWN_Y;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                        && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    Create(_ptbBoard, PossiblePoint);
                }
                if (_piece.PieceColor == ChessColor.RED)
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        currentYPos = (int)ChessLocationY._0;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentYPos = (int)ChessLocationY._0;
                    }
                }
                else
                {
                    if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                    {
                        currentYPos = (int)ChessLocationY._0;
                    }
                    else if (boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED))
                    {
                        Create(_ptbBoard, PossiblePoint);
                        currentYPos = (int)ChessLocationY._0;
                    }
                }
            }
        }
    }
}
