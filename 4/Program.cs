using System.Linq;
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var overlappingPairs = 0;
var partiallyOverlappingPairs = 0;
foreach (string line in lines)
{
    var firstSection = line.Split(',')[0].Split('-');
    var secondSection = line.Split(',')[1].Split('-');
    var rangeFirstSection = Enumerable.Range(int.Parse(firstSection[0]), int.Parse(firstSection[1]) - int.Parse(firstSection[0]) + 1);
    var rangeSecondSection = Enumerable.Range(int.Parse(secondSection[0]), int.Parse(secondSection[1]) - int.Parse(secondSection[0]) + 1);
    if (rangeFirstSection.Intersect(rangeSecondSection).Skip(rangeSecondSection.Count() - 1).Any() || rangeSecondSection.Intersect(rangeFirstSection).Skip(rangeFirstSection.Count() - 1).Any())
    {
        Console.WriteLine(firstSection[0] + "-" + firstSection[1] + "," + secondSection[0] + "-" + secondSection[1]);
        overlappingPairs++;
    }
    if (rangeFirstSection.Intersect(rangeSecondSection).Any())
    {
        partiallyOverlappingPairs++;
    }
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine(overlappingPairs);
Console.WriteLine(partiallyOverlappingPairs);