namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d, e;

            Console.WriteLine("enter a: ");
            a = Convert.ToInt32(Console.ReadLine());
            a = Convert.ToDouble(a);                        // по условия а только целое, поэтому конвертируем в вещественное
            Console.WriteLine();


            Console.WriteLine("enter b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();



            if (a < 0)                                      // если а меньше нуля то
                c = (a - b * Math.Pow(a, 3)) / b;

            else if (a >= 0)                                // если а больше либо равно нулю в то
                c = a * b - 10;

            else                                            // в иных случаях (ну а вдруг)
            {
                Console.WriteLine("ERROR");
                c = 0;
            }


            if (c <= 5)                                     // если с меньше либо равно 5 то
                d = Math.Sin(2 * a) + 2 * c;

            else if (c > 5)                                 // если с больше 5 то
                d = Math.Pow(Math.Cos(a - b / c - a), 2);

            else                                            // в иных случаях (ну а вдруг)
            {
                Console.WriteLine("ERROR");
                d = 0;
            }

            e = (2 * b + 3 * d - 11 * a * c) / 10;


            Console.WriteLine($"a : {a}");                  // вывод всех значений
            Console.WriteLine($"b : {b}");
            Console.WriteLine($"c : {c}");
            Console.WriteLine($"d : {d}");
            Console.WriteLine($"e : {e}");
        }
    }
}