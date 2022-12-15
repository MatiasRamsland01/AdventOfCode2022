using System.Text.RegularExpressions;
Regex coords = new Regex(@"x=(-?\d+), y=(-?\d+)", RegexOptions.Compiled);
var lines = File.ReadAllLines("input.txt");
var Y = 10;
var notValidPositions = new List<int>();
var validPositions = new List<int>();
foreach (var line in lines)
{
    var match = coords.Matches(line);
    (int sx, int sy) = (int.Parse(match[0].Groups[1].Value), int.Parse(match[0].Groups[2].Value));
    (int bx, int by) = (int.Parse(match[1].Groups[1].Value), int.Parse(match[1].Groups[2].Value));
    Console.WriteLine($"Start: {sx}, {sy} - Beacon: {bx}, {by}");
    var distance = Math.Abs(sx - bx) + Math.Abs(sy - by);
    var offset = distance - Math.Abs(sy - Y);
    //If offset is smaller it means that offset is smaller than the row difference. This means that all beacons within this row are further away
    if (offset < 0)
    {
        continue;
    }
    //Defines the range that no other beacon can be
    var dx = sx - offset;
    var dy = sy + offset;

    for (var i = dx; i <= dy; i++)
    {
        notValidPositions.Add(i);
    }
    if (by == Y)
    {
        validPositions.Add(bx);
    }
}
Console.WriteLine(notValidPositions.Except(validPositions).Count());
/* foreach (var validPosition in validPositions)
{
    Console.WriteLine(validPosition);
} */
/* foreach (var notValidPosition in notValidPositions)
{
    Console.WriteLine(notValidPosition);
} */