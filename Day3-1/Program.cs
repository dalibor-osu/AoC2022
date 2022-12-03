string[] input = File.ReadAllLines("./input.txt");
string types = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
int points = 0;

foreach (string line in input) {
    string first = line.Substring(0, line.Length / 2);
    string second = line.Substring(line.Length / 2, line.Length / 2);
    char commonType = ' ';

    foreach (var c in first) {
        if (second.Contains(c))
        {
            commonType = c;
            break;
        }
    }

    points += types.IndexOf(commonType) + 1;
}

Console.WriteLine("Total points: " + points);