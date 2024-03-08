using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class Piece_BorderColor_Change
    {
        public void ToClicked(Form_Board form_board, Pieces piece, bool autoReset = false)
        {
            // reset other pieces' color
            foreach (Control control in form_board.Controls)
            {
                if (control is Pieces otherPiece)
                {
                    otherPiece.BackColor = Color.Transparent;
                }
            }
            piece.BackColor = Color.FromArgb(128, 128, 255);
            // auto clear color when reach auto reset time
            if (autoReset == true) 
            {
                int secondsLeft = 10;
                Timer timer = new Timer();
                timer.Interval = 1000; 
                timer.Tick += (sender, e) =>
                {
                    secondsLeft--;
                    // auto reset when time out (Exception: User just clicked, movement doesnot complete)
                    if (secondsLeft <= 0 && Pieces.isClicked == false)
                    {
                        timer.Stop(); 
                        piece.BackColor = Color.Transparent;
                    }
                };
                timer.Start();
            }
        }

        // change the color of pieces can be captured
        public void Change_OccupiedPiece_Color(Form_Board form_board)
        {
            BoardStatusData boardData = new BoardStatusData();
            PossibleMovement_CircleData PossibleCircleData = new PossibleMovement_CircleData();
            // check all piece on board
            foreach (Control control in form_board.Controls)
            {
                if (control is Pieces piece)
                {
                    // check position of all circle created
                    foreach (Point CirclePosition in Possible_Move_Circle.circlePtb_PositionList)
                    {
                        // if Piece Location = Circle Location -> This Pieces can be captured
                        if (piece.Location == CirclePosition)
                        {
                            piece.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
    }
}
