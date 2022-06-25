using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace ClassLibrary.Mapping
{
    public class EditeurFluent : EntityTypeConfiguration<Editeur>
    {
        public EditeurFluent()
        {
            ToTable("APP_EDITEUR");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("EDITEUR_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Nom).HasColumnName("EDITEUR_NOM").IsRequired();
        }
    }
}
