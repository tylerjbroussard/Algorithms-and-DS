using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ex1
{
    class Fibonacci
    {
        
        static void MainFib(string[] args)
        {
            
            // Console.WriteLine(new Fibonacci().GetFibRecursive(1000)); // Really slow
            
            uint N = 90;                            // We will compute fibonacci value of this number N
            uint numRepeatedComputes = 500000;      // Number of times we will compute fibonacci of N

            DoFibonacciRecusiveWithMemoization(N, numRepeatedComputes);
            DoFibonacciIterative(N, numRepeatedComputes);
        }

        static public void DoFibonacciRecusiveWithMemoization(uint N, uint numRepeatedComputes)
        {
            Stopwatch stopwatch = new Stopwatch();

            ////////////////////////////////////////////////////////////////////////////////////////////
            // We will call GetFibRecursiveMemoization on a new object every time in the for loop below.
            // This means that the memoization done in the first iteration will NOT provide any help (optimization)
            // to subsequent iterations because we are creating a new Fibonacci object every time in the loop
            stopwatch.Start();
            for (int iter = 0; iter < numRepeatedComputes; ++iter)
            {
                ulong fib1 = new Fibonacci().GetFibRecursiveMemoization(N);  // Create object inside the loop, new object for every iteration
            }
            stopwatch.Stop();
            Console.WriteLine("FibRecursiveWithMem(" + N + "). " + numRepeatedComputes + " repeated computes. Diff objects. Time: " + stopwatch.ElapsedMilliseconds + " ms");

            ////////////////////////////////////////////////////////////////////////////////////////////
            // We will call GetFibRecursiveMemoization on the SAME object every time in the for loop below.
            // Thats why we create one object outside the for loop only.
            // This means that the memoization done in the first iteration WILL provide  help (optimization)
            // to subsequent iterations because we would be storing all the computed fibonacci values first time in the loop,
            // and these will just get used for all subsequent loop iterations.
            stopwatch.Reset();
            stopwatch.Start();
            Fibonacci f1 = new Fibonacci();                ///  Create the object once outside the for loop
            for (int iter = 0; iter < numRepeatedComputes; ++iter)
            {
                ulong fib1 = f1.GetFibRecursiveMemoization(N);
            }
            stopwatch.Stop();
            Console.WriteLine("FibRecursiveWithMem(" + N + "). " + numRepeatedComputes + " repeated computes. Same object. Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }

        static public void DoFibonacciIterative(uint N, uint numRepeatedComputes)
        {
            Fibonacci f1 = new Fibonacci();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int iter = 0; iter < numRepeatedComputes; ++iter)
            {
                ulong fib1 = new Fibonacci().GetFibIterative(N);
            }
            stopwatch.Stop();

            Console.WriteLine("GetFibIterative(" + N + "). " + numRepeatedComputes + " repeated computes. Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }

        public ulong GetFibRecursive(uint n)
        {
            return (n == 0) ? 0 : ((n <= 2) ? 1 : GetFibRecursive(n - 1) + GetFibRecursive(n - 2));

            /*  Or u can write this as:
            if (n == 0)
                return 0;
            if (n <= 2)
                return 1;
            else 
                return GetFibRecursive(n - 1) + GetFibRecursive(n - 2);
            */
        }

        public ulong GetFibRecursiveMemoization(uint n)
        {
            if (n == 0)
                return 0;
            else if (n <= 2)
                return 1;
            else
            {
                if (!mFibStore.ContainsKey(n))
                {
                    mFibStore[n] = GetFibRecursiveMemoization(n - 1) + GetFibRecursiveMemoization(n - 2);
                }
                return mFibStore[n];
            }
        }

        public ulong GetFibIterative(uint N)
        {
            ulong fibN_1 = 0;       // initialized to Fib(0), which is 0. Will eventually contain Fib(N-1) value
            ulong fibN_2 = 1;       // initialized to Fib(1), which is 1. Will eventually contain Fib(N-2) value
            ulong fibN = 0;         // Will eventually contain Fib(N) value

            while ( N > 0 )
            {
                fibN = fibN_1 + fibN_2;

                // get ready for next iteration of the loop (if there is one)
                fibN_2 = fibN_1;
                fibN_1 = fibN;

                --N;
            }

            return fibN;
        }

        // Dictionary is used to store the computed fibonacci values.
        // N is the key, and Fib(N) is the value.
        // For exampple:
        // mFibStore[0] will have 0
        // mFibStore[1] will have 1
        // mFibStore[2] will have 1
        // mFibStore[3] will have 2
        // mFibStore[4] will have 3
        // mFibStore[5] will have 5
        // mFibStore[6] will have 8  and so on
        private Dictionary<uint, ulong> mFibStore = new Dictionary<uint, ulong>();
    }
}


/*
So, we have, in order of increasing speed, the following

    Recursive fibonacci with no memoization
    Recursive fibonacci with memoization
    Iterative fibonacci
    Recursive fibonacci with memoization repeatedly on the same object

 * */
