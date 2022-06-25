using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Query
{
    class JeuQuery
    {

        private ContexteFluent _contexte = null;

        public JeuQuery(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public List<Jeu> GetAllJeux()
        {
            List<Jeu> mesJeux = _contexte.Jeux.ToList();
            return mesJeux;
        }

        public Jeu GetJeu(int id)
        {
            List<Jeu> mesJeux = GetAllJeux();
            foreach (Jeu j in mesJeux)
            {
                if (j.Id.Equals(id))
                {
                    return j;                    
                }
            }
            return null;
        }
    }
}
