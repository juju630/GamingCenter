using ClassLibrary;
using ClassLibrary.Entity;
using ClassLibrary.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContexteFluent contexte = new ContexteFluent();
                
                contexte.Genres.Add(new Genre { Nom = "jeu de chasse" });
                contexte.Genres.Add(new Genre { Nom = "jeu de guerre" });

                contexte.SaveChanges();

                List<Genre> mesGenres = contexte.Genres.ToList();
                Console.WriteLine("Liste de mes clients avec Fluent : ");
                foreach (Genre c in mesGenres)
                {
                    Console.WriteLine("Genre n°{0} : {1}", c.Id, c.Nom);                    
                }
                Console.WriteLine("...Fin...");

            }catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
