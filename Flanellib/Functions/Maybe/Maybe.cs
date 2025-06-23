namespace Flanellib.Functions.Maybe
{
    public abstract class Maybe<T>
    {
        public static Maybe<T> Return(T value)
        {
            if (value is null)
            {
                return new Nothing<T>();
            }
            return new Just<T>(value);
        }
    }
}
