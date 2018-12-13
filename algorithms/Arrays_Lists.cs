using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    public static List<int> nodeReverse = new List<int>();

    public static List<int> Merge(List<int> list1, List<int> list2)
    {
        List<int> mergeLists = new List<int>(list1);
        mergeLists.InsertRange(list1.Count, list2);
        mergeLists.Sort();
        return mergeLists;
    }

    public static void ReversePrint(List<int> values)
    {
        for (int i = values.Count; i > 0; i--)
        {
            Console.Write(values[i - 1] + ",");
        }
    }

    public static Node Reverse(Node head)
    {
        while (head.Pointer != null)
        {
            nodeReverse.Add(head.Value);
            return Reverse(head.Pointer);
        }

        nodeReverse.Add(head.Value);
        Node topHat = new Node(nodeReverse[nodeReverse.Count - 1]);
        nodeReverse.RemoveAt(nodeReverse.Count - 1);

        var currentNode = topHat;

        for (int i = nodeReverse.Count; i > 0; i--)
        {
            Node n = new Node(nodeReverse[i - 1]);
            currentNode.Pointer = n;
            currentNode = n;
        }

        return topHat;

    }

    public static void Main(string[] args)
    {
        string test = Console.ReadLine();
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();
        if (test == "merge")
        {
            var firstList = input1.Split(new[] { ',' }).Select(Int32.Parse).ToList();
            var secondList = input2.Split(new[] { ',' }).Select(Int32.Parse).ToList();

            var result = Merge(firstList, secondList);
            result.ForEach(n => Console.Write(n + ","));
        }

        if (test == "reverse_print")
        {
            var numbers = input1.Split(new[] { ',' }).Select(Int32.Parse).ToList();
            ReversePrint(numbers);
        }

        if (test == "reverse")
        {
            var numbers = input1.Split(new[] { ',' }).Select(Int32.Parse).ToList();

            var head = new Node(numbers[0]);
            numbers.RemoveAt(0);

            var currentNode = head;
            foreach (int num in numbers)
            {
                Node n = new Node(num);
                currentNode.Pointer = n;
                currentNode = n;
            }

            var reversedHead = Reverse(head);

            Print(reversedHead);
        }
    }

    public static void Print(Node n)
    {
        if (n == null)
            return;

        Console.Write(n.Value + " ");
        Print(n.Pointer);
    }
}

class Node
{
    public int Value { get; set; }
    public Node Pointer { get; set; }

    public Node(int value)
    {
        Value = value;
    }
}