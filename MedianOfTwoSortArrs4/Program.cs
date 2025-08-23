using System;

public class Solution
{
    public static void Main()
    {
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = { 4, 5, 6 };
        Console.WriteLine(FindMedianSortedArrays(arr1, arr2));
    }
    
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = total / 2;

        // We want to always run the binary search on a smaller array
        if (B.Length > A.Length)
        {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int l = 0;
        int r = B.Length - 1;

        while (true)
        {
            int m = (l + r) / 2;
            int n = half - m - 2; // We subtract -2 bcz the arrays are zero-based adn to take not the index but the length we sub 2
            
            int Aleft = (n >= 0) ? A[n] : int.MinValue;
            int Aright = (n + 1 < A.Length) ? A[n + 1] : int.MaxValue;
            int Bleft = (m >= 0) ? B[m] : int.MinValue;
            int Bright = (m + 1 < B.Length) ? B[m + 1] : int.MaxValue;

            if (Aright >= Bleft && Bright >= Aleft)
            {
                if (total % 2 == 0)
                    return (double)(Math.Max(Bleft, Aleft) + Math.Min(Bright, Aright)) / 2;
                else return (double)Math.Min(Aright, Bright);
            }
            else if (Aleft > Bright)
                l = m + 1;
            else r = m - 1;
        }
    }
}