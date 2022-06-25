using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace ClassLibrary.Mapping
{
    public class JeuFluent : EntityTypeConfiguration<Jeu>
    {
        public JeuFluent()
        {
            ToTable("APP_JEU");
            //primary key
            HasKey(c => c.Id);
            //colones
            Property(c => c.Id).HasColumnName("JEU_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nom).HasColumnName("JEU_NOM").IsRequired().HasMaxLength(50);
            Property(c => c.Description).HasColumnName("JEU_DESCRIPTION").IsRequired();
            Property(c => c.DateSortie).HasColumnName("JEU_DATESORTIE").IsRequired();
            Property(c => c.GenreId).HasColumnName("GENRE_ID").IsRequired();
            Property(c => c.EditeurId).HasColumnName("EDITEUR_ID").IsRequired();
            //foreign key
            HasRequired(c => c.Genre).WithMany().HasForeignKey(c => c.GenreId);
            HasRequired(c => c.Editeur).WithMany().HasForeignKey(c => c.EditeurId);            

        }
    }
}
