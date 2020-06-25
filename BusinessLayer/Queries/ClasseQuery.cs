using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Queries
{
    class ClasseQuery
    {
        private Contexte _contexte;

        public ClasseQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Classe> GetAll()
        {
            return _contexte.Classes;
        }
    }
}
