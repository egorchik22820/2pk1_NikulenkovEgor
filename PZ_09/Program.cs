namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            string maxString = "";
            int maxLength = 0;

            Console.WriteLine("Введите строки (для завершения введите 'stop'):");

            while (true)
            {
                input = Console.ReadLine();

                if (input.ToLower() == "stop")
                    break;

                if (input.Length > maxLength)
                {
                    maxLength = input.Length;
                    maxString = input;
                }
            }

            Console.WriteLine($"Строка максимальной длины: {maxString}");
            Console.ReadLine();

        }
    }
}