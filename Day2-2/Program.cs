string[] input = File.ReadAllLines("./input.txt");
List<char> shapes = new List<char>{'A', 'B', 'C'};
int points = 0;

foreach (string line in input)
{
    char enemyPlay = line[0];
    char outcome = line[2];
    char myPlay = DecideShape(enemyPlay, outcome);
    int win = DecideWin(enemyPlay, myPlay);
    
    points += CalculateRoundPoints(myPlay, win);
}

Console.WriteLine("Points: " + points);




// Part 2 Functions
char DecideShape(char enemy, char outcome)
{
    if (outcome == 'Y') return enemy;

    if (outcome == 'Z')
    {
        int outcomeIndexWin = shapes.IndexOf(enemy) == 2 ? 0 : shapes.IndexOf(enemy) + 1;
        return shapes[outcomeIndexWin];
    }
    
    int outcomeDefeatIndex = shapes.IndexOf(enemy) == 0 ? 2 : shapes.IndexOf(enemy) - 1;
    return shapes[outcomeDefeatIndex];
}

// Part 1 Functions
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