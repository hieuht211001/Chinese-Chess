using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public abstract class Pieces : OvalPictureBox
    {
        public Point pLocation;
        public PictureBox ptbBoard;
        public ChessColor PieceColor;
        public string NameofPiece;
        public Form_Board Board;
        private System.Windows.Forms.Timer timer;
        public Player player = new Player();
        public AutoLocate autoLocate = new AutoLocate();
        public BoardStatusData boardStatus = new BoardStatusData();
        public BoardStatusUI boardUI = new BoardStatusUI();
        public Possible_Move_Circle possibleCircleUI = new Possible_Move_Circle();
        public PossibleMovement_CircleData possibleCircleData = new PossibleMovement_CircleData();
        public Piece_BorderColor_Change pieceColorChange = new Piece_BorderColor_Change();
        public Game_Sound gameSound = new Game_Sound();
        public Pieces(Form_Board _Board, PictureBox _ptbBoard, ChessColor _PieceColor)
        {
            this.ptbBoard = _ptbBoard;
            this.PieceColor = _PieceColor;
            this.Board = _Board;
        }

        public void Create()
        {
            Set_Identical_Property();
            Set_General_Property();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (sender, e) =>
            {
                Set_Function_Pieces();
                if (player.MySide != -1) { timer.Stop(); }
            };
            timer.Start();
            boardStatus.Add_Board_Status(this, true);
        }

        public void Set_General_Property()
        {
            ptbBoard.Controls.Add(this);
            this.BringToFront();
            this.Size = new Size(73, 73);
            this.Padding = new Padding(3);
            this.Location = pLocation;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Cursor = Cursors.Hand;
        }

        public virtual void Set_Identical_Property() { }
        public virtual void Draw_PossibleMoves() { }

        public void Movement_Validate(Point BeforePos, ref Point AfterPos) 
        {
            General_MovementValidate General_Movement = new General_MovementValidate();
            General_Movement.Validate(BeforePos, ref AfterPos);
        }

        public void Set_Function_Pieces()
        {
            if (player.MySide == -1) { return; }
            // enable allie pieces only
            if ((player.MySide == (int)ChessColor.BLACK && this.PieceColor == ChessColor.BLACK) || (player.MySide == (int)ChessColor.RED && this.PieceColor == ChessColor.RED))
            {
                this.MouseDown += Pieces_MouseDown;
                this.MouseMove += Pieces_MouseMove;
                this.MouseUp += Pieces_MouseUp;
            }
            //do with enermy pieces
            else
            {
                this.Click += Pieces_Click;
            }
        }

        static int currentX;
        static int currentY;
        static Point BeforePos;
        static Point AfterPos;
        public static bool isDragging;
        public static bool isClicked;

        private void Pieces_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            pieceColorChange.ToClicked(ptbBoard, this, true);
            pieceColorChange.Change_OccupiedPiece_Color(ptbBoard);
            AfterPos = new Point(this.Left + (e.X - currentX), this.Top + (e.Y - currentY));

            autoLocate.Do(ref AfterPos);

            // if pieces postition doesnot change -> user just click, not drag
            if (BeforePos != AfterPos) 
            {
                isClicked = false;
            }
            // movement validation
            Movement_Validate(BeforePos, ref AfterPos);

            // add sound when move
            if (AfterPos == BeforePos) { gameSound.Add(SOUNDTYPE.RECHECK_MOVE); }
            else { gameSound.Add(SOUNDTYPE.NORMAL_MOVE); }

            // change position
            this.Location = AfterPos;

            // change piece status data
            boardStatus.ChangeDataStatus_AfterMove(this, BeforePos, AfterPos);
            boardUI.Refresh(Board, ptbBoard);
            if (AfterPos != BeforePos) { boardUI.SaveNSend_MyMoves(BeforePos, AfterPos); }
        }

        private void Pieces_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.BringToFront();
                this.Top = this.Top + (e.Y - currentY);
                this.Left = this.Left + (e.X - currentX);
                // auto locate
                //Point tempPoint = new Point(this.Left + (e.X - currentX), this.Top + (e.Y - currentY));
                //autoLocate.Do(ref tempPoint);
                //this.Location = tempPoint;
            }
        }

        private void Pieces_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            isClicked = true;
            currentX = e.X;
            currentY = e.Y;
            pieceColorChange.ToClicked(ptbBoard, this);
            BeforePos = new Point(this.Location.X, this.Location.Y);
            // delete all before piece circle ui
            possibleCircleUI.Delete_All(ptbBoard);
            // delete all before piece circle data
            possibleCircleData.Delete_All_Circle_Data();
            // draw possible move circle of current piece
            Draw_PossibleMoves();
            pieceColorChange.Change_OccupiedPiece_Color(ptbBoard);
        }

        private void Pieces_Click(object sender, EventArgs e)
        {
            // enermy piece that can be captured
            if (this.BackColor == Color.Red)
            {
               Point AfterTempPos = this.Location;
                foreach (Control control in ptbBoard.Controls)
                {
                    if (control is Pieces selectedAlliesPiece)
                    {
                        // selected allies piece
                        if (selectedAlliesPiece.BackColor == Color.FromArgb(128, 128, 255))
                        {
                            Point BeforeTempPos = selectedAlliesPiece.Location;
                            isDragging = false;
                            isClicked = false;
                            selectedAlliesPiece.Location = AfterTempPos;
                            boardStatus.ChangeDataStatus_AfterMove(selectedAlliesPiece, BeforeTempPos, AfterTempPos);
                            boardUI.Refresh(Board, ptbBoard, true);
                            boardUI.SaveNSend_MyMoves(BeforeTempPos, AfterTempPos);
                        }
                    }
                }
            }
        }
    }
}
