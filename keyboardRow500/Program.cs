using System;

class Program
{
    static void Main()
    {
        
        
    }

    static string[] findWords(string[] words)
    {
        string row1 = "qwertyuiop";
        string row2 = "asdfghjkl";
        string row3 = "zxcvbnm";

        List<string> res = new List<string>();
        foreach (var item in words)
        {
            var temp = new HashSet<char>(item.ToLower().ToCharArray());

            if (temp.IsSubsetOf(row1) ||
                temp.IsSubsetOf(row2) ||
                temp.IsSubsetOf(row3))
            {
                res.Add(item);
            }
        }
        
        return res.ToArray();
    }
}