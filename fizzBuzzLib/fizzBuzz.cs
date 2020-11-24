using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleToAttribute("fizzBuzzLib.Test")]
namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        public int UpperBound { get; }

        internal int? Divisor1 { get; }

        internal int? Divisor2 { get; }

        internal string Divisor1Word { get; }

        internal string Divisor2Word { get; }

        internal int _start = 0;

        internal StringBuilder _sb;

        public string GetNext()
        {
            _start++;

            if (_start > UpperBound)
            {
                return null;
            }

            _sb.Clear();

            if (_start % Divisor1 == 0)
            {
                _sb.Append(Divisor1Word);
            }

            if (_start % Divisor2 == 0)
            {
                _sb.Append(Divisor2Word);
            }

            if (_sb.Length > 0)
            {
                return _sb.ToString();
            }

            return _start.ToString();
        }

        public FizzBuzz(int upperBound, int divisor1, int divisor2, string divisor1Word, string divisor2Word)
        {
            if (upperBound < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (divisor1 == 0 || divisor2 == 0)
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrWhiteSpace(divisor1Word) || string.IsNullOrWhiteSpace(divisor2Word))
            {
                throw new ArgumentException();
            }

            UpperBound = upperBound;
            Divisor1 = divisor1;
            Divisor2 = divisor2;
            Divisor1Word = divisor1Word;
            Divisor2Word = divisor2Word;
            _sb = new StringBuilder();
        }

    }
}
