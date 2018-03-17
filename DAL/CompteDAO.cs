using BO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CompteDAO
    {
        private ConnexionSql maConnexion;
        private string provider = "localhost";

        private string dataBase = "banque";

        private string uid = "admin";

        private string mdp = "admin";
        //private List<Compte> listCpt;
        private DataTable dt;
        private MySqlCommand cmd, cmd1;
        private MySqlDataReader reader;
        //private MySqlDataAdapter adapter;

        public CompteDAO()
        {
            try
            {
                maConnexion = ConnexionSql.getInstance(provider, dataBase, uid, mdp);            
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable displayComptes()
        {
            dt = new DataTable();
            try
            {
                
                maConnexion.OpenConnection();
                String reqSelectClients = "SELECT c.num as numCompte, cli.num as numClient, cli.nom, cli.prenom, cli.adresse, c.solde, c.decouvert FROM COMPTE c JOIN CLIENT cli ON cli.num = c.numClient";
                cmd = maConnexion.reqExec(reqSelectClients);
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

                throw(exp);
            }
            finally
            {
                maConnexion.CloseConnection();
            }

        }
        
           
            
        
        public void updateCompte(Compte cpt)
        {
            try
            {
                maConnexion.OpenConnection();
                string reqUpdateCompte = "UPDATE compte SET solde=" + cpt.Solde + ", decouvert=" + cpt.Decouv + " WHERE num=" + cpt.Numero + "";                                      
                cmd1 = maConnexion.reqExec(reqUpdateCompte);
                cmd1.ExecuteNonQuery();
                maConnexion.CloseConnection();
            }
            catch (Exception)
            {

                throw;
            }          
        }
      }

    }

        
    

