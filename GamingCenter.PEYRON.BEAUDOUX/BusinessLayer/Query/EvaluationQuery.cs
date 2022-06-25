using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Query
{
    class EvaluationQuery
    {
        private ContexteFluent _contexte = null;

        public EvaluationQuery(ContexteFluent contexte) => this._contexte = contexte;

        public List<Evaluation> GetAllEvaluations()
        {
            List<Evaluation> mesEvaluations = _contexte.Evaluations.ToList();
            return mesEvaluations;
        }

        public Evaluation GetEvaluation(int id)
        {
            List<Evaluation> mesEvaluations = GetAllEvaluations();
            foreach (Evaluation e in mesEvaluations)
            {
                if (e.Id.Equals(id))
                {
                    return e;
                }
            }
            return null;
        }

        public List<Evaluation> GetJeuEvaluations(int jeuId)
        {
            List<Evaluation> mesExperiences = GetAllEvaluations();
            List<Evaluation> experiencesDuJeu = new List<Evaluation>();

            foreach (Evaluation e in mesExperiences)
            {
                if (e.JeuId.Equals(jeuId))
                {
                    experiencesDuJeu.Add(e);
                }
            }
            return experiencesDuJeu;
        }
    }
}
