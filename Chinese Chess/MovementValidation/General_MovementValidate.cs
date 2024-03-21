using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class General_MovementValidate
    {
        Pieces _selectedPiece;
        Form_Board _form;
        PictureBox _ptb_ChessBoard;
        public General_MovementValidate(Pieces selectedPiece, Form_Board form, PictureBox ptb_ChessBoard)
        {
            this._selectedPiece = selectedPiece;
            this._form = form;
            this._ptb_ChessBoard = ptb_ChessBoard;
        }

        PossibleMovement_CircleData circleData = new PossibleMovement_CircleData();
        public void Validate(Point BeforePos, ref Point AfterPos)
        {
            if (!circleData.GetStatus_AtPosition(AfterPos))   // move in pos have circle
            {
                Pieces.isClicked = true; // keep circle if move not complete
                AfterPos = BeforePos;
            }
            else // checkmate validation
            {
                // change pos temp
                _selectedPiece.Location = AfterPos;
                CheckMate_Rule checkMate_Rule = new CheckMate_Rule(_form, _ptb_ChessBoard);

                // only get king piece 1 time
                if (CheckMate_Rule.myPieceKing == null || CheckMate_Rule.enermyPieceKing == null) { if (!checkMate_Rule.get_pieceKing()) { return; } }

                // checkmate validation
                if (checkMate_Rule.CheckMate_Algorithm(CheckMate_Rule.myPieceKing))
                {
                    _selectedPiece.Location = BeforePos;
                    Pieces.isClicked = true; // keep circle if move not complete
                    AfterPos = BeforePos;
                }
            }
        }
    }
}
