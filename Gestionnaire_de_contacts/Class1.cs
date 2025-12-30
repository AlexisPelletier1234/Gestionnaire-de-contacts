using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Gestionnaire_de_contacts
{
    class Contact
    {
        private string prenom;
        private string nom;
        private string numero;

        public string getPrenom()
        {
            return prenom;
        }
        public string getNom()
        {
            return nom;
        }

        public string getNumero()
        {
            return numero;
        }

        public void setPrenom(string prenom_to_set)
        {
            prenom = prenom_to_set;
        }

        public void setNom(string nom_to_set)
        {
            nom = nom_to_set;
        }

        public void setNumero(string numero_to_set)
        {       
            numero = numero_to_set;

        }

        public bool isPrenomValid(string prenom_to_set)
        {
            bool valid = false;
            if (prenom_to_set.Length > 0){
                valid = true;
            }
            return valid;
        }
        public bool isNomValid(string nom_to_set)
        {
            bool valid = false;
            if (nom_to_set.Length > 0)
            {
                valid = true;
            }
            return valid;
        }
        public bool isNumeroValid(string numero_to_set)
        {
            bool valid = false;
            if (Regex.IsMatch(numero_to_set, @"^\+?\d{1,3}?[-.\s]?\(?\d{1,4}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,9}$"))
            {
                valid = true;
            }
            return valid;
        }

        public string getAll()
        {
            return getPrenom() + " " + getNom() + " " + getNumero();
        }
    }
}
