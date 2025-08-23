using System;

public class Program
{
    public static void Main()
    {
        var dict = new Dictionary<string, List<(string val, int time)>>();
        dict["key"] = new List<(string val, int time)>(); 
        dict["key"].Add(("zbo1", 1));
        dict["key"].Add(("zbo2", 2));
        dict["key"].Add(("zbo3", 3));
        var values = dict.GetValueOrDefault("key", new List<(string val, int time)>());
        foreach (var v in values)
        {
            Console.WriteLine(v);
        }
    }
}

public class TimeMap
{
    private Dictionary<string, List<(string val, int time)>> store;

    public TimeMap()
    {
        store = new Dictionary<string, List<(string val, int time)>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        if (!store.ContainsKey(key))
            store[key] = new List<(string val, int time)>();
        store[key].Add((value, timestamp));
    }

    public string Get(string key, int timestamp)
    {
        string res = "";
        var values = store.GetValueOrDefault(key, new List<(string val, int time)>());

        int l = 0;
        int r = values.Count - 1;

        while (l <= r)
        {
            int m = (l + r) / 2;
            if (values[m].time <= timestamp)
            {
                res = values[m].val;
                l = m + 1;
            }
            else r = m - 1;
        }

        return res;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */