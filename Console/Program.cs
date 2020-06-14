using BusinessLayer;
using Classes;
using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Modele.Projet
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Jalon 1");

            try
            {
                Manager manager = Manager.GetInstance();

                Console.WriteLine("Liste élèves :");
                List<Eleve> eleves = manager.GetAllEleve();
                foreach(Eleve eleve in eleves)
                {
                    Console.WriteLine("ID : {0} - {1} {2}", eleve.EleveId, eleve.Prenom, eleve.Nom);
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
