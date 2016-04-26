using MinistrySuite.Entities;

namespace MinistrySuite.SecondaryEntities
{
    public class ChurchMemberPhoneNumber : PhoneNumber
    {
        public int ChurchMemberId { get; private set; }
        public ChurchMember ChurchMember { get; private set; }

        //Static create for mocking entities for entity Framework seed method
        public static ChurchMemberPhoneNumber Create(int churchMemberId, bool isPrimary, string number)
        {
            var newPhoneNumber = new ChurchMemberPhoneNumber();
            newPhoneNumber.ChurchMemberId = churchMemberId;
            newPhoneNumber.IsPrimary = isPrimary;
            newPhoneNumber.Number = number;

            return newPhoneNumber;
        }

    }
}
