using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Compte
    {
        private int num;
        private Client proprio;
        private double solde;
        private double decouv;

        public Compte() { }

        public Compte(int n, double unSolde, double unDecouv, Client c)
        {
            num = n;
            this.solde = unSolde;
            this.decouv = unDecouv;
            proprio = c;
            this.proprio.ajouterCompte(this);
        }

        public Compte(int n, Client c)
        {
            num = n;
            proprio = c;
            this.proprio.ajouterCompte(this);
        }
    
        public double Solde
        {
            get { return solde; }
            set { solde = value; }
        }

        public double Decouv
        {
            get { return decouv; }
        }


        public bool setDecouv(double value)

        {

            bool res = false;

            if (this.solde > -value)
            {
                decouv = value;

                res = true;
            }


            return (res);

        }

        public int Numero
        {
            get
            { return num; }
        }



        public string Description
        {
            get { return num + " " + proprio + " " + " solde: " + solde + " Euros" + " - decouvert: " + decouv + " Euros"; }
        }

        public Client Propriétaire
        {
            get { return proprio; }
        }


        public void crediter(double mont)
        {
            this.solde = this.solde + mont;
        }

        public bool débiter(double mont)
        {
            if (solde - mont < -decouv)
            {
                return false;
            }
            else
            {
                solde = solde - mont;
                return true;
            }
        }
    }
}
