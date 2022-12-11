﻿string[] lines = System.IO.File.ReadAllLines("input.txt");
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
            headPosition.y++;
            if (NeedToMove(headPosition, tailPosition))
            {
                tailPosition = headPosition;
                tailPosition.y--;
                if (position.ContainsKey(tailPosition))
                {

                    position[tailPosition]++;
                }
                else
                {
                    timesMoved++;
                    position.Add(tailPosition, 1);
                }
            }
        }

    }
    else if (parts[0] == "U")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {
            headPosition.x--;
            if (NeedToMove(headPosition, tailPosition))
            {
                tailPosition = headPosition;
                tailPosition.x++;
                if (position.ContainsKey(tailPosition))
                {

                    position[tailPosition]++;
                }
                else
                {
                    timesMoved++;
                    position.Add(tailPosition, 1);
                }
            }
        }

    }
    else if (parts[0] == "L")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {
            headPosition.y--;
            if (NeedToMove(headPosition, tailPosition))
            {
                tailPosition = headPosition;
                tailPosition.y++;
                if (position.ContainsKey(tailPosition))
                {

                    position[tailPosition]++;
                }
                else
                {
                    timesMoved++;
                    position.Add(tailPosition, 1);
                }
            }
        }


    }
    else if (parts[0] == "D")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {
            headPosition.x++;
            if (NeedToMove(headPosition, tailPosition))
            {
                tailPosition = headPosition;
                tailPosition.x--;
                if (position.ContainsKey(tailPosition))
                {

                    position[tailPosition]++;
                }
                else
                {
                    timesMoved++;
                    position.Add(tailPosition, 1);
                }
            }
        }


    }

}
Console.WriteLine(timesMoved);

static bool NeedToMove((int x, int y) headposition, (int x, int y) tailposition)
{
    if (Overlapping(headposition, tailposition))
    {
        return false;
    }
    if (Beside(headposition, tailposition))
    {
        return false;
    }
    if (Adjacent(headposition, tailposition))
    {
        return false;
    }
    return true;
}

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
//----- Part 2 -----//
/* string[] lines = System.IO.File.ReadAllLines("input.txt");
List<List<string>> playground = new List<List<string>>();
var previous = new List<int>();
(int x, int y)[] items = new (int x, int y)[10];
for (var i = 0; i < 10; i++)
{
    items[i] = ((x: 0, y: 0));
    previous.Add(0);
}
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
            items[0].y++;
            for (var j = 0; j < items.Count(); j++)
            {
                if (j == 9) { continue; }
                if (NeedToMove(items[j], items[j + 1]))
                {
                    Console.WriteLine();
                    items[j + 1] = items[j];
                    items[j + 1].y--;
                }
            }
        }
    }
    else if (parts[0] == "U")
    {
        for (var i = 0; i < Int32.Parse(parts[1]); i++)
        {
            items[0].x--;
            for (var j = 0; j < 1; j++)
            {
                if (j == 9) { continue; }
                if (NeedToMove(items[j], items[j + 1]))
                {
                    items[j + 1] = items[j];
                    items[j + 1].x++;
                }
            }
        }
    }
}
foreach (var item in items)
{
    Console.WriteLine(item);
}
Console.WriteLine(timesMoved); */
/* if (j == 8)
                   {
                       if (position.ContainsKey(items[j + 1]))
                       {

                           position[items[j + 1]]++;
                       }
                       else
                       {
                           timesMoved++;
                           position.Add(items[j + 1], 1);
                       }
                   } */