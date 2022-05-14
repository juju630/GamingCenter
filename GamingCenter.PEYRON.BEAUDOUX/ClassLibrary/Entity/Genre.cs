using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Genre
    {
        private int id;
        private string nom;

        public Genre(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
