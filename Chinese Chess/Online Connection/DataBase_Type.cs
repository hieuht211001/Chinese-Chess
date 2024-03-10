using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    class DataBase_Type
    {
        //datas for database
        public int PlayerID { get; set; }
        public int Avatar { get; set; }
        public int Side { get; set; }
        public string pieceMoved { get; set; }
    }
}
