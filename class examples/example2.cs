using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class a3b3c3d3
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

           Compute2();
            //Compute1(results);
        }

        public static void Compute2()
        {
            int N = 1000;
            Dictionary<ulong, List<Tuple<int, int>>> map = new Dictionary<ulong, List<Tuple<int, int>>>();

            for (int c = 1; c <= N; ++c)
            {
                ulong c3 = (ulong)Math.Pow(c, 3);
                for (int d = 1; d <= N; ++d)
                {
                    ulong sum = c3 + (ulong)Math.Pow(d, 3);

                    // Store sum as key, and the pair (a, b) as its value.
                    AddResult(map, c, d, sum);
                }
            }

            //foreach (KeyValuePair<ulong, List < Tuple<int, int> >> keyValue in map)
            foreach (var keyValue in map)
            {
                PrintCombos(keyValue);
            }
            Console.WriteLine("size of map " + map.Count);
        }

        private static void PrintCombos(KeyValuePair<ulong, List<Tuple<int, int>>> keyValue)
        {
            List<Tuple<int, int>> value = keyValue.Value;

            foreach (var tuple1 in value)
            {
                foreach (var tuple2 in value)
                {
                    Console.WriteLine("sum = " + keyValue.Key + " " + tuple1.Item1 + " " + tuple1.Item2 + " " + tuple2.Item1 + " " + tuple2.Item2);
                }
            }
        }

        public static void AddResult(Dictionary<ulong, List<Tuple<int, int>>> map, int a, int b, ulong sum)
        {
            if (!map.ContainsKey(sum))
            {
                map[sum] = new List<Tuple<int, int>>();
            }

            map[sum].Add(new Tuple<int, int>(a, b));
        }

        public static void Compute1(List<string> results)
        {
            int N = 1000;
            for (int a = 1; a <= N; ++ a)
            {
                ulong a3 = (ulong)Math.Pow(a, 3);
                for (int b = 1; b <= N; ++b)
                {
                    ulong b3 = (ulong)Math.Pow(b, 3);
                    for (int c = 1; c <= N; ++c)
                    {
                        ulong c3 = (ulong)Math.Pow(c, 3);
                        for (int d = 1; d <= N; ++d)
                        {
                            if ((a3 + b3) == (ulong)(c3 + Math.Pow(d,3)))
                            {
                                results.Add(a + " " + b + " " + c + " " + d);
                            }
                        }
                    }
                }
            }
        }
    }
}
/*
 * 
Compute2
N=1000
size of map 498907
119824488 has maxpairs count of 6
11 493
90 492
346 428
428 346
492 90
493 11
 * 
 */
