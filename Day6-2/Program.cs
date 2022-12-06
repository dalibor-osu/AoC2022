string input = File.ReadAllLines("./input.txt")[0]; // Read input
int count = 0;

for (int i = 0; i < input.Length; i++)
{
    string letters = input.Substring(i, 14);
    if (letters.Count(x => x == letters[0]) > 1 ||
        letters.Count(x => x == letters[1]) > 1 ||
        letters.Count(x => x == letters[2]) > 1 ||
        letters.Count(x => x == letters[3]) > 1 ||
        letters.Count(x => x == letters[4]) > 1 ||
        letters.Count(x => x == letters[5]) > 1 ||
        letters.Count(x => x == letters[6]) > 1 ||
        letters.Count(x => x == letters[7]) > 1 ||
        letters.Count(x => x == letters[8]) > 1 ||
        letters.Count(x => x == letters[9]) > 1 ||
        letters.Count(x => x == letters[10]) > 1 ||
        letters.Count(x => x == letters[11]) > 1 ||
        letters.Count(x => x == letters[12]) > 1 ||
        letters.Count(x => x == letters[13]) > 1)
    {
        continue;
    }

    count = i + 14;
    break;
}

Console.WriteLine(count);