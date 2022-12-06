string lines = System.IO.File.ReadAllText(@"input.txt");
Queue<string> set = new Queue<string>(); //Using a FIFO queue since we just want to add and remove from the front of the queue.
var distinctCharacters = 14; //It is 4 in part 1 and 14 in part 2
var charactersProcessed = 0;
for (int i = 0; i < lines.Length; i++)
{
    set.Enqueue(lines.Substring(i, 1).ToString());
    if (set.Count() >= distinctCharacters)
    {
        var result = set.Distinct().Count() == set.Count(); //Check if all characters are distinct
        if (result)
        {
            charactersProcessed += i + 1;
            break;
        }
        set.Dequeue();
    }
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine($"Characters processed to find start-of-packet marker: {charactersProcessed}");

