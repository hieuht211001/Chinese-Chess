using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Chinese_Chess
{
    public enum ButtonSelect
    {
        YES,
        NO
    }
    public enum MessageBoxMode
    {
        ALARM,
        ERROR,
        WAITTING
    }
    public partial class Form_Message : Form
    {
        public MessageBoxMode _mMode;
        public string _message;
        public bool bYesOrNoClicked;
        public Form_Message(MessageBoxMode mMode, string Message)
        {
            InitializeComponent();
            this._mMode = mMode;
            this._message = Message;
            this.CenterFormOnScreen();
        }

        public void ShowMessage()
        {
            if (_mMode == MessageBoxMode.ALARM) 
            {
                lblMessage.Text = this._message;
                this.ShowDialog();
            }
            else if (_mMode == MessageBoxMode.ERROR)
            {
                btn_Yes.Text = "OK";
                btn_No.Enabled = false;
                btn_No.Visible = false;
                btn_Yes.Location = new Point(114, 97);
                lblMessage.Text = this._message;
                this.ShowDialog();
            }
            else if (_mMode == MessageBoxMode.WAITTING)
            {
                CenterFormOnScreen();
                btn_Yes.Enabled = false;
                btn_Yes.Visible = false;
                btn_No.Text = "Exit";
                btn_No.Location = new Point(114, 97);
                lblMessage.Text = this._message;
                this.Show();
            }
        }
        private void CenterFormOnScreen()
        {
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width + 370;
            int formHeight = this.Height;

            this.Left = (screenWidth - formWidth) / 2;
            this.Top = (screenHeight - formHeight) / 2;
        }


        private void btn_Yes_Click(object sender, EventArgs e)
        {
            bYesOrNoClicked = true;
            this.Close();
            this.Dispose();
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            bYesOrNoClicked = false;
            this.Close();
            this.Dispose();
        }

        public void HideMessage()
        {
            this.Close();
            this.Dispose();
        }
    }
}
