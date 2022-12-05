string[] input = File.ReadAllLines("./input.txt"); // Read input
List<string> stacksContent = new(); // lines with content for each stack
List<Stack<char>> stacks = new(); // stack list
int stacksLineCount = -1; 

// Calculate how many stack there are + add each item line to list
foreach (string line in input)
{
    if (line == "")
        break;

    stacksLineCount += 1;
    stacksContent.Add(line); 
}

// Parse stacks count
int stacksCount = int.Parse(stacksContent.Last().Trim().Split(' ').Last());

// Create stacks
for (int i = 0; i < stacksCount; i++)
{
    stacks.Add(new Stack<char>());
}

// Fill stacks with items
int stackIndex = 0;
for (int i = stacksLineCount - 1; i >= 0; i--) // For from bottom
{
    for (int j = 1; j < stacksCount * 4; j += 4) // Every fourth element is an item
    {
        char item = stacksContent[i][j];
        if (char.IsLetter(item)) // Check if item is a letter (it's empty otherwise)
        {
            stacks[stackIndex].Push(item);
        }

        stackIndex += 1; // Add 1 for next stack
    }

    stackIndex = 0; // Reset stacks for new line
}

// Rearrange stacks
bool skip = true;
foreach (string line in input)
{
    if (line == "") // Skip lines to rearrange commands
    {
        skip = false;
        continue;
    }

    if (skip) continue;

    // Parse commands
    string[] commands = line.Trim().Split(' ');
    int itemCount = int.Parse(commands[1]);
    int from = int.Parse(commands[3]) - 1;
    int to = int.Parse(commands[5]) - 1;
    List<char> itemsToMove = new();
    
    // Put all items to move to a list
    for (int i = 0; i < itemCount; i++)
    {
        itemsToMove.Add(stacks[from].Pop());
    }
    
    // Add items to stack in a right order
    for (int i = itemsToMove.Count; i > 0; i--)
    {
        stacks[to].Push(itemsToMove[i - 1]);
    }
}

foreach (var stack in stacks)
{
    Console.Write(stack.Peek());
}