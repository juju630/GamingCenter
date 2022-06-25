using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Query
{
    class EditeurQuery
    {
        private ContexteFluent _contexte = null;

        public EditeurQuery(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public List<Editeur> GetAllEditeurs()
        {
            List<Editeur> mesEditeurs = _contexte.Editeurs.ToList();
            return mesEditeurs;
        }

        public Editeur GetEditeur(int id)
        {
            List<Editeur> mesEditeurs = GetAllEditeurs();
            foreach (Editeur e in mesEditeurs)
            {
                if (e.Id.Equals(id))
                {
                    return e;
                }
            }
            return null;
        }
    }
}
