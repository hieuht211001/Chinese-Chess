﻿using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace Chinese_Chess
{
   public class Board
    {
        public Form_Board form_Board;
        public BoardStatusData boardData = new BoardStatusData();
        public PictureBox ptb_ChessBoard;
        private System.Windows.Forms.Timer timer;
        public Player player = new Player();
        public BoardStatusData boardStatus = new BoardStatusData();
        public BoardStatusUI boardUI = new BoardStatusUI();
        public GetSet_RealTimePosition getSet_RealTimePosition = new GetSet_RealTimePosition();
        public Board(Form_Board _form, PictureBox _ptb_ChessBoard)
        {
            this.form_Board = _form;
            this.ptb_ChessBoard = _ptb_ChessBoard;
        }

        public void Create()
        {
            Set_Ini_Data();

            List<(Type, ChessColor)> piecesInfoKing = new List<(Type, ChessColor)>
            {
                (typeof(Piece_King), ChessColor.BLACK),
                (typeof(Piece_King), ChessColor.RED),
            };

            List<(Type, ChessColor, int)> piecesInfo = new List<(Type, ChessColor, int)> {};

            for (int i = 0; i < 2; i++)
            {
                piecesInfo.Add((typeof(Piece_Cannon), ChessColor.BLACK, i));
                piecesInfo.Add((typeof(Piece_Cannon), ChessColor.RED, i));
                piecesInfo.Add((typeof(Piece_Chariot), ChessColor.BLACK, i));
                piecesInfo.Add((typeof(Piece_Chariot), ChessColor.RED, i));
                piecesInfo.Add((typeof(Piece_Knight), ChessColor.BLACK, i));
                piecesInfo.Add((typeof(Piece_Knight), ChessColor.RED, i));
                piecesInfo.Add((typeof(Piece_Elephant), ChessColor.BLACK, i));
                piecesInfo.Add((typeof(Piece_Elephant), ChessColor.RED, i));
                piecesInfo.Add((typeof(Piece_Advisor), ChessColor.BLACK, i));
                piecesInfo.Add((typeof(Piece_Advisor), ChessColor.RED, i));
            }

            for (int i = 0; i < 5; i++)
            {
                piecesInfo.Add((typeof(Piece_Soldier), ChessColor.BLACK, i));
                piecesInfo.Add((typeof(Piece_Soldier), ChessColor.RED, i));
            }

            foreach (var info in piecesInfo)
            {
                Pieces piece = (Pieces)Activator.CreateInstance(info.Item1, form_Board, ptb_ChessBoard, info.Item2, info.Item3);
                piece.Create();
            }

            foreach (var info in piecesInfoKing)
            {
                Pieces piece = (Pieces)Activator.CreateInstance(info.Item1, form_Board, ptb_ChessBoard, info.Item2);
                piece.Create();
            }

        }

        public void Set_Ini_Data()
        {
            BoardStatusData boardData = new BoardStatusData();
            PossibleMovement_CircleData circleData = new PossibleMovement_CircleData();
            circleData.Set_Circle_Ini_Status();
            boardData.Set_Board_Ini_Status();
        }

        public void DeleteCurrentBoard()
        {
            timer.Stop();
            for (int i = form_Board.Controls.Count - 1; i >= 0; i--)
            {
                Control control = form_Board.Controls[i];
                if (control.Name != nameof(ptb_ChessBoard))
                {
                    form_Board.Controls.RemoveAt(i);
                    if (control.Tag != null && control.Tag.ToString() == "deletedPieceQueue")
                    {
                        continue;
                    }
                    control.Dispose(); // dispose control
                }
            }
            for (int i = ptb_ChessBoard.Controls.Count - 1; i >= 0; i--)
            {
                Control control = ptb_ChessBoard.Controls[i];
                ptb_ChessBoard.Controls.RemoveAt(i);
                control.Dispose(); // dispose control
            }
            timer.Start();
        }

        public static Dictionary<Point, (bool, bool)> tempBoardStatus = new Dictionary<Point, (bool, bool)>();
        public void RealTimeUpdate()
        {
            CheckMate_Rule checkMate_Rule = new CheckMate_Rule(ptb_ChessBoard);
            GameOver_Rule gameOver_Rule = new GameOver_Rule(ptb_ChessBoard);
            AutoPlay_ComputerAlgrithm autoPlay_ComputerAlgrithm = new AutoPlay_ComputerAlgrithm(form_Board, ptb_ChessBoard);
            ChessColor computerSide;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                // only start when 2 players connected
                if (Game_Mode.gameStatus == GAMESTATUS.READY_TOSTART)
                {
                    // compare board status to prevent loop
                    bool areBoardStatusEqual = AreDictionariesEqual(tempBoardStatus, BoardStatusData.BoardStatus);

                    if (Game_Mode.gameStyle == GAMESTYLE.ALONE) // alone mode
                    {
                        Player._MySide = (int)ChessColor.RED;   //red start first
                        enablePieceByPlayerTurn();
                        if (Pieces.isDragging == false) { boardUI.Refresh(form_Board, ptb_ChessBoard); }
                    }
                    else if (Game_Mode.gameStyle == GAMESTYLE.WITH_FRIEND)   //dual mode
                    {
                        // set up first turn
                        enablePieceByPlayerTurn();
                        if (BoardStatusUI.EnermyMoveStep == "Surrender!")
                        {
                            timer.Stop();
                            BoardStatusUI.EnermyMoveStep = "Reseted!";
                            Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "The opponent has surrendered!");
                            form_Message.ShowMessage();
                            if (form_Message.bYesOrNoClicked == true) { Game_Mode.gameStatus = GAMESTATUS.VICTORY; }
                        }
                        else if (BoardStatusUI.EnermyMoveStep == "Draw Request!")
                        {
                            timer.Stop();
                            BoardStatusUI.EnermyMoveStep = "Reseted!";
                            Form_Message form_Message = new Form_Message(MessageBoxMode.ALARM, "The opponent wants to seek a draw?");
                            form_Message.ShowMessage();
                            if (form_Message.bYesOrNoClicked == true)
                            {
                                Game_Mode.gameStatus = GAMESTATUS.OVER;
                                getSet_RealTimePosition.Send_MyMovement("Draw Accepted!");
                            }
                            else { BoardStatusUI.MyMoveStep = "Draw Rejected!"; getSet_RealTimePosition.Send_MyMovement("Draw Rejected!"); }
                        }
                        else if (BoardStatusUI.EnermyMoveStep == "Draw Accepted!")
                        {
                            timer.Stop();
                            BoardStatusUI.EnermyMoveStep = "Reseted!";
                            Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "The opponent accept draw!");
                            form_Message.ShowMessage();
                            Game_Mode.gameStatus = GAMESTATUS.OVER;
                        }
                        else if (BoardStatusUI.EnermyMoveStep == "Draw Rejected!")
                        {
                            timer.Stop();
                            BoardStatusUI.EnermyMoveStep = "Reseted!";
                            Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "The opponent reject draw!");
                            form_Message.ShowMessage();
                            timer.Start();
                        }
                        // get realtime enermy move and change turn
                        else if (BoardStatusUI.EnermyMoveStep != null && BoardStatusUI.EnermyMoveStep != "Connected" && BoardStatusUI.EnermyMoveStep != "Started!" && BoardStatusUI.EnermyMoveStep != "Reseted!")
                        {
                            // update enermy pos & change player turn
                            Update_EnermyPiecesPos(BoardStatusUI.EnermyMoveStep);
                            getSet_RealTimePosition.Reset_EnermyMovement();
                        }
                    }
                    else if (Game_Mode.gameStyle == GAMESTYLE.VS_COMPUTER)     //play with computer
                    {
                        Player._MySide = (int)ChessColor.RED;   //red start first
                        if (player.MySide == (int)ChessColor.RED) { computerSide = ChessColor.BLACK; }
                        else { computerSide = ChessColor.RED; }
                        enablePieceByPlayerTurn();
                        if ((int)Game_Mode.playTurn != player.MySide)
                        {
                            autoPlay_ComputerAlgrithm.Generate_AutoMovement(computerSide);
                        }
                        if (Pieces.isDragging == false) { boardUI.Refresh(form_Board, ptb_ChessBoard); }
                    }

                    // prevent loop -> only update when
                    if (areBoardStatusEqual == false && Pieces.isDragging == false)
                    {
                        checkMate_Rule.RealTime_CheckMate();
                        gameOver_Rule.RealTime_CheckGameStatus();

                        // save last Board Status for Next Comparison
                        tempBoardStatus = new Dictionary<Point, (bool, bool)>(BoardStatusData.BoardStatus);
                    }
                }

                if (Game_Mode.gameStatus == GAMESTATUS.VICTORY)
                {
                    Game_Mode.gameStatus = GAMESTATUS.WAITING;
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "VICTORY!");
                    timer.Stop();
                    form_Message.ShowMessage();
                    if (form_Message.bYesOrNoClicked == true)
                    {
                        resetGameStatus();
                    }
                }
                else if (Game_Mode.gameStatus == GAMESTATUS.DEFEAT)
                {
                    Game_Mode.gameStatus = GAMESTATUS.WAITING;
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "DEFEAT!");
                    timer.Stop();
                    form_Message.ShowMessage();
                    if (form_Message.bYesOrNoClicked == true)
                    {
                        resetGameStatus();
                    }
                }
                else if (Game_Mode.gameStatus == GAMESTATUS.OVER)
                {
                    Game_Mode.gameStatus = GAMESTATUS.WAITING;
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "DRAW!");
                    timer.Stop();
                    form_Message.ShowMessage();
                    if (form_Message.bYesOrNoClicked == true)
                    {
                        resetGameStatus();
                    }
                }
            };
            timer.Start();
        }

        public event EventHandler GameMenuResetRequest;
        void resetGameStatus()
        {
            GameMenuResetRequest?.Invoke(this, EventArgs.Empty);
            //reset board
            Game_Mode.playTurn = ChessColor.RED;    // reset turn to default
            form_Board.Reset();
            // disbale all pieces
            foreach (Control control in ptb_ChessBoard.Controls)
            {
                if (control is Pieces piece) { piece.Enabled = false; }
            }
            timer.Start();
        }

        public void enablePieceByPlayerTurn()
        {
            foreach (Control control in ptb_ChessBoard.Controls)
            {
                if (control is Pieces piece)
                {
                    boardUI.DisablePieces_byPlayerTurn(piece, false);
                }
            }
        }

        // update enermy position, data and change player turn
        public void Update_EnermyPiecesPos(string _EnermyMoveStep)
        {
            string sEnermyBeforePosX = _EnermyMoveStep.Substring(0, 1);
            string sEnermyBeforePosY = "_" + _EnermyMoveStep.Substring(1, 1);
            string sEnermyAfterPosX = _EnermyMoveStep.Substring(2, 1);
            string sEnermyAfterPosY = "_" + _EnermyMoveStep.Substring(3, 1);

            ChessLocationX intEnermyBeforePosX = (ChessLocationX)Enum.Parse(typeof(ChessLocationX), sEnermyBeforePosX);
            ChessLocationY intEnermyBeforePosY = (ChessLocationY)Enum.Parse(typeof(ChessLocationY), sEnermyBeforePosY);
            ChessLocationX intEnermyAfterPosX = (ChessLocationX)Enum.Parse(typeof(ChessLocationX), sEnermyAfterPosX);
            ChessLocationY intEnermyAfterPosY = (ChessLocationY)Enum.Parse(typeof(ChessLocationY), sEnermyAfterPosY);

            Point EnermyBeforePos = new Point((int)intEnermyBeforePosX, (int)intEnermyBeforePosY);
            Point EnermyAfterPos = new Point((int)intEnermyAfterPosX, (int)intEnermyAfterPosY);

            foreach (Control control in ptb_ChessBoard.Controls)
            {
                // check all piece in board
                if (control is Pieces piece)
                {
                    // in case of enermy piece
                    if ((int)piece.PieceColor != player.MySide && piece.Location == EnermyBeforePos)
                    {
                        // change piece location
                        piece.Location = EnermyAfterPos;
                        boardStatus.ChangeDataStatus_AfterMove(piece, EnermyBeforePos, EnermyAfterPos);
                        // add captured enermy ro queue
                        boardUI.Refresh(form_Board, ptb_ChessBoard);
                    }
                }
            }
        }

        public static bool AreDictionariesEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {
            if (dict1 == null || dict2 == null || dict1.Count != dict2.Count)
                return false;

            foreach (var kvp in dict1)
            {
                if (!dict2.TryGetValue(kvp.Key, out TValue value) || !EqualityComparer<TValue>.Default.Equals(value, kvp.Value))
                    return false;
            }

            return true;
        }
    }
}
