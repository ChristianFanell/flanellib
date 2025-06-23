using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Sbd.Extensions
{
    internal static class SbdExtensions
    {
        /// <summary>
        /// Creates a copy of the object, but doesn't store the copy.
        /// </summary>
        /// <typeparam name="T">The type of the object to clone.</typeparam>
        /// <param name="this">The object to clone.</param>
        /// <param name="cloneFunction">The function that clones the object.</param>
        /// <returns>The cloned object.</returns>
        internal static T Cloner<T>(this T @this, Func<T, T> cloneFunction) => 
            cloneFunction(@this);
    
    }
}
