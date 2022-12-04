string[] input = File.ReadAllLines("./input.txt");
int fullyContained = 0;

foreach (string line in input)
{
    string[] sections = line.Split(',');
    string[] firstSection = sections[0].Split('-');
    string[] secondSection = sections[1].Split('-');
    
    int firstMin = int.Parse(firstSection[0]);
    int firstMax = int.Parse(firstSection[1]);
    int secondMin = int.Parse(secondSection[0]);
    int secondMax = int.Parse(secondSection[1]);

    if (firstMin <= secondMin && firstMax >= secondMax) {
        fullyContained += 1;
        continue;
    }

    if (secondMin <= firstMin && secondMax >= firstMax) {
        fullyContained += 1;
    }
}

Console.WriteLine(fullyContained);