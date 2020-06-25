using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    class NoteCommand
    {
        private Contexte _contexte;

        public NoteCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        public int Ajouter(Note n)
        {
            _contexte.Notes.Add(n);
            return _contexte.SaveChanges();
        }

        public void Modifier(Note n)
        {
            Note modifNote = _contexte.Notes.Where(note => note.NoteId == n.NoteId).Where(note => note.EleveId == n.EleveId).FirstOrDefault();
            if (modifNote != null)
            {
                modifNote.Matiere = n.Matiere;
                modifNote.NoteValeur = n.NoteValeur;
                modifNote.DateNote = n.DateNote;
                modifNote.Appreciation = n.Appreciation;
            }
            _contexte.SaveChanges();
        }
    }
}
