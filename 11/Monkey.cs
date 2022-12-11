public class Monkey
{
    public Monkey(int name, List<int> items, string operation, int operationNumber, int divisible, (int, int) possibleMonkeyToThrowTo)
    {
        Name = name;
        Items = new Queue<double>();
        foreach (var item in items)
        {
            Items.Enqueue(item);
        }
        Operation = operation;
        OperationNumber = operationNumber;
        Divisible = divisible;
        PossibleMonkeyToThrowTo = possibleMonkeyToThrowTo;
    }
    public int Name { get; set; }
    public Queue<double> Items { get; set; }
    public string Operation { get; set; }
    public int OperationNumber { get; set; }
    public int Divisible { get; set; }
    public (int, int) PossibleMonkeyToThrowTo { get; set; }
    public int InspectCount { get; set; }
    public double CalculateWorryScore(double old)
    {
        var worryLimiter = 9699690; //LCM of the divisors
        if (Operation == "itself") { return (old * old) % worryLimiter; }
        else if (Operation == "*") { return (old * OperationNumber) % worryLimiter; }
        else if (Operation == "+") { return (old + OperationNumber) % worryLimiter; }
        else { return (old - OperationNumber) % worryLimiter; }
    }
    public int MonkeyToThrowTo(double item)
    {
        if (item % Divisible == 0) { return PossibleMonkeyToThrowTo.Item1; }
        return PossibleMonkeyToThrowTo.Item2;
    }
}