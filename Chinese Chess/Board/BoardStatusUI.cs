using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chinese_Chess
{
    public class BoardStatusUI
    {
        public static int tempNumRed = 0;
        public static int tempNumBlack = 0;
        BoardStatusData boardData = new BoardStatusData();
        public Game_Sound gameSound = new Game_Sound();

        public static string MyMoveStep;
        public static string EnermyMoveStep;

        public void SaveNSend_MyMoves(Point BeforePos, Point AfterPos)
        {
            // name of before pos
            ChessLocationX xEnumBefore = (ChessLocationX)Enum.GetValues(typeof(ChessLocationX)).GetValue(BeforePos.X/ 70);
            string stringXEnumBefore = xEnumBefore.ToString();
            ChessLocationY yEnumBefore = (ChessLocationY)Enum.GetValues(typeof(ChessLocationY)).GetValue(BeforePos.Y/70);
            string stringyEnumBefore = yEnumBefore.ToString();
            string stringyEnumBefore_Replace = stringyEnumBefore.Replace("_", "");
            string BeforePosName = stringXEnumBefore + stringyEnumBefore_Replace;

            // name of after pos
            ChessLocationX xEnumAfter = (ChessLocationX)Enum.GetValues(typeof(ChessLocationX)).GetValue(AfterPos.X / 70);
            string stringXEnumAfter = xEnumAfter.ToString();
            ChessLocationY yEnumAfter = (ChessLocationY)Enum.GetValues(typeof(ChessLocationY)).GetValue(AfterPos.Y / 70);
            string stringyEnumAfter = yEnumAfter.ToString();
            string stringyEnumAfter_Replace = stringyEnumAfter.Replace("_", "");
            string AfterPosName = stringXEnumAfter + stringyEnumAfter_Replace;

            if (BeforePosName != AfterPosName) { MyMoveStep = BeforePosName + AfterPosName; }
            Console.WriteLine(MyMoveStep);
        }

        public void Refresh(Form_Board form_Board, PictureBox ptbChessBoard)
        {
            // check all pieces
            foreach (Control control in ptbChessBoard.Controls)
            {
                if (control is Pieces piece)
                {
                    // check data -> if data doesnot exist -> delete piece ui
                    if (!boardData.GetStatus_AtPosition(new Point(piece.Location.X, piece.Location.Y), piece.PieceColor))
                    {
                        Add_DeletedPieces_toQueue(form_Board, piece);
                    }
                }
            }
        }

        public void Add_DeletedPieces_toQueue(Form_Board form_Board, Pieces piece)
        {
            piece.Enabled = false;
            form_Board.Controls.Add(piece);
            piece.BackColor = Color.Transparent;
            piece.BringToFront();

            gameSound.Add(SOUNDTYPE.TAKE_MOVE);

            if (piece.PieceColor == ChessColor.BLACK)
            {
                form_Board.ptbQueueRed.Size = new Size(5, (int)DeletedQueueLocation.Black_Y + 25 + (int)MOVE.DOWN_Y * tempNumBlack);
                form_Board.ptbQueueRed.Location = new Point(form_Board.ptbQueueRed.Location.X, (int)DeletedQueueLocation.Red_Y + (int)MOVE.UP_Y * tempNumBlack);
                piece.Location = new Point((int)DeletedQueueLocation.Red_X, (int)DeletedQueueLocation.Red_Y + (int)MOVE.UP_Y * tempNumBlack);
                tempNumBlack++;
                PieceStatus.iNumOfDeletedPieceBlack++;
                if (tempNumBlack == 10)
                {
                    tempNumBlack = 0;
                    foreach (Control control in form_Board.Controls)
                    {
                        if (control is Pieces pieceInQueue)
                        {
                            form_Board.ptbQueueRed.Size = new Size(0, 0);
                            if (pieceInQueue.PieceColor == ChessColor.BLACK) { pieceInQueue.Visible = false; }
                        }
                    }
                }
            }
            else
            {
                form_Board.ptbQueueBlack.Size = new Size(5, (int)DeletedQueueLocation.Black_Y + 25 + (int)MOVE.DOWN_Y * tempNumRed);
                piece.Location = new Point((int)DeletedQueueLocation.Black_X, (int)DeletedQueueLocation.Black_Y + (int)MOVE.DOWN_Y * tempNumRed);
                tempNumRed++;
                PieceStatus.iNumOfDeletedPieceRed++;
                if (tempNumRed == 10) 
                {
                    tempNumRed = 0;
                    foreach (Control control in form_Board.Controls)
                    {
                        if (control is Pieces pieceInQueue)
                        {
                            form_Board.ptbQueueRed.Size = new Size(0, 0);
                            if (pieceInQueue.PieceColor == ChessColor.RED) { pieceInQueue.Visible = false; }
                        }
                    }
                }
            }
        }
    }
}
