using System.Collections.Immutable;

namespace consoleProject
{
    /*
     * ФИО студента: Никуленков Егор
     * номер варианта: 15
     * условие задачи (скопировать из листа задания): За основу берется класс, разработанный на 17 практике (создание простого класса).
Для этого класса необходимо реализовать следующие интерфейсы:
1. IClonable с реализацией глубокого копирования (если присутствуют ссылочные
поля)
2. IComporable (по какому из полей будет производится сравнение объектов –
выбираете на свое усмотрение, главное адекватность. Например, сравнение
посылок по весу, пользователей по дате регистрации и т.д.)
Создать массив/список на 10 объектов данного класса и отсортировать эту
коллекцию через стандартный метод Sort()
3. IDisposable. (разбор самостоятельный здесь)
4. Создать пользовательский интерфейс, в который вынести контракт на реализацию
специфичного для вашего класса функционала (например, для пользователя
ресурса (IUser) это может быть идентификатор(свойство) регистрация(метод)
удаление аккаунта (метод)).
Создать новый класс, в котором реализовать данный интерфейс.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingTicket t1 = new ParkingTicket(1, 1000, "10:00", "11:00", 28);
            ParkingTicket t2 = new ParkingTicket(2, 1500, "10:00", "11:33", 33);
            ParkingTicket t3 = new ParkingTicket(3, 2000, "10:00", "12:23", 11);
            ParkingTicket t4 = new ParkingTicket(4, 2500, "10:00", "12:55", 76);
            ParkingTicket t5 = new ParkingTicket(4, 6500, "10:00", "12:55", 76);
            ParkingTicket t6 = new ParkingTicket(4, 7800, "10:00", "12:55", 76);
            ParkingTicket t7 = new ParkingTicket(4, 3000, "10:00", "12:55", 76);
            ParkingTicket t8 = new ParkingTicket(4, 500, "10:00", "12:55", 76);
            ParkingTicket t9 = new ParkingTicket(4, 9999, "10:00", "12:55", 76);
            ParkingTicket tt1 = (ParkingTicket)t1.Clone();
            tt1.summ = 10000;

            ParkingTicket[] arr = new ParkingTicket[10];
            arr[0] = tt1;
            arr[1] = t2;
            arr[2] = t3;
            arr[3] = t4;
            arr[4] = t1;
            arr[5] = t5;
            arr[6] = t6;
            arr[7] = t7;
            arr[8] = t8;
            arr[9] = t9;

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].GetTicketInfo();
            }

            Pasagir pasagir = new Pasagir("Egor", 27);
            pasagir.BuyTicket(tt1);
            pasagir.GetInfo();

            Console.ReadLine();


        }
    }
}