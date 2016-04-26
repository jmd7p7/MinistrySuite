using MinistrySuite.Common;
using MinistrySuite.Enums;
using System;
using System.Collections.Generic;
using MinistrySuite.Util;

namespace MinistrySuite.SecondaryEntities
{
    public abstract class Address : PrimaryCapableEntity
    {
        public int Id { get; private set; }
        public AddressType AddressType { get; set; }
        private string _Street;
        private string _City;
        private string _State;
        private string _Zip;

        //Properties not mapped to persistent storage
        public string AddressAsOneLine => $"{Street}, {City}, {State} {Zip}";
        public List<String> AddressAsTwoLines => new List<string>()
        {
            $"{Street}",
            $"{City}, {State} {Zip}"
        };

        public string Zip
        {
            get { return _Zip; }
            set
            {
                Guard.ForNull(value, "Zip");
                if (value.IsValidZipCode())
                {
                    _Zip = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Zip Code");
                }
            }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        
    }
}
