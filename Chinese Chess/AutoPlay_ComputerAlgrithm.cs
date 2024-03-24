using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class AutoPlay_ComputerAlgrithm
    {
        Form_Board form_Board;
        PictureBox ptb_chessBoard;
        Game_Sound game_Sound = new Game_Sound();
        BoardStatusData boardData = new BoardStatusData();
        Possible_Move_Circle possibleCircleUI = new Possible_Move_Circle();
        PossibleMovement_CircleData possibleCircleData = new PossibleMovement_CircleData();
        BoardStatusData boardStatus = new BoardStatusData();
        BoardStatusUI boardUI = new BoardStatusUI();
        CheckMate_Rule checkMate_Rule;
        GameOver_Rule gameOver_Rule;
        public Piece_King ComputerKing = CheckMate_Rule.enermyPieceKing;
        public static int iComputerLevel = 0;
        Random random = new Random();
        public struct Value_PiecePointPair
        {
            public PiecePointPair PiecePointPair { get; set; }
            public int Value { get; set; }

            public Value_PiecePointPair(int Value, PiecePointPair PiecePointPair)
            {
                this.PiecePointPair = PiecePointPair;
                this.Value = Value;
            }
        }


        public AutoPlay_ComputerAlgrithm(Form_Board _form_Board, PictureBox _ptb_chessBoard)
        {
            this.form_Board = _form_Board;
            this.ptb_chessBoard = _ptb_chessBoard;
            checkMate_Rule = new CheckMate_Rule(ptb_chessBoard);
            gameOver_Rule = new GameOver_Rule(ptb_chessBoard);
            //get computerking
            foreach (Control control in ptb_chessBoard.Controls)
            {
                if (control is Pieces piece && piece.GetType() == typeof(Piece_King))
                {
                    if ((int)piece.PieceColor != Player._MySide)
                    {
                        ComputerKing = piece as Piece_King;
                    }
                }
            }
        }
        public void Generate_AutoMovement(ChessColor pieceColor)
        {
            PiecePointPair BestMove = new PiecePointPair(CheckMate_Rule.enermyPieceKing, new Point(-1, -1)); //temp value
            if (checkMate_Rule.CheckMate_Algorithm(ComputerKing))
            {
                generate_CMDefendMovement(ref BestMove, pieceColor);
            }
            else
            {
                generate_NormalMove(ref BestMove, pieceColor);
            }

            if (BestMove.Point == new Point(-1, -1)) { Game_Mode.gameStatus = GAMESTATUS.VICTORY; return; }

            // move calculated piece
            game_Sound.Add(SOUNDTYPE.NORMAL_MOVE);
            Point BeforePos = BestMove.Piece.Location;
            Point AfterPos = BestMove.Point;
            BestMove.Piece.Location = AfterPos;
            boardStatus.ChangeDataStatus_AfterMove(BestMove.Piece, BeforePos, AfterPos);
            boardUI.Refresh(form_Board, ptb_chessBoard);
            //boardUI.SaveNSend_MyMoves(BeforePos, AfterPos);
        }

        private void generate_CMDefendMovement(ref PiecePointPair BestMove, ChessColor pieceColor)
        {
            int iValue = 0;
            int iMaxValue = 0;
            ChessColor enermyColor;
            List<Point> pieceMoveAblePos = new List<Point>();
            foreach (Control control in ptb_chessBoard.Controls)
            {
                Pieces piece = control as Pieces;
                if (piece != null)
                {
                    if (piece.PieceColor == pieceColor)  // protect king after checkmate
                    {
                        Point PieceBeforePos = piece.Location;
                        if (piece.PieceColor == ChessColor.RED) { enermyColor = ChessColor.BLACK; }
                        else { enermyColor = ChessColor.RED; }

                        // delete previous movement data
                        possibleCircleUI.Delete_All(ptb_chessBoard);
                        // delete all before piece circle data
                        possibleCircleData.Delete_All_Circle_Data();

                        // generate moveable circle
                        piece.Draw_PossibleMoves();

                        // copy moveable pos
                        pieceMoveAblePos.Clear();
                        pieceMoveAblePos = Possible_Move_Circle.circlePtb_PositionList.ToList();
                        possibleCircleUI.Delete_All(ptb_chessBoard);
                        // delete all before piece circle data
                        possibleCircleData.Delete_All_Circle_Data();

                        // create virtual piece
                        PictureBox VirtualPiece = new PictureBox();
                        gameOver_Rule.Set_VirtualPiece(ref VirtualPiece, piece);
                        // hide origin piece
                        piece.Visible = false;

                        foreach (Point moveAblePos in pieceMoveAblePos)
                        {
                            piece.Location = moveAblePos;

                            // if need to eat enermy piece to prevent checkmate
                            if (boardData.GetStatus_AtPosition(piece.Location, enermyColor))
                            {
                                foreach (Control controlEnermy in ptb_chessBoard.Controls)
                                {
                                    if (controlEnermy is Pieces pieceEnermy && pieceEnermy.PieceColor == enermyColor)
                                    {
                                        if (piece.Location == pieceEnermy.Location)
                                        {
                                            // create virtual piece
                                            PictureBox VirtualPieceEnermy = new PictureBox();
                                            gameOver_Rule.Set_VirtualPiece(ref VirtualPieceEnermy, pieceEnermy);
                                            // hide origin piece
                                            ptb_chessBoard.Controls.Remove(pieceEnermy);
                                            if (!checkMate_Rule.CheckMate_Algorithm(ComputerKing)) 
                                            { 
                                                iValue = 2;
                                                if (iValue > iMaxValue)
                                                {
                                                    iMaxValue = iValue;
                                                    BestMove = new PiecePointPair(piece, piece.Location);
                                                }
                                            }
                                            VirtualPieceEnermy.Dispose();
                                            ptb_chessBoard.Controls.Add(pieceEnermy);
                                        }
                                    }
                                }
                            }
                            // just move
                            else
                            {
                                if (!checkMate_Rule.CheckMate_Algorithm(ComputerKing)) 
                                { 
                                    iValue =1;
                                    if (iValue > iMaxValue)
                                    {
                                        iMaxValue = iValue;
                                        BestMove = new PiecePointPair(piece, piece.Location);
                                    }
                                }
                            }
                        }
                        // delete virtual piece and show orgin piece
                        piece.Location = PieceBeforePos;
                        VirtualPiece.Dispose();
                        piece.Visible = true;
                    }
                }
            }
        }

        private void generate_NormalMove(ref PiecePointPair BestMove, ChessColor pieceColor)
        {
            int iValue = 0;
            int iMaxValue = 0;
            foreach (Control control in ptb_chessBoard.Controls)
            {
                if (control is Pieces mypiece)
                {
                    if (mypiece.PieceColor == pieceColor)
                    {
                        iValue = generate_BestMovement_1Piece(mypiece).Value;
                        if (iValue > iMaxValue)
                        {
                            iMaxValue = iValue;
                            BestMove = generate_BestMovement_1Piece(mypiece).PiecePointPair;
                        }
                        else if (iValue == iMaxValue)
                        {
                            //random select when all piece have same value
                            bool randomSelect = random.Next(2) == 0;
                            if (randomSelect)
                            {
                                iMaxValue = iValue;
                                BestMove = generate_BestMovement_1Piece(mypiece).PiecePointPair;
                            }
                        }
                    }
                }
            }
        }
        private Value_PiecePointPair generate_BestMovement_1Piece(Pieces piece)
        {
            int iValue = 0;
            int iMaxValue = 0;
            Point pieceBestPoint = piece.Location;
            List<Point> pieceMoveAblePos = new List<Point>();


            // delete previous movement data
            possibleCircleUI.Delete_All(ptb_chessBoard);
            // delete all before piece circle data
            possibleCircleData.Delete_All_Circle_Data();

            piece.Draw_PossibleMoves();
            // copy moveable pos
            pieceMoveAblePos.Clear();
            pieceMoveAblePos = Possible_Move_Circle.circlePtb_PositionList.ToList();
            possibleCircleUI.Delete_All(ptb_chessBoard);
            // delete all before piece circle data
            possibleCircleData.Delete_All_Circle_Data();

            foreach (Point Point in pieceMoveAblePos)
            {
                if (iComputerLevel == 0 )
                {
                    iValue = calculate_ProfitOfThisMove(piece, Point);
                }
                else
                {
                    iValue = calculate_ProfitOfThisMove(piece, Point) + calculate_RiskyOfThisMove(piece, Point);
                }
                if (iValue > iMaxValue) { iMaxValue = iValue; pieceBestPoint = Point; }
            }
            return new Value_PiecePointPair(iMaxValue, new PiecePointPair(piece, pieceBestPoint));
        }

        // calculate profit of this move (normal move or can take enermy piece)
        private int calculate_ProfitOfThisMove(Pieces piece, Point pieceStepPos)
        {
            int iValue = 0;
            int iMaxValue = 0;
            bool bCheckMate = false;
            Point KingBeforePos;
            // create virtual piece
            PictureBox VirtualPieceEnermy = new PictureBox();
            gameOver_Rule.Set_VirtualPiece(ref VirtualPieceEnermy, piece);
            // hide origin piece
            piece.Visible = false;
            VirtualPieceEnermy.Location = piece.Location;
            if (piece.GetType() == typeof(Piece_King))
            {
                KingBeforePos = ComputerKing.Location;
                ComputerKing.Location = pieceStepPos;
                if (checkMate_Rule.CheckMate_Algorithm(ComputerKing)) { bCheckMate = true; }
                ComputerKing.Location = KingBeforePos;
            }
            else
            {
                piece.Location = pieceStepPos;
                if (checkMate_Rule.CheckMate_Algorithm(ComputerKing)) { bCheckMate = true; }
                piece.Location = VirtualPieceEnermy.Location;
            }
            piece.Visible = true;
            VirtualPieceEnermy.Dispose();

            // if this move can make computer king will be in checkmate state
            if (bCheckMate == true)
            {
                iValue = -10;
                return iValue;
            }

            foreach (Control control in ptb_chessBoard.Controls)
            {
                if (control is Pieces pieceEnermy && pieceEnermy.PieceColor != piece.PieceColor)
                {
                    // if can take enermy Piece
                    if (pieceEnermy.Location == pieceStepPos)
                    {
                        iValue = define_PiecesDefaultValue(pieceEnermy);
                        if (iValue > iMaxValue) { iMaxValue = iValue;}
                    }
                    else
                    {
                        iValue = 1;
                        if (iValue > iMaxValue) { iMaxValue = iValue; }
                    }
                }
            }
            // if cant take enermy piece
            return iMaxValue;
        }

        // calculte risky of movement
        private int calculate_RiskyOfThisMove(Pieces myPiece, Point pieceStepPos)
        {
            int iRiskOfPredictedPos = 0;
            int iRiskOfCurrentPos = 0;
            bool bEnermyPieceExist = false;
            List<Point> enermyPieceMoveablePos = new List<Point>();
            BoardStatusData.BoardStatus[pieceStepPos] = (false, false);
            foreach (Control control in ptb_chessBoard.Controls)
            {
                if (control is Pieces pieceEnermy && pieceEnermy.PieceColor != myPiece.PieceColor)
                {
                    if (pieceEnermy.Location == pieceStepPos) { bEnermyPieceExist = true;}
                    // delete previous movement data
                    possibleCircleUI.Delete_All(ptb_chessBoard);
                    // delete all before piece circle data
                    possibleCircleData.Delete_All_Circle_Data();

                    pieceEnermy.Draw_PossibleMoves();
                    // copy moveable pos
                    enermyPieceMoveablePos.Clear();
                    enermyPieceMoveablePos = Possible_Move_Circle.circlePtb_PositionList.ToList();
                    possibleCircleUI.Delete_All(ptb_chessBoard);
                    // delete all before piece circle data
                    possibleCircleData.Delete_All_Circle_Data();

                    foreach (Point Point in enermyPieceMoveablePos)
                    {
                        if (Point == pieceStepPos) { iRiskOfPredictedPos =  0 - define_PiecesDefaultValue(myPiece); }
                        if (Point == myPiece.Location) { iRiskOfCurrentPos = 0 + define_PiecesDefaultValue(myPiece); }
                    }
                }
            }
            if (bEnermyPieceExist == true && myPiece.PieceColor == ChessColor.BLACK) { BoardStatusData.BoardStatus[pieceStepPos] = (true, false); }
            else if (bEnermyPieceExist == true && myPiece.PieceColor == ChessColor.RED) { BoardStatusData.BoardStatus[pieceStepPos] = (false, true); }
            return (iRiskOfPredictedPos + iRiskOfCurrentPos);
        }

        private int define_PiecesDefaultValue(Pieces piece)
        {
            int iValue = 0;
            if (piece.GetType() == typeof(Piece_Soldier))
            {
                iValue = 2;
                if (piece.PieceColor == ChessColor.RED && piece.Location.Y < (int)ChessLocationY._4) { iValue = 4; }
                else if (piece.PieceColor == ChessColor.BLACK && piece.Location.Y > (int)ChessLocationY._5) { iValue = 4; }
            }
            else if (piece.GetType() == typeof(Piece_Cannon))
            {
                iValue = 8;
            }
            else if (piece.GetType() == typeof(Piece_Chariot))
            {
                iValue = 8;
            }
            else if (piece.GetType() == typeof(Piece_King))
            {
                iValue = 10;
            }
            else if (piece.GetType() == typeof(Piece_Knight))
            {
                iValue = 6;
            }
            else if (piece.GetType() == typeof(Piece_Elephant))
            {
                iValue = 5;
            }
            else if (piece.GetType() == typeof(Piece_Advisor))
            {
                iValue = 5;
            }

            return iValue;
        }
    }
}
