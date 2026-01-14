using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Stack_Queue_Demo
{
    internal class Program
    {
        static void Main(string[] args)

        {//creating 
            Stack stack = new Stack();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            //pop a value 
            object popValue = stack.Pop();
            Console.WriteLine("Popped Value:" + popValue);
            //peek a value
            object peekValue = stack.Peek();
            Console.WriteLine("Peek Value:" + peekValue);
            //search a value in stack
            bool searchValue = stack.Contains(20);
            Console.WriteLine("Search Value:" + searchValue);
            //count of a stack
            Console.WriteLine("Current stack count: " + stack.Count);
            //clearing a stack
            stack.Clear();
            Console.WriteLine("Stack cleared. stack count after clearing:"+stack.Count);
        }
    }
}
