var lines = File.ReadAllLines("input.txt");
List<Monkey> monkeys = new List<Monkey>();
monkeys.Add(new Monkey(0, new List<int>() { 80 }, "*", 5, 2, (4, 3)));
monkeys.Add(new Monkey(1, new List<int>() { 75, 83, 74 }, "+", 7, 7, (5, 6)));
monkeys.Add(new Monkey(2, new List<int>() { 86, 67, 61, 96, 52, 63, 73 }, "+", 5, 3, (7, 0)));
monkeys.Add(new Monkey(3, new List<int>() { 85, 83, 55, 85, 57, 70, 85, 52 }, "+", 8, 17, (1, 5)));
monkeys.Add(new Monkey(4, new List<int>() { 67, 75, 91, 72, 89 }, "+", 4, 11, (3, 1)));
monkeys.Add(new Monkey(5, new List<int>() { 66, 64, 68, 92, 68, 77 }, "*", 2, 19, (6, 2)));
monkeys.Add(new Monkey(6, new List<int>() { 97, 94, 79, 88 }, "itself", 0, 5, (2, 7)));
monkeys.Add(new Monkey(6, new List<int>() { 77, 85 }, "+", 6, 13, (4, 0)));
var rounds = 20;
var monkeyPlaying = 0;

for (var i = 0; i < rounds; i++)
{
    for (var k = 0; k < monkeys.Count(); k++)
    {
        var itemsAtStart = monkeys[monkeyPlaying].Items.Count();
        for (var j = 0; j < itemsAtStart; j++)
        {
            monkeys[monkeyPlaying].InspectCount++;
            var item = monkeys[monkeyPlaying].Items.Dequeue();
            item = monkeys[monkeyPlaying].CalculateWorryScore(item);
            //item = Math.Floor(item / 3); //For part 1 just uncomment this line
            var monkeyToThrowTo = monkeys[monkeyPlaying].MonkeyToThrowTo(item);
            monkeys[monkeyToThrowTo].Items.Enqueue(item);
        }
        if (monkeyPlaying == monkeys.Count() - 1)
            monkeyPlaying = 0;
        else
            monkeyPlaying++;
    }
}
Console.WriteLine($"MonkeyBuisness: {(double)monkeys.OrderByDescending(x => x.InspectCount).First().InspectCount * monkeys.OrderByDescending(x => x.InspectCount).Skip(1).First().InspectCount}");


