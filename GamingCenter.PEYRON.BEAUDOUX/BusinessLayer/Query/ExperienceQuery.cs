using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Query
{
    class ExperienceQuery
    {
        private ContexteFluent _contexte = null;

        public ExperienceQuery(ContexteFluent contexte) => this._contexte = contexte;

        public List<Experience> GetAllExperiences()
        {
            List<Experience> mesExperiences = _contexte.Experiences.ToList();
            return mesExperiences;
        }

        public Experience GetExperience(int id)
        {
            List<Experience> mesExperiences = GetAllExperiences();
            foreach (Experience e in mesExperiences)
            {
                if (e.Id.Equals(id))
                {
                    return e;
                }
            }
            return null;
        }

        public List<Experience> GetJeuExperiences(int jeuId)
        {
            List<Experience> mesExperiences = GetAllExperiences();
            List<Experience> experiencesDuJeu = new List<Experience>();

            foreach (Experience e in mesExperiences)
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
