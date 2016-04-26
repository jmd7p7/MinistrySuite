using MinistrySuite.Common;
using MinistrySuite.SecondaryEntities;
using MinistrySuite.Util;
using System.Collections.Generic;


namespace MinistrySuite.Entities
{
    public class Church : EntityRoot
    {
        public string Name { get; private set; }
        public HouseKeeping HouseKeeping { get; set; }
        private ICollection<ChurchMember> _ChurchMembers;
        private ICollection<Ministry> _Ministries;
        private ICollection<ChurchAddress> _Addresses;
        private ICollection<PrayerRequest> _PrayerRequests;
        private ICollection<ChurchEmailAddress> _EmailAddresses;
        private ICollection<ChurchPhoneNumber> _PhoneNumbers;

        //Properties not mapped to persistent storage
        public ChurchAddress GetPrimaryAddress => PrimaryCapableHelper.GetPrimary(Addresses);
        public ChurchEmailAddress GetPrimaryEmailAddress => PrimaryCapableHelper.GetPrimary(EmailAddresses);
        public ChurchPhoneNumber GetPrimaryPhoneNumber => PrimaryCapableHelper.GetPrimary(PhoneNumbers);

        public virtual ICollection<PrayerRequest> PrayerRequests
        {
            get { return _PrayerRequests; }
            set
            {
                _PrayerRequests = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<ChurchAddress> Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<ChurchEmailAddress> EmailAddresses
        {
            get { return _EmailAddresses; }
            set
            {
                _EmailAddresses = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<ChurchPhoneNumber> PhoneNumbers
        {
            get { return _PhoneNumbers; }
            set
            {
                _PhoneNumbers = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<Ministry> Ministries
        {
            get { return _Ministries; }
            set
            {
                _Ministries = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<ChurchMember> ChurchMembers
        {
            get { return _ChurchMembers; }
            set
            {
                _ChurchMembers = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }
        public Church()
        {
            HouseKeeping = new HouseKeeping();
            ChurchMembers = new HashSet<ChurchMember>();
            Ministries = new HashSet<Ministry>();
            Addresses = new HashSet<ChurchAddress>();
            PrayerRequests = new HashSet<PrayerRequest>();
            EmailAddresses = new HashSet<ChurchEmailAddress>();
            PhoneNumbers = new HashSet<ChurchPhoneNumber>();
        }

        public static Church Create(string name)
        {
            return new Church() { Name = name };
        }
    }
}
