using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchAddressesConfig : EntityTypeConfiguration<ChurchAddress>
    {
        public ChurchAddressesConfig()
        {
            HasKey(ca => ca.Id);
            Property(ca => ca.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ca => ca.Zip).HasMaxLength(10);

            Ignore(ca => ca.AddressAsOneLine);
            Ignore(ca => ca.AddressAsTwoLines);

            Map(m => m.MapInheritedProperties());

            HasRequired(ca => ca.Church)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.ChurchId);
        }
    }
}
