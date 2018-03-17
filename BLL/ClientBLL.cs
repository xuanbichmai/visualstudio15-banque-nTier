using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using BO;

namespace BLL
{
    public class ClientBLL
    {
        private ClientDAO daoClient;
        public ClientBLL()
        {
            daoClient = new ClientDAO();
        }
        public DataTable displayClients()
        {
            return daoClient.displayClients();
        }

        public bool updateClient(Client unClient)
        {
            if(daoClient.updateClient(unClient))
                return true;
            return false;
        }
    }
}
