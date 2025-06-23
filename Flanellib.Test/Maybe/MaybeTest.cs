using Flanellib.Functions.Maybe;
using Flanellib.Functions.Maybe.Extensions;
using System;
using Xunit;

namespace Flanellib.Test.Maybe
{
    public class MaybeTest
    {
        [Fact]
        public void LeftIdentityLaw()
        {
            var a = 5;
            Func<int, Maybe<int>> f = x => Maybe<int>.Return(x * 2);

            var left = Maybe<int>.Return(a).Bind(f);
            var right = f(a);
            
            var leftAsJust = Assert.IsType<Just<int>>(left);
            var rightAsJust = Assert.IsType<Just<int>>(right);
            
            Assert.Equal(leftAsJust.Value, rightAsJust.Value);
            Assert.Equal(10, rightAsJust.Value);
        }


        [Fact]
        public void RightIdentityLaw()
        {
            var m = Maybe<int>.Return(5);

            var left = m.Bind(Maybe<int>.Return);
            var right = m.Map(n => n);
            
            var leftJust = Assert.IsType<Just<int>>(left);
            var rightJust = Assert.IsType<Just<int>>(right);
            
            Assert.Equal(leftJust.Value, rightJust.Value);
            Assert.Equal(5, rightJust.Value);
        }

        [Fact]
        public void AssociativityLaw()
        {
            // Arrange
            var m = Maybe<int>.Return(5);
            Func<int, Maybe<int>> f = x => Maybe<int>.Return(x * 2);
            Func<int, Maybe<int>> g = x => Maybe<int>.Return(x + 3);

            // Act
            var left = m.Bind(f).Bind(g);
            var right = m.Bind(x => f(x).Bind(g));
            var leftJust = Assert.IsType<Just<int>>(left);
            var rightJust = Assert.IsType<Just<int>>(right);
            
            // Assert
            Assert.Equal(leftJust.Value, rightJust.Value);
            Assert.Equal(13, rightJust.Value);
        }

        [Fact]
        public void Map_ShouldTransformValue()
        {
            var maybe = Maybe<int>.Return(5);
            var result = maybe.Map(x => x * 2) as Just<int>;
            Assert.Equal(10, result!.Value);
        }

        [Fact]
        public void Or_ShouldReturnAlternativeValue()
        {
            var maybeStuff = new Nothing<int>();
            var result = maybeStuff.Or(5) as Just<int>;
            
            Assert.Equal(5, result!.Value);
        }

        [Fact]
        public void Tap_ShouldExecuteAction()
        {
            var maybe = Maybe<int>.Return(5);
            int tappedValue = 0;

            maybe.Tap(x => tappedValue = x);

            Assert.Equal(5, tappedValue);
        }
    }
}
