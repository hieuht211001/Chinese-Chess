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
        PictureBox _ptb_ChessBoard;
        public General_MovementValidate(Pieces selectedPiece, PictureBox ptb_ChessBoard)
        {
            this._selectedPiece = selectedPiece;
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
                CheckMate_Rule checkMate_Rule = new CheckMate_Rule(_ptb_ChessBoard);
                GameOver_Rule gameOver_Rule = new GameOver_Rule(_ptb_ChessBoard);
                bool bCanDefendByKillEnermy = false;

                // only get king piece 1 time
                if (CheckMate_Rule.myPieceKing == null || CheckMate_Rule.enermyPieceKing == null) { if (!checkMate_Rule.get_pieceKing()) { return; } }

                // check can defend by kill enermy
                foreach (Control controlEnermy in _ptb_ChessBoard.Controls)
                {
                    if (controlEnermy is Pieces pieceEnermy && pieceEnermy.PieceColor != _selectedPiece.PieceColor)
                    {
                        // check enermy piece location
                        if (pieceEnermy.Location == AfterPos)
                        {
                            // create virtual piece
                            PictureBox VirtualPieceEnermy = new PictureBox();
                            gameOver_Rule.Set_VirtualPiece(ref VirtualPieceEnermy, pieceEnermy);
                            // hide origin piece
                            _ptb_ChessBoard.Controls.Remove(pieceEnermy);
                            if (!checkMate_Rule.CheckMate_Algorithm(CheckMate_Rule.myPieceKing)) { bCanDefendByKillEnermy = true; }
                            _ptb_ChessBoard.Controls.Add(pieceEnermy);
                            VirtualPieceEnermy.Dispose();
                        }
                    }
                }

                Piece_King piece_King_Temp = null;
                if (Game_Mode.DualOrAlone == false)         // alone mode
                {
                    // continiously change piece to check in alone game
                    if (Game_Mode.playTurn == ChessColor.RED) { piece_King_Temp = CheckMate_Rule.myPieceKing as Piece_King; }
                    else { piece_King_Temp = CheckMate_Rule.enermyPieceKing as Piece_King; }
                }
                else              // dual mode
                {
                    piece_King_Temp = CheckMate_Rule.myPieceKing as Piece_King;
                }

                // checkmate validation
                // cant move if cant defend checkmate and can defend checkmate by kill enermy
                if (checkMate_Rule.CheckMate_Algorithm(piece_King_Temp) && bCanDefendByKillEnermy == false)
                {
                    _selectedPiece.Location = BeforePos;
                    Pieces.isClicked = true; // keep circle if move not complete
                    AfterPos = BeforePos;
                }
            }
        }
    }
}
