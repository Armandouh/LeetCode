using System;

class Program
{
    static void Main()
    {
        int[][] matrix = new int[][] {
            new int[] {1, 3, 4},
            new int[] {5, 6, 9},
            new int[] {10, 12, 15}
        };
        Console.WriteLine(SearchMatrix(matrix, 54));
        
    }

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int top = 0;
        int bottom = matrix.Length - 1;
        int row = (top + bottom) / 2;
        
        while (top <= bottom)
        {
            row = (top + bottom) / 2;
            int min = 0;
            int max = matrix[0].Length - 1;

            if (matrix[row][min] > target)
                bottom = row - 1;
            else if (matrix[row][max] < target)
                top = row + 1;
            else
                break;
        }

        int low = 0;
        int high = matrix[row].Length - 1;

        while (low <= high)
        {
            int middle = (high + low) / 2;
            if (matrix[row][middle] == target)
                return true;
            else if (matrix[row][middle] < target)
                low = middle + 1;
            else
                high = middle - 1;
        }

        return false;
    }
}