string[] lines = File.ReadAllLines("inputmock.txt");
var directories = new List<Directory>();
var currentDirectory = new Directory("root");
foreach (var line in lines)
{
    var splittedLine = line.Split(' ');
    if (splittedLine[0] == "$" && splittedLine[1] == "cd")
    {
        if (splittedLine[2] == "..")
        {
            currentDirectory = currentDirectory.Parent;
            continue;
        }
        var newDirectory = new Directory(splittedLine[2]);
        directories.Add(newDirectory);
        newDirectory.Parent = currentDirectory;
        currentDirectory = newDirectory;
    }
    else if (splittedLine[0] == "$" && splittedLine[1] == "ls")
    {
        continue;
    }
    else if (splittedLine[0] == "dir")
    {
        currentDirectory.AddChild(new Directory(splittedLine[1]));
    }
    else
    {
        currentDirectory.AddFile(int.Parse(splittedLine[0]));
    }

}
foreach (var directory in directories)
{
    var total = directory.TotalSize;
    foreach (var file in directory.Directories)
    {
        Console.WriteLine(file.Name + " " + file.TotalSize);
    }
}
