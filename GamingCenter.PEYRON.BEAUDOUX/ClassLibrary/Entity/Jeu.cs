using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Jeu
    {
        private int id;
        private string nom;
        private string description;
        private DateTime dateSortie;

        public Jeu(int id, string nom, string description, DateTime dateSortie)
        {
            this.Id = id;
            this.Nom = nom;
            this.Description = description;
            this.DateSortie = dateSortie;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DateSortie { get => dateSortie; set => dateSortie = value; }
    }
}
