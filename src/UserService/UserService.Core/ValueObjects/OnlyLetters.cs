using System;
using System.Text.RegularExpressions;

namespace UserService.Core.ValueObjects
{
    public struct OnlyLetters
    {
        private String Value;

        private OnlyLetters(String value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return (Value != null ? Value.ToString() : Value);
        }

        private static string Validate(String value)
        {
            var regex = new Regex(@"[a-zA-Z]+");
            Match matchValue = regex.Match(value);

            if (matchValue.Length != value.Length)
            {
                return null;
            }

            return value;

        }

        public static OnlyLetters Parse(string value)
        {

            if (TryParse(value, out var result))
            {
                return result;
            }

            return null;

        }

        public static bool TryParse(string value, out OnlyLetters result)
        {
            result = new OnlyLetters(Validate(value));
            return true;
        }

        public static implicit operator OnlyLetters(String value)
        {
            return Parse(value);
        }
    }
}
