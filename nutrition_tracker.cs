// nutrition_tracker.cs
//TODO:
// need to create class/functions to analyze difference in data set(s)
// still need to test
// include conditions for if user wants to lose, gain, or maintain weight



using System;

public struct UserData {
    public string userName;
    public int userAge;
    public double userWeight, userHeight; // userHeight in meters
    // public double[] dailyCalories;
    // public double[] weeklyCalories; // contains calorie count for a week (has seven entries)
    public double[,] userCalories; // 2-d array; 4 weeks, 7 days in a week
    public int weightStatus; // 1 = Lose weight; 2 = Maintain weight; 3 = Gain Weight;
    public UserData(string userName, int userAge, double userWeight, double userHeight, int weightStatus) {
        this.userName = userName;
        this.userAge = userAge;
        this.userWeight = userWeight;
        this.userHeight = userHeight;
        this.weightStatus = weightStatus;
        userCalories = new double[4,7];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 7; j++) {
                userCalories[i,j] = 0;
            }
        }
        
    }
}
// class NutritionTracker {
//     static void Main(string[] args) {
//         user2 = new UserData("troymeadows", 20, 125, 1.65);
//         int minCalories = 500;
//         int maxCalories = 0; // placeholder; need to calculate for later

//     }
// }