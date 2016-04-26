using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class PrayerRequestUpdateConfig : EntityTypeConfiguration<PrayerRequestUpdate>
    {
        public PrayerRequestUpdateConfig()
        {
            HasKey(pru => pru.Id);
            Property(pru => pru.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pru => pru.UpdateInformation).HasMaxLength(500).IsRequired();

            HasRequired(pru => pru.PrayerRequest)
                .WithMany(pr => pr.Updates)
                .HasForeignKey(pru => pru.PrayerRequestId);
        }
    }

}
