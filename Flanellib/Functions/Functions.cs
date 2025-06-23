using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Functions
{
    public static class Functions
    {

        /// <summary>
        /// Checks condition and returns true if any
        /// </summary>
        /// <typeparam name="T">The type of the input</typeparam>
        /// <param name="left">The left hand side of the fork</param>
        /// <param name="right">The right hand side of the fork</param>
        /// <returns>A function that takes a <typeparamref name="T"/> and returns true if either of the functions return true</returns>
        public static Func<T, bool> Either<T>(Func<T, bool> left, Func<T, bool> right) => 
            (T val) => left(val) || right(val);


        /// <summary>
        /// Checks condition and returns true if both
        /// </summary>
        /// <typeparam name="T">The type of the input</typeparam>
        /// <param name="left">The left hand side of the fork</param>
        /// <param name="right">The right hand side of the fork</param>
        /// <returns>A function that takes a <typeparamref name="T"/> and returns true if both of the functions return true</returns>
        public static Func<T, bool> Both<T>(Func<T, bool> left, Func<T, bool> right) =>
            (T val) => left(val) && right(val);


        /// <summary>
        /// Composes multiple validation functions into one. 
        /// Returns a function that takes a <typeparamref name="T"/> and returns true if all of the functions return true.
        /// </summary>
        /// <typeparam name="T">The type of the input</typeparam>
        /// <param name="funcs">The functions to compose</param>
        /// <returns>A function that takes a <typeparamref name="T"/> and returns true if all of the functions return true</returns>
        public static Func<T, bool> Validator<T>(Func<T, bool>[] funcs) =>
            (T val) => funcs.All(f => f(val));

        /// <summary>
        /// Composes two functions together.
        /// </summary>
        /// <typeparam name="TIn">The type of the input</typeparam>
        /// <typeparam name="TMid">The type of the intermediate result</typeparam>
        /// <typeparam name="TOut">The type of the output</typeparam>
        /// <param name="f">The first function</param> 
        /// <param name="g">The second function</param>
        /// <returns>A function that takes a <typeparamref name="TIn"/> and returns a <typeparamref name="TOut"/></returns>
        public static Func<TIn, TOut> Compose<TIn, TMid, TOut>(Func<TIn, TMid> f, Func<TMid, TOut> g) => 
            (TIn val) => g(f(val));
        
        /// <summary>
        /// Composes three functions together.
        /// </summary>
        /// <typeparam name="TIn">The type of the input</typeparam>
        /// <typeparam name="TMid1">The type of the first intermediate result</typeparam>
        /// <typeparam name="TMid2">The type of the second intermediate result</typeparam>
        /// <typeparam name="TOut">The type of the output</typeparam>
        /// <param name="f">The first function</param>
        /// <param name="g">The second function</param>
        /// <param name="h">The third function</param>
        /// <returns>A function that takes a <typeparamref name="TIn"/> and returns a <typeparamref name="TOut"/></returns>
        public static Func<TIn, TOut> Compose<TIn, TMid1, TMid2, TOut>(Func<TIn, TMid1> f, Func<TMid1, TMid2> g, Func<TMid2, TOut> h) =>
            val => h(g(f(val)));


        /// <summary>
        /// Returns the input as is.
        /// </summary>
        /// <typeparam name="T">The type of the input and output</typeparam>
        /// <param name="val">The input value</param>
        /// <returns>The same input value</returns>
        public static T Identity<T>(T val) => val;

    }
}
