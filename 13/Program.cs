var lines = File.ReadAllLines("input.txt");
var packets = new List<List<int>>();

for (int i = 0; i < lines.Length; i++)
{
    var splittetLine = lines[i].Substring(1, lines[i].Length - 2).ToString();
    packets.Add(new List<int>());
    foreach (var part in splittetLine.Split(','))
    {
        packets[i].Add(int.Parse(part));
    }


}
foreach (var item in packets)
{
    foreach (var item2 in item)
    {
        Console.Write(item2 + " ");
    }
    Console.WriteLine();
}