using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Sbd
{
    public abstract class DomainPrimitiveBase<T>
    {
        protected DomainPrimitiveBase(T value)
        {
            EnsureTypeIsPrimitive();
            Value = ValidatePastConstructor(value);
        }

        public T Value { get; }
        
        protected abstract void Validate(T value);

        private T ValidatePastConstructor(T value)
        {
            Validate(value);
            return value;
        }
        
        private void EnsureTypeIsPrimitive() 
        {
            var type = typeof(T);
            if (type.IsPrimitive || type == typeof(string)) {
                return;
            }
            throw new InvalidOperationException($"T must be an int, double, decimal, bool, string, etc and not class, interface, struct or record: {typeof(T)}");
        }
        
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            var valueObject = (DomainPrimitiveBase<T>)obj;

            return Value!.Equals(valueObject.Value);
        }

        public override int GetHashCode()
        {
            return Value!.GetHashCode();
        }
    }
}
