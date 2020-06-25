using ASP.NET.Projet.Models;
using BusinessLayer;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Projet.Controllers
{
    public class HomeController : Controller
    {
        Manager manager = Manager.GetInstance();
        List<EleveViewModel> elevesVM = new List<EleveViewModel>();
        List<ClasseViewModel> classesVM = new List<ClasseViewModel>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListeEleves()
        {
            List<Eleve> eleves = manager.GetAllEleve();
            foreach(var eleve in eleves)
            {
                elevesVM.Add(new EleveViewModel { Identite = $"{ eleve.Nom.ToUpper() } {eleve.Prenom }", ID = eleve.EleveId });
            }

            return View(elevesVM);
        }

        [HttpGet]
        public ActionResult RechercheEleve(string name)
        {
            List<Eleve> elevesRecherche = manager.GetEleveByName(name);
            foreach (var eleveTrouve in elevesRecherche)
            {
                elevesVM.Add(new EleveViewModel { Identite = $"{ eleveTrouve.Nom.ToUpper() } {eleveTrouve.Prenom }" });
            }
            
            return View(elevesVM);
        }

        public ActionResult DetailEleve(int idEleve)
        {
            Eleve eleve = manager.GetEleveById(idEleve);

            List<Note> notes = manager.GetNotesByEleve(idEleve);
            if (notes.Any())
            {
                foreach (var note in notes)
                {
                    eleve.Notes.Add(note);
                }
            }

            List<Absence> absences = manager.GetAbsencesByEleve(idEleve);
            if (absences.Any())
            {
                foreach (var absence in absences)
                {
                    eleve.Absences.Add(absence);
                }
            }
            
            /*return View(eleveVM);*/

            return View(eleve);
        }

        public ActionResult ListeClasses()
        {
            List<Classe> classes = manager.GetAllClasses();
            foreach (var classe in classes)
            {
                classesVM.Add(new ClasseViewModel { Nom = $"{ classe.NomEtablissement }", Niveau = $"{ classe.Niveau }", ID = classe.ClasseId });
            }

            return View(classesVM);
        }

        public ActionResult DetailClasse(int idClasse)
        {
            List<Eleve> elevesClasse = manager.GetEleveByClasse(idClasse);
            foreach (var eleve in elevesClasse)
            {
                elevesVM.Add(new EleveViewModel { Identite = $"{ eleve.Nom.ToUpper() } {eleve.Prenom }" });
            }

            return View(elevesVM);
        }

        [HttpGet]
        public ActionResult AjouterNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterNote(Note note)
        {
            if(!ModelState.IsValid)
            {
                return View(note);
            }
            manager.AjouterNote(note);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult ModifierNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModifierNote(Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }
            manager.ModifierNote(note);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult AjouterAbsence()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterAbsence(Absence absence)
        {
            if (!ModelState.IsValid)
            {
                return View(absence);
            }
            manager.AjouterAbsence(absence);
            return Redirect("/");
        }
    }
}