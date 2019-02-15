using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    /*
     *  "ab" ->  "ab" and  "ba"
     *  "abc" ->  "abc" "bac" "cab" "cba" "bca" "acb"   6 total.
     *  "abcd" --> Will have 4! permutations : 24
     *  for a string of length N, u will have N! permutations.
     *  
     *  "abc"  Find me all permutations of "ab" , and then I will add 'c' to all of them in all the insertion points
     *          result set has "ba" and "ab" --> Adding 'c' to every string in the result set -->> "cba", "bca", "bac"
     *                                                                                             "cab", "acb", "abc"
     *  "ab"    Find me all permutations of "a", and then I will add 'b' to all of them in all the insertion points
     *          result set has "a" --> Adding 'b' to every string in the result set -->>  "ba" and "ab"
     *  "a"     the permutations of this is just the stirng "a"  <-- recursion base case.
     */

    class StringPermutationsRecur
    {
        static void Main(string[] args)
        {
            string inputStr = "abcdefg";
            List<StringBuilder> results = new List<StringBuilder>();
            StringBuilder str = new StringBuilder(inputStr);
            permute(str, results);

            Console.WriteLine("Num permutations of " + inputStr + " " + results.Count);
            foreach (var permutationStr in results)
            {
                //Console.WriteLine(permutationStr);
            }
        }

        // abc -> ab -> a [recursion stops]  
        // AddPermutations:        (ba),              (ab) 
        // AddPermutations:  (cba, bca, bac),   (cab, acb, abc)

        public static void permute(StringBuilder str, List<StringBuilder> results)
        {
            if (str.Length == 1)
            {
                results.Add(str);
                return;
            }

            List<StringBuilder> localResults = new List<StringBuilder>();
            permute(new StringBuilder(str.ToString(0, str.Length - 1)), localResults);
            AddPermutations(localResults, str[str.Length - 1], results);
        }

        private static void AddPermutations(List<StringBuilder> localResults, char ch, List<StringBuilder> results)
        {
            for (int ii = 0; ii < localResults.Count; ++ii)
            {
                StringBuilder strToAddChIn = localResults.ElementAt(ii);
                for (int strIndex = 0; strIndex <= strToAddChIn.Length; ++strIndex)
                {
                    StringBuilder newStr = AddCharToStringAtPosition(strToAddChIn, strIndex, ch);
                    results.Add(newStr);
                }
            }
        }

        private static StringBuilder AddCharToStringAtPosition(StringBuilder strToAddChIn, int insertPos, char ch)
        {
            StringBuilder newString = new StringBuilder(strToAddChIn.ToString());
            return newString.Insert(insertPos, ch);
        }
    }
}
