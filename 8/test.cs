/* string[] lines = System.IO.File.ReadAllLines(@"input.txt");
var treesVisible = lines[0].Length * 2;
for (var i = 1; i < lines.Length - 1; i++)
{
    for (var j = 1; j < lines.Length - 1; j++)
    {
        var visible = true;
        var tree = Int32.Parse(lines[i][j].ToString());
        var left = Int32.Parse(lines[i][j - 1].ToString());
        var right = Int32.Parse(lines[i][j + 1].ToString());
        var top = Int32.Parse(lines[i - 1][j].ToString());
        var bottom = Int32.Parse(lines[i + 1][j].ToString());
        var recursivePointerVertical = i - 1;
        var recursivePointerHorizontal = j - 1;
        while (recursivePointerVertical > 0 && visible == true)
        {
            var element = Int32.Parse(lines[recursivePointerVertical][j].ToString());
            if (element >= tree)
            {
                visible = false;
            }
            recursivePointerVertical--;
        }
        while (recursivePointerVertical < lines.Length && visible == true)
        {
            var element = Int32.Parse(lines[recursivePointerVertical][j].ToString());
            if (element >= tree)
            {
                visible = false;
            }
            recursivePointerVertical++;
        }
        while (recursivePointerHorizontal < lines.Length && visible == true)
        {
            var element = Int32.Parse(lines[i][recursivePointerHorizontal].ToString());
            if (element >= tree)
            {
                visible = false;
            }
            recursivePointerVertical++;
        }
        while (recursivePointerVertical > 0 && visible == true)
        {
            var element = Int32.Parse(lines[i][recursivePointerHorizontal].ToString());
            if (element >= tree)
            {
                visible = false;
            }
            recursivePointerVertical--;
        }
        if (visible)
        {
            treesVisible++;
        }
    }
    treesVisible += 2;

}
Console.WriteLine(treesVisible); */