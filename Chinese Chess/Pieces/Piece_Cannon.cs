using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class Piece_Cannon : Pieces
    {
        int _PiecesNum;
        public Piece_Cannon(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor, int PiecesNum) : base(_Board, _ptbBoard, _PieceColor)
        { this._PiecesNum = PiecesNum; }

        public override void Set_Identical_Property()
        {
            if (PieceColor == ChessColor.BLACK)
            {
                this.Image = global::Chinese_Chess.Properties.Resources.cannonBlack;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.B, (int)ChessLocationY._7); }
                else { pLocation = new Point((int)ChessLocationX.H, (int)ChessLocationY._7); }
            }
            else
            {
                this.Image = global::Chinese_Chess.Properties.Resources.cannonRed;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.B, (int)ChessLocationY._2); }
                else { pLocation = new Point((int)ChessLocationX.H, (int)ChessLocationY._2); }
            }
        }

        public override void Draw_PossibleMoves()
        {
            CannonPossibleMove cannonPossibleMove = new CannonPossibleMove(ptbBoard, this);
            cannonPossibleMove.Draw();
        }
    }
}
