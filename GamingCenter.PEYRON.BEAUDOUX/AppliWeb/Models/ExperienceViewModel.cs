using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppliWeb.Models
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }
        public string Joueur { get; set; }
        public float TempsDeJeu { get; set; }
        public float Pourcentage { get; set; }
        public int JeuId { get; set; }

        public ExperienceViewModel(int id, string joueur, float tempsDeJeu, float pourcentage, int jeuId)
        {
            Id = id;
            Joueur = joueur;
            TempsDeJeu = tempsDeJeu;
            Pourcentage = pourcentage;
            JeuId = jeuId;
        }

        public static ExperienceViewModel CreateViewModel(Experience exp)
        {
            return new ExperienceViewModel(exp.Id, exp.Joueur, exp.TempsDeJeu, exp.Pourcentage, exp.JeuId);
        }

        public static List<ExperienceViewModel> CreateViewModelList(List<Experience> liste)
        {
            List<ExperienceViewModel> listeviewModel = new List<ExperienceViewModel>();
            foreach(Experience exp in liste)
            {
                listeviewModel.Add(new ExperienceViewModel(exp.Id, exp.Joueur, exp.TempsDeJeu, exp.Pourcentage, exp.JeuId));
            }
            return listeviewModel;  
        }

        public static Experience CreateEntity(ExperienceViewModel exp)
        {
            Experience entity = new Experience
            {
                Id = exp.Id,
                Joueur = exp.Joueur,
                TempsDeJeu = exp.TempsDeJeu,
                Pourcentage = exp.Pourcentage,
                JeuId = exp.JeuId
            };

            return entity;
        }

        public static List<Experience> CreateEntityList(List<ExperienceViewModel> liste)
        {
            List<Experience> listeEntity = new List<Experience>();
            foreach (ExperienceViewModel exp in liste)
            {
                Experience entity = new Experience
                {
                    Id = exp.Id,
                    Joueur = exp.Joueur,
                    TempsDeJeu = exp.TempsDeJeu,
                    Pourcentage = exp.Pourcentage,
                    JeuId = exp.JeuId
                };

                listeEntity.Add(entity);
            }
            return listeEntity;
        }
    }
}