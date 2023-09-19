namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите число от 1 до 99");
            int k = Convert.ToInt32(Console.ReadLine());

            switch (k)
            {
                case 1:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 2:
                case 3:
                case 4:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 21:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 22:
                case 23:
                case 24:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 31:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 32:
                case 33:
                case 34:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 41:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 42:
                case 43:
                case 44:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 51:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 52:
                case 53:
                case 54:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 61:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 62:
                case 63:
                case 64:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 71:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 72:
                case 73:
                case 74:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 81:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 82:
                case 83:
                case 84:
                    Console.WriteLine($"мне {k} года");
                    break;

                case 91:
                    Console.WriteLine($"мне {k} год");
                    break;

                case 92:
                case 93:
                case 94:
                    Console.WriteLine($"мне {k} года");
                    break;

                default:
                    Console.WriteLine($"мне {k} лет");
                    break;

            }

            Console.ReadLine();
        }
    }
}