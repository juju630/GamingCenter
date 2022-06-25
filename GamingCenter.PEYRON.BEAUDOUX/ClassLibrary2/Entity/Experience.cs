using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Experience
    {
        public int Id { get; set; }
        public string Joueur { get; set; }
        public float TempsDeJeu { get; set; }
        public float Pourcentage { get; set; }
        public int JeuId { get; set; }
        public Jeu Jeu { get; set; }

    }
        
}
