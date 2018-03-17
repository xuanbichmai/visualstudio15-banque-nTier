using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Client
    {
        private int num;
        private string nom;
        private string prenom;
        private string adresse;
        private List<Compte> comptes = new List<Compte>();

        public Client() { }

        public Client(int num, string nom, string prenom, string ad)
        {
            this.num = num;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = ad;
        }

        public int Numero
        {
            get { return num; }
        }
        public string Nom
        {
            get { return nom; }
        }
        public string Prenom
        {
            get { return prenom; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public void ajouterCompte(Compte cpt)
        {

            this.comptes.Add(cpt);

        }

        public override string ToString()

        {

            return (this.num + " " + this.nom + " " + this.prenom + " habitant " + this.adresse);
        }

    }
}

