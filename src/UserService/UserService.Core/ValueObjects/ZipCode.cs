using System;
using System.Text.RegularExpressions;

namespace UserService.Core.ValueObjects
{
    public class ZipCode
    {
        private String Value;

        private ZipCode(String value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return (Value != null ? Value.ToString() : Value);
        }

        private static string Validate(String value)
        {
            Regex regex = new Regex(@"[^\d]");
            String onlyNumber = regex.Replace(value, "");

            if (onlyNumber.Length != 8)
            {
                return null;
            }

            return onlyNumber;
        }

        public static ZipCode Parse(string value)
        {

            if (TryParse(value, out var result))
            {
                return result;
            }

            return null;
        }

        public static bool TryParse(string value, out ZipCode result)
        {
            result = new ZipCode(Validate(value));
            return true;
        }

        public static implicit operator ZipCode(String value)
        {
            return Parse(value);
        }
    }
}
