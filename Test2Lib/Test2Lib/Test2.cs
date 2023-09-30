using System;

namespace Test2Lib
{
    public class EInvalidNumber : Exception
    {
        public EInvalidNumber(int number) : base($"Invalid number: {number}")
        {
        }
    }

    public class Test2
    {
        public void Run()
        {
            string input;
            int x, y=0;

            do
            {
                Console.Write("Enter an integer (or 'stop' to exit): ");
                input = Console.ReadLine();

                if (input.ToLower() == "stop")
                    break;

                if (!int.TryParse(input, out x))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }

                try
                {
                    if (x < 0)
                        throw new EInvalidNumber(x);

                    y = x + 3;

                    if (y > 1000)
                    {
                        y = 0;
                        continue;
                    }    

                    if (y % 11 == 0)
                        Console.WriteLine($"Y is divisible by 11: {y}");
                }
                catch (EInvalidNumber e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);

            Console.WriteLine($"Final value of Y: {y}");
        }
    }
}
