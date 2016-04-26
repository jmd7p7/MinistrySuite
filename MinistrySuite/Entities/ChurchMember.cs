using MinistrySuite.Common;
using MinistrySuite.SecondaryEntities;
using System;
using System.Collections.Generic;
using MinistrySuite.Util;

namespace MinistrySuite.Entities
{
    public class ChurchMember : EntityRoot
    {
        public virtual Church Church { get; private set; }
        public int ChurchId { get; private set; }
        private string _FirstName;
        private string _LastName;
        private DateTimeOffset? _DateOfBirth;
        public HouseKeeping HouseKeeping { get; set; }
        private ICollection<Ministry> _Ministries;
        private ICollection<ChurchMemberAddress> _Addresses;
        private ICollection<ChurchMemberEmailAddress> _EmailAddresses;
        private ICollection<ChurchMemberPhoneNumber> _PhoneNumbers;

        //Properties not mapped to persistent storage
        public ChurchMemberAddress GetPrimaryAddress => PrimaryCapableHelper.GetPrimary(Addresses);
        public ChurchMemberEmailAddress GetPrimaryEmailAddress => PrimaryCapableHelper.GetPrimary(EmailAddresses);
        public ChurchMemberPhoneNumber GetPrimaryPhoneNumber => PrimaryCapableHelper.GetPrimary(PhoneNumbers);
        public string FullName => $"{FirstName} {LastName}";

        public string LastName
        {
            get { return _LastName; }
            set
            {
                Guard.ForNullOrEmptyOrWhiteSpace(value, "LastName");
                Guard.ForOutSideMinOrMaxIntegerBounds(0, 50, value.Length, "LastName");
                _LastName = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                Guard.ForNullOrEmptyOrWhiteSpace(value, "FirstName");
                Guard.ForOutSideMinOrMaxIntegerBounds(0, 50, value.Length, "FirstName");
                _FirstName = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public DateTimeOffset? DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if(value > DateTimeOffset.Now || value < DateTimeOffset.Now.AddYears(-125))
                {
                    throw new ArgumentException("Date of birth cannot be greater than today or less than 125 years ago.");
                }
                _DateOfBirth = value;
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

        public virtual ICollection<ChurchMemberAddress> Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<ChurchMemberEmailAddress> EmailAddresses
        {
            get { return _EmailAddresses; }
            set
            {
                _EmailAddresses = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<ChurchMemberPhoneNumber> PhoneNumbers
        {
            get { return _PhoneNumbers; }
            set
            {
                _PhoneNumbers = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }
        public ChurchMember()
        {
            HouseKeeping = new HouseKeeping();
            Ministries = new HashSet<Ministry>();
            Addresses = new HashSet<ChurchMemberAddress>();
            EmailAddresses = new HashSet<ChurchMemberEmailAddress>();
            PhoneNumbers = new HashSet<ChurchMemberPhoneNumber>();
        }

        public string GetAge()
        {
            if(DateOfBirth == null)
            {
                return null;
            }
            return (DateTimeOffset.Now.Year - DateOfBirth.Value.Year).ToString();
        }

        public static ChurchMember Create(int churchId, string firstName, string lastName, 
            DateTimeOffset dob, List<Ministry> ministries)
        {
            ChurchMember newMember = new ChurchMember();
            newMember.ChurchId = churchId;
            newMember.FirstName = firstName;
            newMember.LastName = lastName;
            newMember.DateOfBirth = dob;
            newMember.Ministries = ministries;

            return newMember;
        }
    }
}
