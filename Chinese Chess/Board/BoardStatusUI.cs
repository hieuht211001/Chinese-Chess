using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class BoardStatusUI
    {
        BoardStatusData boardData = new BoardStatusData();
        public void Refresh(Form_Board form_Board)
        {
            // check all pieces
            foreach (Control control in form_Board.Controls)
            {
                if (control is Pieces piece)
                {
                    // check data -> if data doesnot exist -> delete piece ui
                    if (!boardData.GetStatus_AtPosition(new Point(piece.Location.X, piece.Location.Y), piece.PieceColor))
                    {
                        piece.Enabled = false;
                        piece.Visible = false;
                    }
                }
            }
        }
    }
}
