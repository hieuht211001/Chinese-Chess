using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    class Piece_Advisor: Pieces
    {
        int _PiecesNum;
        public Piece_Advisor(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor, int PiecesNum) : base(_Board, _ptbBoard, _PieceColor) 
        { this._PiecesNum = PiecesNum; }

        public override void Set_Identical_Property()
        {
            if (PieceColor == ChessColor.BLACK)
            {
                this.Image = global::Chinese_Chess.Properties.Resources.advisorBlack;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.D, (int)ChessLocationY._9); }
                else { pLocation = new Point((int)ChessLocationX.F, (int)ChessLocationY._9); }
            }
            else
            {
                this.Image = global::Chinese_Chess.Properties.Resources.advisorRed;
                if (_PiecesNum == (int)PIECE.NUM_1)
                { pLocation = new Point((int)ChessLocationX.D, (int)ChessLocationY._0); }
                else { pLocation = new Point((int)ChessLocationX.F, (int)ChessLocationY._0); }
            }
        }

        public override void Draw_PossibleMoves()
        {
            AdvisorPossibleMove advisorPossibleMove = new AdvisorPossibleMove(ptbBoard, this);
            advisorPossibleMove.Draw();
        }
    }
}

