string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var possibilities = new Dictionary<string, int>() // Score mapping dictionary
{
    {"AX", 4},
    {"BY", 5},
    {"CZ", 6},
    {"AY", 8},
    {"AZ", 3},
    {"BZ", 9},
    {"BX", 1},
    {"CX", 7},
    {"CY", 2},
};
var mappingDict = new Dictionary<string, string>() //Dictionary to map different outcomes given a condition of rock, paper, scissor
{
    {"AX", "AZ"},
    {"BY", "BY"},
    {"CZ", "CX"},
    {"AY", "AX"},
    {"AZ", "AY"},
    {"BZ", "BZ"},
    {"BX", "BX"},
    {"CX", "CY"},
    {"CY", "CZ"},
};
var score = 0;
var scoreCondition = 0;
foreach (string line in lines)
{
    score += possibilities[line.Replace(" ", string.Empty)];
    scoreCondition += possibilities[mappingDict[line.Replace(" ", string.Empty)]];
}
Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine($"Score of following the plan of direct choosing rock, paper or scissor: {score}");
Console.WriteLine($"Score of following the plan of either winning, loosing or drawing: {scoreCondition}");