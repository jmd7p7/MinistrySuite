using MinistrySuite.Entities;
using MinistrySuite.Enums;

namespace MinistrySuite.SecondaryEntities
{
    public class ChurchMemberEmailAddress : EmailAddress
    {
        public int ChurchMemberId { get; private set; }
        public virtual ChurchMember ChurchMember { get; private set; }

        //Static create method for entity framework

        public static ChurchMemberEmailAddress Create(int churchMemberId, bool isPrimary, EmailAddressType emailAddressType, string emailAddress)
        {
            var newEmailAddress = new ChurchMemberEmailAddress();
            newEmailAddress.ChurchMemberId = churchMemberId;
            newEmailAddress.IsPrimary = isPrimary;
            newEmailAddress.EmailAddressType = emailAddressType;
            newEmailAddress.Email_Address = emailAddress;

            return newEmailAddress;
        }
    }
}
