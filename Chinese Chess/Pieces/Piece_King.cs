using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class Piece_King : Pieces
    {
        public Piece_King(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor) : base(_Board, _ptbBoard, _PieceColor) { }

        public override void Set_Identical_Property()
        {
            if (PieceColor == ChessColor.BLACK)
            {
                this.Image = global::Chinese_Chess.Properties.Resources.kingBlack;
                pLocation = new Point((int)ChessLocationX.E, (int)ChessLocationY._9);
            }
            else
            {
                this.Image = global::Chinese_Chess.Properties.Resources.kingRed;
                pLocation = new Point((int)ChessLocationX.E, (int)ChessLocationY._0);
            }
        }

        public override void Draw_PossibleMoves()
        {
            KingPossibleMove kingPossibleMove = new KingPossibleMove(ptbBoard, this);
            kingPossibleMove.Draw();
        }
    }
}
