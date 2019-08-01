using System;

namespace nutrition_tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData user1 = new UserData("troymeadows", 20, 125, 1.5, 2);
            Console.WriteLine(user1.userName); // test
            Console.WriteLine("User's Age: {0}", user1.userAge); // test
        }
    }
}
