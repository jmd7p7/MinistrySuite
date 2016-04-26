using MinistrySuite.Common;
using MinistrySuite.Enums;
using MinistrySuite.Util;
using System;

namespace MinistrySuite.SecondaryEntities
{
    public abstract class EmailAddress : PrimaryCapableEntity
    {
        public int Id { get; private set; }
        private string _Email_Address;
        public EmailAddressType EmailAddressType { get; set; }
        public string Email_Address
        {
            get { return _Email_Address; }
            set
            {
                if (value.IsValidEmailAddress())
                {
                    _Email_Address = value;
                }
                else
                {
                    throw new ArgumentException("The email address is invalid.");
                }
            }
        }

    }
}
