using BusinessLayer;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Projet.ViewModels.Common;

namespace WPF.Projet.ViewModels
{
    public class ListeEleveViewModel : BaseViewModel
    {
        private Manager _manager;
        private ObservableCollection<DetailEleveViewModel> _eleves;
        private DetailEleveViewModel _selectedEleve;

        public ListeEleveViewModel()
        {
            _manager = Manager.GetInstance();
            _eleves = new ObservableCollection<DetailEleveViewModel>();
            
            foreach (Eleve eleve in _manager.GetAllEleve())
            {
                DetailEleveViewModel detailEleve = new DetailEleveViewModel
                {
                    Nom = eleve.Nom,
                    Prenom = eleve.Prenom,
                    DateNaissance = eleve.DateNaissance
                };

                List<Note> notes = _manager.GetNotesByEleve(eleve.EleveId);
                if(notes.Any())
                {
                    detailEleve.Moyenne = notes.Select(n => n.NoteValeur).Average();
                }

                List<Absence> absences = _manager.GetAbsencesByEleve(eleve.EleveId);
                if (absences.Any())
                {
                    detailEleve.NbAbsences = absences.Select(a => a).Count();
                }

                _eleves.Add(detailEleve);
            }

            if (_eleves != null && _eleves.Count > 0)
            {
                _selectedEleve = _eleves.ElementAt(0);
            }
        }

        public ObservableCollection<DetailEleveViewModel> Eleves
        {
            get { return _eleves; }
            set
            {
                _eleves = value;
                OnPropertyChanged("Eleves");
            }
        }

        public DetailEleveViewModel SelectedEleve
        {
            get { return _selectedEleve; }
            set
            {
                _selectedEleve = value;
                OnPropertyChanged("SelectedEleve");
            }
        }
    }
}