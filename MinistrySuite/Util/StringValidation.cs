using System;
using System.Text.RegularExpressions;

namespace MinistrySuite.Util
{
    public static class StringValidation
    {
        public static bool IsValidZipCode(this string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentException("In class StringValidation method IsValidZipCode. Argument cannot be null, empty, or white space.");
            }
            string USZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            return Regex.Match(zipCode, USZipRegEx).Success;
        }

        public static bool IsValidEmailAddress(this string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentException("In class StringValidation method IsValidEmailAddress. Argument cannot be null, empty, or white space.");
            }
            string emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.Match(emailAddress, emailRegex, RegexOptions.IgnoreCase).Success;
        }

        public static bool IsNumeric(this string _string)
        {
            if (string.IsNullOrWhiteSpace(_string))
            {
                throw new ArgumentException("In class StringValidation method IsNumeric. Argument cannot be null, empty, or white space.");
            }

            foreach (char ch in _string)
            {
                if (char.IsDigit(ch) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidPhoneNumber(this string _string)
        {
            if (string.IsNullOrWhiteSpace(_string))
            {
                throw new ArgumentException("In class StringValidation method IsValidPhoneNumber. Argument cannot be null, empty, or white space.");
            }
            if(_string.IsNumeric() && _string.Length == 10)
            {
                return true;
            }
            return false;
        }
    }
}
