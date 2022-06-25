using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Text;

namespace ClassLibrary.Mapping
{
    public class ContexteFluent : DbContext
    {
        public ContexteFluent() : base("name=ConnexionString")
        {
            Database.SetInitializer<ContexteFluent>(new DropCreateDatabaseIfModelChanges<ContexteFluent>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            //modelBuilder.Configurations.Add(new GenreFluent());
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Editeur> Editeurs { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Jeu> Jeux { get; set; }
    }
}
