// nutrition_tracker.cs

using System;

public struct UserData {
    public string userName;
    public string userGender;
    public int userAge;
    public double userWeight;
    public double userHeight; // userHeight in inches

    public double[,] userCalories; // 2-d array; 4 weeks, 7 days in a week
    public int weightStatus; // 1 = Lose weight; 2 = Maintain weight; 3 = Gain Weight;
    public int activity; // 1 = sedentary, 2 = lightly active, 3 = moderately active, 4 = very active, 5 = extra active
    public UserData(string userName, int userAge, string userGender, double userWeight, double userHeight, int weightStatus, int userActivity) {
        this.userName = userName;
        this.userAge = userAge;
        this.userGender = userGender;
        this.userWeight = userWeight;
        this.userHeight = userHeight;
        this.weightStatus = weightStatus;
        this.activity = userActivity;
        userCalories = new double[4,7];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 7; j++) {
                userCalories[i,j] = 0;
            }
        }
    }
}