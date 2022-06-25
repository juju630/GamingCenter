using BusinessLayer.Query;
using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Command
{
    class EvaluationCommand
    {
        private ContexteFluent _contexte = null;

        public EvaluationCommand(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public int CreateEvaluation(Evaluation eval)
        {
            _contexte.Evaluations.Add(new Evaluation { NomEvaluateur = eval.NomEvaluateur, Date = eval.Date, Note = eval.Note, JeuId = eval.JeuId });
            return _contexte.SaveChanges();
        }

        public int DeleteEvaluation(int id)
        {
            Evaluation tmp = new EvaluationQuery(_contexte).GetEvaluation(id);
            if (tmp != null)
            {
                _contexte.Evaluations.Remove(tmp);
                return _contexte.SaveChanges();
            }
            return 0;
        }
    }
}
