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
    public partial class Form_Game_Setting : Form
    {
        Form_Board formBoard;
        public Form_Game_Setting(Form_Board _formBoard)
        {
            InitializeComponent();
            this.formBoard = _formBoard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formBoard.Reset();
        }

        private void btn_AutoLocate_Click(object sender, EventArgs e)
        {
            if (Game_General_Setting.bAutoLocate == false)
            {
                Game_General_Setting.bAutoLocate = true;
                btn_AutoLocate.Text = "Auto Locate On";
                btn_AutoLocate.BackColor = Game_Color.DEEP_RED;
                btn_AutoLocate.ForeColor = Game_Color.WHITE;
            }
            else
            {
                Game_General_Setting.bAutoLocate = false;
                btn_AutoLocate.Text = "Auto Locate Off";
                btn_AutoLocate.BackColor = Game_Color.SLIGHT_PINK;
                btn_AutoLocate.ForeColor = Game_Color.DEEP_RED;
            }
        }

        private void btn_SoundOnOff_Click(object sender, EventArgs e)
        {
            if (Game_Sound.bSoundEnable == false)
            {
                Game_Sound.bSoundEnable = true;
                btn_SoundOnOff.Text = "Sound On";
                btn_SoundOnOff.BackColor = Game_Color.DEEP_RED;
                btn_SoundOnOff.ForeColor = Game_Color.WHITE;
            }
            else
            {
                Game_Sound.bSoundEnable = false;
                btn_SoundOnOff.Text = "Sound Off";
                btn_SoundOnOff.BackColor = Game_Color.SLIGHT_PINK;
                btn_SoundOnOff.ForeColor = Game_Color.DEEP_RED;
            }
        }
    }
}
