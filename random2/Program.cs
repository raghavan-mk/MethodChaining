using System;

namespace random2
{
    class Program
    {
        static void Main(string[] args)
        {
            Digit d = new Digit(10);
            byte number = d;
            Console.WriteLine(number);
            Digit d1 = (Digit) number;
            Console.WriteLine(d1);
            int? n = null;
            Console.WriteLine(n);
            NullableString(n.ToString());
        }
        #nullable enable
        static string NullableString(string input){
            return "";
        }
    }   

    readonly struct Digit{
        readonly byte digit;

        public Digit(byte digit)  {
            this.digit = digit;
        }

        public static implicit operator byte(Digit d) => d.digit;
        public static explicit operator Digit(byte digit) => new Digit(digit);

        public override string ToString() => $"{digit}";

    }
}
