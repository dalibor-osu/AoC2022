using Day7_1;

string[] input = File.ReadAllLines("./input.txt"); // Read input;

Dir home = new Dir("/");
Dir currentDir = home;
int size = 0;

for (int i = 0; i < input.Length; i++)
{
    if (input[i][0] != '$' || i == 0) continue;

    string[] arguments = input[i].Trim().Split(' ');

    if (arguments[1] == "cd")
    {
        if (arguments[2] == "..")
        {
            if (currentDir.ParentDir != null) currentDir = currentDir.ParentDir;
        }
        else
        {
            currentDir = currentDir.subDirs.Find(x => x.Name == arguments[2]);
        }
    }
    
    if (arguments[1] == "ls")
    {
        int lineIndex = i + 1;
        while (lineIndex < input.Length && input[lineIndex][0] != '$')
        {
            string[] info = input[lineIndex].Trim().Split(' ');

            if (info[0] == "dir")
            {
                currentDir.subDirs.Add(new Dir(info[1], currentDir));
            }
            else
            {
                currentDir.files.Add(new F(info[1], int.Parse(info[0])));
            }
            
            lineIndex++;
        }
    }
}

AddSize(home);
Console.WriteLine(size);

void AddSize(Dir dir)
{
    foreach (var subDir in dir.subDirs)
    {
        if (subDir.subDirs.Count > 0)
        {
            subDir.subDirs.ForEach(AddSize);
        }

        if (subDir.GetCompleteSize() < 100000) size += subDir.GetCompleteSize();
    }
    if (dir.GetCompleteSize() < 100000) size += dir.GetCompleteSize();
}
