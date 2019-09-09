using System;
using System.Linq;
using System.Collections.Generic;

class MainClass {
  // 1. Write a method that takes in a list of integers and returns their sum
  public static int Sum(Stack<int> values)
  {
    if (values.Any())
      return values.Pop() + Sum(values);
      
    return 0;
  }
  
  // 2. Write a method that determines if the passed string is a palindrome or not
  public static bool IsPalindrome(string input)
  {
    input = input.Replace(" ", string.Empty);
    return Palindromer(input);
  }
  
  private static bool Palindromer(string input)
  {
    if (input.Length < 2)
      return true;
    
    if (input[0] == input[input.Length - 1])
      return Palindromer(input.Substring(1, input.Length - 2));
      
    return false;
  }
  
  // 3. Implement a recursive method to count how many possible ways a child can 
  //    run up n stairs 1 step, 2 steps, or 3 steps at a time.
  public static int StepWays(int steps)
  {
    if (steps == 0)
      return 0;
      
    return Stepper(steps);
  }
  
  static Dictionary<int, int> StepCache = new Dictionary<int,int>();
  
  private static int Stepper(int steps)
  {
    _counter++;
    if (steps < 0)
      return 0;
    if (steps == 0)
      return 1;
    else
    {
      if (StepCache.ContainsKey(steps))
        return StepCache[steps];
      
      var hops = Stepper(steps-1) + Stepper(steps-2) + Stepper(steps-3);
      StepCache.Add(steps,hops);
      return StepCache[steps];
    }
  }
  
  static int _counter;
  
  // For testing. Don't modify.
  public static void Main (string[] args) {
    string test = Console.ReadLine();
    string input = Console.ReadLine();
    if (test == "sum")
    {
      var numbers = new Stack<int>();
      input.Split(new[] {','}).Select(Int32.Parse).ToList().ForEach(n => numbers.Push(n));
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