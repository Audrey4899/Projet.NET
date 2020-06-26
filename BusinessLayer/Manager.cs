using BusinessLayer.Commands;
using BusinessLayer.Queries;
using Classes;
using Classes.Entites;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Manager
    {
        private Contexte contexte;
        private static Manager _Instance;

        private Manager()
        {
            contexte = new Contexte();
        }
        public static Manager GetInstance()
        {
            if (_Instance != null)
            {
                return _Instance;
            }
            _Instance = new Manager();
            return _Instance;
        }

        #region Eleve

        public List<Eleve> GetAllEleve()
        {
            EleveQuery eq = new EleveQuery(contexte);
            return eq.GetAll().ToList();
        }

        public List<Eleve> GetEleveByName(string name)
        {
            EleveQuery eq = new EleveQuery(contexte);
            return eq.GetByName(name).ToList();
        }

        public Eleve GetEleveById(int idEleve)
        {
            EleveQuery eq = new EleveQuery(contexte);
            return eq.GetById(idEleve);
        }

        public List<Eleve> GetEleveByClasse(int idClasse)
        {
            EleveQuery eq = new EleveQuery(contexte);
            return eq.GetByClasse(idClasse).ToList();
        }

        public int AjouterEleve(Eleve e)
        {
            EleveCommand ec = new EleveCommand(contexte);
            return ec.Ajouter(e);
        }

        public void ModifierEleve(Eleve e)
        {
            EleveCommand ec = new EleveCommand(contexte);
            ec.Modifier(e);
        }

        public void SupprimerEleve(int eleveId)
        {
            EleveCommand ec = new EleveCommand(contexte);
            ec.Supprimer(eleveId);
        }

        #endregion

        #region Note

        public List<Note> GetAllNote()
        {
            NoteQuery nq = new NoteQuery(contexte);
            return nq.GetAll().ToList();
        }
        
        public List<Note> GetNotesByEleve(int idEleve)
        {
            NoteQuery nq = new NoteQuery(contexte);
            return nq.GetNotesByEleve(idEleve).ToList();
        }

        public int AjouterNote(Note n)
        {
            NoteCommand nc = new NoteCommand(contexte);
            return nc.Ajouter(n);
        }

        public void ModifierNote(Note n)
        {
            NoteCommand nc = new NoteCommand(contexte);
            nc.Modifier(n);
        }

        public Note GetNoteById(int idNote)
        {
            NoteQuery nq = new NoteQuery(contexte);
            return nq.GetNoteById(idNote);
        }

        #endregion

        #region Absence

        public List<Absence> GetAllAbsence()
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            return aq.GetAll().ToList();
        }
        public List<Absence> GetAbsencesByEleve(int idEleve)
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            return aq.GetAbsencesByEleve(idEleve).ToList();
        }

        public int AjouterAbsence(Absence a)
        {
            AbsenceCommand ac = new AbsenceCommand(contexte);
            return ac.Ajouter(a);
        }

        public List<Absence> Get5Last()
        {
            AbsenceQuery aq = new AbsenceQuery(contexte);
            return aq.Get5Last().ToList();
        }

        #endregion

        #region Classe
        public List<Classe> GetAllClasses()
        {
            ClasseQuery cq = new ClasseQuery(contexte);
            return cq.GetAll().ToList();
        }

        #endregion
    }
}
