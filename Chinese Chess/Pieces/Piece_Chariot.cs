using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class Piece_Chariot : Pieces
    {
        int _PiecesNum;
        public Piece_Chariot(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor, int PiecesNum) : base(_Board, _ptbBoard, _PieceColor)
        { this._PiecesNum = PiecesNum; }

        public override void Set_Identical_Property()
        {
            if (PieceColor == ChessColor.BLACK)
            {
                this.Image = global::Chinese_Chess.Properties.Resources.chariotBlack;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.A, (int)ChessLocationY._9); }
                else { pLocation = new Point((int)ChessLocationX.J, (int)ChessLocationY._9); }
            }
            else
            {
                this.Image = global::Chinese_Chess.Properties.Resources.chariotRed;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.A, (int)ChessLocationY._0); }
                else { pLocation = new Point((int)ChessLocationX.J, (int)ChessLocationY._0); }
            }
        }

        public override void Draw_PossibleMoves()
        {
            ChariotPossibleMove chariotPossibleMove = new ChariotPossibleMove(ptbBoard, this);
            chariotPossibleMove.Draw();
        }
    }
}
