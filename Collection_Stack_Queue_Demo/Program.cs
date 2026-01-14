// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System;
using System.Linq;
class Program
{
       static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 2,5,1,8,4,10,23,56,93 };
        // Using a lambda expression to filter even numbers
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even Numbers in the List:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
    }

}
