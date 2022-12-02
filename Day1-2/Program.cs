string[] input = File.ReadAllLines("./input.txt");

int[] calories = {0, 0, 0};
int currentCalories = 0;

foreach (string line in input) {
    if (line == "") {
        for (int i = 0; i < 3; i++)
        {
            if (currentCalories <= calories[i]) continue;
            
            if (i == 0) {
                calories[i + 1] = calories[i];
                calories[i + 2] = calories[i + 1];
            }
            
            if (i == 1) {
                calories[i + 1] = calories[i];
            }
            
            calories[i] = currentCalories;
            break;
        }
        
        currentCalories = 0;
    } else {
        currentCalories += int.Parse(line);
    }
}

Console.WriteLine("Max calories: " + (calories[0] + calories[1] + calories[2]));