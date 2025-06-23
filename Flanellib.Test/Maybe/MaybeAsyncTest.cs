using Flanellib.Functions.Maybe;
using Flanellib.Functions.Maybe.Extensions;
using Xunit;

namespace Flanellib.Test.Maybe
{
    public class MaybeAsyncTest
    {
        [Fact]
        public async Task MaybeAsync_CalculateTask_ShouldReturnCalculatedTask()
        {
            // Arrange
            var maybe = Maybe<int>.Return(11);

            // Act
            var primes = await maybe.BindAsync(BorrowAThreadAndCalculateSomePrimes);

            // Assert
            
            var unwrapped = primes switch
            {
                Just<int> n => n.Value,
                _ => throw new Exception("nepp!")
            };

            Assert.Equal(5, unwrapped);
        }


        private static async Task<int> BorrowAThreadAndCalculateSomePrimes(int val)
        {
            int start = 1;
            int end = val;

            return await Task.Run(() => CountPrimes(start, end));
        }


        #region vibe coding utils

        /// <summary>
        /// A simple, processor-intensive function to count prime numbers using trial division.
        /// This is not the most efficient prime counting algorithm (e.g., Sieve of Eratosthenes is better),
        /// but it serves well as a CPU-bound example for Task.Run().
        /// </summary>
        /// <param name="start">The starting number (inclusive).</param>
        /// <param name="end">The ending number (inclusive).</param>
        /// <returns>The count of prime numbers in the range.</returns>
        private static int CountPrimes(int start, int end)
        {
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Determines if a number is prime using basic trial division.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is prime, false otherwise.</returns>
        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false; // Exclude even numbers > 2

            // Check for divisibility only up to the square root of the number
            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion vibe coding utils
    }
}
