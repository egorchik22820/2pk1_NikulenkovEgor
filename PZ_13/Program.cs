namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            double a1 = 0.5;
            double d = 0.3;

            Console.WriteLine(Foo(n, a1, d));
            Console.ReadLine();

            static double Foo(int n, double A1, double D)
            {
                if (n == 1) return A1;

                return Foo(n - 1, A1, D) + D;
            }
        }
    }
}