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
    public class CompteBLL
    {
        private CompteDAO daoCpt;
        public CompteBLL()
        {
            daoCpt = new CompteDAO();
        }
        public DataTable displayComptes()
        {
            return daoCpt.displayComptes();
        }

        public void updateCompte(Compte cpt)
        {
            daoCpt.updateCompte(cpt);
            
        }
    }
}
