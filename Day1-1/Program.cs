string[] input = File.ReadAllLines("./input.txt");

int calories = 0;
int currentCalories = 0;

foreach (string line in input) {
    if (line == "") {
        if(currentCalories > calories) calories = currentCalories;
        currentCalories = 0;
    } else {
        int lineCalories = int.Parse(line);
        currentCalories += lineCalories;
    }
}

Console.WriteLine("Max calories: " + calories);