using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class GameOver_Rule: CheckMate_Rule
    {
        public BoardStatusData boardData = new BoardStatusData();
        public Possible_Move_Circle possibleCircleUI = new Possible_Move_Circle();
        public PossibleMovement_CircleData possibleCircleData = new PossibleMovement_CircleData();

        public GameOver_Rule(PictureBox _ptb_ChessBoard) : base(_ptb_ChessBoard) { }

        public void RealTime_CheckGameStatus()
        {
            // only get king piece 1 time
            if (myPieceKing == null || enermyPieceKing == null) { if (!get_pieceKing()) { return; } }

            if (!CanDefendCheckMate(myPieceKing))
            {
                Game_Mode.gameStatus = GAMESTATUS.DEFEAT;

            }
            if (!CanDefendCheckMate(enermyPieceKing))
            {
                Game_Mode.gameStatus = GAMESTATUS.VICTORY;

            }
            if (isSlateMate_Check(myPieceKing)
                || isSlateMate_Check(enermyPieceKing))
            { Game_Mode.gameStatus = GAMESTATUS.OVER; }
        }

        public bool CanDefendCheckMate(Piece_King sampleKing )
        {
            List<Point> pieceMoveAblePos = new List<Point>();
            bool bCanDefend = false;
            Point pieceBeforePos;

            bool CheckMateCondition = false; // default value
            if (sampleKing == myPieceKing) { CheckMateCondition = CheckMateStatus_Me; }
            else if (sampleKing == enermyPieceKing) { CheckMateCondition = CheckMateStatus_Enermy; }

            if (CheckMateCondition == true && Pieces.isDragging == false )
            {
                foreach (Control control in ptb_ChessBoard.Controls)
                {
                    if (control is Pieces piece)
                    {
                        if (piece.PieceColor == sampleKing.PieceColor)  // protect king after checkmate
                        {
                            ChessColor enermyColor;
                            if (piece.PieceColor == ChessColor.RED ) { enermyColor = ChessColor.BLACK; }
                            else { enermyColor = ChessColor.RED; }

                            pieceBeforePos = piece.Location;

                            // delete previous movement data
                            possibleCircleUI.Delete_All(ptb_ChessBoard);
                            // delete all before piece circle data
                            possibleCircleData.Delete_All_Circle_Data();

                            // generate moveable circle
                            piece.Draw_PossibleMoves();

                            // copy moveable pos
                            pieceMoveAblePos.Clear();
                            pieceMoveAblePos = Possible_Move_Circle.circlePtb_PositionList.ToList();
                            possibleCircleUI.Delete_All(ptb_ChessBoard);
                            // delete all before piece circle data
                            possibleCircleData.Delete_All_Circle_Data();

                            // create virtual piece
                            PictureBox VirtualPiece = new PictureBox();
                            Set_VirtualPiece(ref VirtualPiece, piece);
                            // hide origin piece
                            piece.Visible = false;

                            foreach (Point moveAblePos in pieceMoveAblePos)
                            {
                                piece.Location = moveAblePos;

                                // if need to eat enermy piece to prevent checkmate
                                if (boardData.GetStatus_AtPosition(piece.Location, enermyColor))
                                {
                                    foreach (Control controlEnermy in ptb_ChessBoard.Controls)
                                    {
                                        if (controlEnermy is Pieces pieceEnermy && pieceEnermy.PieceColor == enermyColor)
                                        {
                                            if (piece.Location == pieceEnermy.Location)
                                            {
                                                // create virtual piece
                                                PictureBox VirtualPieceEnermy = new PictureBox();
                                                Set_VirtualPiece(ref VirtualPieceEnermy, pieceEnermy);
                                                // hide origin piece
                                                ptb_ChessBoard.Controls.Remove(pieceEnermy);
                                                if (!CheckMate_Algorithm(sampleKing)) { bCanDefend = true; }
                                                VirtualPieceEnermy.Dispose();
                                                ptb_ChessBoard.Controls.Add(pieceEnermy);
                                            }
                                        }
                                    }
                                }
                                // just move
                                else
                                {
                                    if (!CheckMate_Algorithm(sampleKing)) { bCanDefend = true; }
                                }
                            }

                            // delete virtual piece and show orgin piece
                            piece.Location = pieceBeforePos;
                            VirtualPiece.Dispose();
                            piece.Visible = true;
                            if (bCanDefend) { return bCanDefend; }
                        }
                    }
                }
                return false;
            }
            return true;
        }

        public void Set_VirtualPiece(ref PictureBox VirtualPiece, PictureBox piece)
        {
            VirtualPiece.Image = piece.Image;
            VirtualPiece.SizeMode = piece.SizeMode;
            VirtualPiece.Location = piece.Location;
            VirtualPiece.Size = piece.Size;
            VirtualPiece.Padding = VirtualPiece.Padding;
        }

        // cant move any pieces when no checkmate
        public bool isSlateMate_Check(Piece_King sampleKing)
        {
            List<Point> pieceMoveAblePos = new List<Point>();
            int iTotalMoveablePos = 0;
            Point pieceBeforePos;

            bool CheckMateCondition = false; // default value
            if (sampleKing == myPieceKing) { CheckMateCondition = CheckMateStatus_Me; }
            else if (sampleKing == enermyPieceKing) { CheckMateCondition = CheckMateStatus_Enermy; }

            
            if (CheckMateCondition == false && Pieces.isDragging == false )  // no checkmate status
            {
                foreach (Control control in ptb_ChessBoard.Controls)
                {
                    if (control is Pieces piece)
                    {
                        if (piece.PieceColor == sampleKing.PieceColor)  // protect king after checkmate
                        {
                            pieceBeforePos = piece.Location;

                            // delete previous movement data
                            possibleCircleUI.Delete_All(ptb_ChessBoard);
                            // delete all before piece circle data
                            possibleCircleData.Delete_All_Circle_Data();

                            piece.Draw_PossibleMoves();
                            // copy moveable pos
                            pieceMoveAblePos.Clear();
                            pieceMoveAblePos = Possible_Move_Circle.circlePtb_PositionList.ToList();
                            possibleCircleUI.Delete_All(ptb_ChessBoard);
                            // delete all before piece circle data
                            possibleCircleData.Delete_All_Circle_Data();

                            // create virtual piece
                            PictureBox VirtualPiece = new PictureBox();
                            Set_VirtualPiece(ref VirtualPiece, piece);
                            // hide origin piece
                            piece.Visible = false;

                            foreach (Point moveAblePos in pieceMoveAblePos)
                            {
                                piece.Location = moveAblePos;
                                if (!CheckMate_Algorithm(sampleKing)) { iTotalMoveablePos += pieceMoveAblePos.Count; }
                            }

                            // delete virtual piece and show orgin piece
                            piece.Location = pieceBeforePos;
                            VirtualPiece.Dispose();
                            piece.Visible = true;
                        }
                    }
                }
                if (iTotalMoveablePos == 0) return true;
            }
            return false;
        }
    }
}
