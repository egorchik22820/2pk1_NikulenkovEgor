namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("задание 1");         // задание 1

            for (int i = 10; i <= 80; i += 4)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("задание 2");         // задание 2


            char latter = 'В';
            for (int i = 0; i < 7; i++)
            {

                Console.Write(latter++);
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("задание 3");         // задание 3


            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("#");
                }
                Console.Write("\n");

            }


            Console.WriteLine("======================================");
            Console.WriteLine( "задание 4");        // задание 3

            int howMany = 0;
            for (int i = -500; i < 200; i++)
            {
                if (i % 5 == 0)
                {
                    Console.Write($"{i} ");
                    howMany++;
                }
                else
                    continue;
            }

            Console.WriteLine("\n");
            Console.WriteLine($"{howMany} значений, удовлетворяющих условия");


            Console.WriteLine("========================================");
            Console.WriteLine("задание 5");         // задание 5


            for (int i = 5, j = 70; i - j <= 19; i++, j--)
            {
                Console.WriteLine($"i : {i}\tj : {j}");
            }

                                                    //все работает
        }
    }
}