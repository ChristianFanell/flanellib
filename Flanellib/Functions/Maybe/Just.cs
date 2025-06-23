namespace Flanellib.Functions.Maybe
{
    public class Just<T>(T value) : Maybe<T>
    {
        public T Value { get; } = value;
    }
}
