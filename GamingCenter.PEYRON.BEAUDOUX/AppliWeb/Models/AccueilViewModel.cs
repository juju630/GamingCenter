using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppliWeb.Models
{
    public class AccueilViewModel
    {
        public AccueilViewModel()
        {
            Evaluations = new List<EvaluationViewModel>(5);
            Jeux = new List<JeuViewModel>(5);
        }

        public List<EvaluationViewModel> Evaluations { get; set; }
        public List<JeuViewModel> Jeux { get; set; }


    }
}