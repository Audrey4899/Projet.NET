using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Queries
{
    class NoteQuery
    {
        private Contexte _contexte;

        public NoteQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Note> GetAll()
        {
            return _contexte.Notes;
        }

        public IQueryable<Note> GetNotesByEleve(int idEleve)
        {
            return _contexte.Notes.Where(n => n.EleveId == idEleve);
        }
    }
}
