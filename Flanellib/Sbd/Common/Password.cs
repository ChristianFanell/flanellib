using Flanellib.Functions.UtilFunctions;
using Flanellib.Sbd.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flanellib.Sbd.Common
{
    public sealed class Password : SecretBase<string, string>
    {
        /// <param name="value">The password value.</param>
        public Password(string value): base(value) { }

        protected override string Clone() => 
            _value!.Cloner(s => s[..]);
        
        protected override string Extract(string copy) => copy;
        
        protected override string Validate(string value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, 100);
            Func<string, bool>[] customValidationConditions = [
                val => val.Length >= 8,
                val => val.Any(char.IsUpper),
                val => val.Any(char.IsNumber),
               
            ];

            return UtilFunctions.StringValidator(value, 50, customValidationConditions);
        }
    }
}
