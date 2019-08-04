using System;

namespace nutrition_tracker
{
    static class Constants {
        public const int numDays = 7;
        public const int numWeeks = 4;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // user with random number of calories consumed each day
            UserData user1 = new UserData("troymeadows", 20, "female", 125, 65, 2, 3);
            UserData user2 = new UserData("josh", 21, "male", 180, 72, 1, 2);
            int calorieMin = 500;
            int calorieMax = 5000;
            Random randNum = new Random();

            for (int i = 0; i < Constants.numWeeks; i++) {
                for (int j = 0; j < Constants.numDays; j++) {
                    user1.userCalories[i,j] = randNum.Next(calorieMin, calorieMax);
                }
            }

            printUserInfo(user1); // need to test
            Console.WriteLine("User 1's Min and Max Calories for 1 Month:");
            double[] minMax = new double[2];
            minMax = userMinMaxCalories(user1);
            Console.WriteLine("Minimum: {0}", minMax[0]); // testing min max method
            Console.WriteLine("Maximum: {0}", minMax[1]);
        }

        static public double userCalorieGoal(UserData user) {
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
                default:
                    break;
            }

            // calorie calc to lose, maintain, or gain weight
            switch(user.weightStatus) {
                case 1:
                    recCalories = recCalories - 500; // eat 500 less calories per day to lose a pound in a week
                    break;
                case 2:
                    break; // user consumes same amount recommended
                case 3:
                    recCalories = recCalories + 500; // eat 500 more calories per day to gain a pound each week
                    break;
                default:
                    break;
            }
            return recCalories;
        }

        static public void printUserInfo(UserData user) {
            Console.WriteLine();
            Console.WriteLine("----- USER INFORMATION -----");
            Console.WriteLine("User's Name: {0}", user.userName);
            Console.WriteLine("User's Age: {0}", user.userAge);
            Console.WriteLine("User Gender: {0}", user.userGender);
            Console.WriteLine("User Weight: {0} lbs", user.userWeight);
            Console.WriteLine("User Height: {0} in.", user.userHeight);

            switch(user.weightStatus) {
                case 1:
                    Console.WriteLine("This user would like to lose weight.");
                    break;
                case 2:
                    Console.WriteLine("This user would like to maintain their weight.");
                    break;
                case 3:
                    Console.WriteLine("This user would like to gain weight.");
                    break;
                default:
                    Console.WriteLine("The user did not enter a goal.");
                    break;
            }
            
            Console.WriteLine("The user should consume {0} calories each day to work towards their goal.", userCalorieGoal(user));
            Console.WriteLine();
        }

        static public double[] userMinMaxCalories(UserData user) { // need to test
            double minCal;
            double maxCal;
            minCal = user.userCalories[0,0];
            maxCal = user.userCalories[0,0];
            for (int i = 1; i < Constants.numWeeks; i++) {
                for (int j = 1; j < Constants.numDays; j++) {
                    if (minCal > user.userCalories[i,j]) {
                        minCal = user.userCalories[i,j];
                    }
                    if (maxCal < user.userCalories[i,j]) {
                        maxCal = user.userCalories[i,j];
                    }
                }
            }
            double[] minMax = new double[2];
            minMax[0] = minCal;
            minMax[1] = maxCal;
            return minMax;
        }

        static public double userAvgCaloriesMonth(UserData user) {
            double sum = 0;
            for (int i = 0; i < Constants.numWeeks; i++) {
                for (int j = 0; j < Constants.numDays; j++) {
                    sum = sum + user.userCalories[i,j];
                }
            }
            double avgCalMonth = sum / (Constants.numWeeks * Constants.numDays);
            return avgCalMonth;
        }

        static public double[] userAvgCaloriesWeek(UserData user) {
            double[] sum = new double[4];
            return sum;
        }
    }
}
