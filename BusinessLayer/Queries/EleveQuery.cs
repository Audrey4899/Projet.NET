using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Queries
{
    class EleveQuery
    {
        private Contexte _contexte;

        public EleveQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Eleve> GetAll()
        {
            return _contexte.Eleves;
        }

        public IQueryable<Eleve> GetByName(string name)
        {
            return _contexte.Eleves.Where(e => e.Nom == name || e.Prenom == name);
        }

        public Eleve GetById(int idEleve)
        {
            return _contexte.Eleves.Where(e => e.EleveId == idEleve).SingleOrDefault();
        }

        public IQueryable<Eleve> GetByClasse(int idClasse)
        {
            return _contexte.Eleves.Where(e => e.ClasseId == idClasse);
        }

        /*SELECT e.nom, AVG(n.valeur) as Moyenne FROM eleve e, note n  WHERE e.EleveId = n.EleveId GROUP BY (e.EleveId) ORDER BY Moyenne DESC*/

        /*public IQueryable<Eleve> Get5Best()
        {
            return _contexte.Eleves
                .Join(_contexte.Eleves, 
                  eleve => eleve.EleveId,        
                  note => note.EleveId,   
                  (eleve, note) => new { Eleve = eleve, Note = note })
        
                .GroupBy(eleve => eleve.Eleve.EleveId)
                .Select(eleve => new { Moyenne = eleve.Average(note => note.Note.NoteValeur), ID = eleve.Key})
                .OrderByDescending(eleve => eleve.Moyenne)
                .ToList();
        }*/
    }
}
