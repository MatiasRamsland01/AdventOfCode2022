// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("input.txt");
List<List<string>> playground = new List<List<string>>();
(int x, int y) headPosition = (x: 0, y: 0);
(int x, int y) tailPosition = (x: 0, y: 0);
var position = new Dictionary<(int, int), int>();
position.Add((0, 0), 1);


var timesMoved = 1;
foreach (var line in lines)
{
    var parts = line.Split(" ");
    if (parts[0] == "R")
    {

        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {
            Console.WriteLine($"Before, headPosition: {headPosition}, tailPosition: {tailPosition}");
            if (Adjacent(headPosition, tailPosition) == true && Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false)
            {
                Console.WriteLine("Adjacent");
                headPosition.y++;
                if (Overlapping(headPosition, tailPosition) == true || Beside(headPosition, tailPosition) == true)
                {
                    continue;
                }
                tailPosition = headPosition;
                tailPosition.y--;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }
                continue;
            }
            headPosition.y++;

            if (Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false)
            {
                Console.WriteLine("Not Adjacent");
                tailPosition.y++;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

            }
        }

    }
    else if (parts[0] == "U")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {

            if (Adjacent(headPosition, tailPosition) == true && Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false)
            {
                headPosition.x--;
                tailPosition = headPosition;
                tailPosition.x++;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

                continue;
            }
            headPosition.x--;

            if (Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false && Adjacent(headPosition, tailPosition) == false)
            {
                tailPosition.x--;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

            }

        }
    }
    else if (parts[0] == "L")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {

            if (Adjacent(headPosition, tailPosition) == true && Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false)
            {
                headPosition.y--;

                tailPosition = headPosition;
                tailPosition.y++;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

                continue;
            }
            headPosition.y--;

            if (Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false && Adjacent(headPosition, tailPosition) == false)
            {

                tailPosition.y--;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

            }

        }
    }
    else if (parts[0] == "D")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {

            if (Adjacent(headPosition, tailPosition) == true && Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false)
            {
                headPosition.x++;

                tailPosition = headPosition;
                tailPosition.x--;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

                continue;
            }
            headPosition.x++;

            if (Overlapping(headPosition, tailPosition) == false && Beside(headPosition, tailPosition) == false && Adjacent(headPosition, tailPosition) == false)
            {

                tailPosition.x++;
                if (position.ContainsKey((tailPosition.x, tailPosition.y)))
                {
                    position[(tailPosition.x, tailPosition.y)]++;
                }
                else
                {
                    timesMoved++;
                    position.Add((tailPosition.x, tailPosition.y), 1);
                }

            }

        }

    }

}
Console.WriteLine(timesMoved);


static bool Overlapping((int x, int y) headposition, (int x, int y) tailposition)
{
    if (headposition == tailposition)
    {
        return true;
    }
    return false;

}

static bool Beside((int x, int y) headposition, (int x, int y) tailposition)
{
    //Checks if head is under tail
    if (headposition == (tailposition.x + 1, tailposition.y))
    {
        return true;
    }
    //Checks if head is above tail
    if (headposition == (tailposition.x - 1, tailposition.y))
    {
        return true;
    }
    //Checks if head is to the right of tail
    if (headposition == (tailposition.x, tailposition.y + 1))
    {
        return true;
    }
    //Checks if head is to the left of tail
    if (headposition == (tailposition.x, tailposition.y - 1))
    {
        return true;
    }
    return false;

}

static bool Adjacent((int x, int y) headposition, (int x, int y) tailposition)
{
    //Checks if head is top right of tail
    if (headposition == (tailposition.x - 1, tailposition.y + 1))
    {
        return true;
    }
    //Checks if head is top left of tail
    if (headposition == (tailposition.x - 1, tailposition.y - 1))
    {
        return true;
    }
    //Checks if head is bottom right of tail
    if (headposition == (tailposition.x + 1, tailposition.y + 1))
    {
        return true;
    }
    //Checks if head is bottom left of tail
    if (headposition == (tailposition.x + 1, tailposition.y - 1))
    {
        return true;
    }
    return false;

}

