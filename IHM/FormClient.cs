using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BO;
using IHM;

namespace DAL
{
    public partial class FormClient : Form
    {
        private ClientBLL clientBLL;
        private CompteBLL comptBLL;
        private FormCompt formCompt=null;
        public FormClient(FormCompt formCpt)
        {
            InitializeComponent();
            clientBLL = new ClientBLL();
            comptBLL = new CompteBLL();
            this.formCompt = formCpt;

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int numCli = Convert.ToInt16(tbId.Text);
            string nomCli = tbNom.Text;
            string prenomCli = tbPrenom.Text;
            string adrCli = tbAdr.Text;
            Client unClient = new Client(numCli, nomCli, prenomCli, adrCli);
            //DataGridView dg = (DataGridView) formCompt.Controls["dgv1"];
            try
            {
                clientBLL.updateClient(unClient);
                formCompt.gridViewLoad();
                //dg.DataSource = comptBLL.displayComptes();
                
                if (clientBLL.updateClient(unClient))
                {
                    tbAdr.Enabled = false;
                    btnEnregistrer.Enabled = false;
                    MessageBox.Show("Votre adresse est bien mise à jour!");                
                }          
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
