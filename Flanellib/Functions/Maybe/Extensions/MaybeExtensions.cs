using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Functions.Maybe.Extensions
{
    public static class MaybeExtensions
    {
        public static Maybe<TOut> Bind<TIn, TOut>(this Maybe<TIn> @this, Func<TIn, Maybe<TOut>> f)
        {
            try
            {
                var value = @this switch
                {
                    Just<TIn> some => f(some.Value),
                    _ => new Nothing<TOut>()
                };

                return value;
            }
            catch (Exception exception)
            {
                return new Error<TOut>(exception);
            }
        }

        
        public static Maybe<TOut> Bind<TIn, TOut>(this Maybe<Maybe<TIn>> @this, Func<TIn, Maybe<TOut>> f)
        {
            try
            {
                var value = @this switch
                {
                    Just<Maybe<TIn>> some => some.Value.Bind(f),
                    _ => new Nothing<TOut>()
                };

                return value;
            }
            catch (Exception exception)
            {
                return new Error<TOut>(exception);
            }
        }

        
        public static Maybe<TOut> Map<TIn, TOut>(this Maybe<TIn> @this, Func<TIn, TOut> fmapFn)
        {
            try
            {
                var value = @this switch
                {
                    Just<TIn> some => Maybe<TOut>.Return(fmapFn(some.Value)),
                    _ => new Nothing<TOut>()
                };

                return value;
            }
            catch (Exception exception)
            {
                return new Error<TOut>(exception);
            }
        }

       
        public static Maybe<T> Or<T>(this Maybe<T> @this, Func<T> thisInstead)
        {
            var value = @this switch
            {
                Nothing<T> => new Just<T>(thisInstead()),
                _ => @this
            };

            return value;
        }

        public static Maybe<T> Or<T>(this Maybe<T> @this, T thisInstead)
        {
            var value = @this switch
            {
                Nothing<T> => new Just<T>(thisInstead),
                _ => @this
            };

            return value;
        }
        
        public static Maybe<T> Tap<T>(this Maybe<T> @this, Action<T> action)
        {
            var value = @this switch
            {
                Just<T> some => some.Value,
                _ => default
            };

            if (value is not null)
            {
                action(value);
            }

            return @this;
        }
    }
}
