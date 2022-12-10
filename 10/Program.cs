string[] lines = System.IO.File.ReadAllLines("input.txt");
var x = 1;
var cycle = 0;
var signalIntervals = new List<int> { 220, 180, 140, 100, 60, 20 };
var signalStrength = new List<int>();
foreach (var line in lines)
{
    cycle++;
    signalIntervals.ToList().ForEach((interval) =>
    {
        if (cycle % interval == 0)
        {
            signalStrength.Add(x * cycle);
            signalIntervals.Remove(interval);
        }
    });
    var splittetLine = line.Split(' ');
    var command = splittetLine[0];
    if (command == "noop") { continue; }
    for (var i = 0; i < 2; i++)
    {
        if (i == 0) { continue; }
        cycle++;
        signalIntervals.ToList().ForEach((interval) =>
        {
            if (cycle % interval == 0)
            {
                signalStrength.Add(x * cycle);
                signalIntervals.Remove(interval);
            }
        });
        x += Int32.Parse(splittetLine[1]);

    }
}
Console.WriteLine($"Sum: {signalStrength.Sum()}");
/* 
// ----- Part 2 -----
string[] lines = System.IO.File.ReadAllLines("input.txt");
var signalIntervals = new List<int> { 220, 180, 140, 100, 60, 20 };
var sprite = new List<List<string>>();
for (var i = 0; i < signalIntervals.Count(); i++)
{
    sprite.Add(new List<string>());
}
var x = 1;
var cycle = 0;
var pointer = 0;
foreach (var line in lines)
{
    if (cycle % 40 == 0 && cycle != 0) //Move to next line
    {
        pointer++;
        cycle = 0;

    }

    // Check if pixel is visible
    if (PixelVisible(cycle, x))
        sprite[pointer].Add("#");
    else
    {
        sprite[pointer].Add(".");
    }

    cycle++;
    var splittetLine = line.Split(' ');
    var command = splittetLine[0];
    if (command == "noop") { continue; }
    for (var i = 0; i < 2; i++)
    {
        if (i == 0) { continue; }

        if (cycle % 40 == 0) //Move to next line
        {
            pointer++;
            cycle = 0;

        }
        if (PixelVisible(cycle, x))
            sprite[pointer].Add("#");
        else
        {
            sprite[pointer].Add(".");
        }
        cycle++;
        x += Int32.Parse(splittetLine[1]);


    }
}
foreach (var line in sprite)
{
    foreach (var character in line)
    {
        Console.Write(character);
    }
    Console.WriteLine();
}

static bool PixelVisible(int crt, int sprite)
{
    if (crt == sprite || crt == sprite - 1 || crt == sprite + 1)
        return true;
    else
        return false;
}
 */