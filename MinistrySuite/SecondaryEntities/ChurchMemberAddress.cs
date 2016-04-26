using MinistrySuite.Entities;
using MinistrySuite.Enums;

namespace MinistrySuite.SecondaryEntities
{
    public class ChurchMemberAddress : Address
    {
        public virtual ChurchMember ChurchMember { get; private set; }
        public int ChurchMemberId { get; private set; }

        //Static create method for entity framework seed method
        public static ChurchMemberAddress Create(int churchMemberId, bool isPrimary, AddressType addressType, string street, string city, string state, string zip)
        {
            ChurchMemberAddress newAddress = new ChurchMemberAddress();
            newAddress.ChurchMemberId = churchMemberId;
            newAddress.IsPrimary = isPrimary;
            newAddress.AddressType = addressType;
            newAddress.Street = street;
            newAddress.City = city; 
            newAddress.State = state;
            newAddress.Zip = zip;

            return newAddress;
        }

    }
}
