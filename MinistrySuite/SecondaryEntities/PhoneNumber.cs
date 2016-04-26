using MinistrySuite.Common;
using MinistrySuite.Util;
using MinistrySuite.Enums;

namespace MinistrySuite.SecondaryEntities
{
    public class PhoneNumber : PrimaryCapableEntity
    {
        public int Id { get; private set; }
        private string _Number;
        public PhoneNumberType PhoneNumberType { get; set; }
        public string Number
        {
            get
            {
                return _Number;
            }
            set
            {
                Guard.ForNullOrEmptyOrWhiteSpace(value, "[Phone]Number");
                if (value.IsValidPhoneNumber())
                {
                    _Number = value;
                }
            }
        }

        //properties not mapped to persistent storage
        public string GetFormattedNumber => $"({_Number.Substring(0, 3)}) {_Number.Substring(3, 3)}-{_Number.Substring(6, 4)}";

    }
}
