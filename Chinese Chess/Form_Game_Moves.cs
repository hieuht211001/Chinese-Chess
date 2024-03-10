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
    public partial class Form_Game_Moves : Form
    {
        public Form_Game_Moves()
        {
            InitializeComponent();
        }
        public static int iNumber = 0;
        public void Create_Moves_Panel(Point PanelPos)
        {
            Panel pnaelforText = new Panel();
            pnaelforText.Size = new System.Drawing.Size(360, 49);
            pnaelforText.Location = PanelPos;
            pnaelforText.BackColor = Color.Transparent;
            pnaelforText.BorderStyle = BorderStyle.FixedSingle;
            pnaelforText.Visible = true;

            Label Number = new Label();
            Number.Text = "1";
            Number.Size = new System.Drawing.Size(116, 45);
            Number.Location = new System.Drawing.Point(4, PanelPos.Y+2);
            Number.Font = new System.Drawing.Font("210 OmniGothic 050", 12F, System.Drawing.FontStyle.Regular);
            Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Number.Visible = true;

            this.Controls.Add(Number);
            this.Controls.Add(pnaelforText);
        }
        public void Create_MyMoveStep_History(string sMoveStep,Point PanelPos)
        {
            Label MyMove = new Label();
            MyMove.Text = sMoveStep;
            MyMove.Size = new System.Drawing.Size(114, 45);
            MyMove.Location = new System.Drawing.Point(120, PanelPos.Y + 2);
            MyMove.Font = new System.Drawing.Font("210 OmniGothic 050", 12F, System.Drawing.FontStyle.Regular);
            MyMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            MyMove.Visible = true;
            MyMove.BackColor = Color.Red;
            this.Controls.Add(MyMove);
            MyMove.BringToFront();
        }
        public static bool bOutofSpace;
        public void Create_EnermyMoveStep_History(string sMoveStep, Point PanelPos)
        {
            Label EnermyMove = new Label();
            EnermyMove.Text = sMoveStep;
            EnermyMove.Size = new System.Drawing.Size(114, 45);
            EnermyMove.Location = new System.Drawing.Point(234, PanelPos.Y + 2);
            EnermyMove.Font = new System.Drawing.Font("210 OmniGothic 050", 12F, System.Drawing.FontStyle.Regular);
            EnermyMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            EnermyMove.Visible = true;
            this.Controls.Add(EnermyMove);
            bOutofSpace = true;

            iNumber++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BoardStatusUI.MyMoveStep !=  null)
            {
                Create_Moves_Panel(new Point(-5, 49 * iNumber));
                Create_MyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                BoardStatusUI.MyMoveStep = null;
            }
            // need to check and repair
            if (BoardStatusUI.EnermyMoveStep != null)
            {
                Create_EnermyMoveStep_History(BoardStatusUI.EnermyMoveStep, new Point(-5, 49 * iNumber));
                BoardStatusUI.EnermyMoveStep = null;
            }
        }
    }
}
