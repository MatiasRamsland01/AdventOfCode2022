var lines = File.ReadAllLines("input.txt").Skip(1).ToArray();
List<(int, HashSet<(int, int)>)> blizzards = new List<(int, HashSet<(int, int)>)>(); //Where the symbol is the key and the value is a set of coordinates
char[] blizzzardSymbols = { '<', '>', '^', 'v' };
var r = 0; //Row
var c = 0; //Column
for (int i = 0; i < blizzzardSymbols.Length; i++)
{
    blizzards.Add((i, new HashSet<(int, int)>()));
}
for (r = 0; r < lines.Length; r++)
{
    var split = lines[r].Skip(1).ToArray();
    for (c = 0; c < split.Length; c++)
    {
        char item = split[c];
        Console.WriteLine($"{item}");
        if (blizzzardSymbols.Contains(item))
        {
            blizzards[blizzzardSymbols.ToList().IndexOf(item)].Item2.Add((r, c));
        }
    }
}
var target = (r, c - 1); //Target node will always be the same
var lcm = Math.Floor(r * c / (decimal)GCD(r, c)); //Least common multiple of r and c. Used to avoid computing the same node multiple times. So it goes into a loop
//Using BFS to find the shortest path
var queue = new Queue<(int, int, int)>();
queue.Enqueue((0, -1, 0)); //time, row, column
var seen = new HashSet<(int, int, decimal)>(); //Set to track visited locations. So we can skip analyzing them again
Console.WriteLine($"Target: {target}");
while (queue.Count() >= 1)
{
    var (time, cr, cc) = queue.Dequeue(); //current time, current row, current column
    time++;

    foreach ((int dr, int dc) in new (int, int)[] { (0, 1), (0, -1), (-1, 0), (1, 0), (0, 0) }) // Possible directions
    {
        var nr = cr + dr; //Next row
        var nc = cc + dc; //Next column
        Console.WriteLine($"Checking: {nr}, {nc}");
        if ((nr, nc) == target) //We found the target
        {
            Console.WriteLine($"Found target at {time}");
            return;
        }
        if ((nr < 0 || nr >= r || nc < 0 || nc >= c) && (nr, nc) != (-1, 0)) //Out of bounds/map
        {
            continue;
        }
        var next = true; //Variable to check if we should add the node to the queue

        foreach ((int i, int tr, int tc) in new (int, int, int)[] { (0, 0, -1), (1, 0, 1), (2, -1, 0), (3, 1, 0) }) //Possible blizzard locations. So we can check if the node isa valid position
        {

            if (blizzards[i].Item2.Contains(((nr - tr * time) % r, (nc - tc * time) % c))) //Node will be in a blizzard
            {
                next = false;
                break;
            }
        }

        if (next)
        {
            var key = (nr, nc, time % lcm);
            if (seen.Contains(key)) //Node has already been visited
            {
                continue;
            }
            seen.Add(key);
            queue.Enqueue((time, nr, nc));
            Console.WriteLine($"Added: {nr}, {nc}");
        }
    }


}
//Printing blizzards
/* foreach (var blizzard in blizzards)
{
    foreach (var item in blizzard.Item2)
    {
        Console.Write($"({item.Item1}, {item.Item2}) ");
    }
    Console.WriteLine();
} */
static int GCD(int num1, int num2)
{
    int Remainder;

    while (num2 != 0)
    {
        Remainder = num1 % num2;
        num1 = num2;
        num2 = Remainder;
    }

    return num1;
}