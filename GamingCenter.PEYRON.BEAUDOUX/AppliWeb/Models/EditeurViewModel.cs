using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppliWeb.Models
{
    public class EditeurViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public EditeurViewModel(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public static EditeurViewModel createViewModel(Editeur editeur)
        {
            return new EditeurViewModel(editeur.Id, editeur.Nom);
        }

        public static List<EditeurViewModel> createViewModelList(List<Editeur> liste)
        {
            List<EditeurViewModel> listeViewModel = new List<EditeurViewModel>();
            foreach(Editeur editeur in liste)
            {
                listeViewModel.Add(new EditeurViewModel(editeur.Id, editeur.Nom));
            }
            return listeViewModel;
        }

        public static Editeur CreateEntity(EditeurViewModel genre)
        {
            return new Editeur
            {
                Id = genre.Id,
                Nom = genre.Nom,
            };
        }

        public static List<Editeur> CreateEntityListe(List<EditeurViewModel> liste)
        {
            List<Editeur> listeEntity = new List<Editeur>();
            foreach (EditeurViewModel genre in liste)
            {
                listeEntity.Add(new Editeur
                {
                    Id = genre.Id,
                    Nom = genre.Nom,
                });
            }
            return listeEntity; ;
        }
    }
}