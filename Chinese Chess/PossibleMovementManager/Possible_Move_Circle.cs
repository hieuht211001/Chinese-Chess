using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinese_Chess
{
    public class Possible_Move_Circle: PossibleMovement_CircleData
    {
        public static List<PictureBox> circle_ptbList = new List<PictureBox>();
        public static List<Point> circlePtb_PositionList = new List<Point>();
        public void Create(PictureBox ptbBoard, Point point)
        {
            PictureBox ptb = new PictureBox();
            ptb.Image = global::Chinese_Chess.Properties.Resources.step_circle;
            ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            ptb.Size = new Size(70, 70);
            ptb.Visible = true;
            ptb.Location = point;
            ptb.BackColor = Color.Transparent;
            ptbBoard.Controls.Add(ptb);
            // add to list to delete all circle when click other pieces
            //circle_ptbList.Add(ptb);
            //ptb.Click += Ptb_Click;
            Add_Circle_ByPos(point);
            circle_ptbList.Add(ptb);
            circlePtb_PositionList.Add(ptb.Location);

            // Delete circle when move completed
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender, e) =>
            {
                if (Pieces.isDragging == false && Pieces.isClicked == false)
                {
                    ptbBoard.Controls.Remove(ptb);
                    ptb.Dispose();
                    Delete_Circle_ByPos(point);
                    timer.Stop();
                }
            };
            timer.Start();
        }

        public void Delete_All(PictureBox ptbBoard)
        {
            foreach (PictureBox ptb in circle_ptbList)
            {
                ptbBoard.Controls.Remove(ptb);
                ptb.Dispose();
            }
            circle_ptbList.Clear();
            circlePtb_PositionList.Clear();
        }
    }
}
