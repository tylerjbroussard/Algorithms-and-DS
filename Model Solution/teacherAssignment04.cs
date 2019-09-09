using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static List<int> Merge(List<int> list1, List<int> list2)
  {
    var result = new List<int>();
    
    while (list1.Any() && list2.Any())
    {
      if (list1.First() < list2.First())
      {
        result.Add(list1.First());
        list1.RemoveAt(0);
      }
      else
      {
        result.Add(list2.First());
        list2.RemoveAt(0);
      }
    }
    
    result.AddRange(list1);
    result.AddRange(list2);
    
    return result;
  }
  
  public static void ReversePrint(List<int> values)
  {
    if (values.Any())
    {
      var n = values.First();
      values.RemoveAt(0);
      ReversePrint(values);
      Console.Write(n + " ");
    }
  }
  
  public static Node Reverse(Node head)
  {
    if (head.Pointer == null)
      return head;
    
    var next = head.Pointer;
    head.Pointer = null;
    var last = Reverse(next);
    next.Pointer = head;
    return last;
  }
  
  public static void Main (string[] args) {
    string test = Console.ReadLine();
    string input1 = Console.ReadLine();
    string input2 = Console.ReadLine();
    if (test == "merge")
    {
      var firstList = input1.Split(new[] {','}).Select(Int32.Parse).ToList();
      var secondList = input2.Split(new[] {','}).Select(Int32.Parse).ToList();
      
      var result = Merge(firstList, secondList);
      result.ForEach(n => Console.Write(n + ","));
    }
    
    if (test == "reverse_print")
    {
      var numbers = input1.Split(new[] {','}).Select(Int32.Parse).ToList();
      ReversePrint(numbers);
    }
    
    if (test == "reverse")
    {
      var numbers = input1.Split(new[] {','}).Select(Int32.Parse).ToList();
      
      // implement a test 
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

class Node {
  // Feel free to modify this class however you like
  public int Value { get; set; }
  public Node Pointer { get; set; }
  
  public Node (int value)
  {
    Value = value;
  }
}