string[] lines = System.IO.File.ReadAllLines(@"Calories.txt");
var max = 0;
var listOfValues = new List<int>();
var currentValue = 0;
foreach (string line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        if (currentValue > max)
        {
            max = currentValue;
        }
        listOfValues.Add(currentValue);
        currentValue = 0;
    }
    else { currentValue += Int32.Parse(line); }
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine($"The elf with maximum calories have: {max} kcal");
Console.WriteLine($"The 3 elf with the highest calories have in total: {listOfValues.OrderByDescending(d => d).Take(3).Sum()} kcal");
