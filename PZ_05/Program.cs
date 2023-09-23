namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[10];
            int i;

            for (i = 0; <= 9; i = i + 1)
                A[i] = i + 2;


            Console.WriteLine("elements of arrey: ");

            for (i = 0; i <= 9; i = i + 1)
                Console.WriteLine(" A[{0}]={1 }", i, A[i]);
        }
    }
}