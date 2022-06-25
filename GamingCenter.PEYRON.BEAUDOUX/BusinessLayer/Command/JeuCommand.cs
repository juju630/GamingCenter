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
    class JeuCommand
    {
        private ContexteFluent _contexte = null;

        public JeuCommand(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public int CreateJeu(Jeu jeu)
        {
            _contexte.Jeux.Add(jeu);
            return _contexte.SaveChanges();
        }

        public int DeleteJeu(int id)
        {
            Jeu tmp = new JeuQuery(_contexte).GetJeu(id);
            if(tmp != null)
            {
                _contexte.Jeux.Remove(tmp);
                return _contexte.SaveChanges();
            }
            return 0;
        }

        public int UpdateJeu(Jeu jeu)
        {
            Jeu tmp = new JeuQuery(_contexte).GetJeu(jeu.Id);
            if (jeu != null)
            {
                tmp.DateSortie = jeu.DateSortie;
                tmp.Nom = jeu.Nom;
                tmp.Description = jeu.Description;
                tmp.GenreId = jeu.GenreId;
                tmp.EditeurId = jeu.EditeurId;
                return _contexte.SaveChanges();
            }
            return 0;
        }
    }
}
