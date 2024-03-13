using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    public class Player
    {
        public static int _MyID;
        public int MyID { get { return _MyID; } }

        public static int _MyAvatar;
        public int MyAvatar { get { return _MyAvatar; } }

        public static int _MySide = -1; // start value
        public int MySide { get { return _MySide; } }


        public static int _FriendPlayerID;
        public int FriendPlayerID { get { return _FriendPlayerID; } }
    }
}
