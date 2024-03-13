using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class Possible_Move_Circle: PossibleMovement_CircleData
    {
        public static List<PictureBox> circle_ptbList = new List<PictureBox>();
        public static List<Point> circlePtb_PositionList = new List<Point>();
        public PictureBox _ptbBoard;
        public BoardStatusData boardStatus = new BoardStatusData();
        public Game_Sound gameSound = new Game_Sound();
        public BoardStatusUI boardUI = new BoardStatusUI();

        public void Create(PictureBox ptbBoard, Point point)
        {
            PictureBox ptb = new PictureBox();
            ptb.Image = global::Chinese_Chess.Properties.Resources.step_circle;
            ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            ptb.Size = new Size(70, 70);
            ptb.Visible = true;
            ptb.Location = point;
            ptb.BackColor = Color.Transparent;
            ptbBoard.Controls.Add(ptb);

            this._ptbBoard = ptbBoard;
            ptb.Click += PtbMovementCircle_Click;

            Add_Circle_ByPos(point);
            // add to list to delete all circle when click other pieces
            circle_ptbList.Add(ptb);
            circlePtb_PositionList.Add(ptb.Location);
            // Delete circle when move completed
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender, e) =>
            {
                if (Pieces.isDragging == false && Pieces.isClicked == false)
                {
                    ptbBoard.Controls.Remove(ptb);
                    ptb.Dispose();
                    Delete_Circle_ByPos(point);
                    timer.Stop();
                }
            };
            timer.Start();
        }

        private void PtbMovementCircle_Click(object sender, EventArgs e)
        {
            PictureBox selectedCircle = sender as PictureBox;
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null && mouseEvent.Button == MouseButtons.Left)
            {
                foreach (Control control in _ptbBoard.Controls)
                {
                    if (control is Pieces selectedPiece)
                    {
                        if (selectedPiece.BackColor == Color.FromArgb(128, 128, 255))
                        {
                            Pieces.isDragging = false;
                            Pieces.isClicked = false;
                            boardStatus.ChangeDataStatus_AfterMove(selectedPiece, selectedPiece.Location, selectedCircle.Location);
                            // change enable disable status
                            foreach (Control control2 in _ptbBoard.Controls)
                            {
                                if (control is Pieces piece && piece.PieceColor == selectedPiece.PieceColor)
                                {
                                    boardUI.DisablePieces_byPlayerTurn(piece, false);
                                }
                            }
                            boardUI.SaveNSend_MyMoves(selectedPiece.Location, selectedCircle.Location);
                            selectedPiece.Location = selectedCircle.Location;

                            gameSound.Add(SOUNDTYPE.NORMAL_MOVE);
                        }
                    }
                }
            }
        }

        public void Delete_All(PictureBox ptbBoard)
        {
            foreach (PictureBox ptb in circle_ptbList)
            {
                ptbBoard.Controls.Remove(ptb);
                ptb.Dispose();
            }
            circle_ptbList.Clear();
            circlePtb_PositionList.Clear();
        }
    }
}
