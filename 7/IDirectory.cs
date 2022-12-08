public interface IDirectory
{
    int Sum();
    void AddFile(int file);
    void AddChild(Directory directory);
}