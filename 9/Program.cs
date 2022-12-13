var visitedLocations = new HashSet<(int x, int y)>() { (0, 0) }; //Using a hashset to avoid duplicates
/* var head = (x: 0, y: 0); // Part 1
var tail = (x: 0, y: 0); // Part 1 */
var ropeSize = 10; // Part 2
var rope = new (int x, int y)[ropeSize]; // Part 2
for (var i = 0; i < ropeSize; i++) // Part 2
{
    rope[i] = (0, 0); // Part 2
}
var lines = File.ReadAllLines("input.txt");
foreach (var line in lines)
{
    var splittetLine = line.Split(" ");
    var x = splittetLine[0];
    var y = Int32.Parse(splittetLine[1]);
    for (var i = 0; i < y; i++)
    {
        var dx = x == "R" ? 1 : x == "L" ? -1 : 0;
        var dy = x == "U" ? 1 : x == "D" ? -1 : 0;
        /* head.x += dx; // Part 1
        head.y += dy; */ // Part 1
        rope[0].Item1 += dx; // Part 2
        rope[0].Item2 += dy; // Part 2
        for (var j = 0; j < ropeSize - 1; j++) // Part 2
        {
            var head = rope[j];
            var tail = rope[j + 1];

            var deltaX = head.x - tail.x;
            var deltaY = head.y - tail.y;
            if (Math.Abs(deltaX) > 1 || Math.Abs(deltaY) > 1) //Check if we need to move the tail
            {
                if (deltaX == 0) // Since there are no change i x direction we only need to move in the y direction
                {
                    int yStep = Decimal.ToInt32(Math.Floor((decimal)deltaY / 2));
                    tail.y += yStep;
                }
                else if (deltaY == 0) //  Since there are no change i y direction we only need to move in the x direction
                {
                    int xStep = Decimal.ToInt32(Math.Floor((decimal)deltaX / 2));
                    tail.x += xStep;
                }
                else //Change in both x and y direction
                {
                    tail.x += deltaX > 0 ? 1 : -1;
                    tail.y += deltaY > 0 ? 1 : -1;
                }
            }
            rope[j + 1] = tail; // Part 2
            if (j == ropeSize - 2) // Part 2
            {
                visitedLocations.Add(tail);
            }
        }
        //visitedLocations.Add(tail); // Part 1


    }
}
Console.WriteLine(visitedLocations.Count);