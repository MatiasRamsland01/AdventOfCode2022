public class Directory
{
    public Directory(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public Directory? Parent { get; set; }
    public List<Directory> Directories { get; set; } = new List<Directory>();
    public List<int> Files { get; set; } = new List<int>();
    public int Sum()
    {
        var sum = Files.Sum();
        //This is supposed to go recursively through all children directories and sum their files
        foreach (var directory in Directories)
        {
            sum += directory.Sum();
        }
        return sum;
    }
    public void AddFile(int file)
    {
        Files.Add(file);
    }
    public void AddChild(Directory directory)
    {
        Directories.Add(directory);
    }
}