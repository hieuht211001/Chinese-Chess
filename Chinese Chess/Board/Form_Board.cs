using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public partial class Form_Board : Form
    {
        public Board board;
        public Form_Board()
        {
            InitializeComponent();
            board = new Board(this, ptb_ChessBoard);
            board.Create();
            ChangeColorMode(BoardColor.WHITE);
        }

        public void ChangeColorMode(BoardColor boardColor)
        {
            PictureBox ptb_ChessBoard = this.Controls.Find("ptb_ChessBoard", true).FirstOrDefault() as PictureBox;
            if (boardColor == BoardColor.WHITE)
            {
                this.BackColor = Color.FromArgb(255, 251, 242);
                ptb_ChessBoard.Image = global::Chinese_Chess.Properties.Resources.Chessboard_Light; 
            }
            else if (boardColor == BoardColor.PINK)
            {
                this.BackColor = Color.FromArgb(241, 203, 157);
                ptb_ChessBoard.Image = global::Chinese_Chess.Properties.Resources.Chessboard_Pink;
            }
        }
    }
}
