using System;

class Program
{
    static void Main()
    {
        int[] temps = [73, 74, 75, 71, 69, 72, 76, 73];
        var output = DailyTemps(temps);
        foreach (int n in output)
        {
            Console.WriteLine(n);
        }

    }

    public static int[] DailyTemps(int[] temperatures)
    {
        int[] output = new int[temperatures.Length];
        Stack<(int index, int temp)> Decreasing = new Stack<(int index, int temp)>();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (Decreasing.Count != 0 && Decreasing.Peek().temp < temperatures[i])
            {
                var popped = Decreasing.Pop();
                output[popped.index] = i - popped.index;
            }
            
            Decreasing.Push((i, temperatures[i]));
        }

        return output;
    } 
}