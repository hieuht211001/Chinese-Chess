using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    class Game_Movement_History
    {
        public static List<string> RED = new List<string>();
        public static List<string> BLACK = new List<string>();
        public static List<PiecePointPair> DELETED_RED = new List<PiecePointPair>();
        public static List<PiecePointPair> DELETED_BLACK = new List<PiecePointPair>();
    }

    public struct PiecePointPair
    {
        public Pieces Piece { get; set; }
        public Point Point { get; set; }

        public PiecePointPair(Pieces piece, Point point)
        {
            Piece = piece;
            Point = point;
        }
    }
}
