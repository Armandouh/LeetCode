using System;

public class Solution
{
    public static void Main()
    {
        int[] arr1 = { 1, 2, 3, 4, 5, 6};
        int[] arr2 = { 1, 2 };
        Console.WriteLine(FindMedianSortedArrays(arr1, arr2));
    }
    
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = total / 2;

        // We want to always run the binary search on a smaller array
        if (A.Length > B.Length)
        {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int l = 0;
        int r = A.Length;

        while (l <= r)
        {
            int m = (l + r) / 2; // A
            int n = half - m; // B

            int Aleft  = (m > 0) ? A[m - 1] : int.MinValue;
            int Aright = (m < A.Length) ? A[m] : int.MaxValue;
            int Bleft  = (n > 0) ? B[n - 1] : int.MinValue;
            int Bright = (n < B.Length) ? B[n] : int.MaxValue;


            if (Bright >= Aleft && Aright >= Bleft)
            {
                // Even length
                if (total % 2 == 0)
                {
                    return (Math.Max(Aleft, Bleft) + Math.Min(Aright, Bright)) / 2.0;
                }

                // Odd length
                else
                    return (double)Math.Min(Aright, Bright);
            }
            else if (Aleft > Bright)
                r = m - 1;
            else
                l = m + 1;
        }
        throw new InvalidOperationException("Input arrays not sorted properly.");
    }
}