using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class CannonPossibleMove : Possible_Move_Circle
    {
        public Pieces _piece;
        public PictureBox _ptbBoard;
        public BoardStatusData boardStatus = new BoardStatusData();
        public CannonPossibleMove(PictureBox ptbBoard, Pieces piece)
        {
            this._piece = piece;
            this._ptbBoard = ptbBoard;
        }

        public void Draw()
        {
            int currentXPos = _piece.Location.X;
            int currentYPos = _piece.Location.Y;
            int iTotalNumOfPieces = 0;

            // right
            while (currentXPos < (int)ChessLocationX.J)
            {
                currentXPos += (int)MOVE.RIGHT_X;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                    && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    // stop if meet another piece (both allies and enermy)
                    if (iTotalNumOfPieces == 0) { Create(_ptbBoard, PossiblePoint); }
                }
                else { iTotalNumOfPieces += 1; }
                // able to take enermy's piece
                if (iTotalNumOfPieces == 2)
                {
                    if (_piece.PieceColor == ChessColor.RED && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK)) { Create(_ptbBoard, PossiblePoint); }
                    if (_piece.PieceColor == ChessColor.BLACK && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)) { Create(_ptbBoard, PossiblePoint); }
                }
            }

            // reset var
            currentXPos = _piece.Location.X;
            currentYPos = _piece.Location.Y;
            iTotalNumOfPieces = 0;
            // left
            while (currentXPos > (int)ChessLocationX.A)
            {
                currentXPos += (int)MOVE.LEFT_X;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                    && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    // stop if meet another piece (both allies and enermy)
                    if (iTotalNumOfPieces == 0) { Create(_ptbBoard, PossiblePoint); }
                }
                else { iTotalNumOfPieces += 1; }
                // able to take enermy's piece
                if (iTotalNumOfPieces == 2)
                {
                    if (_piece.PieceColor == ChessColor.RED && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK)) { Create(_ptbBoard, PossiblePoint); }
                    if (_piece.PieceColor == ChessColor.BLACK && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)) { Create(_ptbBoard, PossiblePoint); }
                }
            }

            // reset var
            currentXPos = _piece.Location.X;
            currentYPos = _piece.Location.Y;
            iTotalNumOfPieces = 0;
            // up
            while (currentYPos > (int)ChessLocationY._9)
            {
                currentYPos += (int)MOVE.UP_Y;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                        && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    // stop if meet another piece (both allies and enermy)
                    if (iTotalNumOfPieces == 0) { Create(_ptbBoard, PossiblePoint); }
                }
                else { iTotalNumOfPieces += 1; }
                // able to take enermy's piece
                if (iTotalNumOfPieces == 2)
                {
                    if (_piece.PieceColor == ChessColor.RED && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK)) { Create(_ptbBoard, PossiblePoint); }
                    if (_piece.PieceColor == ChessColor.BLACK && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)) { Create(_ptbBoard, PossiblePoint); }
                }
            }
            // reset var
            currentXPos = _piece.Location.X;
            currentYPos = _piece.Location.Y;
            iTotalNumOfPieces = 0;
            // down
            while (currentYPos < (int)ChessLocationY._0)
            {
                currentYPos += (int)MOVE.DOWN_Y;
                Point PossiblePoint = new Point(currentXPos, currentYPos);
                if (!boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)
                        && !boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK))
                {
                    // stop if meet another piece (both allies and enermy)
                    if (iTotalNumOfPieces == 0) { Create(_ptbBoard, PossiblePoint); }
                }
                else { iTotalNumOfPieces += 1; }
                // able to take enermy's piece
                if (iTotalNumOfPieces == 2)
                {
                    if (_piece.PieceColor == ChessColor.RED && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.BLACK)) { Create(_ptbBoard, PossiblePoint); }
                    if (_piece.PieceColor == ChessColor.BLACK && boardStatus.GetStatus_AtPosition(PossiblePoint, ChessColor.RED)) { Create(_ptbBoard, PossiblePoint); }
                }
            }
        }
    }
}
