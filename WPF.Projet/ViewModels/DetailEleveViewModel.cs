using Classes.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Projet.ViewModels.Common;

namespace WPF.Projet.ViewModels
{
    public class DetailEleveViewModel : BaseViewModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public double Moyenne { get; set; }
        public int NbAbsences { get; set; }
    }
}