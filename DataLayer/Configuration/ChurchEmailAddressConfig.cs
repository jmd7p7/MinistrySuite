using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    class ChurchEmailAddressConfig : EntityTypeConfiguration<ChurchEmailAddress>
    {
        public ChurchEmailAddressConfig()
        {
            HasKey(cea => cea.Id);
            Property(cea => cea.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(m => m.MapInheritedProperties());

            HasRequired(cea => cea.Church)
                .WithMany(c => c.EmailAddresses)
                .HasForeignKey(cea => cea.ChurchId);
        }
    }
}
