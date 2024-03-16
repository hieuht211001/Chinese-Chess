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
    public partial class Main_UI : Form
    {
        // panel left
        public Form_Board form_Board = null;
        //panel right
        public Form_Menu form_Menu = null;
        public Form_Connect form_Connect = null;
        public Form_Setting form_Setting = null;
        public Form_Game_Start form_Game_Start = null;
        Timer timer;
        public bool dragging;
        public Point startPoint;
        Timer timerCheckGameStatus;

        public Main_UI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Main_UI_Load(object sender, EventArgs e)
        {
            form_Board = new Form_Board();
            form_Board.TopLevel = false;
            panelForBoard.Controls.Add(form_Board);
            int x = (panelForBoard.Width - form_Board.Width) / 2;
            int y = (panelForBoard.Height - form_Board.Height) / 2;
            form_Board.Location = new Point(x, y);
            form_Board.Show();

            form_Menu = new Form_Menu();
            form_Menu.TopLevel = false;
            this.panelForMenu.Controls.Add(form_Menu);
            form_Menu.Parent = panelForMenu;
            int x2 = (panelForMenu.Width - form_Menu.Width) / 2;
            int y2 = (panelForMenu.Height - form_Menu.Height) / 2;
            form_Menu.Dock = DockStyle.Fill;
            form_Menu.Location = new Point(x2, y2);
            form_Menu.Show();
            form_Menu.btn_PlayWithFriend_Clicked += form_Menu_btn_PlayWithFriend_Clicked;
            form_Menu.btn_Setting_Clicked += form_Menu_btn_btn_Setting_Clicked;

            form_Connect = new Form_Connect();
            form_Connect.TopLevel = false;
            form_Connect.Parent = panelForMenu;
            this.panelForMenu.Controls.Add(form_Connect);
            int x3 = (panelForMenu.Width - form_Connect.Width) / 2;
            int y3 = (panelForMenu.Height - form_Connect.Height) / 2;
            form_Connect.Location = new Point(x3, y3);
            form_Connect.btn_Back_Clicked += form_Connect_btn_Back_Clicked;
            form_Connect.btn_Apply_Clicked += Form_Connect_btn_Apply_Clicked;
            form_Connect.Hide();

            form_Setting = new Form_Setting();
            form_Setting.TopLevel = false;
            form_Setting.Parent = panelForMenu;
            this.panelForMenu.Controls.Add(form_Setting);
            int x4 = (panelForMenu.Width - form_Setting.Width) / 2;
            int y4 = (panelForMenu.Height - form_Setting.Height) / 2;
            form_Setting.Location = new Point(x4, y4);
            form_Setting.btn_Back_Clicked += form_Connect_btn_Back_Clicked;
            form_Setting.Hide();

            form_Game_Start = new Form_Game_Start();
            form_Game_Start.TopLevel = false;
            form_Game_Start.Parent = panelForMenu;
            this.panelForMenu.Controls.Add(form_Game_Start);
            int x5 = (panelForMenu.Width - form_Game_Start.Width) / 2;
            int y5 = (panelForMenu.Height - form_Game_Start.Height) / 2;
            form_Game_Start.Location = new Point(x5, y5);
            form_Game_Start.Show();
        }

        private void Form_Connect_btn_Apply_Clicked(object sender, EventArgs e)
        {
            timerCheckGameStatus = new Timer();
            timerCheckGameStatus.Interval = 500;
            timerCheckGameStatus.Tick += (sender1, e1) =>
            {
                if (Game_Mode.gameStatus == GAMESTATUS.READY_TOSTART)
                {
                    form_Menu.Visible = false;
                    form_Connect.Visible = false;
                    form_Setting.Visible = false;
                    form_Game_Start.Visible = true;
                    timerCheckGameStatus.Stop();
                }
            };
            timerCheckGameStatus.Start();
        }

        private void form_Connect_btn_Back_Clicked(object sender, EventArgs e)
        {
            form_Menu.Visible = true;
            form_Connect.Visible = false;
            form_Setting.Visible = false;
            form_Game_Start.Visible = false;
        }

        private void form_Menu_btn_PlayWithFriend_Clicked(object sender, EventArgs e)
        {
            form_Connect.Visible = true;
            form_Menu.Visible = false;
            form_Setting.Visible = false;
            form_Game_Start.Visible = false;
        }

        private void form_Menu_btn_btn_Setting_Clicked(object sender, EventArgs e)
        {
            form_Connect.Visible = false;
            form_Menu.Visible = false;
            form_Setting.Visible = true;
            form_Game_Start.Visible = false;
        }

        private void Main_UI_MouseDown(object sender, MouseEventArgs e)
        {
            Point cursorPos = PointToClient(Cursor.Position);
            int IcursorPosY = Convert.ToInt32(cursorPos.Y);
            if (IcursorPosY < this.Height/30) { dragging = true; }
            startPoint = new Point(e.X,e.Y);
        }

        private void Main_UI_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void Main_UI_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
