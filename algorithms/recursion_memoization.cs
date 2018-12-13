using System;
using System.Linq;
using System.Collections.Generic;

class MainClass
//Remember, these problems are meant to be solved recursively — do not use loops
{
    static int total;
    static int dex = 0;
    static int _counter;
    static Dictionary<int, int> stepStore = new Dictionary<int, int>();

    // 1. Write a method that takes in a list of integers and returns their sum

    public static int Sum(Stack<int> values)
    {
        if (values.Count > 0)
        {
            total += values.Pop();
            return Sum(values);
        }
        else
        {
            return total;
        }
    }

    // 2. Write a method that determines if the passed string is a palindrome or not

    public static bool IsPalindrome(string input)
    {
        if (_counter == 0 && dex < (input.Length - 1))
        {
            if (input[dex] == ' ')
            {
                input = input.Remove(dex, 1);
            }
            dex++;
            return IsPalindrome(input);
        }

        if (input[_counter] == input[input.Length - (_counter + 1)] && (_counter + 1) < input.Length)
        {
            _counter++;

            return IsPalindrome(input);
        }
        else if ((_counter + 1) == input.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 3. Implement a recursive method to count how many possible ways a child can 

    public static int StepWays(int steps)
    {
        _counter++;
        if (steps < 1)
        {
            return 0;
        }
        else if (steps <= 4)
        {
            if (!stepStore.ContainsKey(steps))
            {
                stepStore[steps] = 1 + StepWays(steps - 1) + StepWays(steps - 2);
            }
            return stepStore[steps];
        }
        else
        {
            if (!stepStore.ContainsKey(steps))
            {
                stepStore[steps] = StepWays(steps - 1) + StepWays(steps - 2) + StepWays(steps - 3);
            }
            return stepStore[steps];
        }
    }


    // For testing. Don't modify.
    public static void Main(string[] args)
    {
        string test = Console.ReadLine();
        string input = Console.ReadLine();
        if (test == "sum")
        {
            var numbers = new Stack<int>();
            input.Split(new[] { ',' }).Select(Int32.Parse).ToList().ForEach(n => numbers.Push(n));
            Console.WriteLine(Sum(numbers));
        }

        if (test == "palindrome")
        {
            Console.WriteLine(IsPalindrome(input));
        }

        if (test == "step_ways")
        {
            var steps = int.Parse(input);
            Console.WriteLine(StepWays(steps));


        }

        if (test == "step_ways_memo")
        {
            var steps = int.Parse(input);
            Console.WriteLine(StepWays(steps));
            Console.WriteLine(_counter);

        }
    }
}