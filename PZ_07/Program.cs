namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = Convert.ToInt32(Console.ReadLine());          // вводим строки
            int col = Convert.ToInt32(Console.ReadLine());          // вводим столбцы
            Console.WriteLine();

            char[,] arr = new char[row, col];                       // массив чаров

            Random rand = new Random();


            for (int i = 0; i < row; i++)                           // заполняем массив
            {
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = (char)(rand.Next(65, 90));          // случайное число в заданном диапозоне конвертируем в нужный символ по таблице аски и заносим в массив
                }
            }

            for (int i = 0; i < row; i++)                           // выводим в виде таблице
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }


            
        }
    }
}