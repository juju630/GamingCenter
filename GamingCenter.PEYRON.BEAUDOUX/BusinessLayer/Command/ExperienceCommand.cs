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
    class ExperienceCommand
    {
        private ContexteFluent _contexte = null;

        public ExperienceCommand(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public int CreateExperience(string joueur, float tempsDeJeu, float pourcentage, int jeuId)
        {
            _contexte.Experiences.Add(new Experience { Joueur = joueur, TempsDeJeu = tempsDeJeu, Pourcentage = pourcentage, JeuId = jeuId });
            return _contexte.SaveChanges();
        }

        public int DeleteExperience(int id)
        {
            Experience tmp = new ExperienceQuery(_contexte).GetExperience(id);
            if (tmp != null)
            {
                _contexte.Experiences.Remove(tmp);
                return _contexte.SaveChanges();
            }
            return 0;
        }
    }
}
