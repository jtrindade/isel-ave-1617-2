using System;
using Data;

public class Program
{
  public static void Main(string[] args)
  {
    if (args.Length == 2) {
      Person p = new Person(args[0], args[1]);
      Greet(p);
    } else {
      Greet("World");
    }
  }

  public static void Greet(string target) 
  {
    Console.WriteLine("Hello {0}!", target);
  }

  public static void Greet(Person person) 
  {
    Greet(person.ToString());
  }
}

