string[] input = File.ReadAllLines("./input.txt"); // Read input;
int rows = input.Length;
int columns = input[0].Length;
int[,] trees = new int [rows, columns];
int[,] visibilityMap = new int [rows, columns];
int visibleTrees = 0;
int currentHigestTree;

int maxViewScore = 0;

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        trees[i, j] = int.Parse(input[i][j].ToString());
        visibilityMap[i, j] = 0;
    }
}

for (int i = 0; i < rows; i++)
{
    currentHigestTree = -1;
    for (int j = 0; j < columns; j++)
    {
        int tree = trees[i, j];
        if (tree > currentHigestTree)
        {
            currentHigestTree = tree;
            
            if (visibilityMap[i, j] == 0)
            {
                visibleTrees++;
                visibilityMap[i, j] += 1;
            }
        }
        
        if(currentHigestTree == 9) break;
    }
}

for (int i = 0; i < rows; i++)
{
    currentHigestTree = -1;
    for (int j = columns - 1; j >= 0; j--)
    {
        int tree = trees[i, j];
        if (tree > currentHigestTree)
        {
            currentHigestTree = tree;
            
            if (visibilityMap[i, j] == 0)
            {
                visibleTrees++;
                visibilityMap[i, j] += 1;
            }
        }
        
        if(currentHigestTree == 9) break;
    }
}

for (int j = 0; j < columns; j++)
{
    currentHigestTree = -1;
    for (int i = 0; i < rows; i++)
    {
        int tree = trees[i, j];
        if (tree > currentHigestTree)
        {
            currentHigestTree = tree;
            
            if (visibilityMap[i, j] == 0)
            {
                visibleTrees++;
                visibilityMap[i, j] += 1;
            }
        }
        
        if(currentHigestTree == 9) break;
    }
}

for (int j = 0; j < columns; j++)
{
    currentHigestTree = -1;
    for (int i = rows - 1; i >= 0; i--)
    {
        int tree = trees[i, j];
        if (tree > currentHigestTree)
        {
            currentHigestTree = tree;
            
            if (visibilityMap[i, j] == 0)
            {
                visibleTrees++;
                visibilityMap[i, j] += 1;
            }
        }
        
        if(currentHigestTree == 9) break;
    }
}

Console.WriteLine(visibleTrees);
