using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Functions.Maybe.Extensions
{
    public static class MaybeAsyncExtensions
    {
        public static async Task<Maybe<TOut>> BindAsync<TIn, TOut>(
            this Maybe<TIn> @this,
            Func<TIn, Task<TOut>> f)
        {
            try
            {
                Maybe<TOut> updatedValue = @this switch
                {
                    Just<TIn> s => new Just<TOut>(await f(s.Value)),
                    Nothing<TIn> _ => new Nothing<TOut>(),
                    Error<TIn> e => new Error<TOut>(e.CapturedError),
                    _ => new Error<TOut>(new Exception($"Shit got real"))
                };
                return updatedValue;
            }
            catch (Exception e)
            {
                return new Error<TOut>(e);
            }
        }
    }
}
