using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppliWeb.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public GenreViewModel(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public static GenreViewModel CreateViewModel(Genre genre)
        {
            return new GenreViewModel(genre.Id, genre.Nom);
        }

        public static List<GenreViewModel> CreateViewModelListe(List<Genre> liste)
        {
            List<GenreViewModel> listeViewModel = new List<GenreViewModel>();
            foreach(Genre genre in liste)
            {
                listeViewModel.Add(new GenreViewModel(genre.Id, genre.Nom));
            }
            return listeViewModel;  ;
        }

        public static Genre CreateEntity(GenreViewModel genre)
        {
            return new Genre
            {
                Id = genre.Id,
                Nom = genre.Nom,
            };
        }

        public static List<Genre> CreateEntityListe(List<GenreViewModel> liste)
        {
            List<Genre> listeEntity = new List<Genre>();
            foreach (GenreViewModel genre in liste)
            {
                listeEntity.Add( new Genre
                {
                    Id = genre.Id,
                    Nom = genre.Nom,
                });
            }
            return listeEntity; ;
        }
    }

}