namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int[] arr = new int[10];                       // создание массива
             Random rand = new Random();            


             for (int i = 0; i < arr.Length; i++)           // заполнение массива случайными числами
             {
                 arr[i] = rand.Next(0, 50);
             }



             for (int i = 0; i < arr.Length; i++)           // сортировка и вывод значений массива
             {
                int valmas = arr[i];                        // чтобы не менять значение в массиве

                int sum = 0;

                if (valmas > 9)                             // если число не однозначное , то
                 {

                    while (valmas > 0)                      // таким образом отделяем разряды
                    {
                        sum = sum + valmas % 10;
                        valmas /= 10;
                    }
                 }
                else sum = valmas;                          // иначе число записывает как сумму

                Console.WriteLine(arr[i] + "\t" + sum);     // вывод
            }
        }


    }
}