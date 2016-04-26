using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchMemberEmailAddressConfig : EntityTypeConfiguration<ChurchMemberEmailAddress>
    {
        public ChurchMemberEmailAddressConfig()
        {
            HasKey(cmea => cmea.Id);
            Property(cmea => cmea.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(m => m.MapInheritedProperties());

            HasRequired(cmea => cmea.ChurchMember)
                .WithMany(cm => cm.EmailAddresses)
                .HasForeignKey(cmea => cmea.ChurchMemberId);
        }
    }
}
