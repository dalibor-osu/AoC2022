namespace Day7_1;

public class Dir
{
    public string Name;
    public List<Dir> subDirs;
    public List<F> files;
    public Dir? ParentDir;
    
    public Dir(string name, Dir? parentDir = null)
    {
        Name = name;
        subDirs = new List<Dir>();
        files = new List<F>();
        ParentDir = parentDir;
    }

    public int GetCompleteSize()
    {
        int size = 0;
        files.ForEach(x => size += x.Size);
        subDirs.ForEach(x => size += x.GetCompleteSize());
        return size;
    }
}