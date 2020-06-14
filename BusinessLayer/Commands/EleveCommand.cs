using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    class EleveCommand
    {
        private Contexte _contexte;

        public EleveCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        public int Ajouter(Eleve e)
        {
            _contexte.Eleves.Add(e);
            return _contexte.SaveChanges();
        }

        public void Modifier(Eleve e)
        {
            Eleve modifEleve = _contexte.Eleves.Where(eleve => eleve.EleveId == e.EleveId).FirstOrDefault();
            if (modifEleve != null)
            {
                modifEleve.Nom = e.Nom;
                modifEleve.Prenom = e.Prenom;
                modifEleve.ClasseId = e.ClasseId;
                modifEleve.DateNaissance = e.DateNaissance;
            }
            _contexte.SaveChanges();
        }

        public void Supprimer (int eleveId)
        {
            Eleve supprEleve = _contexte.Eleves.Where(eleve => eleve.EleveId == eleveId).FirstOrDefault();
            if (supprEleve != null)
            {
                _contexte.Eleves.Remove(supprEleve);
            }
            _contexte.SaveChanges();
        }
    }
}
