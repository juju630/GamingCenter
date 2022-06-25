using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppliWeb.Models
{
    public class EvaluationViewModel
    {

        public int Id { get; set; }
        public string NomEvaluateur { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Range(0, 10, ErrorMessage = "Enter number between 0 to 10")]
        public float Note { get; set; }
        public int JeuId { get; set; }

        public string NomJeu { get; set; }

        public EvaluationViewModel(int id, string nomEvaluateur, DateTime date, int jeuId, float note)
        {
            Id = id;
            NomEvaluateur = nomEvaluateur;
            Date = date;
            JeuId = jeuId;
            Note = note;
        }
        public EvaluationViewModel()
        {
        }

        public static EvaluationViewModel CreateViewModel(Evaluation eval)
        {
            return new EvaluationViewModel(eval.Id, eval.NomEvaluateur, eval.Date, eval.JeuId, eval.Note);
        }

        public static List<EvaluationViewModel> CreateViewModelListe(List<Evaluation> liste)
        {
            List<EvaluationViewModel> listeViewModel = new List<EvaluationViewModel>();
            foreach(Evaluation eval in liste)
            {
                listeViewModel.Add(new EvaluationViewModel(eval.Id, eval.NomEvaluateur, eval.Date, eval.JeuId, eval.Note));
            }
            return listeViewModel; 
        }

        public static Evaluation CreateEntity(EvaluationViewModel eval)
        {
            Evaluation entity = new Evaluation
            {
                Id = eval.Id,
                NomEvaluateur = eval.NomEvaluateur,
                Date = eval.Date,
                JeuId = eval.JeuId,
                Note = eval.Note
            };
            return entity;
        }

        public static List<Evaluation> CreateEntityListe(List<EvaluationViewModel> liste)
        {
            List<Evaluation> listeEntity = new List<Evaluation>();
            foreach (EvaluationViewModel eval in liste)
            {
                listeEntity.Add(CreateEntity(eval));
            }
            return listeEntity;
        }
    }
}