using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace ClassLibrary.Mapping
{
    class GenreFluent : EntityTypeConfiguration<Genre>
    {
        public GenreFluent()
        {
            ToTable("APP_GENRE");
            HasKey(g => g.Id);

            Property(e => e.Id).HasColumnName("GENRE_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Nom).HasColumnName("GENRE_NOM").IsRequired();
        }
    }
}
