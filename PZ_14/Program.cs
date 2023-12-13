using System;
using System.IO;
using System.Text;

namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Запрашиваем у пользователя ввод строки
            Console.Write("Введите строку S: ");
            string userInput = Console.ReadLine();

            // Проверяем, что пользователь ввел непустую строку
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Строка не должна быть пустой. Повторите ввод.");
                return;
            }

            // Формируем имя файла, добавляя расширение .txt
            string fileName = userInput + ".txt";

            // Вызываем метод для записи текста в файл
            WriteTextToFile(fileName);

            // Выводим сообщение об успешном создании файла
            Console.WriteLine($"Файл {fileName} успешно создан и заполнен текстом.");

            // Вызываем метод для обновления содержимого файла
            UpdateFileContent(fileName);

            // Выводим сообщение об успешном обновлении файла
            Console.WriteLine($"Файл {fileName} обновлен.");
            Console.ReadLine();
        }

        // Метод для записи текста в файл
        static void WriteTextToFile(string fileName)
        {
            Console.WriteLine("Введите текст для записи в файл (введите пустую строку для завершения):");

            FileStream fileStream = null;
            StreamWriter writer = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(fileStream, Encoding.UTF8);

                string line;
                while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                {
                    writer.WriteLine(line);
                }

                // Сбрасываем буфер и записываем данные на диск
                writer.Flush();
            }
            finally
            {
                CloseStreams(writer, fileStream);
            }
        }

        static void UpdateFileContent(string fileName)
        {
            FileStream fileStream = null;
            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);

                if (fileStream.CanRead)
                {
                    reader = new StreamReader(fileStream, Encoding.UTF8);

                    if (fileStream.CanWrite)
                    {
                        // Позиционируем поток в начало файла
                        fileStream.Seek(0, SeekOrigin.Begin);

                        writer = new StreamWriter(fileStream, Encoding.UTF8);

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Добавляем символ '*' после каждого символа в строке
                            foreach (char c in line)
                            {
                                writer.Write(c);
                                writer.Write('*');
                            }
                            writer.WriteLine(); // Добавляем новую строку после каждой обработанной строки
                        }

                        // Сбрасываем буфер и записываем данные на диск
                        writer.Flush();

                        // Обрезаем файл, если новое содержимое короче предыдущего
                        fileStream.SetLength(fileStream.Position);
                    }
                }
            }
            finally
            {
                CloseStreams(reader, writer, fileStream);
            }
        }

        // Метод для явного закрытия потоков
        static void CloseStreams(params IDisposable[] streams)
        {
            foreach (var stream in streams)
            {
                if (stream != null)
                {
                    // Проверяем, открыт ли поток перед вызовом Dispose
                    var fileStream = stream as FileStream;
                    if (fileStream != null && (fileStream.CanRead || fileStream.CanWrite))
                    {
                        stream.Dispose();
                    }
                }
            }
        }




    }   
    
}