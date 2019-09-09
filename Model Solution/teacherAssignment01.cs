using System;

class Base62Converter {
  const string _base62 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

  // 1. For our first problem, write a function that converts a given base-62 string
  //    into an integer. Only a single string will be provided, and it will be up to
  //    11 characters in length.  
  public static ulong ToBase10(string videoId){
    ulong result = 0;
    foreach (char c in videoId)
    {
      var charValue = (ulong) _base62.IndexOf(c);
      result = result * 62 + charValue;
    }
    
    return result;
  }
  
  // 2. Write a function that does the opposite of the previous one. That is, it
  //    decodes a Morse Code sequence into a word.
  public static string ToBase62(ulong number){
    var result = "";
    while(number > 0)
    {
      var index = (int) (number % 62);
      result = _base62[index] + result;
      number /= 62;
    }
    return result;
  }
  
  // For testing. Don't modify.
  public static void Main (string[] args) {
    string mode = Console.ReadLine();
    string arg = Console.ReadLine();
    if (mode == "decode")
    {
      Console.WriteLine(ToBase10(arg));
    }
    
    if (mode == "encode")
    {
      var videoKey = ulong.Parse(arg);
      Console.WriteLine(ToBase62(videoKey));
    }
  }
}