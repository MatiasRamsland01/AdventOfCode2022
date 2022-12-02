string[] lines = System.IO.File.ReadAllLines(@"Calories.txt");
var caloriesCarried = new List<int>();
var currentValue = 0;
foreach (string line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        caloriesCarried.Add(currentValue);
        currentValue = 0;
    }
    else { currentValue += Int32.Parse(line); }
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine($"The elf with maximum calories have: {caloriesCarried.Max()} kcal");
Console.WriteLine($"The 3 elf with the highest calories have in total: {caloriesCarried.OrderByDescending(d => d).Take(3).Sum()} kcal");
