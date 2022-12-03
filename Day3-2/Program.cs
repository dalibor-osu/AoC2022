string[] input = File.ReadAllLines("./input.txt");
string types = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
int points = 0;

for (int i = 0; i < input.Length; i += 3) {
    char commonType = ' ';
    
    foreach (char c in input[i]) {
        if (input[i + 1].Contains(c) && input[i + 2].Contains(c)) {
            commonType = c;
            break;
        }
    }
    
    points += types.IndexOf(commonType) + 1;
}

Console.WriteLine("Total points: " + points);