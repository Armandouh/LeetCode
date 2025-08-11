using System;

class Program
{
    static void Main()
    {
        string[] tokens = { "4", "13", "5", "/", "+" };
        Console.WriteLine(Evaluate(tokens));
    }

    static int Evaluate(string[] tokens)
    {
        Stack<int> nums = new Stack<int>();

        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "+")
            {
                int operand2 = nums.Pop();
                int operand1 = nums.Pop();

                int result = operand1 + operand2;
                nums.Push(result);
            }
            else if (tokens[i] == "-")
            {
                int operand2 = nums.Pop();
                int operand1 = nums.Pop();

                int result = operand1 - operand2;
                nums.Push(result);
            }
            else if (tokens[i] == "*")
            {
                int operand2 = nums.Pop();
                int operand1 = nums.Pop();

                int result = operand1 * operand2;
                nums.Push(result);
            }
            else if (tokens[i] == "/")
            {
                int operand2 = nums.Pop();
                int operand1 = nums.Pop();

                int result = operand1 / operand2;
                nums.Push(result);
            }
            else 
                nums.Push(int.Parse(tokens[i]));
        }

        return nums.Pop();
    }
}