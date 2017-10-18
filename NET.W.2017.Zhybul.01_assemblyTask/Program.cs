using System;
using GreetingModule;


    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter your name, please");
            string name = Console.ReadLine();

            Greeting welcoming = new Greeting();
            welcoming.GreetingMethod(name);

	    Console.WriteLine("This is Main Program string.");

            Farewell bye = new Farewell();
            bye.FarewellMethod();
            Console.ReadKey();
        }
    }