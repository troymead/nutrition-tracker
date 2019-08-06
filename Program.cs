using System;
// TODO: Add comments for method descriptions

namespace nutrition_tracker
{
    // class that simply holds constants that are used frequently in program
    static class Constants {
        public const int numDays = 7;
        public const int numWeeks = 4;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // user with random number of calories consumed each day
            UserData user1 = new UserData("John Doe", 20, "male", 160, 72, 2, 3);
            UserData user2 = new UserData("Jamie Jam", 45, "female", 140, 65, 1, 2);
            UserData user3 = new UserData("Jordan Michael", 18, "male", 200, 62, 3, 4); // need to test new users
            Random randNum = new Random();

            // fills 2-d array simulating a month with random amounts of calories
            for (int i = 0; i < Constants.numWeeks; i++) {
                for (int j = 0; j < Constants.numDays; j++) {
                    user1.userCalories[i,j] = randNum.Next((Convert.ToInt32(userCalorieGoal(user1))-1000), (Convert.ToInt32(userCalorieGoal(user1)+1000)));
                    user2.userCalories[i,j] = randNum.Next((Convert.ToInt32(userCalorieGoal(user2))-1000), (Convert.ToInt32(userCalorieGoal(user2)+1000)));
                    user3.userCalories[i,j] = randNum.Next((Convert.ToInt32(userCalorieGoal(user3))-1000), (Convert.ToInt32(userCalorieGoal(user3)+1000)));
                }
            }

            printUserInfo(user1);
            Console.WriteLine();
            printUserSummary(user1);
            Console.WriteLine();
            
            Console.WriteLine();
            printUserInfo(user2);
            Console.WriteLine();
            printUserSummary(user2);
            Console.WriteLine();

            Console.WriteLine();
            printUserInfo(user3);
            Console.WriteLine();
            printUserSummary(user3);
            Console.WriteLine();
        }

        // method to calculate user goal based on user information
        static public double userCalorieGoal(UserData user) {
            double recCalories;
            recCalories = 0;

            // difference in gender means difference in calorie intak
            if (user.userGender == "male") {
                recCalories = 66 + (6.3 * user.userWeight) + (12.9 * user.userHeight) - (6.8 * user.userAge);
            }
            else if (user.userGender == "female") {
                recCalories = 655 + (4.3 * user.userWeight) + (4.7 * user.userHeight) - (4.7 * user.userAge);
            }

            // switch statement to update calculation based on user activity level
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

            // switch statement for calorie calculation to lose, maintain, or gain weight
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

        // method that prints user's information
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

        static public void printUserSummary(UserData user) {
            // method will print user's min and max calorie intake and which day
            // also prints average calories per week and for a month
            Console.WriteLine("----- USER SUMMARY -----");
            Console.WriteLine("User Minimum Calories for the month: {0} calories", userMinMaxCalories(user)[0]);
            Console.WriteLine("User Maximum Calories for the month: {0} calories", userMinMaxCalories(user)[1]);
            Console.WriteLine("Average Calorie Consumption for Each Week:");

            double[] weeklyAvg = new double[4];
            weeklyAvg = userAvgCaloriesWeek(user);

            for (int i = 0; i < 4; i++) {
                Console.WriteLine("Average for Week {0}: {1} calories", (i+1), weeklyAvg[i]);
            }

            Console.WriteLine("Average Calorie Consumption for the month: {0} calories", userAvgCaloriesMonth(user));
            Console.WriteLine("Number of times the Goal Was Met: {0}", goalMet(user));

            if (goalMet(user) < 14) {
                Console.WriteLine("You can do better than that! Push yourself harder next month!");
            }
            else if (goalMet(user) < 20) {
                Console.WriteLine("You're on the right track. Keep working towards a perfect month!");
            }
            else {
                Console.WriteLine("Excellent Work! Keep this momentum going into the next month!");
            }
        }

        // method to determine minimum and maximum calorie consumption; returns an array
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

        // calculates the average amount of calories in a month
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

        // calculates the average amount of calories for each week
        static public double[] userAvgCaloriesWeek(UserData user) {
            double[] sum = new double[4];
            double[] avg = new double[4];
            for(int i = 0; i < Constants.numWeeks; i++) {
                for (int j = 0; j < Constants.numDays; j++) {
                    sum[i] = sum[i] + user.userCalories[i,j];
                }
                avg[i] = sum[i] / 7;
            }
            return avg;
        }

        // method that tracks the number of times a user's calorie goal was made in a month
        static public int goalMet(UserData user) {
            double goal = userCalorieGoal(user);
            int counter = 0;
            for (int i = 0; i < Constants.numWeeks; i++) {
                for (int j = 0; j < Constants.numDays; j++) {
                    if (user.userCalories[i,j] <= goal) {
                        counter  = counter + 1;
                    }
                }
            }
            return counter;
        }
    }
}
