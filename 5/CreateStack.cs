public static class StacksCraneMover
{
    public static List<List<string>> CreateStacks(string url)
    {
        string[] lines = System.IO.File.ReadAllLines(@url);
        var mappingDict = new Dictionary<int, int>();
        List<List<string>> stacks = new List<List<string>>();
        for (var j = 0; j < lines[lines.Length - 1].Length; j++)
        {
            try
            {
                mappingDict.Add(j, Int32.Parse(lines[lines.Length - 1].Substring(j, 1)) - 1);
                stacks.Add(new List<string>());
            }
            catch { }
        }
        for (var i = lines.Length - 2; i > -1; i--)
        {
            foreach (var item in mappingDict)
            {
                if (lines[i][item.Key] != ' ')
                    stacks[item.Value].Add(lines[i][item.Key].ToString());
            }
        }
        return stacks;

    }


}