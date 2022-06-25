using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ClassLibrary
{
    public class Contexte : DbContext
    {
        public Contexte() : base("name=ConnexionString")
        {
            Database.SetInitializer<Contexte>(new DropCreateDatabaseAlways<Contexte>());
        }

        public DbSet<Editeur> Editeurs { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Jeu> Jeux { get; set; }
    }
}
