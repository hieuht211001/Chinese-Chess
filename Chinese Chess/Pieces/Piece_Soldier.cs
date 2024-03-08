using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class Piece_Soldier : Pieces
    {
        int _PiecesNum;
        public Piece_Soldier(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor, int PiecesNum) : base(_Board, _ptbBoard, _PieceColor)
        { this._PiecesNum = PiecesNum; }

        public override void Set_Identical_Property()
        {
            if (PieceColor == ChessColor.BLACK)
            {
                this.Image = global::Chinese_Chess.Properties.Resources.soldierBlack;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.A, (int)ChessLocationY._6); }
                else if (_PiecesNum == (int)PIECE.NUM_2)
                { pLocation = new Point((int)ChessLocationX.C, (int)ChessLocationY._6); }
                else if (_PiecesNum == (int)PIECE.NUM_3)
                { pLocation = new Point((int)ChessLocationX.E, (int)ChessLocationY._6); }
                else if (_PiecesNum == (int)PIECE.NUM_4)
                { pLocation = new Point((int)ChessLocationX.G, (int)ChessLocationY._6); }
                else if (_PiecesNum == (int)PIECE.NUM_5)
                { pLocation = new Point((int)ChessLocationX.J, (int)ChessLocationY._6); }
            }
            else
            {
                this.Image = global::Chinese_Chess.Properties.Resources.soldierRed;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.A, (int)ChessLocationY._3); }
                else if (_PiecesNum == (int)PIECE.NUM_2)
                { pLocation = new Point((int)ChessLocationX.C, (int)ChessLocationY._3); }
                else if (_PiecesNum == (int)PIECE.NUM_3)
                { pLocation = new Point((int)ChessLocationX.E, (int)ChessLocationY._3); }
                else if (_PiecesNum == (int)PIECE.NUM_4)
                { pLocation = new Point((int)ChessLocationX.G, (int)ChessLocationY._3); }
                else if (_PiecesNum == (int)PIECE.NUM_5)
                { pLocation = new Point((int)ChessLocationX.J, (int)ChessLocationY._3); }
            }
        }

        public override void Draw_PossibleMoves()
        {
            SoldierPossibleMove soldierPossibleMove = new SoldierPossibleMove(ptbBoard, this);
            soldierPossibleMove.Draw();
        }
    }
}
