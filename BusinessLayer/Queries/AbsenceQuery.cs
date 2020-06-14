using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Queries
{
    class AbsenceQuery
    {
        private Contexte _contexte;

        public AbsenceQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Absence> GetAll()
        {
            return _contexte.Absences;
        }

        public IQueryable<Absence> GetAbsencesByEleve(int idEleve)
        {
            return _contexte.Absences.Where(a => a.EleveId == idEleve);
        }
    }
}
