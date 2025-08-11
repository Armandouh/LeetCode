using System;
using System.Text;

class Program
{
    static void Main()
    {
        String str = "(){}{{";
        Stack<int> sheesh = new Stack<int>();
        sheesh.Push(1);
        sheesh.Push(2);
        //Console.WriteLine(sheesh.Count == 0);
        
        Console.WriteLine(isValid(str));
    }

    static bool isValid(string s)
    {
        Stack<int> myStack = new Stack<int>();

        foreach (char c in s)
        {
            if (c == '[')
                myStack.Push(']');
            else if (c == '{')
                myStack.Push('}');
            else if (c == '(')
                myStack.Push(')');
            else if (myStack.Count == 0 || myStack.Pop() != c)
                return false;
        }

        return myStack.Count == 0;
    }
}