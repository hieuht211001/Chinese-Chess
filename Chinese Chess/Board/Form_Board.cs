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
        public Form_Board()
        {
            InitializeComponent();
            Board board = new Board(this, ptb_ChessBoard);
            board.Create();

        }
    }
}
