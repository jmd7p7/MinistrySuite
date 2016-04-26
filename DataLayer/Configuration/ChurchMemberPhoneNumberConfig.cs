using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchMemberPhoneNumberConfig : EntityTypeConfiguration<ChurchMemberPhoneNumber>
    {
        public ChurchMemberPhoneNumberConfig()
        {
            HasKey(cmpn => cmpn.Id);
            Property(cmpn => cmpn.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cmpn => cmpn.Number).HasMaxLength(10);
            Ignore(cmpn => cmpn.GetFormattedNumber);

            Map(m => m.MapInheritedProperties());

            HasRequired(cmpn => cmpn.ChurchMember)
                .WithMany(cm => cm.PhoneNumbers)
                .HasForeignKey(cmpn => cmpn.ChurchMemberId);
        }
    }
}
