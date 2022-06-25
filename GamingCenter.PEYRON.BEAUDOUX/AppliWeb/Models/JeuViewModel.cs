using AppliWeb.Resources;
using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppliWeb.Models
{
    public class JeuViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateSortie { get; set; }

        [Display(Name ="GenreId", ResourceType =typeof(localize))]
        public int GenreId { get; set; }
        public string GenreNom { get; set; }
        public string EditeurNom { get; set; }

        [Display(Name ="EditeurId",ResourceType =typeof(localize))]
        public int EditeurId { get; set; }
        public float Moyenne { get; set; }
        
        public List<EvaluationViewModel> Evaluations { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }


        public JeuViewModel(int id, string nom, string description, DateTime dateSortie, int genreId, int editeurId, string genreNom, string editeurNom)
        {
            Id = id;
            Nom = nom;
            Description = description;
            DateSortie = dateSortie;
            GenreId = genreId;
            EditeurId = editeurId;
            GenreNom = genreNom;
            EditeurNom = editeurNom;
        }

        public JeuViewModel()
        {
        }

        public static JeuViewModel CreateViewModel(Jeu jeu)
        {
            
            return new JeuViewModel(jeu.Id, jeu.Nom, jeu.Description, jeu.DateSortie, jeu.GenreId, jeu.EditeurId, jeu.Genre.Nom, jeu.Editeur.Nom); ;
        }

        public static List<JeuViewModel> CreateViewModelList(List<Jeu> liste)
        {
            List<JeuViewModel> listeViewmodel = new List<JeuViewModel>();
            foreach(Jeu jeu in liste)
            {
                listeViewmodel.Add(JeuViewModel.CreateViewModel(jeu));
            }
            return listeViewmodel;
        }

        public static Jeu CreateEntity(JeuViewModel jeu)
        {
            Jeu entity = new Jeu
            {
                Id = jeu.Id,
                Nom = jeu.Nom,
                Description = jeu.Description,
                DateSortie = jeu.DateSortie,
                GenreId = jeu.GenreId,
                EditeurId = jeu.EditeurId
            };

            return entity;
        }

        public static List<Jeu> CreateEntityList(List<JeuViewModel> liste)
        {
            List<Jeu> listeEntity = new List<Jeu>();
            foreach (JeuViewModel jeu in liste)
            {
                Jeu entity = new Jeu
                {
                    Id = jeu.Id,
                    Nom = jeu.Nom,
                    Description = jeu.Description,
                    DateSortie = jeu.DateSortie,
                    GenreId = jeu.GenreId,
                    EditeurId = jeu.EditeurId
                };
                listeEntity.Add(entity);

            }
            return listeEntity;
        }

        public void updateMoyenne()
        {
            int nbNotes = Evaluations.Count();
            float val = 0;
            foreach(EvaluationViewModel eval in Evaluations)
            {
                val += eval.Note;
            }
            Moyenne = val / nbNotes;
        }
    }
}