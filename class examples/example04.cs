using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1
{
    class EnumerateSubsets
    {
        static void Main(string[] args)
        {
            EnumerateSubsets es = new EnumerateSubsets();
            es.PrintAllSubsets("abc");
            es.PrintSubsetSize("abc");
            es.PrintSubsetSize("abcde");
            es.PrintSubsetSize("abcdefghij");
           // es.PrintSubsetSize("abcdefghijklmnopqrstuvwxyz");
            es.PrintAllSubsets(null);
            es.PrintSubsetSize("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");
        }

        public void PrintAllSubsets(string inputStr)
        {
            List<string> allSubsets = GetAllSubsets(inputStr);
            if (allSubsets != null)
            {
                Console.WriteLine("Subsets of " + inputStr + " are(" + allSubsets.Count + ")");

                foreach (var subset in allSubsets)
                {
                    Console.WriteLine(subset);
                }
            }
        }

        public void PrintSubsetSize(string inputStr)
        {
            List<string> allSubsets = GetAllSubsets(inputStr);
            if (allSubsets != null)
                Console.WriteLine(inputStr + " has " + allSubsets.Count + " subsets");
        }

        public List<string> GetAllSubsets(string inputStr)
        {
            // Check if we are violating the limitation of our algorithm
            if (!InputValid(inputStr))
            {
                Console.WriteLine("Invalid input string, max length supported is " + sizeof(int) * 8);
                return null;
            }

            int numSubsets = (int)Math.Pow(2, inputStr.Length);
            List<string> results = new List<string>(numSubsets);
            
            for (int ii = 0; ii < numSubsets; ++ ii)
            {
                string subsetStr = GenerateOneSubsetFromBitPattern( ii, inputStr);
                results.Add(subsetStr);
            }

            return results;
        }

        private string GenerateOneSubsetFromBitPattern(int value, string inputStr)
        {
            //  sizeof returns size of int in bytes, multiply by 8 to get number of bits (since there are 8 bits per byte)
            int numberOfBitsInInt = sizeof(int) * 8;
            int numBitsToCheck = Math.Min(numberOfBitsInInt, inputStr.Length);
            string subsetStr = "";

            for (int i = 0; i < numBitsToCheck; ++i)
            {
                // Check if the ith bit of value is 1:
                // We do this by  left shifting 0x1 (which is bit pattern 01 ) by i places.
                // This puts the 1 in 0x1 at the   ith position.
                // And when we do a bit and with value, it tells us if the  ith bit in value is 1 or 0
                int bitPatternWithIthBitAs1 = 0x1 << i;
                int ithBitValue = value & bitPatternWithIthBitAs1;
                if (ithBitValue != 0)
                    subsetStr = subsetStr + inputStr[i];        // Take ith char of str
            }

            return subsetStr;
        }

        private bool InputValid(string inputStr)
        {
            return (inputStr != null) && (inputStr.Length <= sizeof(int) * 8);
        }
    }
}
