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

        /*public IQueryable<Eleve> Get5Best()
        {
            return _contexte.Eleves.GroupBy(e => e.EleveId, e => e.Notes.Select(n => n.NoteValeur), (key, notes) => new { EleveId = key, Moyenne = notes.Average() })
                .OrderBy(e => e.Moyenne.Take(5));
        }*/
    }
}
