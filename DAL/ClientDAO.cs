using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using BO;
using System.Data;

namespace DAL
{
    public class ClientDAO
    {
        private ConnexionSql maConnexion1;
        private string provider = "localhost";

        private string dataBase = "banque";

        private string uid = "admin";

        private string mdp = "admin";
        private DataTable dt = null;
        private MySqlCommand cmd, cmd1;
        private MySqlDataReader reader;
        

        public ClientDAO()
        {
            try
            {
                maConnexion1 = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                //maConnexion1.OpenConnection();
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public DataTable displayClients()
        {
            dt = new DataTable();
            try
            {

                maConnexion1.OpenConnection();
                String reqSelectClients = "SELECT * FROM client";
                cmd = maConnexion1.reqExec(reqSelectClients);
                reader = cmd.ExecuteReader();

                for (int i = 0; i <= reader.FieldCount - 1; i++)
                {
                    dt.Columns.Add(reader.GetName(i));
                }
                while (reader.Read())

                {
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i <= reader.FieldCount - 1; i++)
                    {
                        dr[i] = reader.GetValue(i);

                    }

                    dt.Rows.Add(dr);

                }
                reader.Close();
                return dt;
            }
            catch (Exception exp)
            {

                throw (exp);
            }
            finally
            {
                maConnexion1.CloseConnection();
            }

        }


        public bool updateClient(Client unClient)
        {
            try
            {
                maConnexion1.OpenConnection();
                string reqUpdateCompte = "UPDATE client SET adresse='"+unClient.Adresse+"' WHERE num="+unClient.Numero+"";                     
                cmd1 = maConnexion1.reqExec(reqUpdateCompte);
                cmd1.ExecuteNonQuery();
                maConnexion1.CloseConnection();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
