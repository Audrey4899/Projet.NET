using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    class AbsenceCommand
    {
        private Contexte _contexte;

        public AbsenceCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        public int Ajouter(Absence a)
        {
            _contexte.Absences.Add(a);
            return _contexte.SaveChanges();
        }
    }
}
