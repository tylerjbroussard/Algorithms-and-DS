using System;
using System.Text;

class Base62Converter
{
    // 1. For our first problem, write a function that converts a given base-62 string
    //    into an integer. Only a single string will be provided, and it will be up to
    //    11 characters in length.  
    public static ulong ToBase10(string videoId)
    {

        const string _base62 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        ulong[] base62Exponents = new ulong[62];
        ulong[] base62Char = new ulong[62];
        ulong[] calculateExponentList = new ulong[62];
        string userDefinedUrl = videoId;
        ulong base62Exp = 62;
        ulong counterForExp = 1;
        ulong totalBase10Value = 0;

        for (uint i = 0; i < _base62.Length; i++)
        {
            base62Exponents[i] = 62 - i;

        }


        for (int i = 0; i < userDefinedUrl.Length; i++)
        {
            uint x = 0;

            while (x < _base62.Length)
            {
                if (userDefinedUrl[i] == _base62[(int)x])
                {
                    base62Char[i] = x;

                    break;
                }
                else
                {
                    x++;
                }
            }
        }


        for (int y = 0; y < userDefinedUrl.Length - 1; y++)
        {
            calculateExponentList[y] = 1;
            int counter1 = (userDefinedUrl.Length - (int)counterForExp);

            while (counter1 > 0)
            {
                calculateExponentList[y] *= base62Exp;
                counter1--;
            }

            counterForExp++;

            if (y == userDefinedUrl.Length - 2)
            {
                calculateExponentList[userDefinedUrl.Length - 1] = 1;


            }
        }

        for (int z = 0; z <= userDefinedUrl.Length; z++)
        {
            totalBase10Value += (base62Char[z] * calculateExponentList[z]);
        }

        return totalBase10Value;


    }

    // 2. Write a function that does the opposite of the previous one. That is, it
    //    decodes a Morse Code sequence into a word.
    public static string ToBase62(ulong number)
    {
        const string _base62 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        ulong base62Exp = 62;
        ulong counterForExp = 0;
        ulong exponentCounter = 0;
        ulong totalBase10Value = number;
        UInt64 base10String = (UInt64)totalBase10Value;
        UInt64 runningTotal = (UInt64)totalBase10Value;
        ulong[] numList = new ulong[62];
        ulong charBase62;
        ulong multiplier = 0;
        StringBuilder base62Final = new StringBuilder();

        while (base10String > 62)
        {
            base10String = base10String / base62Exp; //become the value to multiply and find new char

            exponentCounter++;  //this is your exponent place value


            if (base10String < 62 & base10String > 0)
            {

                charBase62 = Convert.ToUInt64(base10String); //become whole number


                base62Final.Append(_base62[(int)base10String]);
                multiplier = 1;
                do
                {

                    multiplier *= 62;
                    exponentCounter--;

                } while (exponentCounter > 0);


                numList[counterForExp] = charBase62 * multiplier;
                runningTotal -= numList[counterForExp];
                counterForExp++;
                base10String = runningTotal;



            }
        }
        base62Final.Append(_base62[(int)base10String]);
        return base62Final.ToString();
    }

    // For testing. Don't modify.
    public static void Main(string[] args)
    {
        string mode = Console.ReadLine();
        string arg = Console.ReadLine();
        if (mode == "decode")
        {
            Console.WriteLine(ToBase10(arg));
        }

        if (mode == "encode")
        {
            var videoKey = ulong.Parse(arg);
            Console.WriteLine(ToBase62(videoKey));
        }
    }

}