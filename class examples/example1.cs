using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary conversions");
            Console.WriteLine(ConvertToBinary(0));
            Console.WriteLine(ConvertToBinary(1));
            Console.WriteLine(ConvertToBinary(10));
            Console.WriteLine(ConvertToBinary(15));
            Console.WriteLine(Convert(15, 2));

            Console.WriteLine("Base 3 conversions");

            Console.WriteLine(Convert(15, 3));
            Console.WriteLine(Convert(26, 3));

            Console.WriteLine("Base16 conversions");

            Console.WriteLine(Convert(1, 16));
            Console.WriteLine(Convert(15, 16));

            Console.WriteLine(Convert(16, 16));
            Console.WriteLine(Convert(32, 16));
            Console.WriteLine(Convert(64, 16));
            Console.WriteLine(Convert(255, 16));
            Console.WriteLine(Convert(256, 16));

            Console.WriteLine(Convert(1024, 16));

        }

        // Assumes number >= 0 and base > 0; Does no validation of input
        public static string Convert(int number, int baseValue)
        {
            // Lets not worry about bases > 16, or any negative numbers.
            if ((number < 0) || (baseValue < 0) || (baseValue > 16))
                return "";

            int numBits = sizeof(int) * 8;
            StringBuilder bitString = new StringBuilder(numBits); // optional to pass in capacity.. just being efficient to prevent reallocations
            for (int ii = 0; ii < numBits; ++ii)
            {
                bitString.Append("0");
            }
            int index = 0;
            while (number > 0)
            {
                int lsb = number % baseValue;  // lsb will have values from 0 to (baseValue - 1)
                
                bitString[numBits - index - 1] = GetChar((uint)lsb);

                number /= baseValue;   // number = number / baseValue;

                ++index;
            }

            return bitString.ToString();
        }

        private static char GetChar(uint number)
        {
            char ch = '0';
            if (number <= 9)
                ch = (char)(((int)'0') + number);
            else
                ch = (char)(((int)'A') + (number - 10));

            return ch;
        }

        // Assumes number >= 0. Does no validation of input
        public static string ConvertToBinary(uint number)
        {
            int numBits = sizeof(uint) * 8;
            StringBuilder bitString = new StringBuilder(numBits); // optional to pass in capacity.. just being efficient to prevent reallocations
            for (uint ii = 0; ii < numBits; ++ii)
            {
                bitString.Append("0");
            }
            for (int ii = 0; ii < numBits; ++ ii)
            {
                uint lsb = ((number >> ii) & 0x1);
                if (lsb == 0)
                    bitString[numBits - ii - 1] = '0';
                else
                    bitString[numBits - ii - 1] = '1';

                /**
                 * Or could say:  bitString[numBits - ii - 1] = (lsb == 0) ? "0" : "1");
                 * or bitString[numBits - ii - 1] = (((number >> ii) & 0x1) == 0 ? "0" : "1");   Not preferable, as harder to understand
                 * */
            }

            return bitString.ToString();
        }
    }
}
