using System;
using System.Linq;
using System.Collections.Generic;

// 1. Create a Reverse Polish Notation calculator
class RPN
{

    public Stack<int> firstStack = new Stack<int>();
    int x, y;

    public void Process(string input)
    {
        switch (input)
        {
            case "+":
                {
                    PopTop();
                    firstStack.Push(x + y);
                    break;
                }
            case "-":
                {
                    PopTop();
                    firstStack.Push(x - y);
                    break;
                }
            case "/":
                {
                    PopTop();
                    firstStack.Push(x / y);
                    break;
                }
            case "*":
                {
                    PopTop();
                    firstStack.Push(x * y);
                    break;
                }
            default:
                firstStack.Push(Convert.ToInt32(input));
                break;
        }
    }

    public void PopTop()
    {
        y = firstStack.Pop();
        x = firstStack.Pop();
    }

    public string Result()
    {
        return firstStack.Peek().ToString();
    }
}

class MainClass
{
    public static int highValue = 0;
    public static Queue<int> queueStorage = new Queue<int>();

    // 2. Write a RemoveMax() function
    public static int RemoveMax(ref Stack<int> values)
    {
        while (values.Count > 0)
        {
            int stackValue = values.Pop();
            highValue = Math.Max(highValue, stackValue);
            queueStorage.Enqueue(stackValue);
        }
        while (queueStorage.Count > 0)
        {
            int element = queueStorage.Dequeue();
            if (element != highValue)
            {
                values.Push(element);
            }
        }
        while (values.Count > 0)
        {
            queueStorage.Enqueue(values.Pop());
        }
        while (queueStorage.Count > 0)
        {
            values.Push(queueStorage.Dequeue());
        }
        return highValue;
    }

    // For testing. Don't modify.
    public static void Main(string[] args)
    {
        string test = Console.ReadLine();
        if (test == "rpn")
        {
            var rpn = new RPN();
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "end")
                {
                    break;
                }
                else
                {
                    rpn.Process(userInput);
                    Console.WriteLine("=" + rpn.Result());

                }
            }
        }

        if (test == "remove_max")
        {
            var s1 = new Stack<int>();
            Console.ReadLine()
              .Split(new[] { ',' })
              .Select(Int32.Parse).ToList()
              .ForEach(n => s1.Push(n));

            Console.WriteLine(RemoveMax(ref s1));
            Console.WriteLine(
              string.Join(",", s1.Reverse().Select(i => i.ToString()).ToArray()));
        }
    }
}