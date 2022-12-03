using System.Text;
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var currentPrioritySum = 0;
foreach (string line in lines)
{
    var substring1 = line.Substring(0, line.Length / 2);
    var substring2 = line.Substring(line.Length / 2, (line.Length) / 2);
    for (int i = 0; i < substring1.Length; i++)
    {
        if (substring2.Contains(substring1[i]))
        {
            var priority = Encoding.ASCII.GetBytes(substring1[i].ToString());
            if (priority[0] >= 97)
            {

                currentPrioritySum += priority[0] - 97 + 1;
            }
            else if (priority[0] < 97)
            {
                currentPrioritySum += priority[0] - 65 + 27;
            }
            break;
        }
    }
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine($"currentPrioritySum: {currentPrioritySum}");

// ----- Part two ----- //
var tempdata = new Dictionary<string, int>();
var j = 0;
var currentPrioritySumBadges = 0;
foreach (string line in lines)
{
    j++;

    var usedValues = new List<string>();
    // Check if the letter is already in the dictionary and does not already have added that value for the given item
    for (var i = 0; i < line.Length; i++)
    {
        if (tempdata.ContainsKey(line[i].ToString()) && !usedValues.Contains(line[i].ToString()))
        {
            tempdata[line[i].ToString()] += 1;
            usedValues.Add(line[i].ToString());
        }
        else if (!tempdata.ContainsKey(line[i].ToString()) && !usedValues.Contains(line[i].ToString()))
        {
            tempdata.Add(line[i].ToString(), 1);
            usedValues.Add(line[i].ToString());
        }
    }
    // For every 3th line, find the values that are in the dictionary with the highest value
    if (j % 3 == 0 && j != 0)
    {
        var sharedItem = tempdata.MaxBy(kvp => kvp.Value).Key; ;
        tempdata = new Dictionary<string, int>();

        var priority = Encoding.ASCII.GetBytes(sharedItem);
        if (priority[0] >= 97)
        {
            currentPrioritySumBadges += priority[0] - 97 + 1;
        }
        else if (priority[0] < 97)
        {
            currentPrioritySumBadges += priority[0] - 65 + 27;
        }
    }
}
Console.WriteLine(currentPrioritySumBadges);