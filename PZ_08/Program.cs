namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();                             // задание 1
            
            int[][] arr = new int[10][];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[rand.Next(5, 35)];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rand.Next(0, 100);
                }
            }


            Console.WriteLine("======================");            // задание 2
            Console.WriteLine("задание 2\n");


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "  ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("======================");            // задание 3
            Console.WriteLine("задание 3\n");


            int[] odarr = new int[arr.Length];

            for (int i = 0; i < odarr.Length; i++)
            {
                odarr[i] = arr[i][arr[i].Length - 1];
                Console.Write(odarr[i] + "\t");
            }
            Console.WriteLine();


            Console.WriteLine("======================");            // задание 4
            Console.WriteLine("задание 4\n");

            
            for (int i = 0; i < arr.Length; i++)
            {
                int max = 0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (max < arr[i][j]) max = arr[i][j];
                    else continue;
                }
                odarr[i] = max;
            }

            for (int i = 0; i < odarr.Length; i++)
            {
                Console.Write(odarr[i] + "\t");
            }
            Console.WriteLine();


            Console.WriteLine("======================");            // задание 5
            Console.WriteLine("задание 5\n");


            int[][] arr2 = new int[arr.Length][];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr2[i][j] = arr[i][j];
                }
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}