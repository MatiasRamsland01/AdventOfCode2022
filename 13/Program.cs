using System.Text.Json.Nodes;
//Found out from reddit that in order to parse the data we could use JSON nodes
var lines = File.ReadAllText("input.txt");
var result = GetPackets(lines)
            .Chunk(2)
            .Select((pair, index) => Compare(pair[0], pair[1]) < 0 ? index + 1 : 0)
            .Sum();

var divider = GetPackets("[[2]]\n[[6]]").ToList();
var packets = GetPackets(lines).Concat(divider).ToList();
packets.Sort(Compare);
var result2 = (packets.IndexOf(divider[0]) + 1) * (packets.IndexOf(divider[1]) + 1);
Console.WriteLine(result2);

IEnumerable<JsonNode> GetPackets(string input) =>
        from line in input.Split("\n")
        where !string.IsNullOrEmpty(line)
        select JsonNode.Parse(line);

int Compare(JsonNode nodeA, JsonNode nodeB)
{
    if (nodeA is JsonValue && nodeB is JsonValue)
    {
        return (int)nodeA - (int)nodeB;
    }
    else
    {
        var list1 = nodeA as JsonArray ?? new JsonArray((int)nodeA);
        var list2 = nodeB as JsonArray ?? new JsonArray((int)nodeB);
        return Enumerable.Zip(list1, list2)
            .Select(p => Compare(p.First, p.Second))
            .FirstOrDefault(c => c != 0, list1.Count - list2.Count);
    }
}