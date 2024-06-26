﻿using System;
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
        int iNumber = 0;

        // create panel to show enermy and my movement infor
        public void Create_Moves_Panel(Point PanelPos)
        {
            Panel pnaelforText = new Panel();
            pnaelforText.Size = new System.Drawing.Size(360, 49);
            pnaelforText.Location = PanelPos;
            pnaelforText.BackColor = Color.Transparent;
            pnaelforText.BorderStyle = BorderStyle.FixedSingle;
            pnaelforText.Visible = true;

            Label Number = new Label();
            Number.Text = $"{iNumber + 1}";
            Number.Size = new System.Drawing.Size(116, 45);
            Number.Location = new System.Drawing.Point(4, PanelPos.Y+2);
            Number.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Number.Visible = true;

            this.Controls.Add(Number);
            this.Controls.Add(pnaelforText);
        }
        // create label for text about my movement
        public void Create_MyMoveStep_History(string sMoveStep,Point PanelPos)
        {
            Label MyMove = new Label();
            MyMove.Text = sMoveStep;
            MyMove.Size = new System.Drawing.Size(114, 45);
            MyMove.Location = new System.Drawing.Point(120, PanelPos.Y + 2);
            MyMove.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            MyMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            MyMove.Visible = true;
            MyMove.ForeColor = Color.White;
            if (Player._MySide == (int)ChessColor.RED) { MyMove.BackColor = Game_Color.DEEP_RED;}
            else { MyMove.BackColor = Color.FromArgb(140, 122, 118);  }
            this.Controls.Add(MyMove);
            MyMove.BringToFront();
        }

        // create label for text about enermy movement
        public void Create_EnermyMoveStep_History(string sMoveStep, Point PanelPos)
        {
            Label EnermyMove = new Label();
            EnermyMove.Text = sMoveStep;
            EnermyMove.Size = new System.Drawing.Size(114, 45);
            EnermyMove.Location = new System.Drawing.Point(234, PanelPos.Y + 2);
            EnermyMove.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            EnermyMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            EnermyMove.Visible = true;
            EnermyMove.ForeColor = Color.White;
            if (Player._MySide != (int)ChessColor.RED) { EnermyMove.BackColor = Game_Color.DEEP_RED; }
            else { EnermyMove.BackColor = Color.FromArgb(140, 122, 118); }
            this.Controls.Add(EnermyMove);
            EnermyMove.BringToFront();
        }

        // check is there any text in step line (my pos)
        public bool IsMyStep_alreadyInThisPos(Point PanelPos)
        {
            Control controlAtPoint = this.GetChildAtPoint(new Point(120, PanelPos.Y + 2));
            if (controlAtPoint != null && controlAtPoint is Label) { return true; }
            else { return false; }
        }

        // check is there any text in step line (enermy pos)
        public bool IsEnermyStep_alreadyInThisPos(Point PanelPos)
        {
            Control controlAtPoint = this.GetChildAtPoint(new Point(234, PanelPos.Y + 2));
            if (controlAtPoint != null && controlAtPoint is Label) { return true; }
            else { return false; }
        }

        string tempMyMoveStep, tempEnermyMoveStep;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // write my move step
            if (BoardStatusUI.MyMoveStep != tempMyMoveStep && BoardStatusUI.MyMoveStep != "Connected" && BoardStatusUI.MyMoveStep != "Started!" && BoardStatusUI.MyMoveStep != "Reseted!")
            {
                if (Game_Mode.gameStyle == GAMESTYLE.WITH_FRIEND)  // play dual online
                {
                    // if don't have step in this pos
                    if (IsMyStep_alreadyInThisPos(new Point(-5, 49 * iNumber)) == false)
                    {
                        Create_Moves_Panel(new Point(-5, 49 * iNumber));
                        Create_MyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                    }
                    else    // already have 
                    {
                        iNumber++;
                        Create_Moves_Panel(new Point(-5, 49 * iNumber));
                        Create_MyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                    }
                    if (Player._MySide == (int)ChessColor.RED) { Game_Movement_History.RED.Add(BoardStatusUI.MyMoveStep); }
                    else { Game_Movement_History.BLACK.Add(BoardStatusUI.MyMoveStep); }
                    tempMyMoveStep = BoardStatusUI.MyMoveStep;
                }

                else if (Game_Mode.gameStyle == GAMESTYLE.ALONE || Game_Mode.gameStyle == GAMESTYLE.VS_COMPUTER)  // play alone -> all move step send to my move step -> check by play turn
                {
                    if (Game_Mode.playTurn == ChessColor.RED)
                    {
                        // if don't have step in this pos
                        if (IsEnermyStep_alreadyInThisPos(new Point(-5, 49 * iNumber)) == false)
                        {
                            Create_Moves_Panel(new Point(-5, 49 * iNumber));
                            Create_EnermyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                        }
                        else    // already have 
                        {
                            iNumber++;
                            Create_Moves_Panel(new Point(-5, 49 * iNumber));
                            Create_EnermyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                        }
                        tempMyMoveStep = BoardStatusUI.MyMoveStep;
                        Game_Movement_History.BLACK.Add(BoardStatusUI.MyMoveStep);
                    }
                    else
                    {
                        // if don't have step in this pos
                        if (IsMyStep_alreadyInThisPos(new Point(-5, 49 * iNumber)) == false)
                        {
                            Create_Moves_Panel(new Point(-5, 49 * iNumber));
                            Create_MyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                        }
                        else    // already have 
                        {
                            iNumber++;
                            Create_Moves_Panel(new Point(-5, 49 * iNumber));
                            Create_MyMoveStep_History(BoardStatusUI.MyMoveStep, new Point(-5, 49 * iNumber));
                        }
                        tempMyMoveStep = BoardStatusUI.MyMoveStep;
                        Game_Movement_History.RED.Add(BoardStatusUI.MyMoveStep);
                    }
                }
            }
            // write enermy move step
            if (BoardStatusUI.EnermyMoveStep != tempEnermyMoveStep && BoardStatusUI.EnermyMoveStep != "Connected" && BoardStatusUI.EnermyMoveStep != "Started!" && BoardStatusUI.EnermyMoveStep != "Reseted!")
            {

                // if don't have step in this pos
                if (IsEnermyStep_alreadyInThisPos(new Point(-5, 49 * iNumber)) == false)
                {
                    Create_Moves_Panel(new Point(-5, 49 * iNumber));
                    Create_EnermyMoveStep_History(BoardStatusUI.EnermyMoveStep, new Point(-5, 49 * iNumber));
                }
                else    // already have 
                {
                    iNumber++;
                    Create_Moves_Panel(new Point(-5, 49 * iNumber));
                    Create_EnermyMoveStep_History(BoardStatusUI.EnermyMoveStep, new Point(-5, 49 * iNumber));
                }
                tempEnermyMoveStep = BoardStatusUI.EnermyMoveStep;
                if (Player._MySide == (int)ChessColor.RED) { Game_Movement_History.BLACK.Add(BoardStatusUI.MyMoveStep); }
                else { Game_Movement_History.RED.Add(BoardStatusUI.MyMoveStep); }
            }

            // recreate new movement history +  when occur a restart request from setting tab
            if (iNumber == 10 || Game_Mode.gameStatus == GAMESTATUS.WAITING || Form_Game_Setting.bRestartRequest == true)
            {
                foreach (Control control in this.Controls)
                {

                    this.Controls.Remove(control);
                    control.Dispose();
                }
                if (this.Controls.Count == 0) { iNumber = 0; Form_Game_Setting.bRestartRequest = false; }
            }
        }
    }
}
