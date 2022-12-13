public interface IDirectory
{
    void AddFile(int file);
    void AddChild(Directory directory);
}