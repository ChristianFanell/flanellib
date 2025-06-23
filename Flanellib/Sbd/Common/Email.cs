using Flanellib.Functions.UtilFunctions;
using Flanellib.Sbd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Sbd.Common
{
    public sealed class Email(string value) : DomainPrimitiveBase<string>(value), IReturn<string, Email>
    {
        public Email Return(string input) => new (input);

        protected override void Validate(string emailString)
        {
            UtilFunctions.EmailValidator(emailString);
        }
        
    }
}
