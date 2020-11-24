using System;
using Xunit;
using FizzBuzzLib;

namespace FizzBuzzLib.Test
{
    public class FizzBuzzTest
    {
        [Theory]
        [InlineData(0, 3, 5, "fizz", "buzz")]
        [InlineData(-1, 2, 6, "fizz", "buzz")]
        public void Initializing_fizzBuzz_Class_with_upperBound_less_than_1_throws_exception(int upperBound, int divisor1, int divisor2, string divisor1Word, string divisor2Word)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FizzBuzz(upperBound, divisor1, divisor2, divisor1Word, divisor2Word));
        }

        [Theory]
        [InlineData(100, 0, 5, "fizz", "buzz")]
        [InlineData(50, 2, 0, "fizz", "buzz")]
        [InlineData(25, 0, 0, "fizz", "buzz")]
        public void Initializing_fizzBuzz_Class_with_divisor1_or_divisor2_as_zero_throws_exception(int upperBound, int divisor1, int divisor2, string divisor1Word, string divisor2Word)
        {
            Assert.Throws<ArgumentException>(() => new FizzBuzz(upperBound, divisor1, divisor2, divisor1Word, divisor2Word));
        }

        [Theory]
        [InlineData(100, 1, 5, "", "buzz")]
        [InlineData(50, 2, 1, null, "buzz")]
        [InlineData(25, 1, 1, "fizz", "")]
        [InlineData(25, 1, 1, "fizz", null)]
        [InlineData(25, 1, 1, null, null)]
        [InlineData(25, 1, 1, " ", "fizz")]
        [InlineData(25, 1, 1, "fizz", "    ")]
        public void Initializing_fizzBuzz_Class_with_null_or_empty_divisor_words_throws_exception(int upperBound, int divisor1, int divisor2, string divisor1Word, string divisor2Word)
        {
            Assert.Throws<ArgumentException>(() => new FizzBuzz(upperBound, divisor1, divisor2, divisor1Word, divisor2Word));
        }

        [Theory]
        [InlineData(100, 3, 5, "fizz", "buzz")]
        [InlineData(200, 2, 6, "fizz", "buzz")]
        [InlineData(25, 7, 8, "fizz", "buzz")]
        [InlineData(75, 9, 9, "fizz", "buzz")]
        public void Can_Initialize_fizzBuzz_Class_With_Proper_Values(int upperBound, int divisor1, int divisor2, string divisor1Word, string divisor2Word)
        {
            FizzBuzz fizzBuzz = new FizzBuzz(upperBound, divisor1, divisor2, divisor1Word, divisor2Word);

            Assert.Equal(upperBound, fizzBuzz.UpperBound);
            Assert.Equal(divisor1, fizzBuzz.Divisor1);
            Assert.Equal(divisor2, fizzBuzz.Divisor2);
            Assert.Equal(divisor1Word, fizzBuzz.Divisor1Word);
            Assert.Equal(divisor2Word, fizzBuzz.Divisor2Word);
            Assert.Equal(0, fizzBuzz._start);
            Assert.Equal(0, fizzBuzz._sb.Length);
        }

        [Theory]
        [InlineData(100, 3, 5, "fizz", "buzz")]
        [InlineData(100, 7, 6, "fizz", "buzz")]
        public void fizzBuzz_fetches_Proper_Values(int upperBound, int divisor1, int divisor2, string divisor1Word, string divisor2Word)
        {
            FizzBuzz fizzBuzz = new FizzBuzz(upperBound, divisor1, divisor2, divisor1Word, divisor2Word);
            int lcm = 0; // this is the LCM of divisor1, and divisor2
            if (divisor1 == divisor2)
            {
                lcm = divisor1;
            }
            else if (divisor1 > divisor2 && divisor1 % divisor2 == 0)
            {
                lcm = divisor1;
            }
            else if (divisor2 > divisor1 && divisor2 % divisor1 == 0)
            {
                lcm = divisor2;
            }
            else 
            {
                lcm = divisor1 * divisor2;
            }


            string val = string.Empty;
            for(int x=1; x<= upperBound; x++)
            {
                val = fizzBuzz.GetNext();
                if (x % lcm == 0)
                {
                    Assert.Equal($"{divisor1Word}{divisor2Word}", val);
                    continue;
                }
                if (x % divisor1 == 0)
                {
                    Assert.Equal(divisor1Word, val);
                    continue;
                }
                if (x % divisor2 == 0)
                {
                    Assert.Equal(divisor2Word, val);
                    continue;
                }

                Assert.Equal(x.ToString(), val);
            }

        }
    }
}
