using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class CheckMate_Rule
    {
        public PictureBox ptb_ChessBoard;
        public static Piece_King myPieceKing = null;
        public static Piece_King enermyPieceKing = null;

        public static bool CheckMateStatus_Me;
        public static bool CheckMateStatus_Enermy;
        public CheckMate_Rule( PictureBox _ptb_ChessBoard)
        {
            this.ptb_ChessBoard = _ptb_ChessBoard;
        }

        public void RealTime_CheckMate()
        {
            // only get king piece 1 time
            if (myPieceKing == null || enermyPieceKing == null) { if (!get_pieceKing()) { return; } }

            if (CheckMate_Algorithm(myPieceKing)) { CheckMateStatus_Me = true; myPieceKing.BackColor = Color.LimeGreen; }
            else { CheckMateStatus_Me = false; myPieceKing.BackColor = Color.Transparent; }
            if (CheckMate_Algorithm(enermyPieceKing)) { CheckMateStatus_Enermy = true; enermyPieceKing.BackColor = Color.LimeGreen; }
            else { CheckMateStatus_Enermy = false; enermyPieceKing.BackColor = Color.Transparent; }
        }

        public bool get_pieceKing()
        {
            foreach (Control control in ptb_ChessBoard.Controls)
            {
                if (control is Pieces piece && piece.GetType() == typeof(Piece_King))
                {
                    if ((int)piece.PieceColor == Player._MySide)
                    {
                        myPieceKing = piece as Piece_King;
                    }
                    else
                    {
                        enermyPieceKing = piece as Piece_King;
                    }
                }
            }

            // return true if find 2 kings completed
            if (myPieceKing != null && enermyPieceKing != null) { return true; }
            else { return false; }
        }

        public bool CheckMate_Algorithm(Piece_King sampleKing)
        {
            int sampleKing_XPos = sampleKing.Location.X;
            int sampleKing_YPos = sampleKing.Location.Y;

            Point Knight_CM_CenterPoint_UpRight = new Point(sampleKing_XPos + (int)MOVE.RIGHT_X, sampleKing_YPos + (int)MOVE.UP_Y);
            Point Knight_CM_CenterPoint_UpLeft = new Point(sampleKing_XPos + (int)MOVE.LEFT_X, sampleKing_YPos + (int)MOVE.UP_Y);
            Point Knight_CM_CenterPoint_DownRight= new Point(sampleKing_XPos + (int)MOVE.RIGHT_X, sampleKing_YPos + (int)MOVE.DOWN_Y);
            Point Knight_CM_CenterPoint_DownLeft = new Point(sampleKing_XPos + (int)MOVE.LEFT_X, sampleKing_YPos + (int)MOVE.DOWN_Y);

            bool _1pieceExist = false;
            bool _moreThan2pieceExist = false;
            ChessColor enermyKingColor;

            Point Soldier_CM_Right_Pos = new Point(sampleKing_XPos + (int)MOVE.RIGHT_X, sampleKing_YPos);
            Point Soldier_CM_Left_Pos = new Point(sampleKing_XPos + (int)MOVE.LEFT_X, sampleKing_YPos);
            Point Soldier_CM_UpDown_Pos;

            if (sampleKing.PieceColor == ChessColor.RED) { enermyKingColor = ChessColor.BLACK; Soldier_CM_UpDown_Pos = new Point(sampleKing_XPos, sampleKing_YPos + (int)MOVE.UP_Y); }
            else { enermyKingColor = ChessColor.RED; Soldier_CM_UpDown_Pos = new Point(sampleKing_XPos, sampleKing_YPos + (int)MOVE.DOWN_Y); }
            // right
            while (sampleKing_XPos < (int)ChessLocationX.J)
            {
                sampleKing_XPos += (int)MOVE.RIGHT_X;
                Point CheckPoint = new Point(sampleKing_XPos, sampleKing_YPos);
                if ((isThisPiece_inPos(typeof(Piece_King), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Chariot), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Soldier), enermyKingColor, CheckPoint) == true && (CheckPoint == Soldier_CM_Right_Pos || CheckPoint == Soldier_CM_Left_Pos || CheckPoint == Soldier_CM_UpDown_Pos))
                    || (isThisPiece_inPos(typeof(Piece_Cannon), enermyKingColor, CheckPoint) == true && _1pieceExist == true && _moreThan2pieceExist == false))
                { return true; }
                else
                {
                    // already exist -> more than 2 piece
                    if (isThisPiece_inPos(null, null, CheckPoint) == true && _1pieceExist == true) { _moreThan2pieceExist = true; }
                    else if (isThisPiece_inPos(null, null, CheckPoint) == true) { _1pieceExist = true; }
                }
            }


            reset_Var(sampleKing, ref sampleKing_XPos, ref sampleKing_YPos, ref _1pieceExist, ref _moreThan2pieceExist);
            // left
            while (sampleKing_XPos > (int)ChessLocationX.A)
            {
                sampleKing_XPos += (int)MOVE.LEFT_X;
                Point CheckPoint = new Point(sampleKing_XPos, sampleKing_YPos);
                if ((isThisPiece_inPos(typeof(Piece_King), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Chariot), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Soldier), enermyKingColor, CheckPoint) == true && (CheckPoint == Soldier_CM_Right_Pos || CheckPoint == Soldier_CM_Left_Pos || CheckPoint == Soldier_CM_UpDown_Pos))
                    || (isThisPiece_inPos(typeof(Piece_Cannon), enermyKingColor, CheckPoint) == true && _1pieceExist == true && _moreThan2pieceExist == false))
                { return true; }
                else
                {
                    // already exist -> more than 2 piece
                    if (isThisPiece_inPos(null, null, CheckPoint) == true && _1pieceExist == true) { _moreThan2pieceExist = true; }
                    else if (isThisPiece_inPos(null, null, CheckPoint) == true) { _1pieceExist = true; }
                }
            }

            reset_Var(sampleKing, ref sampleKing_XPos, ref sampleKing_YPos, ref _1pieceExist, ref _moreThan2pieceExist);
            // up
            while (sampleKing_YPos > (int)ChessLocationY._9)
            {
                sampleKing_YPos += (int)MOVE.UP_Y;
                Point CheckPoint = new Point(sampleKing_XPos, sampleKing_YPos);
                if ((isThisPiece_inPos(typeof(Piece_King), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Chariot), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Soldier), enermyKingColor, CheckPoint) == true && (CheckPoint == Soldier_CM_Right_Pos || CheckPoint == Soldier_CM_Left_Pos || CheckPoint == Soldier_CM_UpDown_Pos))
                    || (isThisPiece_inPos(typeof(Piece_Cannon), enermyKingColor, CheckPoint) == true && _1pieceExist == true && _moreThan2pieceExist == false))
                { return true; }
                else
                {
                    // already exist -> more than 2 piece
                    if (isThisPiece_inPos(null, null, CheckPoint) == true && _1pieceExist == true) { _moreThan2pieceExist = true; }
                    else if (isThisPiece_inPos(null, null, CheckPoint) == true) { _1pieceExist = true; }
                }
            }

            reset_Var(sampleKing, ref sampleKing_XPos, ref sampleKing_YPos, ref _1pieceExist, ref _moreThan2pieceExist);
            // down
            while (sampleKing_YPos < (int)ChessLocationY._0)
            {
                sampleKing_YPos += (int)MOVE.DOWN_Y;
                Point CheckPoint = new Point(sampleKing_XPos, sampleKing_YPos);
                if ((isThisPiece_inPos(typeof(Piece_King), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Chariot), enermyKingColor, CheckPoint) == true && _1pieceExist == false)
                    || (isThisPiece_inPos(typeof(Piece_Soldier), enermyKingColor, CheckPoint) == true && (CheckPoint == Soldier_CM_Right_Pos || CheckPoint == Soldier_CM_Left_Pos || CheckPoint == Soldier_CM_UpDown_Pos))
                    || (isThisPiece_inPos(typeof(Piece_Cannon), enermyKingColor, CheckPoint) == true && _1pieceExist == true && _moreThan2pieceExist == false))
                { return true; }
                else
                {
                    // already exist -> more than 2 piece
                    if (isThisPiece_inPos(null, null, CheckPoint) == true && _1pieceExist == true) { _moreThan2pieceExist = true; }
                    else if (isThisPiece_inPos(null, null, CheckPoint) == true) { _1pieceExist = true; }
                }
            }

            reset_Var(sampleKing, ref sampleKing_XPos, ref sampleKing_YPos, ref _1pieceExist, ref _moreThan2pieceExist);
            // right up
            if (sampleKing_XPos < (int)ChessLocationX.J && sampleKing_YPos > (int)ChessLocationY._9)
            {
                Point MovePoint1 = new Point(sampleKing_XPos + (int)MOVE.RIGHT_X * 1, sampleKing_YPos + (int)MOVE.UP_Y * 2);
                Point MovePoint2 = new Point(sampleKing_XPos + (int)MOVE.RIGHT_X * 2, sampleKing_YPos + (int)MOVE.UP_Y * 1);
                if ((isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint1) == true || isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint2) == true)
                    && isThisPiece_inPos(null, null, Knight_CM_CenterPoint_UpRight) == false)
                { return true; }
            }

            // right down
            if (sampleKing_XPos < (int)ChessLocationX.J && sampleKing_YPos < (int)ChessLocationY._0)
            {
                Point MovePoint1 = new Point(sampleKing_XPos + (int)MOVE.RIGHT_X * 1, sampleKing_YPos + (int)MOVE.DOWN_Y * 2);
                Point MovePoint2 = new Point(sampleKing_XPos + (int)MOVE.RIGHT_X * 2, sampleKing_YPos + (int)MOVE.DOWN_Y * 1);
                if ((isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint1) == true || isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint2) == true)
                    && isThisPiece_inPos(null, null, Knight_CM_CenterPoint_DownRight) == false)
                { return true; }
            }

            // left up
            if (sampleKing_XPos > (int)ChessLocationX.A && sampleKing_YPos > (int)ChessLocationY._9)
            {
                Point MovePoint1 = new Point(sampleKing_XPos + (int)MOVE.LEFT_X * 1, sampleKing_YPos + (int)MOVE.UP_Y * 2);
                Point MovePoint2 = new Point(sampleKing_XPos + (int)MOVE.LEFT_X * 2, sampleKing_YPos + (int)MOVE.UP_Y * 1);
                if ((isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint1) == true || isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint2) == true)
                    && isThisPiece_inPos(null, null, Knight_CM_CenterPoint_UpLeft) == false)
                { return true; }
            }

            // left down
            if (sampleKing_XPos > (int)ChessLocationX.A && sampleKing_YPos < (int)ChessLocationY._0)
            {
                Point MovePoint1 = new Point(sampleKing_XPos + (int)MOVE.LEFT_X * 1, sampleKing_YPos + (int)MOVE.DOWN_Y * 2);
                Point MovePoint2 = new Point(sampleKing_XPos + (int)MOVE.LEFT_X * 2, sampleKing_YPos + (int)MOVE.DOWN_Y * 1);
                if ((isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint1) == true || isThisPiece_inPos(typeof(Piece_Knight), enermyKingColor, MovePoint2) == true)
                    && isThisPiece_inPos(null, null, Knight_CM_CenterPoint_DownLeft) == false)
                { return true; }
            }

            return false;
        }

        //reset var value function
        public void reset_Var(Piece_King sampleKing, ref int sampleKing_XPos, ref int sampleKing_YPos, ref bool _1pieceExist, ref bool _moreThan2pieceExist)
        {
            sampleKing_XPos = sampleKing.Location.X;
            sampleKing_YPos = sampleKing.Location.Y;
            _1pieceExist = false;
            _moreThan2pieceExist = false;
        }

        public bool isThisPiece_inPos(Type findPieceType = null, ChessColor? pieceColor = null, Point? findPoint = null)
        {
            bool bExist = false;
            foreach (Control control in ptb_ChessBoard.Controls)
            {
                if (control is Pieces piece)
                {
                    if ( findPieceType == null && pieceColor == null)   // search all 2 side  + all piece
                    {
                        if (piece.Location == findPoint) { bExist = true; }
                    }
                    else if (findPieceType == null) // search all piece in 1 side
                    {
                        if (piece.PieceColor == pieceColor && piece.Location == findPoint) { bExist = true; }
                    }
                    else if (pieceColor == null)    // search 2 side of special piece
                    {
                        if (piece.GetType() == findPieceType && piece.Location == findPoint) { bExist = true; }
                    }
                    else
                    {
                        if (piece.PieceColor == pieceColor && piece.GetType() == findPieceType && piece.Location == findPoint) { bExist = true; }
                    }
                }
            }
            return bExist;
        }
    }
}
