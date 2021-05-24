using System;
using System.Text.RegularExpressions;

namespace UserService.Core.ValueObjects
{
    public struct Cellphone
    {
        private String Value;

        private Cellphone(String value)
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
            Boolean isEquals = true;
            String phone = onlyNumber.Substring(2);
            String pattern = @"((11|12|13|14|15|16|17|18|19|21|22|24|27|28|31|32|33|34|35|37|38|41|42|43|44|45|46|47|48|49|51|53|54|55|61|62|63|64|65|66|67|68|69|71|73|74|75|77|79|81|82|83|84|85|86|87|88|89|91|92|93|94|95|96|97|98|99)(9)(6|7|8|9)([0-9]{3})(\d{4}))|((11)(9)(51|52|53|54|57|59|4[0-9])([0-9]{2}(\d{4})))";

            for (int i = 1; i < phone.Length; i++)
            {
                if (phone[0] != phone[i])
                {
                    isEquals = false;
                    break;
                }
            }

            if (!Regex.IsMatch(onlyNumber, pattern, RegexOptions.IgnoreCase) || isEquals || phone.Length < 9)
            {
                return null;
            }

            return onlyNumber;

        }

        public static Cellphone Parse(string value)
        {

            if (TryParse(value, out var result))
            {
                return result;
            }

            return null;
        }

        public static bool TryParse(string value, out Cellphone result)
        {
            result = new Cellphone(Validate(value));
            return true;
        }

        public static implicit operator Cellphone(String value)
        {
            return Parse(value);
        }
    }
}
