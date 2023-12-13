namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] mas1 = { 1.23, 4.567, 0.4235, 132.0 };
            double[] mas2 = { 4.73, 32.67, 7.0935, 100.0, 453.243653 };

            static double medianValue(double[] arr)
            {

                Array.Sort(arr);
                int arrLen = arr.Length;
                int midIndex = arrLen / 2;

                if (arrLen % 2 == 0)
                {
                    double midValue1 = arr[midIndex - 1];
                    double midValue2 = arr[midIndex];

                    return (midValue1 + midValue2) / 2;
                }
                else
                {
                    return (arr[midIndex]);
                }
            }


            for (int i = 0; i < mas1.Length; i++)
            {
                Console.Write(mas1[i] + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < mas2.Length; i++)
            {
                Console.Write(mas2[i] + "\t");
            }
            Console.WriteLine("\n");

            Console.WriteLine(medianValue(mas1)); 
            Console.ReadLine();

            Console.WriteLine(medianValue(mas2));
            Console.ReadLine();
        }
    }
}