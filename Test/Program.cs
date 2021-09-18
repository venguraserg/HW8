using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1. List Virtual Servers" +
               Environment.NewLine + "2. List Image Templates" +
               Environment.NewLine + "3. Exit");

            var input = Console.ReadKey();
            var key = input.KeyChar;
            int value;
            if (int.TryParse(key.ToString(), out value))
            {
                Console.WriteLine();
                RouteChoice(value);
            }
            else
            {
                Console.WriteLine("Invalid Entry.");
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey(false);

            Console.ReadLine();

        }

        private static void RouteChoice(int menuChoice)
        {
            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine("1111111");
                    //GetVirtualServers();
                    break;
                case 2:
                    Console.WriteLine("222222");
                    //GetImageTemplate();
                    break;
                default:
                    Console.WriteLine("Invalid Entry!");
                    break;
            }
        }
    }
}
