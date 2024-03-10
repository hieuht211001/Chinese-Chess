using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    public enum ChessLocationX
    {
        A = 0,
        B = 70,
        C = 140,
        D = 210,
        E = 280,
        F = 350,
        G = 420,
        H = 490,
        J = 560
    }

    public enum ChessLocationY
    {
        _0 = 630,
        _1 = 560,
        _2 = 490,
        _3 = 420,
        _4 = 350,
        _5 = 280,
        _6 = 210,
        _7 = 140,
        _8 = 70,
        _9 = 0
    }
    public enum DeletedQueueLocation
    {
        Red_X = 770,
        Red_Y = 680,
        Black_X = 15,
        Black_Y = 50
    }
}
