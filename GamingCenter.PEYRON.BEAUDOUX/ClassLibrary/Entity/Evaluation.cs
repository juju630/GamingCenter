using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Evaluation
    {
        private int id;
        private string nomEvaluateur;
        private DateTime date;
        private float note;

        public Evaluation(int id, string nomEvaluateur, DateTime date, float note)
        {
            Id = id;
            NomEvaluateur = nomEvaluateur;
            Date = date;
            Note = note;
        }

        public int Id { get => id; set => id = value; }
        public string NomEvaluateur { get => nomEvaluateur; set => nomEvaluateur = value; }
        public DateTime Date { get => date; set => date = value; }
        public float Note { get => note; set => note = value; }
    }
}
