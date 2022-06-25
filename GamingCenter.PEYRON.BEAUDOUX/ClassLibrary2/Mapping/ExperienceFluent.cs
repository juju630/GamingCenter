using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;
namespace ClassLibrary.Mapping
{
    public class ExperienceFluent : EntityTypeConfiguration<Experience>
    {
        public ExperienceFluent()
        {
            ToTable("APP_EXPERIENCE");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("EXP_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Joueur).HasColumnName("EXP_JOUEUR").IsRequired();
            Property(e => e.TempsDeJeu).HasColumnName("EXP_TEMPSJEU").IsRequired();
            Property(e => e.Pourcentage).HasColumnName("EXP_POURCENTAGE").IsRequired();
            Property(e => e.JeuId).HasColumnName("JEU_ID").IsRequired();

            HasRequired(e => e.Jeu).WithMany().HasForeignKey(e => e.JeuId);
        }
    }
}
