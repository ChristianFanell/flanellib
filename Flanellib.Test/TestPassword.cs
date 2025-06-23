using Flanellib.Sbd.Common;

namespace Flanellib.Test
{
    public class TestPassword
    {
        [Fact]
        public void Password_InitEmpty_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Password(string.Empty));
        }

        [Fact]
        public void Password_InitTooShort_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Password("a"));
        }

        [Fact]
        public void Password_InitTooLong_ThrowsArgumentException()
        {
            var val = new string('a', 101);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Password(val));
        }

        [Fact]
        public void Password_InitNotASCII_ThrowsArgumentException()
        {
            var leffe = new Password("123abCd!£");
            
            Console.WriteLine(leffe.Show());

            Assert.Throws<ArgumentException>(() => new Password(""));
        }

        [Fact]
        public void Password_InitNotOnlyLetters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Password("a1"));
        }

        [Fact]
        public void Password_InitNotOnlyLettersAndNumbers_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Password("a1!"));
        }
    }
}