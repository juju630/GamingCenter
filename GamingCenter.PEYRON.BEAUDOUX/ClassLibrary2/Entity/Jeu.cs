using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Jeu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateSortie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int EditeurId { get; set; }
        public Editeur Editeur { get; set; }   
    }
}
