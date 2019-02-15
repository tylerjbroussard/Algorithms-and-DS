using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class MyList
    {
        static void MainLinkedList(string[] args)
        {
            LinkedList<int> l1 = CreateList(100);
            Output(l1);
            PrintNthFromLast(1, l1);
            PrintNthFromLast(99, l1);
            PrintNthFromLast(100, l1);
            PrintNthFromLast(101, l1);
        }

        // Not catching exceptions, etc in this example, to keep it simple.
        public static void PrintNthFromLast(uint N, LinkedList<int> list)
        {
            if ((list == null) || (list.Count == 0))
                return;
            /* 1 2 3 4 5 
             * Lets say N = 2
             * current <- 1
             * NBehindCurrent  <- 1
             * loop and will make current point to node with value 3  
             * NBehindCurrent <-- 1  and so, NBehindCurrent is 2 behind current.
             * Now, I will move both current and NBehindCurrent forward until current gets to the end of the list
             */
            var current = list.GetEnumerator();
            var NBehindCurrent = list.GetEnumerator();
            current.MoveNext();
            NBehindCurrent.MoveNext();

            uint num = N;
            while ((num > 0 ) && current.MoveNext())        // Advance current by N
            {
                --num;
            }
            if (num > 0)    // if num is still > 0, it means we ran out of the list before num could get down to 0
            {
                Console.WriteLine("Ran out of list for " + N + "th element");
            }
            else
            {
                while (current.MoveNext())         // move current forward
                {
                    NBehindCurrent.MoveNext();     // move NBehindCurrent also forward, so that it stays N behind current
                }

                Console.WriteLine(N + "th element from end of list is " + NBehindCurrent.Current);
            }
        }

        public static void Output(LinkedList<int> list)
        {
            if (list == null)
                return;
            
            foreach( var element in list)
            {
                Console.WriteLine(element);
            }
        }

        public static LinkedList<int> CreateList(int size)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (int ii = 0; ii < size; ++ ii)
            {
                list.AddLast(ii);
            }

            return list;
        }
    }
}
