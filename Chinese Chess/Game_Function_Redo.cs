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
    class Game_Function_Redo
    {
        public BoardStatusData boardStatus = new BoardStatusData();
        public BoardStatusUI boardUI = new BoardStatusUI();
        PictureBox ptb_ChessBoard;
        Form_Board form_Board;
        public Game_Function_Redo(PictureBox _ptb_ChessBoard, Form_Board _form_Board)
        {
            this.ptb_ChessBoard = _ptb_ChessBoard;
            this.form_Board = _form_Board;
        }

        static int bTurn = -1;
        public void Redo_AloneMode()
        {
            string sRedoStepText = "";

            if (checkLastMove() == ChessColor.RED && bTurn == -1) { bTurn = 0; }
            else if (checkLastMove() == ChessColor.BLACK && bTurn == -1) { bTurn = 1; }

            if (bTurn == 0)
            {
                bTurn = 1;
                if (Game_Movement_History.RED.Count == 0) 
                {
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "All pieces are in initial state!");
                    form_Message.ShowMessage();
                    return; 
                }
                sRedoStepText = Game_Movement_History.RED[Game_Movement_History.RED.Count - 1];
                Game_Movement_History.RED.Remove(sRedoStepText);
            }
            else if (bTurn == 1) 
            {
                bTurn = 0;
                if (Game_Movement_History.BLACK.Count == 0) 
                {
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "All pieces are in initial state!");
                    form_Message.ShowMessage();
                    return;
                }
                sRedoStepText = Game_Movement_History.BLACK[Game_Movement_History.BLACK.Count - 1];
                Game_Movement_History.BLACK.Remove(sRedoStepText);
            }
            Point BeforePos, AfterPos;
            changeStepText2Point(sRedoStepText, out BeforePos, out AfterPos);

            foreach (Control control in ptb_ChessBoard.Controls)
            {
                if (control is Pieces piece && piece.Location == AfterPos)
                {
                    piece.Location = BeforePos;
                    boardStatus.ChangeDataStatus_AfterMove(piece, AfterPos, BeforePos);
                    boardUI.Refresh(form_Board, ptb_ChessBoard);
                }
            }

            // restore deleted pieces
            Pieces deletedPiece = getDeletedPieces(AfterPos);
            if (deletedPiece == null) { return; }
            form_Board.Controls.Remove(deletedPiece);
            ptb_ChessBoard.Controls.Add(deletedPiece);
            deletedPiece.Location = AfterPos;
            boardStatus.ChangeDataStatus_AfterMove(deletedPiece, AfterPos, AfterPos);
        }


        private Pieces getDeletedPieces(Point FindPos)
        {
            Pieces deletedPiece = null;
            if (Game_Movement_History.DELETED_BLACK.Count > 0)
            {
                foreach (var pair in Game_Movement_History.DELETED_BLACK)
                {
                    if (pair.Point == FindPos) { deletedPiece = pair.Piece; Game_Movement_History.DELETED_BLACK.Remove(pair); return deletedPiece; }
                }
            }
            if (Game_Movement_History.DELETED_RED.Count > 0)
            {
                foreach (var pair in Game_Movement_History.DELETED_RED)
                {
                    if (pair.Point == FindPos) { deletedPiece = pair.Piece; Game_Movement_History.DELETED_RED.Remove(pair); return deletedPiece; }
                }
            }
            return deletedPiece;
        }

        private ChessColor checkLastMove()
        {
           if ( Game_Movement_History.RED.Count % 2 == 0 && Game_Movement_History.BLACK.Count % 2 == 0)
           {
                return ChessColor.BLACK;
           }
           else
           {
                return ChessColor.RED;
           }
        }

        public void changeStepText2Point(string sStepText, out Point BeforePos, out Point AfterPos)
        {
            string sEnermyBeforePosX = sStepText.Substring(0, 1);
            string sEnermyBeforePosY = "_" + sStepText.Substring(1, 1);
            string sEnermyAfterPosX = sStepText.Substring(2, 1);
            string sEnermyAfterPosY = "_" + sStepText.Substring(3, 1);

            ChessLocationX intEnermyBeforePosX = (ChessLocationX)Enum.Parse(typeof(ChessLocationX), sEnermyBeforePosX);
            ChessLocationY intEnermyBeforePosY = (ChessLocationY)Enum.Parse(typeof(ChessLocationY), sEnermyBeforePosY);
            ChessLocationX intEnermyAfterPosX = (ChessLocationX)Enum.Parse(typeof(ChessLocationX), sEnermyAfterPosX);
            ChessLocationY intEnermyAfterPosY = (ChessLocationY)Enum.Parse(typeof(ChessLocationY), sEnermyAfterPosY);

            BeforePos = new Point((int)intEnermyBeforePosX, (int)intEnermyBeforePosY);
            AfterPos = new Point((int)intEnermyAfterPosX, (int)intEnermyAfterPosY);
        }
    }
}
