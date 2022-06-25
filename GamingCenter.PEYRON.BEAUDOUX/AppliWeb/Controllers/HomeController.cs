using AppliWeb.Models;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliWeb.Controllers
{
    public class HomeController : Controller
    {

        public IEnumerable<JeuViewModel> getJeux()
        {
            List<JeuViewModel> liste = JeuViewModel.CreateViewModelList(Manager.GetInstance().GetAllJeux());
            foreach(JeuViewModel jeu in liste)
            {
                jeu.Evaluations = EvaluationViewModel.CreateViewModelListe(Manager.GetInstance().GetJeuEvaluations(jeu.Id));
                jeu.Experiences = ExperienceViewModel.CreateViewModelList(Manager.GetInstance().GetJeuExperiences(jeu.Id));
                jeu.updateMoyenne();
            }
            return liste.OrderByDescending(jeu => jeu.Moyenne).Take(5);
        }

        public IEnumerable<EvaluationViewModel> getEvaluations()
        {
            List<EvaluationViewModel> liste = EvaluationViewModel.CreateViewModelListe(Manager.GetInstance().GetAllEvaluations()).OrderByDescending(e => e.Date).Take(5).ToList();
            foreach(EvaluationViewModel evaluation in liste)
            {
                evaluation.NomJeu = Manager.GetInstance().GetJeu(evaluation.JeuId).Nom;
            }
            return liste;
        }

        public IEnumerable<EditeurViewModel> getEditeurs()
        {
            return EditeurViewModel.createViewModelList(Manager.GetInstance().GetAllEditeurs());
        }

        public IEnumerable<GenreViewModel> getGenres()
        {
            return GenreViewModel.CreateViewModelListe(Manager.GetInstance().GetAllGenres());
        }

        public ActionResult Index()
        {
            ViewBag.Genres = getGenres();
            ViewBag.Editeurs = getEditeurs();
            AccueilViewModel accueil = new AccueilViewModel
            {
                Evaluations = getEvaluations().ToList(),
                Jeux = getJeux().ToList(),

            };
            return View("Index", accueil);
        }

        public ActionResult Details(int id)
        {
            return RedirectToAction("Details", "Jeux", new { id = id});
        }


    }
}