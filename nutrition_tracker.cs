// nutrition_tracker.cs
//TODO:
// need to create class/functions to analyze difference in data set(s)
// still need to test



using System;

public struct UserData {
    public string userName;
    public double userWeight;
    public double[] dailyCalories; // contains calorie count for a week (has seven entries)
    public double[] weeklyCalories;
    public UserData(string userName) {
        this.userName = userName;
    }
}
class NutritionTracker {
    static void Main(string[] args) {
        user1 = new UserData("troymead");
        Console.WriteLine(user1.userName);
    }
}