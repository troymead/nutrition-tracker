using System;

namespace nutrition_tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData user1 = new UserData("troymeadows", 20, "female", 125, 1.5, 2, 3);
            Console.WriteLine(user1.userName); // test
            Console.WriteLine("User's Age: {0}", user1.userAge); // test
            int calorieMin = 50;
            int calorieMax = 10000;
            Random randNum = new Random();
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 7; j++) {
                    user1.userCalories[i,j] = randNum.Next(calorieMin, calorieMax);
                }
            }
            Console.WriteLine("User Calories for Day 1: {0}", user1.userCalories[0,0]); // need to test

        }
        public double userCalorieGoal(UserData user) {
            double recCalories;
            recCalories = 0;
            if (user.userGender == "male") {
                recCalories = 66 + (6.3 * user.userWeight) + (12.9 * user.userHeight) - (6.8 * user.userAge);
            }
            else if (user.userGender == "female") {
                recCalories = 655 + (4.3 * user.userWeight) + (4.7 * user.userHeight) - (4.7 * user.userAge);
            }
            switch (user.activity) {
                case 1:
                    recCalories = recCalories * 1.2;
                    break;
                case 2:
                    recCalories = recCalories * 1.375;
                    break;
                case 3:
                    recCalories = recCalories * 1.55;
                    break;
                case 4:
                    recCalories = recCalories * 1.725;
                    break;
                case 5:
                    recCalories = recCalories * 1.9;
                    break;
            }
            return recCalories;
        }
    }
}
