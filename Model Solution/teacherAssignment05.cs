using System;
using System.Linq;
using System.Collections.Generic;

// 1. Create a Reverse Polish Notation calculator
class RPN {
  Stack<int> _stack = new Stack<int>();
  
  public void Process(string input) {
    int firstOperand;
    int secondOperand;
    switch(input)
    {
      case "+":
        secondOperand = _stack.Pop();
        firstOperand = _stack.Pop();
        _stack.Push(firstOperand + secondOperand);
        break;
      case "-":
        secondOperand = _stack.Pop();
        firstOperand = _stack.Pop();
        _stack.Push(firstOperand - secondOperand);
        break;
      case "*":
        secondOperand = _stack.Pop();
        firstOperand = _stack.Pop();
        _stack.Push(firstOperand * secondOperand);
        break;
      case "/":
        secondOperand = _stack.Pop();
        firstOperand = _stack.Pop();
        _stack.Push(firstOperand / secondOperand);
        break;
      default:
        _stack.Push(int.Parse(input));
        break;
    }
  }
  
  public string Result() {
    return _stack.Peek().ToString();
  }
}

class MainClass {
  // 2. Write a RemoveMax() function
  public static int RemoveMax(Stack<int> values){
    var q = new Queue<int>();
    int max = values.Peek();
    while(values.Any())
    {
      if (max < values.Peek())
        max = values.Peek();
      q.Enqueue(values.Pop());
    }
    
    while (q.Any())
    {
      var current = q.Dequeue();
      if (current < max)
       values.Push(current);
    }
    
    while (values.Any())
    {
      q.Enqueue(values.Pop());
    }
    
    while (q.Any())
    {
      values.Push(q.Dequeue());
    }
    return max;
  }
  
  // For testing. Don't modify.
  public static void Main (string[] args) {
    string test = Console.ReadLine();
    if (test == "rpn") 
    {
      var rpn = new RPN();
      while (true) 
      {
        var input = Console.ReadLine();
        if (input == "end")
          break;
          
        rpn.Process(input);
        Console.WriteLine("=" + rpn.Result());
      }
    }
    
    if (test == "remove_max")
    {
      var s1 = new Stack<int>();
      Console.ReadLine()
        .Split(new[] {','})
        .Select(Int32.Parse).ToList()
        .ForEach(n => s1.Push(n));
      
      
      Console.WriteLine(RemoveMax(s1));
      Console.WriteLine(
        string.Join(",", s1.Reverse().Select(i => i.ToString()).ToArray()));
    }
  }
}