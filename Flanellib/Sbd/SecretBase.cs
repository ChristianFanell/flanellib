using Flanellib.Sbd.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Flanellib.Sbd 
{
    /// <summary>
    /// A class that implements the logic for a secret. 
    /// The secret is of type <typeparamref name="T"/> and is shown as type <typeparamref name="TShow"/>.
    /// </summary>
    /// <typeparam name="T">The type of the secret.</typeparam>
    /// <typeparam name="TShow">The type of how the secret is shown.</typeparam>
    public abstract class SecretBase<T, TShow>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        private protected T _value;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        private bool _consumed; 

        protected SecretBase(T value)
        {
            ArgumentNullException.ThrowIfNull(value);
            _value = ValidatePastConstructor(value);
        }
        
        private T ValidatePastConstructor(T value)
        {
            Validate(value);
            return value;
        }

        public TShow Show()
        {
            if (_consumed)
            {
                Deny();
            }
            var readOnce = Clone();
            _value = default!;
            _consumed = true;
            return Extract(readOnce!);
        }

        public sealed override string ToString() =>
            "value = **************";


        public sealed override bool Equals(object? obj) =>
            throw new InvalidOperationException("Value are not allowed to be compared");
 

        public sealed override int GetHashCode() =>
            throw new InvalidOperationException("Value are not allowed to be hashed");

        protected abstract T Clone();

        protected abstract TShow Extract(T copy);

        protected abstract T Validate(T value);

        private void Deny() =>
            throw new InvalidOperationException("Not allowed to read the value more than once");
    }
}
