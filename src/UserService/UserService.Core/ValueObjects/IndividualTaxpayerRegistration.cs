using System;
using System.Text.RegularExpressions;

namespace UserService.Core.ValueObjects
{
    public struct IndividualTaxpayerRegistration
    {
        private String Value;

        private IndividualTaxpayerRegistration(String value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return (Value != null ? Value.ToString() : Value);
        }

        private static string Validate(String value)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Regex regex = new Regex(@"[^\d]");
            Boolean isEquals = true;
            string tempCpf;
            string digit;
            int sum;
            int remaining;
            int lengthCpf;
            value = regex.Replace(value, "");
            lengthCpf = value.Length;

            for (int i = 1; i < lengthCpf; i++)
            {
                if (value[0] != value[i])
                {
                    isEquals = false;
                    break;
                }
            }

            if (String.IsNullOrEmpty(value) || isEquals || lengthCpf != 11)
            {
                return null;
            }

            tempCpf = value.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            }

            remaining = sum % 11;

            if (remaining < 2)
            {
                remaining = 0;
            }
            else
            {
                remaining = 11 - remaining;
            }

            digit = remaining.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            }

            remaining = sum % 11;

            if (remaining < 2)
            {
                remaining = 0;
            }
            else
            {
                remaining = 11 - remaining;
            }

            digit = digit + remaining.ToString();

            if (!value.EndsWith(digit))
            {
                return null;
            }

            return value;

        }

        public static IndividualTaxpayerRegistration Parse(string value)
        {

            if (TryParse(value, out var result))
            {
                return result;
            }

            return null;

        }

        public static bool TryParse(string value, out IndividualTaxpayerRegistration result)
        {
            result = new IndividualTaxpayerRegistration(Validate(value));
            return true;
        }

        public static implicit operator IndividualTaxpayerRegistration(String value)
        {
            return Parse(value);
        }
    }
}
