using BusinessLayer.Command;
using BusinessLayer.Query;
using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Manager
    {
        private ContexteFluent _contexte;
        private static Manager _instance;

        private Manager()
        {
            _contexte = new ContexteFluent();

        }

        public static Manager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Manager();
            }
            return _instance;
        }

        #region --- JEUX ---
        public List<Jeu> GetAllJeux()
        {
            return new JeuQuery(_contexte).GetAllJeux();
        }

        public Jeu GetJeu(int id)
        {
            return new JeuQuery(_contexte).GetJeu(id);
        }

        public int DeleteJeu(int id)
        {
            return new JeuCommand(_contexte).DeleteJeu(id);
        }

        public int CreateJeu(Jeu jeu)
        {
            return new JeuCommand(_contexte).CreateJeu(jeu); ;
        }

        public int UpdateJeu(Jeu jeu)
        {
            return new JeuCommand(_contexte).UpdateJeu(jeu);
        }
        #endregion

        #region --- GENRES ---
        public List<Genre> GetAllGenres()
        {
            return new GenreQuery(_contexte).GetAllGenres();
        }

        public Genre GetGenre(int id)
        {
            return new GenreQuery(_contexte).GetGenre(id);
        }

        public Genre GetGenreByName(string name)
        {
            return new GenreQuery(_contexte).GetGenreByName(name);
        }

        public int DeleteGenre(int id)
        {
            return new GenreCommand(_contexte).DeleteGenre(id);
        }

        public int CreateGenre(Genre genre)
        {
            return new GenreCommand(_contexte).CreateGenre(genre); ;
        }

        public int UpdateGenre(int id, string nom)
        {
            return new GenreCommand(_contexte).UpdateGenre(id, nom);
        }
        #endregion

        #region --- EDITEUR ---
        public List<Editeur> GetAllEditeurs()
        {
            return new EditeurQuery(_contexte).GetAllEditeurs();
        }

        public Editeur GetEditeur(int id)
        {
            return new EditeurQuery(_contexte).GetEditeur(id);
        }

        public int DeleteEditeur(int id)
        {
            return new EditeurCommand(_contexte).DeleteEditeur(id);
        }

        public int CreateEditeur(string nom)
        {
            return new EditeurCommand(_contexte).CreateEditeur(nom); ;
        }

        public int UpdateEditeur(int id, string nom)
        {
            return new EditeurCommand(_contexte).UpdateEditeur(id, nom);
        }
        #endregion

        #region --- EVALUTATION ---
        public List<Evaluation> GetAllEvaluations()
        {
            return new EvaluationQuery(_contexte).GetAllEvaluations();
        }

        public Evaluation GetEvaluation(int id)
        {
            return new EvaluationQuery(_contexte).GetEvaluation(id);
        }

        public List<Evaluation> GetJeuEvaluations(int jeuId)
        {
            return new EvaluationQuery(_contexte).GetJeuEvaluations(jeuId);
        }

        public int DeleteEvaluation(int id)
        {
            return new EvaluationCommand(_contexte).DeleteEvaluation(id);
        }

        public int CreateEvaluation(Evaluation eval)
        {
            return new EvaluationCommand(_contexte).CreateEvaluation(eval);
        }
        #endregion

        #region --- EXPERIENCE ---
        public List<Experience> GetAllExperiences()
        {
            return new ExperienceQuery(_contexte).GetAllExperiences();
        }

        public Experience GetExperience(int id)
        {
            return new ExperienceQuery(_contexte).GetExperience(id);
        }

        public List<Experience> GetJeuExperiences(int jeuId)
        {
            return new ExperienceQuery(_contexte).GetJeuExperiences(jeuId);
        }

        public int DeleteExperience(int id)
        {
            return new ExperienceCommand(_contexte).DeleteExperience(id);
        }

        public int CreateExperience(string nomJoueur,float tempsJeu,float pourcentage,int jeu)
        {
            return new ExperienceCommand(_contexte).CreateExperience(nomJoueur, tempsJeu, pourcentage, jeu); ;
        }
        #endregion
    }
}
