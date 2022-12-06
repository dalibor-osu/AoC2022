string input = File.ReadAllLines("./input.txt")[0]; // Read input
int count = 0;

for (int i = 0; i < input.Length; i++)
{
    string letters = input.Substring(i, 4);
    if (letters.Count(x => x == letters[0]) > 1 || letters.Count(x => x == letters[1]) > 1 || letters.Count(x => x == letters[2]) > 1 || letters.Count(x => x == letters[3]) > 1)
    {
        continue;
    }

    count = i + 4;
    break;
}

Console.WriteLine(count);