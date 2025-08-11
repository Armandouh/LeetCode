using System;

class Program
{
    static void Main()
    {
    }

    static bool validSudoku(char[][] board)
    {
        Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
        Dictionary<(int, int), HashSet<char>> boxes = new Dictionary<(int, int), HashSet<char>>();

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char num = board[r][c];

                if (num == '.')
                    continue;

                if (!rows.ContainsKey(r)) rows[r] = new HashSet<char>();
                if (!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                if (!boxes.ContainsKey((r / 3, c / 3))) boxes[(r / 3, c / 3)] = new HashSet<char>();

                if (rows[r].Contains(num) ||
                    cols[c].Contains(num) ||
                    boxes[(r / 3, c / 3)].Contains(num))
                    return false;

                rows[r].Add(num);
                cols[c].Add(num);
                boxes[(r / 3, c / 3)].Add(num);
            }
        }

        return true;
    }
}