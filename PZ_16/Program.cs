namespace PZ_16;
internal class Program
{
    static int mapSize = 25; // размер поля
    static char[,] map = new char[mapSize, mapSize];

    // стартовая позиция
    static int playerY = mapSize / 2;
    static int playerX = mapSize / 2;

    static byte enemies = 5; // враги
    static byte buffs = 5;   // бафы
    static int health = 5;   // хилки
    static int step = 0;     // шаги
    static int stepsave = 0; // сохраненный шаг

    static int plHP = 50; // здоровье игрока
    static int plDMG = 10;// урон игрока

    static int enHP = 30; // здоровье врагов
    static int enDMG = 5; // урон врагов

    // расположение текста в окне
    static int centerY = Console.WindowHeight / 2;
    static int centerX = (Console.WindowHeight / 2) - 15;


    static string lastAction = "Начало игры"; // последние действие
    static bool bringbuff = false;            // подобрал ли усиление
    static int selectedMenuItem = 0;


    static void Savegame() // сохранение
    {
        string path = "save.txt"; // создание текстового файла
        using (StreamWriter writer = new StreamWriter(path)) // запись в него параметров
        {
            writer.WriteLine($"playerX={playerX}");
            writer.WriteLine($"playerY={playerY}");
            writer.WriteLine($"playerHP={plHP}");
            writer.WriteLine($"playerStrong={plDMG}");
            writer.WriteLine($"playerStepCount={step}");
            writer.WriteLine($"enemyHP={enHP}");
            writer.WriteLine($"hasBuff={bringbuff}");
            writer.WriteLine($"buffStep={stepsave}");

            for (int i = 0; i < mapSize; i++) // запись карты
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'P')
                    {
                        map[i, j] = '_';
                    }
                    writer.Write(map[i, j]);
                }
                writer.WriteLine();
            }
        }
    }

    static void Loadgame() // загрузка
    {
        string path = "save.txt"; // путь

        if (File.Exists(path)) // если существует
        {
            string[] lines = File.ReadAllLines(path); // передача файлов с документа в игру

            if (lines.Length >= mapSize)
            {
                if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                int.TryParse(lines[2].Split('=')[1], out int loadedPlayerHP) &&
                int.TryParse(lines[3].Split('=')[1], out int loadedPlayerStrong) &&
                int.TryParse(lines[4].Split('=')[1], out int loadedPlayerStepCount) &&
                int.TryParse(lines[5].Split('=')[1], out int loadedEnemyHP) &&
                bool.TryParse(lines[6].Split('=')[1], out bool loadedHasBuff) &&
                int.TryParse(lines[7].Split('=')[1], out int loadedBuffStep))
                {
                    playerX = loadedPlayerX;
                    playerY = loadedPlayerY;
                    plHP = loadedPlayerHP;
                    plDMG = loadedPlayerStrong;
                    step = loadedPlayerStepCount;
                    stepsave = loadedBuffStep;
                    enHP = loadedEnemyHP;
                    bringbuff = loadedHasBuff;

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            map[i, j] = '_';
                        }
                    }

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            map[i, j] = lines[i + 8][j];
                        }
                    }

                    map[playerX, playerY] = 'P';

                    Console.Clear();
                    UpdateMap(); //вывод на консоль
                }
            }
            else
            {
                Console.WriteLine("Ошибка чтения файла сохранения.");
            }
        }
        else
        {
            Console.WriteLine("Файл сохранения не найден.");
        }
    }

    static void GetPlayerPosition(out int x, out int y) // узнать позицию игрока
    {
        x = playerX;
        y = playerY;
    }

    static void Victory()
    {
        for (int i = 0; i < mapSize; i++) // есть ли враги
        {
            for (int j = 0; j < mapSize; j++)
            {
                if (map[i, j] == 'E')
                {
                    return;
                }
            }
        }

        Console.Clear();
        Centertext("Игра пройдена", centerY);
        Centertext("Вы сделали " + step + " шагов", centerY + 1);
        Centertext("Нажмите Enter для выхода из игры", centerY + 2);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Enter);

        Environment.Exit(0); // Выход
    }

    //карта и движение
    static void GenerationMap()
    {
        Random random = new Random();

        
        for (int i = 0; i < mapSize; i++) // Создание пустого поля
        {
            for (int j = 0; j < mapSize; j++)
            {
                if (j == mapSize - 1)
                {
                    Console.SetCursorPosition(i, j); // решение проблемы с гранцией карты(переставление курсора)
                    map[i, j] = '_';
                }
                else
                {
                    map[i, j] = '_';
                }
            }
        }
        map[playerY, playerX] = 'P'; // игрок ставится в середину поля

        // временные координаты для проверки занятости клетки
        int x;
        int y;

        while (enemies > 0) // добавление врагов
        {
            x = random.Next(0, mapSize);
            y = random.Next(0, mapSize);

            if (map[x, y] == '_')
            {
                map[x, y] = 'E';
                enemies--;
            }
        }

        while (buffs > 0) // добавление усилений
        {
            x = random.Next(0, mapSize);
            y = random.Next(0, mapSize);

            if (map[x, y] == '_')
            {
                map[x, y] = 'B';
                buffs--;
            }
        }

        while (health > 0) // добавление хилок
        {
            x = random.Next(0, mapSize);
            y = random.Next(0, mapSize);

            if (map[x, y] == '_')
            {
                map[x, y] = 'H';
                health--;
            }
        }
        UpdateMap();
    }

    static void UpdateMap()  // отображение заполненного поля в консоли
    {
        Console.Clear();
        for (int i = 0; i < mapSize; i++) //запись карты в консоль
        {
            for (int j = 0; j < mapSize; j++)
            {
                switch (map[i, j]) // разные цвета элементов
                {
                    case 'E':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'H':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                Console.Write(map[i, j]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    static void Move() // движение игрока
    {
        // предыдущие координаты игрока
        int playerOldY;
        int playerOldX;

        while (true)
        {
            playerOldX = playerX;
            playerOldY = playerY;

            switch (Console.ReadKey().Key) // управление через клавиатуру
            {
                case ConsoleKey.UpArrow:
                    playerX--;
                    step++;
                    break;
                case ConsoleKey.DownArrow:
                    playerX++;
                    step++;
                    break;
                case ConsoleKey.LeftArrow:
                    playerY--;
                    step++;
                    break;
                case ConsoleKey.RightArrow:
                    playerY++;
                    step++;
                    break;
                case ConsoleKey.Escape: // сохранение и выход из игры
                    Savegame();
                    Console.Clear();
                    Centertext("_Игра сохранена", centerY);
                    Console.ReadLine();
                    Centertext("Нажмите Enter чтобы выйти в меню", centerY + 1);
                    ConsoleKeyInfo keyInfo;
                    do
                    {
                        keyInfo = Console.ReadKey();
                    } while (keyInfo.Key != ConsoleKey.Enter);

                    StartGame();
                    Console.ReadLine();
                    return;
            }

            // ограничение по границам карты
            if (playerX < 0) playerX = 0;
            if (playerY < 0) playerY = 0;
            if (playerX >= mapSize) playerX = mapSize - 1;
            if (playerY >= mapSize) playerY = mapSize - 1;

            Console.CursorVisible = false; // невидимый курсор

            // предыдущее положение игрока удаляется
            map[playerOldY, playerOldX] = '_';
            Console.SetCursorPosition(playerOldY, playerOldX);
            Console.Write('_');

            // обновленное положение игрока
            map[playerY, playerX] = 'P';
            Console.SetCursorPosition(playerY, playerX);
            Console.ForegroundColor = ConsoleColor.Magenta; // цвет игрока
            Console.Write('P');
            Console.ForegroundColor = ConsoleColor.White; // цвет следа за игроком
            Console.SetCursorPosition(0, mapSize);

            // применение функций 
            Fight();
            BuffUp();
            Heal();
            Victory();

            // показатели
            int x, y;
            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"Здоровье: {plHP}  ");
            Console.WriteLine($"Сила атаки: {plDMG}  ");
            Console.WriteLine($"Сделано шагов: {step}  ");
            GetPlayerPosition(out x, out y);
            Console.WriteLine($"x = {x}, y = {y}" + "  ");

            Console.SetCursorPosition(mapSize + 5, mapSize / 2);
            Console.Write("Последнее действие: " + lastAction);
        }
    }

    static void BuffUp() // Логика баффов
    {
        if (map[playerX, playerY] == 'B')
        {
            bringbuff = true;
            stepsave = step; //сохранение шага на котором взят бафф
            plDMG = plDMG * 2;
            map[playerX, playerY] = '_';
            lastAction = "Поднят бафф                            ";
        }
        if (stepsave == step - 20)
        {
            bringbuff = false;
            plDMG = 10; // возврат к изначальному урону
            lastAction = "Бафф закончился                        ";
        }
    }

    static void Heal()
    {
        if (map[playerX, playerY] == 'H')
        {
            plHP = 50; // лечение до максимума
            map[playerX, playerY] = '_'; 
            lastAction = "Поднята аптечка                        ";
        }
    } // хил
    static void Fight()
    {
        if (map[playerX, playerY] == 'E')
        {
            while (plHP > 0 && enHP > 0) // пока живы
            {
                enHP = enHP - plDMG;
                plHP = plHP - enDMG;

                if (plHP <= 0) // если здоровье игрока кончилось, экран проигрыша
                {
                    lastAction = "Вы проиграли бой. Здоровье: 0";
                    Console.Clear();
                    Centertext("Игра окончена", centerY);
                    Console.SetCursorPosition(centerX, centerY + 1);
                    Console.WriteLine("Нажмите Enter для возвращения в меню");

                    ConsoleKeyInfo keyInfo;
                    do
                    {
                        keyInfo = Console.ReadKey();
                    } while (keyInfo.Key != ConsoleKey.Enter);

                    StartGame();
                }

                if (enHP <= 0) // если враг побежден, то игрок остается в ячейке
                {
                    map[playerX, playerY] = '_';
                    Console.SetCursorPosition(playerY, playerX);
                    Console.Write('_');
                    Console.SetCursorPosition(playerY, playerX);
                    Console.Write('P');
                    lastAction = "Вы победили врага и потеряли " + (50 - plHP) + " HP   ";
                }
                else // анимация боя
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('+');
                        Thread.Sleep(60);
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('*');
                        Thread.Sleep(60);
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('%');
                        Thread.Sleep(60);
                    }
                    Console.Write('_');
                }
            }
            enHP = 30; // возврат здоровья для следующего игрока
        }
    } // бой

    // меню
    static void StartGame()
    {
        Console.SetCursorPosition(centerX, centerY);
        Centertext("N - начать игру", centerY);
        Centertext("  L - загрузить последнее сохранение", centerY + 1);
        Centertext("Escape - выйти", centerY + 2);

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.N:
                GenerationMap();
                Move();
                break;
            case ConsoleKey.L:
                Loadgame();
                Move();
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Game";
        StartGame();
        Move();
    }

    static void Centertext(string text, int y) //  текст по середине
    {
        int centerX = Console.WindowWidth / 2 - text.Length / 2;
        Console.SetCursorPosition(centerX, y);
        Console.WriteLine(text);
    }
    //ntntnt
}