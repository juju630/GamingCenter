using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entity
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string NomEvaluateur { get; set; }
        public DateTime Date { get; set; }
        public float Note { get; set; }
        public int JeuId { get; set; }
        public Jeu Jeu { get; set; }

    }
}
