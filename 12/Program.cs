var lines = File.ReadAllLines("input.txt");
var grid = new List<List<string>>();
var sr = 0; //Start row
var sc = 0; //Start column
var er = 0; //End row
var ec = 0; //End column
for (var i = 0; i < lines.Length; i++)
{
    var parts = lines[i].ToCharArray();
    grid.Add(new List<string>());
    for (var j = 0; j < parts.Length; j++)
    {
        if (parts[j] == 'S')
        {
            sr = i;
            sc = j;
            grid[i].Add("a"); // Start node has a value of a. Lowest point
            continue;
        }
        if (parts[j] == 'E')
        {
            er = i;
            ec = j;
            grid[i].Add("z"); // End node has a value of z. Highest point
            continue;

        }
        grid[i].Add(parts[j].ToString());
    }
}
var queue = new Queue<(int value, int x, int y)>();
queue.Enqueue((0, sr, sc));
var visited = new List<(int x, int y)>() { (sr, sc) };
var found = false;
//Breath First Search
while (queue.Count() > 0 && !found)
{
    Console.WriteLine("Queue: {0}", queue.Count());
    var (pathValue, r, c) = queue.Dequeue();
    //We need to check the 4 neighbors
    var neighbors = new List<(int x, int y)>() { (r - 1, c), (r + 1, c), (r, c - 1), (r, c + 1) };
    foreach (var (nr, nc) in neighbors)
    {
        //Out of bounds
        if (nr < 0 || nr >= grid.Count() || nc < 0 || nc >= grid[0].Count())
            continue;
        //Already visited node
        if (visited.Contains((nr, nc)))
            continue;
        //Check if neighbor node is invalid
        if ((System.Text.Encoding.ASCII.GetBytes(grid[nr][nc])[0] - System.Text.Encoding.ASCII.GetBytes(grid[r][c])[0]) > 1)
            continue;
        //We have found our node
        if (nr == er && nc == ec)
        {
            Console.WriteLine(pathValue + 1);
            found = true;
            break;
        }
        visited.Add((nr, nc));
        //Add to queue
        queue.Enqueue((pathValue + 1, nr, nc));

    }
}


//---Part 2---//
//For part two we can just reverse it. Start at E and find the nearest a

/* var lines = File.ReadAllLines("input.txt");
var grid = new List<List<string>>();
var er = 0; //End row
var ec = 0; //End column
for (var i = 0; i < lines.Length; i++)
{
    var parts = lines[i].ToCharArray();
    grid.Add(new List<string>());
    for (var j = 0; j < parts.Length; j++)
    {
        if (parts[j] == 'S')
        {
            grid[i].Add("a");
            continue;
        }
        if (parts[j] == 'E')
        {
            er = i;
            ec = j;
            grid[i].Add("z");
            continue;

        }
        grid[i].Add(parts[j].ToString());
    }
}

var queue = new Queue<(int value, int x, int y)>();
queue.Enqueue((0, er, ec));
var visited = new List<(int x, int y)>() { (er, ec) };
var found = false;
//Breath First Search
while (queue.Count() > 0 && !found)
{
    var (pathValue, r, c) = queue.Dequeue();
    //We need to check the 4 neighbors
    var neighbors = new List<(int x, int y)>() { (r - 1, c), (r + 1, c), (r, c - 1), (r, c + 1) };
    foreach (var (nr, nc) in neighbors)
    {
        //Out of bounds
        if (nr < 0 || nr >= grid.Count() || nc < 0 || nc >= grid[0].Count())
            continue;
        //Already visited node
        if (visited.Contains((nr, nc)))
            continue;
        //Check if neighbor node is invalid
        if ((System.Text.Encoding.ASCII.GetBytes(grid[nr][nc])[0] - System.Text.Encoding.ASCII.GetBytes(grid[r][c])[0]) < -1)
            continue;
        //We have found our node
        if (grid[nr][nc] == "a")
        {
            Console.WriteLine(pathValue + 1);
            found = true;
            break;
        }
        visited.Add((nr, nc));
        //Add to queue
        queue.Enqueue((pathValue + 1, nr, nc));

    }
} */