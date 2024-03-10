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
    public partial class Form_Game_Start : Form_Menu_Base
    {
        public Form_Game_Moves form_Game_Moves = null;
        public Form_Game_Setting form_Game_Setting = null;
        public Form_Game_Start()
        {
            InitializeComponent();
        }

        private void Form_Game_Start_Load(object sender, EventArgs e)
        {
            form_Game_Moves = new Form_Game_Moves();
            form_Game_Moves.TopLevel = false;
            form_Game_Moves.Parent = panel1;
            this.panel1.Controls.Add(form_Game_Moves);
            int x3 = (panel1.Width - form_Game_Moves.Width) / 2;
            int y3 = (panel1.Height - form_Game_Moves.Height) / 2;
            form_Game_Moves.Location = new Point(x3, y3);
            form_Game_Moves.Show();

            form_Game_Setting = new Form_Game_Setting();
            form_Game_Setting.TopLevel = false;
            form_Game_Setting.Parent = panel1;
            this.panel1.Controls.Add(form_Game_Setting);
            int x4 = (panel1.Width - form_Game_Setting.Width) / 2;
            int y4 = (panel1.Height - form_Game_Setting.Height) / 2;
            form_Game_Setting.Location = new Point(x4, y4);
            form_Game_Setting.Hide();
        }
    }
}
