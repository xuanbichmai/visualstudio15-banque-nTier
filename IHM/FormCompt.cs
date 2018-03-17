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
using DAL;

namespace IHM
{
    public partial class FormCompt : Form
    {
        private CompteBLL cptBLL;
        private int currentRowIndex;
        public FormCompt()
        {
            InitializeComponent();
            cptBLL = new CompteBLL();
        }

        private void FormCompt_Load(object sender, EventArgs e)
        {
            gridViewLoad();
            tb1.Visible = false;
            label1.Visible = false;
            btnValider.Visible = false;
        }

        public void gridViewLoad()
        {
            dgv1.DataSource = cptBLL.displayComptes();
            dgv1.CurrentCell = null;
            dgv1.CurrentCell = dgv1.Rows[currentRowIndex].Cells[1];

            //dgv1.CurrentRow.Selected = true;
           
            
        }
        private void setVisible()
        {
            tb1.Visible = true;
            label1.Visible = true;
            btnValider.Visible = true;
        }
      

        private void créditerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisible();
            label1.Text = "Montant à créditer";
            btnValider.Text = "Créditer";
        }

        private void débiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisible();
            label1.Text = "Montant à débiter";
            btnValider.Text = "Débiter";
        }

        private void découvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisible();
            label1.Text = "Montant de découvert";
            btnValider.Text = "Valider le découvert";
        }


        private void btnValider_Click(object sender, EventArgs e)
        {          
            int numCpt = Convert.ToInt32(dgv1.CurrentRow.Cells[0].Value);
            double solde = Convert.ToDouble(dgv1.CurrentRow.Cells[5].Value);
            double decouv = Convert.ToDouble(dgv1.CurrentRow.Cells[6].Value);
            int numClient = Convert.ToInt32(dgv1.CurrentRow.Cells[1].Value);
            string nom = dgv1.CurrentRow.Cells[2].Value.ToString();
            string prenom = dgv1.CurrentRow.Cells[3].Value.ToString();
            string adr = dgv1.CurrentRow.Cells[4].Value.ToString();
            Client unClient = new Client(numClient, nom, prenom, adr);
            Compte cpt = new Compte(numCpt, solde, decouv, unClient);

            try
            {
                
                if (btnValider.Text == "Créditer")
                {
                    cpt.crediter(Convert.ToDouble(tb1.Text));
                    //MessageBox.Show(Convert.ToString(cpt.Solde)+" "+Convert.ToString(cpt.Numero) );
                    cptBLL.updateCompte(cpt);
                    gridViewLoad();
                    MessageBox.Show("Crédit bien effectué!");
                    tb1.Clear();                 
                }

                if (btnValider.Text == "Débiter")
                {
                    double dDebit = Convert.ToDouble(tb1.Text);

                    if (cpt.débiter(dDebit) == false)
                    {
                        MessageBox.Show("Prélèvement non autorisé! Votre découvert: " + cpt.Decouv + " Votre solde: " + cpt.Solde);
                    }
                    else
                    {
                        cptBLL.updateCompte(cpt);
                        gridViewLoad();
                        MessageBox.Show("Dédit bien effectué!");
                        tb1.Clear();
                    }
                }

                if (btnValider.Text == "Valider le découvert")
                {
                    double dDecouv = Convert.ToDouble(tb1.Text);
                    if (cpt.setDecouv(dDecouv) == false)
                    {
                        MessageBox.Show("Désolez! Votre nouveau découvert est invalide! Votre solde est déja négatif de " + -cpt.Solde + " Euros");
                    }
                    else
                    {
                        cpt.setDecouv(Convert.ToDouble(tb1.Text));
                        cptBLL.updateCompte(cpt);
                        gridViewLoad();
                        MessageBox.Show("Votre nouveau découvert a été bien effectué!");
                        tb1.Clear();
                    }
                }
            }
            catch (FormatException exp)
            {
                MessageBox.Show(exp.Message);
            }
            catch (NullReferenceException exp)
            {
                MessageBox.Show(exp.Message);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClient formClient = new FormClient(this);
            formClient.tbId.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            formClient.tbId.Enabled = false;
            formClient.tbNom.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            formClient.tbNom.Enabled = false;
            formClient.tbPrenom.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
            formClient.tbPrenom.Enabled = false;
            formClient.tbAdr.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
            formClient.ShowDialog();                   
        }

        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentRowIndex = dgv1.CurrentCell.RowIndex;
        }

        private void FormCompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
                btnValider.PerformClick();
                //gridViewLoad();
            }
        }


    }
}
