using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chinese_Chess
{
    class DataBase_Connection
    {
        //firebase connection Settings
        public IFirebaseConfig DataBase_Server = new FirebaseConfig()
        {
            AuthSecret = "yPQAd8DfopdbjfwImex1d12GRDxJmaVpdjKD84Q4",
            BasePath = "https://chinese-chess-db-default-rtdb.firebaseio.com/"
        };

        public FireSharp.FirebaseClient client;

        //Code to warn console if class cannot connect when called.
        public DataBase_Connection()
        {
            try
            {
                client = new FireSharp.FirebaseClient(DataBase_Server);
            }
            catch (Exception)
            {
                Form_Message form_Message = new Form_Message(MessageBoxMode.ERROR, "Connection to server failed");
                form_Message.ShowMessage();
            }
        }
    }
}
