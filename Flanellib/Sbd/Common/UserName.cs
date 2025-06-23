using Flanellib.Sbd.Common;
using Flanellib.Sbd.Interfaces;

namespace Flanellib.Sbd.Common
{
    public class UserName(string value) : DomainPrimitiveBase<string>(value), IReturn<string, UserName>
    {
        public UserName Return(string input)
        {
            return new UserName(input);
        }

        protected override void Validate(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, 100);
            ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, 3);

            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z-' ]+$");
            if (!regex.IsMatch(value))
            {
                throw new ArgumentException("Invalid name format. Only letters, hyphens, apostrophes, and spaces are allowed.");
            }
        }
    }
}