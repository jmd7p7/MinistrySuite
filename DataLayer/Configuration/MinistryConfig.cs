using MinistrySuite.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class MinistryConfig : EntityTypeConfiguration<Ministry>
    {
        public MinistryConfig()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name).HasMaxLength(100);
            Property(m => m.Description).HasMaxLength(500);

            HasRequired(m => m.Church)
                .WithMany(ch => ch.Ministries)
                .HasForeignKey(m => m.ChurchId);

        }

    }
}
