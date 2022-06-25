using AppliWeb.Models;
using BusinessLayer;
using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliWeb.Controllers
{
    public class JeuxController : Controller
    {         
        public IEnumerable<JeuViewModel> getJeux()
        {
            return JeuViewModel.CreateViewModelList(Manager.GetInstance().GetAllJeux());
        }

        public IEnumerable<JeuViewModel> getJeuxFiltres(string searchString)
        {
            List<JeuViewModel> jeux = new List<JeuViewModel>(getJeux());
            return getJeux().Where(jeu => jeu.Nom.ToUpper().Contains(searchString.ToUpper()));
        }

        public IEnumerable<EditeurViewModel> getEditeurs()
        {
            return EditeurViewModel.createViewModelList(Manager.GetInstance().GetAllEditeurs());
        }

        public IEnumerable<GenreViewModel> getGenres()
        {
            return GenreViewModel.CreateViewModelListe(Manager.GetInstance().GetAllGenres());
        }

        public ActionResult Index(string searchString)
        {
            ViewBag.Genres = getGenres();
            ViewBag.Editeurs = getEditeurs();
            if (!String.IsNullOrEmpty(searchString))
            {                
                return View("ListJeux", getJeuxFiltres(searchString));
            }

            return View("ListJeux",getJeux());
        }

        public ActionResult Details(int id)
        {
            
            JeuViewModel jeu = JeuViewModel.CreateViewModel(Manager.GetInstance().GetJeu(id));
            jeu.Evaluations = EvaluationViewModel.CreateViewModelListe(Manager.GetInstance().GetJeuEvaluations(id));
            jeu.Experiences = ExperienceViewModel.CreateViewModelList(Manager.GetInstance().GetJeuExperiences(id));
            jeu.updateMoyenne();        
              
            return View("DetailsJeu", jeu);
        }

        public ActionResult Evaluer(int id)
        {
            EvaluationViewModel eval = new EvaluationViewModel();
            eval.JeuId = id;

            return View("Evaluer", eval);
        }

        public ActionResult Edit(int id)
        {
            JeuViewModel jeu = JeuViewModel.CreateViewModel(Manager.GetInstance().GetJeu(id));
            ViewBag.Genres = getGenres();
            ViewBag.Editeurs = getEditeurs();
            return View("EditJeu", jeu);
        }

        public ActionResult Delete(int id)
        {
            Manager.GetInstance().DeleteJeu(id);
            return View("ListJeux", getJeux());
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Genres = getGenres();
            ViewBag.Editeurs = getEditeurs();
            return View("AddJeu");
        }


        [HttpPost]
        public ActionResult Edit(JeuViewModel jeu)
        {
            Manager.GetInstance().UpdateJeu(JeuViewModel.CreateEntity(jeu));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(JeuViewModel jeu)
        {
            Manager.GetInstance().CreateJeu(JeuViewModel.CreateEntity(jeu));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddEvaluation(EvaluationViewModel eval)
        {
            Manager.GetInstance().CreateEvaluation(EvaluationViewModel.CreateEntity(eval));           
            return RedirectToAction("Details", new { id = eval.JeuId });
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ClearSearch()
        {
            return RedirectToAction("Index");
        }

    }
}