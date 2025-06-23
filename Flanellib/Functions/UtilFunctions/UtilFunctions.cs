using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Flanellib.Sbd.Extensions;

namespace Flanellib.Functions.UtilFunctions
{
    internal static class UtilFunctions
    {
        internal static string StringValidator(string val, int maxLength, Func<string, bool>[] customArgs)
        {
            var validated = StringValidator(val, maxLength);

            if (!customArgs.All(s => s.Invoke(validated)))
            {
                throw new ArgumentException($"Value does not match all conditions: {val}", nameof(val));
            }

            return validated;
        }

        private static string StringValidator(string val, int maxLength)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(val, nameof(val));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(val.Length, maxLength, nameof(maxLength));
            
            var isValidCharRange = !val.All(c => c <= 127);

            if (!isValidCharRange)
            {
                throw new ArgumentException("Value contains non-ASCII characters", nameof(val));
            }
            
            return val;
        }

        
        internal static string EmailValidator(string email)
        {
            ArgumentNullException.ThrowIfNull(email);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(email.Length, 100);

            if (!Regex.IsMatch(email, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-zA-Z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-zA-Z0-9][\w\.-]{0,253}[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                throw new ArgumentException("Invalid email format", nameof(email));
            }

            return email;
        }
    }
}
