using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
