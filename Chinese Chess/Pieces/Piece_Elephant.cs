using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class Piece_Elephant: Pieces
    {
        int _PiecesNum;
        public Piece_Elephant(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor, int PiecesNum) : base(_Board, _ptbBoard, _PieceColor) 
        { this._PiecesNum = PiecesNum; }

        public override void Set_Identical_Property()
        {
            if (PieceColor == ChessColor.BLACK)
            {
                this.Image = global::Chinese_Chess.Properties.Resources.elephantBlack;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.C, (int)ChessLocationY._9); }
                else { pLocation = new Point((int)ChessLocationX.G, (int)ChessLocationY._9); }
            }
            else
            {
                this.Image = global::Chinese_Chess.Properties.Resources.elephantRed;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.C, (int)ChessLocationY._0); }
                else { pLocation = new Point((int)ChessLocationX.G, (int)ChessLocationY._0); }
            }
        }

        public override void Draw_PossibleMoves()
        {
            ElephantPossibleMove elephantPossibleMove = new ElephantPossibleMove(ptbBoard, this);
            elephantPossibleMove.Draw();
        }

    }
}

