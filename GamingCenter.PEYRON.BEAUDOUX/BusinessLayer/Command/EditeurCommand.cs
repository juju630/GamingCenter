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
    class EditeurCommand
    {
        private ContexteFluent _contexte = null;

        public EditeurCommand(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public int CreateEditeur(string nom)
        {
            _contexte.Editeurs.Add(new Editeur { Nom = nom });
            return _contexte.SaveChanges();
        }

        public int DeleteEditeur(int id)
        {
            Editeur tmp = new EditeurQuery(_contexte).GetEditeur(id);
            if (tmp != null)
            {
                _contexte.Editeurs.Remove(tmp);
                return _contexte.SaveChanges();
            }
            return 0;
        }

        public int UpdateEditeur(int id, string nom)
        {
            Editeur tmp = new EditeurQuery(_contexte).GetEditeur(id);
            if (tmp != null)
            {
                tmp.Nom = nom;
                return _contexte.SaveChanges();
            }
            return 0;
        }
    }
}
