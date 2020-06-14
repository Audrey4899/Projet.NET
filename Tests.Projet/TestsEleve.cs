using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BusinessLayer;
using Classes.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Projet
{
    [TestClass]
    public class TestsEleve
    {
        Manager manager = Manager.GetInstance();

        [TestMethod]
        public void TestGetAllEleve()
        {
            List<Eleve> eleves = manager.GetAllEleve();
            Assert.IsNotNull(eleves);
        }

        [TestMethod]
        public void TestAjoutEleve()
        {
            List<Note> newNotes = new List<Note>();
            newNotes.Add(new Note { Appreciation = "Bien", DateNote = DateTime.Parse("07/10/2019", CultureInfo.CreateSpecificCulture("fr-FR")), Matiere = "PHP", NoteValeur = 15 });
            newNotes.Add(new Note { Appreciation = "AB", DateNote = DateTime.Parse("27/01/2020", CultureInfo.CreateSpecificCulture("fr-FR")), Matiere = "Anglais", NoteValeur = 12 });

            List<Absence> newAbsences = new List<Absence>();
            newAbsences.Add(new Absence { DateAbsence = DateTime.Parse("28/04/2020", CultureInfo.CreateSpecificCulture("fr-FR")), Motif = "Maladie" });
            newAbsences.Add(new Absence { DateAbsence = DateTime.Parse("20/02/2020", CultureInfo.CreateSpecificCulture("fr-FR")), Motif = "Passage du permis" });

            List<Eleve> newEleves = new List<Eleve>();
            newEleves.Add(new Eleve { Nom = "Martin", Prenom = "Pierre", DateNaissance = DateTime.Parse("07/10/1999", CultureInfo.CreateSpecificCulture("fr-FR")), Notes = newNotes });
            newEleves.Add(new Eleve { Nom = "Dupont", Prenom = "Julie", DateNaissance = DateTime.Parse("18/12/1998", CultureInfo.CreateSpecificCulture("fr-FR")), Absences = newAbsences });
            Classe newClasse = new Classe { Niveau = "LP WEB", NomEtablissement = "UCA IUT", Eleves = newEleves };

            Eleve newEleve = new Eleve { Nom = "Toto", Prenom = "Tata", DateNaissance = DateTime.Parse("09/12/1999", CultureInfo.CreateSpecificCulture("fr-FR")), Classe = newClasse };
            
            manager.AjouterEleve(newEleve);
            Eleve testEleve = manager.GetAllEleve().FirstOrDefault(e => e.Prenom.Equals("Tata"));
            Assert.IsTrue(newEleve.Nom == testEleve.Nom);
        }

        [TestMethod]
        public void TestModifEleve()
        {
            Eleve newEleve = new Eleve { Nom = "Toto", Prenom = "Tata", DateNaissance = DateTime.Parse("09/12/1999", CultureInfo.CreateSpecificCulture("fr-FR")), Classe = new Classe { Niveau = "LP WEB", NomEtablissement = "UCA IUT" } };
            newEleve.Nom = "Titi";
            Eleve eleveModif = newEleve;
            manager.ModifierEleve(eleveModif);
            Eleve testModifEleve = manager.GetAllEleve().FirstOrDefault(e => e.Prenom.Equals("Tata"));
            Assert.IsTrue(eleveModif.Nom == "Titi");
        }

        [TestMethod]
        public void TestSupprEleve()
        {
            Eleve newEleve = new Eleve { Nom = "Doe", Prenom = "John", DateNaissance = DateTime.Parse("14/03/2003", CultureInfo.CreateSpecificCulture("fr-FR")), Classe = new Classe { Niveau = "3B", NomEtablissement = "College ABC" } };
            manager.SupprimerEleve(newEleve.EleveId);
            Eleve testSupprEleve = manager.GetAllEleve().FirstOrDefault(e => e.Prenom.Equals("John"));
            Assert.IsNull(testSupprEleve);
        }
    }
}
