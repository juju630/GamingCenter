using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Query
{
    class GenreQuery
    {
        private ContexteFluent _contexte = null;

        public GenreQuery(ContexteFluent contexte)
        {
            this._contexte = contexte;
        }

        public List<Genre> GetAllGenres()
        {
            List<Genre> mesGenres = _contexte.Genres.ToList();
            return mesGenres;
        }

        public Genre GetGenre(int id)
        {
            List<Genre> mesGenre = GetAllGenres();
            foreach (Genre g in mesGenre)
            {
                if (g.Id.Equals(id))
                {
                    return g;
                }
            }
            return null;
        }

        public Genre GetGenreByName(string name)
        {
            List<Genre> mesGenre = GetAllGenres();
            foreach (Genre g in mesGenre)
            {
                if (g.Nom.Equals(name))
                {
                    return g;
                }
            }
            return null;
        }
    }
}
