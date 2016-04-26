using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchMemberAddressConfig : EntityTypeConfiguration<ChurchMemberAddress>
    {
        public ChurchMemberAddressConfig()
        {
            HasKey(cma => cma.Id);
            Property(cma => cma.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cma => cma.Zip).HasMaxLength(10);

            Ignore(cma => cma.AddressAsOneLine);
            Ignore(cma => cma.AddressAsTwoLines);

            Map(m => m.MapInheritedProperties());

            HasRequired(cma => cma.ChurchMember)
                .WithMany(cm => cm.Addresses)
                .HasForeignKey(cma => cma.ChurchMemberId);
        }
    }
}
