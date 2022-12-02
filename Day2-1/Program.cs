string[] input = File.ReadAllLines("./input.txt");
List<char> shapes = new List<char>{'A', 'B', 'C'};
int points = 0;

foreach (string line in input)
{
    char enemyPlay = line[0];
    char myPlay = ConvertPlay(line[2]);
    int win = DecideWin(enemyPlay, myPlay);

    points += CalculateRoundPoints(myPlay, win);
}

Console.WriteLine("Points: " + points);




// Functions
int DecideWin(char enemy, char me)
{
    if (enemy == me) return 3;

    int enemyIndex = shapes.IndexOf(enemy);
    int meIndex = shapes.IndexOf(me);

    return enemyIndex == GetWinIndex(meIndex) ? 6 : 0;
}

int GetWinIndex(int meIndex)
{
    int winIndex = meIndex - 1;
    return winIndex == -1 ? 2 : winIndex;
}

int CalculateRoundPoints(char shape, int win)
{
    int points = 0;
    
    switch (shape)
    {
        case 'A':
            points += 1;
            break;
        case 'B':
            points += 2;
            break;
        case 'C':
            points += 3;
            break;
    }

    return points + win;
}

char ConvertPlay(char play)
{
    switch (play)
    {
        case 'X':
            return 'A';
        case 'Y':
            return 'B';
        case 'Z':
            return 'C';
        default:
            return 'D';
    }
}