string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var treesVisible = 0; //Amount of trees that are visible
for (var i = 0; i < lines.Length; i++)
{
    for (var j = 0; j < lines[i].Length; j++)
    {
        // Find the edges of the map So it is automatically visible
        if (i == 0 || j == 0 || i == lines.Length - 1 || j == lines[i].Length - 1)
        {
            treesVisible++;
            continue;
        }

        var tree = Int32.Parse(lines[i][j].ToString());
        var left = Int32.Parse(lines[i][j - 1].ToString());
        var right = Int32.Parse(lines[i][j + 1].ToString());
        var top = Int32.Parse(lines[i - 1][j].ToString());
        var bottom = Int32.Parse(lines[i + 1][j].ToString());

        //Quick check if the tree is not visible. This is to avoid further computation if it is not nescessary
        if (tree <= left && tree <= right && tree <= top && tree <= bottom)
        {
            continue;
        }

        // Check if the tree is visible from the top by recursively checking the the next top element
        var visibleTop = false;
        if (tree > top)
        {
            visibleTop = true;
            var pointer = i - 1;
            while (pointer >= 0)
            {
                var element = Int32.Parse(lines[pointer][j].ToString());
                if (element >= tree)
                {
                    visibleTop = false;
                    break;
                }
                pointer--;
            }
        }

        // Check if the tree is visible from the bottom by recursively checking the the next bottom element
        var visibleBottom = false;
        if (tree > bottom)
        {
            visibleBottom = true;
            var pointer = i + 1;
            while (pointer < lines.Length)
            {
                var element = Int32.Parse(lines[pointer][j].ToString());
                if (element >= tree)
                {
                    visibleBottom = false;
                    break;
                }
                pointer++;
            }
        }

        // Check if the tree is visible from the Left by recursively checking the the next left element
        var visibleLeft = false;
        if (tree > left)
        {
            visibleLeft = true;
            var pointer = j - 1;
            while (pointer >= 0)
            {
                var element = Int32.Parse(lines[i][pointer].ToString());
                if (element >= tree)
                {
                    visibleLeft = false;
                    break;
                }
                pointer--;
            }
        }

        // Check if the tree is visible from the right by recursively checking the the next right element
        bool visibleRight = false;
        if (tree > right)
        {
            visibleRight = true;
            var pointer = j + 1;
            while (pointer < lines[i].Length)
            {
                var element = Int32.Parse(lines[i][pointer].ToString());
                if (element >= tree)
                {
                    visibleRight = false;
                    break;
                }
                pointer++;
            }
        }

        // If any of the sides are visible, then the tree is visible
        if (visibleTop || visibleBottom || visibleLeft || visibleRight)
        {
            treesVisible++;
        }
    }


}
Console.WriteLine(treesVisible);
/* 
//-----Part 2-----//
string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var treesScore = new List<int>();
for (var i = 0; i < lines.Length; i++)
{
    for (var j = 0; j < lines[i].Length; j++)
    {
        // Find the edges of the map
        var tree = Int32.Parse(lines[i][j].ToString());

        //Init the values and check if an exception is thrown, and finds out where it is an edge
        int left;int right;int top;int bottom;
        try{left = Int32.Parse(lines[i][j - 1].ToString());}catch{left = -1;}
        try{right = Int32.Parse(lines[i][j + 1].ToString());}catch{right = -1;}
        try{top = Int32.Parse(lines[i - 1][j].ToString());}catch{top = -1;}
        try{bottom = Int32.Parse(lines[i + 1][j].ToString());}catch{bottom = -1;}

        //Quick check if the tree is not visible. This is to avoid further computation if it is not nescessary
        if (tree <= left && tree <= right && tree <= top && tree <= bottom)
        {
            treesScore.Add(1);
            continue;
        }

        // Check if the tree is visible from the top and find the amount of trees visible
        var visibleTop = 1;
        if (tree > top && top != -1)
        {
            var pointer = i - 1;
            while (pointer > 0)
            {
                var element = Int32.Parse(lines[pointer][j].ToString());
                if (element >= tree)
                {
                    break;
                }
                visibleTop += 1;
                pointer--;
            }
        }

        // Check if the tree is visible from the bottom and find the amount of trees visible
        var visibleBottom = 1;
        if (tree > bottom && bottom != -1)
        {
            var pointer = i + 1;
            while (pointer < lines.Length - 1)
            {
                var element = Int32.Parse(lines[pointer][j].ToString());

                if (element >= tree)
                {
                    break;
                }
                visibleBottom += 1;
                pointer++;
            }
        }

        // Check if the tree is visible from the Left and find the amount of trees visible
        var visibleLeft = 1;
        if (tree > left && left != -1)
        {
            var pointer = j - 1;
            while (pointer > 0)
            {
                var element = Int32.Parse(lines[i][pointer].ToString());
                if (element >= tree)
                {
                    break;
                }
                visibleLeft += 1;
                pointer--;
            }
        }

        // Check if the tree is visible from the right and find the amount of trees visible
        var visibleRight = 1;
        if (tree > right && right != -1)
        {
            var pointer = j + 1;
            while (pointer < lines[i].Length - 1)
            {
                var element = Int32.Parse(lines[i][pointer].ToString());
                if (element >= tree)
                {
                    break;
                }
                visibleRight += 1;
                pointer++;
            }
        }
        //Add the score to the list
        treesScore.Add(visibleTop * visibleBottom * visibleLeft * visibleRight);
    }
}
Console.WriteLine($"Max score: {treesScore.Max()}");
 */



