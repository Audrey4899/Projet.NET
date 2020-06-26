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
        List<AbsenceViewModel> absenceVM = new List<AbsenceViewModel>();

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
        public ActionResult AjouterNote(NoteViewModel noteVM, int idEleve)
        {
            if(!ModelState.IsValid)
            {
                return View(noteVM);
            }
            Note note = new Note { Appreciation = noteVM.Appreciation, DateNote = noteVM.Date, Matiere = noteVM.Matiere, NoteValeur = noteVM.Note, EleveId = idEleve };
            manager.AjouterNote(note);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult ModifierNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModifierNote(NoteViewModel noteVM, int idEleve, int idNote)
        {
            if (!ModelState.IsValid)
            {
                return View(noteVM);
            }

            Note note = manager.GetNoteById(idNote);

            note.Appreciation = noteVM.Appreciation;
            note.DateNote = noteVM.Date;
            note.Matiere = noteVM.Matiere;
            note.NoteValeur = noteVM.Note;
            note.EleveId = idEleve;

            manager.ModifierNote(note);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult AjouterAbsence()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterAbsence(AbsenceViewModel absenceVM, int idEleve)
        {
            if (!ModelState.IsValid)
            {
                return View(absenceVM);
            }
            Absence absence = new Absence { DateAbsence = absenceVM.Date, Motif = absenceVM.Motif, EleveId = idEleve };
            manager.AjouterAbsence(absence);
            return Redirect("/");
        }

        public ActionResult ListeLastAbsences()
        {
            List<Absence> absences = manager.Get5Last();
            if(absences.Any())
            {
                foreach (var absence in absences)
                {
                    absenceVM.Add(new AbsenceViewModel { Motif = $"{ absence.Motif }", Date = absence.DateAbsence });
                }
            }

            return View(absenceVM);
        }
    }
}