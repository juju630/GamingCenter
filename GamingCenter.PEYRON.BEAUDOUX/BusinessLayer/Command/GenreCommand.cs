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
    class GenreCommand
    {
        private ContexteFluent _contexte = null;
        
        public GenreCommand(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public int CreateGenre(Genre genre)
        {
            _contexte.Genres.Add(genre);
            return _contexte.SaveChanges();
        }

        public int  DeleteGenre(int id)
        {
            Genre tmp = new GenreQuery(_contexte).GetGenre(id);
            if (tmp != null)
            {
                _contexte.Genres.Remove(tmp);
                return _contexte.SaveChanges();
            }
            return 0;
        }

        public int UpdateGenre(int id, string nom)
        {
            Genre tmp = new GenreQuery(_contexte).GetGenre(id);
            if (tmp != null)
            {
                tmp.Nom = nom;
                _contexte.Genres.Add(tmp);
                return _contexte.SaveChanges();
            }
            return 0;
        }
    }
}
