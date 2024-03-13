using System;
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

        public void RealTimeUpdate()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                // only start when 2 players connected
                if (Game_Mode.gameStatus == GAMESTATUS.READY_TOSTART)
                {
                    // set up first turn
                    enablePieceByPlayerTurn();
                    // get realtime enermy move and change turn
                    string _EnermyMoveStep = getSet_RealTimePosition.Read_EnermyMovement();
                    if (_EnermyMoveStep != null && _EnermyMoveStep != "Connected")
                    {
                        BoardStatusUI.EnermyMoveStep = _EnermyMoveStep;
                        // update enermy pos & change player turn
                        Update_EnermyPiecesPos(_EnermyMoveStep);
                        getSet_RealTimePosition.Reset_EnermyMovement();
                    }
                }
            };
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
    }
}
