namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //пользователем вводятся значения и присваиваются переменным a, b, c
            
            Console.WriteLine("a = ");                          
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("b = ");
            double b = double.Parse(Console.ReadLine());        

            Console.WriteLine("c = ");
            double c = double.Parse(Console.ReadLine());

            // содание переменных, в которые я для удобства буду заносить промежуточные значения вычислений
            double num1, num2, num3;


            //сами вычисления с использованием методов класса Math с соблюдением порядка действий
            num1 = Math.Log(Math.Pow(b, -Math.Sqrt((Math.Abs(a)))));

            num2 = a - b / 2;

            num3 = Math.Pow(Math.Sin(Math.Atan(c)), 2);

            //num1 и num2 перемножаются и к ним прибавляется num3(последние действия в примере)
            //и выводиться результат
            Console.WriteLine("Result : "  + num1 *  num2 + num3);
        }

        // пример номер 17, проверил результат, все верно))
    }

}