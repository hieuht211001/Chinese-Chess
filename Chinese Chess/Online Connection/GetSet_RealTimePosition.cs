using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{

    public class GetSet_RealTimePosition
    {
        Player playerData = new Player();
        DataBase_Function db_Function  = new DataBase_Function();

        public void SetIniData()
        {
            db_Function.SetIniData(playerData.MyID, playerData.MyAvatar, playerData.MySide, "Connected");
            Console.WriteLine("Doing set ini!");
        }

        public void Send_MyMovement( string pieceMoved)
        {
            db_Function.UpdateData(playerData.MyID, pieceMoved);
            Console.WriteLine("Doing send!");
        }

        public void Reset_EnermyMovement()
        {
            db_Function.UpdateData(playerData.FriendPlayerID, "Reseted!");
            Console.WriteLine("Doing reset!");
        }

        public void Delete_MyGameInfo()
        {
            db_Function.DeleteData(playerData.MyID);
            Console.WriteLine("Doing delete!");
        }

        public void Read_EnermyMoveStep_RealTime()
        {
            Player player = new Player();
            new DataBase_Function().Listen_ReadData(player.FriendPlayerID);
            Console.WriteLine("Doing read!");
        }

        public int Get_EnermyAvatar()
        {
            foreach (var item in db_Function.LoadData())
            {
                if (item.Value.PlayerID == playerData.FriendPlayerID)
                {
                    return item.Value.Avatar;
                }
                Console.WriteLine("Doing get avatar!");
            }
            return -1;
        }

        public int Get_EnermySide()
        {
            foreach (var item in db_Function.LoadData())
            {
                if (item.Value.PlayerID == playerData.FriendPlayerID)
                {
                    return item.Value.Side;
                }
                Console.WriteLine("Doing get side!");
            }
            return (int)ChessColor.ERROR;
        }

    }
}
