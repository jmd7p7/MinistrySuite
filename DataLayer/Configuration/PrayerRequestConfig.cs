using MinistrySuite.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class PrayerRequestConfig : EntityTypeConfiguration<PrayerRequest>
    {
        public PrayerRequestConfig()
        {
            HasKey(pr => pr.Id);
            Property(pr => pr.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pr => pr.Title).HasMaxLength(100).IsRequired();
            Property(pr => pr.Request).HasMaxLength(500).IsRequired();
            Property(pr => pr.StartDate).IsRequired();
            Property(pr => pr.EndDate).IsRequired();

            HasRequired(pr => pr.Church)
                .WithMany(ch => ch.PrayerRequests)
                .HasForeignKey(pr => pr.ChurchId);
        }
    }
}
