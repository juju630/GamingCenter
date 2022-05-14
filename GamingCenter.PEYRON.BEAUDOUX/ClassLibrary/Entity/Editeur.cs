using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Editeur
    {
        private int id;
        private string nom;

        public Editeur(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
