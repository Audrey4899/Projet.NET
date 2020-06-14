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
                elevesVM.Add(new EleveViewModel { Identite = $"{ eleve.Nom } {eleve.Prenom }" });
            }

            return View(elevesVM);
        }

        public ActionResult RechercheEleve(string name)
        {
            List<Eleve> elevesRecherche = manager.GetEleveByName(name);
            foreach (var eleveTrouve in elevesRecherche)
            {
                elevesVM.Add(new EleveViewModel { Identite = $"{ eleveTrouve.Nom } {eleveTrouve.Prenom }" });
            }

            return View(elevesVM);
        }

        public ActionResult DetailEleve(int idEleve)
        {
            Eleve detailEleve = manager.GetEleveById(idEleve);
            EleveViewModel eleveVM = new EleveViewModel 
            { 
                Identite = $"{ detailEleve.Nom } {detailEleve.Prenom }", 
                Notes = $"{ detailEleve.Notes }", 
                Absences = $"{ detailEleve.Absences }" 
            };

            return View(eleveVM);
        }

        public ActionResult DetailClasse(int idClasse)
        {
            List<Eleve> elevesClasse = manager.GetEleveByClasse(idClasse);
            foreach (var eleve in elevesClasse)
            {
                elevesVM.Add(new EleveViewModel { Identite = $"{ eleve.Nom } {eleve.Prenom }" });
            }

            return View(elevesVM);
        }

        //TO DO :
        //Ajouter absence
        //Ajout/Modification Note

    }
}