namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void PowerA3(double a, out double b)
            {
                b = a * a * a;
            }

            double inValue;
            double outValue;

            while (true)
            {
                Console.WriteLine("введите число , которое вы хотите возвести в куб\n");
                inValue = Convert.ToDouble(Console.ReadLine());

                PowerA3(inValue, out outValue);
                Console.WriteLine(outValue);
            }
        }
    }
}