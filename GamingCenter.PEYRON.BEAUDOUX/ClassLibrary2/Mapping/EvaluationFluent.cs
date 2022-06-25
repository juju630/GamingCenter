using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;
namespace ClassLibrary.Mapping
{
    public class EvaluationFluent : EntityTypeConfiguration<Evaluation>
    {
        public EvaluationFluent()
        {
            ToTable("APP_EVALUATION");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("EVAL_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.NomEvaluateur).HasColumnName("EVAL_NOMEVALUATEUR").IsRequired();
            Property(e => e.Date).HasColumnName("EVAL_DATE").IsRequired();
            Property(e => e.Note).HasColumnName("EVAL_NOTE").IsRequired();
            Property(e => e.JeuId).HasColumnName("JEU_ID").IsRequired();

            HasRequired(e => e.Jeu).WithMany().HasForeignKey(e => e.JeuId);
        }
    }
}
