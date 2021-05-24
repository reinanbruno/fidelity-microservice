using System;
using System.Text.RegularExpressions;

namespace UserService.Core.ValueObjects
{
    public struct Email
    {
        private String Value;

        private Email(String value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return (Value != null ? Value.ToString() : Value);
        }

        private static string Validate(String value)
        {
            String pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                         + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                         + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                         + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

            if(!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
            {
                return null;
            }

            return value;

        }

        public static Email Parse(string value)
        {

            if (TryParse(value, out var result))
            {
                return result;
            }

            return null;
        }

        public static bool TryParse(string value, out Email result)
        {
            result = new Email(Validate(value));
            return true;
        }

        public static implicit operator Email(String value)
        {
            return Parse(value);
        }
    }
}