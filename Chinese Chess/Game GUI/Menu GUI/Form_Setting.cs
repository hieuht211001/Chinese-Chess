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
    public partial class Form_Setting : Form_Menu_Base
    {
        public Form_Setting()
        {
            InitializeComponent();
        }

        public event EventHandler btn_Back_Clicked;
        private void btn_Back_Click(object sender, EventArgs e)
        {
            btn_Back_Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
