using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Drawing;

namespace Chinese_Chess
{
   public class Board
    {
        public Form_Board form_Board;
        public PictureBox ptb_ChessBoard;
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
    }
}
