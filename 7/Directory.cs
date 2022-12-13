public class Directory : IDirectory
{
    public Directory(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public Directory? Parent { get; set; }
    public List<Directory> Directories { get; set; } = new List<Directory>();
    public List<int> Files { get; set; } = new List<int>();
    public long TotalSize
    {
        get
        {
            long size = 0;
            foreach (var file in Files)
            {
                size += file;
            }
            foreach (var directory in Directories)
            {
                size += directory.TotalSize;
            }
            return size;

        }

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