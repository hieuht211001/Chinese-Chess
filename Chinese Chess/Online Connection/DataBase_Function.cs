using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    class DataBase_Function
    {
        DataBase_Connection db_Connection = new DataBase_Connection();

        //set datas to database
        public void SetIniData(int PlayerID, int Avatar, int Side, string pieceMoved)
        {
            try
            {
                DataBase_Type DB_Set = new DataBase_Type()
                {
                    PlayerID = PlayerID,
                    Avatar = Avatar,
                    Side = Side,
                    pieceMoved = pieceMoved
                };
                var SetData = db_Connection.client.Set("Player's List/" + PlayerID, DB_Set);
            }
            catch (Exception)
            {
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Server's Database Set-up failed");
                form_Message.ShowMessage();
                return;
            }

        }

        //Update datas
        public void UpdateData(int PlayerID, string pieceMoved)
        {
            try
            {
                DataBase_Type DB_Set = new DataBase_Type()
                {
                    pieceMoved = pieceMoved
                };
                var SetData = db_Connection.client.Update("Player's List/" + PlayerID, DB_Set); ;
            }
            catch (Exception)
            {
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Server's Database Update failed");
                form_Message.ShowMessage();
                return;
            }
        }

        //Delete datas
        public void DeleteData(int PlayerID)
        {
            try
            {
                var SetData = db_Connection.client.Delete("Player's List/" + PlayerID);
            }
            catch (Exception)
            {
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Server's Database Delete failed");
                form_Message.ShowMessage();
                return;
            }
        }

        //List of the datas
        public Dictionary<int, DataBase_Type> LoadData()
        {
            try
            {
                FirebaseResponse al = db_Connection.client.Get("Player's List/" );
                Dictionary<int, DataBase_Type> ListData = JsonConvert.DeserializeObject<Dictionary<int, DataBase_Type>>(al.Body.ToString());
                return ListData;
            }
            catch (Exception)
            {
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Server's Database Load failed");
                form_Message.ShowMessage();
                return null;
            }
        }
    }
}
