using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Experience
    {
        private int id;
        private string joueur;
        private float tempsDeJeu;
        private float pourcentage;

        public Experience(int id, string joueur, float tempsDeJeu, float pourcentage)
        {
            Id = id;
            Joueur = joueur;
            TempsDeJeu = tempsDeJeu;
            Pourcentage = pourcentage;
        }

        public int Id { get => id; set => id = value; }
        public string Joueur { get => joueur; set => joueur = value; }
        public float TempsDeJeu { get => tempsDeJeu; set => tempsDeJeu = value; }
        public float Pourcentage { get => pourcentage; set => pourcentage = value; }
    }
        
}
