using System.Text.RegularExpressions;
Regex coords = new Regex(@"x=(-?\d+), y=(-?\d+)", RegexOptions.Compiled);
var lines = File.ReadAllLines("input.txt");
var Y = 2000000;
var notValidPositions = new List<int>();
var validPositions = new List<int>();
foreach (var line in lines)
{
    var match = coords.Matches(line);
    (int signalX, int signalY) = (int.Parse(match[0].Groups[1].Value), int.Parse(match[0].Groups[2].Value));
    (int beaconX, int beaconY) = (int.Parse(match[1].Groups[1].Value), int.Parse(match[1].Groups[2].Value));
    var d = Math.Abs(signalX - beaconX) + Math.Abs(signalY - beaconY);
    var offset = d - Math.Abs(signalY - Y);
    if (offset < 0)
    {
        continue;
    }
    var lx = signalX - offset;
    var hx = signalX + offset;
    for (int x = lx; x <= hx; x++)
    {
        notValidPositions.Add(x);
    }
    if (beaconY == Y)
    {
        validPositions.Add(beaconX);
    }
}
var setdiff = notValidPositions.Except(validPositions);
Console.WriteLine(setdiff.Count());
/* foreach (var validPosition in validPositions)
{
    Console.WriteLine(validPosition);
} */
/* foreach (var notValidPosition in notValidPositions)
{
    Console.WriteLine(notValidPosition);
} */