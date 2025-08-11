using System;

class Program
{
    static void Main()
    {
        int[] positions = [10, 8, 0, 5, 3];
        int[] speeds = [2, 4, 1, 1, 3];
        Console.WriteLine(getFleet(12, positions, speeds));

        double a = 2.5;
        double b = Math.Ceiling(a);
        Console.WriteLine(b);
    }

    public static int getFleet(int target, int[] position, int[] speed)
    {
        if (position.Length == 1)
            return 1;

        (int position, int speed)[] cars = new (int position, int speed)[position.Length];
        for (int i = 0; i < position.Length; i++)
            cars[i] = (position[i], speed[i]);
        
        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));
        Stack<double> fleets = new Stack<double>();

        for (int i = 0; i < cars.Length; i++)
        {
            double curT = (double)(target - cars[i].position) / cars[i].speed;
            
            if (fleets.Count == 0 || curT > fleets.Peek())
                fleets.Push(curT);
        }

        return fleets.Count;
    }
}