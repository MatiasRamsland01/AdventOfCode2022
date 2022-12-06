StacksCraneMover.CreateStacks(@"inputStacks.txt");
string[] lines = System.IO.File.ReadAllLines(@"inputOperations.txt");
List<List<string>> StacksCraneMover9000 = StacksCraneMover.CreateStacks(@"inputStacks.txt"); // For part 1
List<List<string>> StacksCraneMover9001 = StacksCraneMover.CreateStacks(@"inputStacks.txt"); // For part 2
foreach (var line in lines)
{
    var operation = line.Replace(" ", "").Split(new String[] { "from", "to", "move" }, StringSplitOptions.RemoveEmptyEntries);
    for (var i = Int32.Parse(operation[0].ToString()); i > 0; i--)
    {
        var from = Int32.Parse(operation[1].ToString()) - 1;
        var to = Int32.Parse(operation[2].ToString()) - 1;
        StacksCraneMover9000[to].Add(StacksCraneMover9000[from].Last());
        StacksCraneMover9000[from].RemoveAt(StacksCraneMover9000[from].Count - 1);
        StacksCraneMover9001[to].Add(StacksCraneMover9001[from][StacksCraneMover9001[from].Count() - i]);
        StacksCraneMover9001[from].RemoveAt(StacksCraneMover9001[from].Count - i);
    }
}
var resultCraneMover9000 = "";
var resultCraneMover9001 = "";
for (var i = 0; i < StacksCraneMover9000.Count(); i++)
{
    resultCraneMover9000 += StacksCraneMover9000[i].Last();
    resultCraneMover9001 += StacksCraneMover9001[i].Last();
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine($"Result using Crane mover 9000: {resultCraneMover9000}");
Console.WriteLine($"Result using Crane mover 9001: {resultCraneMover9001}");
