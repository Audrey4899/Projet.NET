using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Projet.ViewModels.Common;

namespace WPF.Projet.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ListeEleveViewModel _listeEleveViewModel;

        public HomeViewModel()
        {
            _listeEleveViewModel = new ListeEleveViewModel();
        }

        public ListeEleveViewModel ListeEleveViewModel
        {
            get { return _listeEleveViewModel; }
            set { _listeEleveViewModel = value; }
        }
    }
}