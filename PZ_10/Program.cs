namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Исходный текст с упоминаниями времени
            string text = "Время по Гринвичу: 10.30.45, 15.20.10, 18.45.30";

            // Разделить текст на отдельные слова
            string[] words = text.Split(' ');

            // Пройти по каждому слову
            for (int i = 0; i < words.Length; i++)
            {
                // Проверить, является ли слово временем в формате HH.MM.SS
                if (IsValidTime(words[i]))
                {
                    // Парсинг времени в формате HH.MM.SS
                    string[] timeParts = words[i].Split('.');
                    int hours = int.Parse(timeParts[0]);
                    int minutes = int.Parse(timeParts[1]);
                    int seconds = int.Parse(timeParts[2]);

                    // Создание объекта DateTime с временем по Гринвичу
                    DateTime greenwichTime = new DateTime(1, 1, 1, hours, minutes, seconds);

                    // Добавление 5 часов для перевода в GMT+5
                    DateTime gmt5Time = greenwichTime.AddHours(5);

                    // Замена исходного времени на переведенное время в тексте
                    words[i] = gmt5Time.ToString("HH.mm.ss");
                }
            }

            // Объединение слов обратно в текст
            string newText = string.Join(" ", words);

            // Вывод результата
            Console.WriteLine(newText);
        }

        // Проверка, является ли строка временем в формате HH.MM.SS
        static bool IsValidTime(string time)
        {
            string[] timeParts = time.Split('.');
            if (timeParts.Length != 3)
            {
                return false;
            }

            int hours, minutes, seconds;
            if (!int.TryParse(timeParts[0], out hours) ||
                !int.TryParse(timeParts[1], out minutes) ||
                !int.TryParse(timeParts[2], out seconds))
            {
                return false;
            }

            if (hours < 0 || hours > 23 ||
                minutes < 0 || minutes > 59 ||
                seconds < 0 || seconds > 59)
            {
                return false;
            }

            return true;
        }
    }
}