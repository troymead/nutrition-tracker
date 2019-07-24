// nutrition_tracker.cs
//TODO:
// need to create class/functions to analyze difference in data set(s)
// still need to test
// include conditions for if user wants to lose, gain, or maintain weight



using System;

public struct UserData {
    public string userName;
    public int userAge;
    public double userWeight;
    public double userHeight; // in meters (to make it easier for calculations)
    public double[] dailyCalories; // contains calorie count for a week (has seven entries)
    public double[] weeklyCalories;

    public int weightStatus; // 1 = Lose weight; 2 = Maintain weight; 3 = Gain Weight;
    public UserData(string userName) {
        this.userName = userName;
    }

    public UserData(string userName, int userAge) {
        this.userName = userName;
        this.userAge = userAge;
    }

    public UserData(string userName, int userAge, double userWeight, double userHeight) {
        this.userName = userName;
        this.userAge = userAge;
        this.userWeight = userWeight;
        this.userHeight = userHeight;
    }
}
class NutritionTracker {
    static void Main(string[] args) {
        user1 = new UserData("troymead");
        user2 = new UserData("troymeadows", 20, 125, 1.65);
        int minCalories = 500;
        int maxCalories = 0; // placeholder; need to calculate for later
        Console.WriteLine(user1.userName);
        Console.WriteLine(user2.userAge);

    }
}