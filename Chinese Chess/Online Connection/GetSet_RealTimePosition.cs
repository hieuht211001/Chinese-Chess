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
        }

        public void Send_MyMovement( string pieceMoved)
        {
            db_Function.UpdateData(playerData.MyID, pieceMoved);
        }

        public void Reset_EnermyMovement()
        {
            db_Function.UpdateData(playerData.FriendPlayerID, null);
        }

        public void Delete_MyGameInfo()
        {
            db_Function.DeleteData(playerData.MyID);
        }

        public string Read_EnermyMovement()
        {
            foreach (var item in db_Function.LoadData())
            {
                try
                {
                    if (item.Value.PlayerID == playerData.FriendPlayerID)
                    {
                        return item.Value.pieceMoved;
                    }
                }
                catch (Exception ex)
                {
                    Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Friend is not connected");
                    form_Message.ShowMessage();
                    return null;
                }
            }
            return null;
        }

        public int Get_EnermyAvatar()
        {
            foreach (var item in db_Function.LoadData())
            {
                if (item.Value.PlayerID == playerData.FriendPlayerID)
                {
                    return item.Value.Avatar;
                }
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
            }
            return (int)ChessColor.ERROR;
        }

    }
}
