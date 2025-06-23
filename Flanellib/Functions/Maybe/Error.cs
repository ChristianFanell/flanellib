namespace Flanellib.Functions.Maybe
{
    /// <summary>
    /// Creates a new <see cref="Maybe{T}"/> containing an error.
    /// </summary>
    /// <param name="exception">The error to contain.</param>
    /// <remarks>
    /// This is effectively a way to capture an exception and return it as a value.
    /// Use this when you want to do something like <c>return Error(e);</c>.
    /// </remarks>
    public class Error<T>(Exception exception) : Maybe<T>
    {
        public Exception CapturedError => exception;
    }
}
