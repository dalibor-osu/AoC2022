using Day7_2;

string[] input = File.ReadAllLines("./input.txt"); // Read input;
int availableSpace = 70000000;
int neededSpace = 30000000;

Dir home = new Dir("/");
Dir currentDir = home;

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

int totalSize = home.GetCompleteSize();
int neededSize = -(availableSpace - totalSize - neededSpace);
int lowestSize = FindDir();

Console.WriteLine(lowestSize);


int FindDir()
{
    unsafe
    {
        int currentLowestSize = availableSpace;
        int* pCurrentLowestSize = &currentLowestSize;
        foreach (var subDir in home.subDirs)
        {
            subDir.CheckSize(neededSize, pCurrentLowestSize);
        }

        return currentLowestSize;
    }
}