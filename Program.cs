using System;
using System.Text;

namespace MusicCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо UTF-8 для коректного виведення кирилиці
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool running = true;

            while (running)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("        СИСТЕМА ОБЛІКУ «МУЗИЧНА КОЛЕКЦІЯ»        ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1 — Про програму та структуру сутності");
                Console.WriteLine("2 — Табулювання: розрахунок обсягу треку від часу");
                Console.WriteLine("3 — Зведена таблиця прослуховувань (два входи)");
                Console.WriteLine("4 — Показати всі треки (лаб. 10)");
                Console.WriteLine("5 — Додати новий трек (лаб. 10)");
                Console.WriteLine("6 — Пошук треку за параметрами (лаб. 11)");
                Console.WriteLine("7 — Зберегти базу у файл (лаб. 15)");
                Console.WriteLine("8 — Завантажити базу з файлу (лаб. 15)");
                Console.WriteLine("0 — Вихід із програми");
                Console.WriteLine("==================================================");
                Console.Write("Оберіть пункт меню: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAbout();
                        Pause();
                        break;

                    case "2":
                        ShowTabulation();
                        Pause();
                        break;

                    case "3":
                        ShowTwoDimensionalTable();
                        Pause();
                        break;

                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Console.WriteLine("Функціонал знаходиться на стадії розробки (буде реалізовано в наступних лабораторних).");
                        Pause();
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("Роботу застосунку завершено. До побачення!");
                        break;

                    default:
                        Console.WriteLine("Помилка: пункту з таким номером не існує. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }
        // Пауза перед поверненням у меню
        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey(true);
            Console.Clear();
        }

        // Пункт 1: Довідка про проєкт і сутність
        static void ShowAbout()
        {
            Console.WriteLine("=== ДОВІДКА ПРО ПРОЄКТ ===");
            Console.WriteLine("Тема: Музична колекція (Варіант №7)");
            Console.WriteLine("Головна сутність: Трек");
            Console.WriteLine("Довідник: Жанр (код, назва, чи активний)");
            Console.WriteLine("Підсумкова величина: загальна тривалість колекції та топ-5 за прослуховуваннями.\n");

            Console.WriteLine("Поля сутності «Трек»:");
            Console.WriteLine("1. int                     код                    (призначається автоматично)");
            Console.WriteLine("2. string                  виконавець             (не порожній рядок)");
            Console.WriteLine("3. string                  назва                  (не порожній рядок)");
            Console.WriteLine("4. string                  альбом                 (назва альбому/синглу)");
            Console.WriteLine("5. int                     рік                    (від 1900 до поточного)");
            Console.WriteLine("6. int                     тривалість             (у секундах, > 0)");
            Console.WriteLine("7. int                     код жанру              (ідентифікатор з довідника)");
            Console.WriteLine("8. int                     кількість прослуховувань (ціле невід'ємне число)");
        }
        // Пункт 2: Табулювання функції (Рівень А)
        // Розрахунок орієнтовного розміру нестисненого аудіо (WAV 16-bit 44.1kHz Stereo ≈ 10.09 МБ/хв)
        static void ShowTabulation()
        {
            Console.WriteLine("=== ТАБУЛЮВАННЯ ФУНКЦІЇ ===");
            Console.WriteLine("Залежність обсягу нестисненого аудіофайлу (WAV, 44.1 кГц / 16 біт) від тривалості треку:\n");

            double fromMinutes = 1.0;
            double toMinutes = 5.5;
            double step = 0.5;
            const double MegabytesPerMinute = 10.094;

            Console.WriteLine("+----------------------+----------------------+");
            Console.WriteLine("| Тривалість t (хв)    | Орієнтовний обсяг MB |");
            Console.WriteLine("+----------------------+----------------------+");

            // Використовуємо 1e-9 для запобігання втрати останньої ітерації через неточність double
            for (double t = fromMinutes; t <= toMinutes + 1e-9; t += step)
            {
                double sizeMb = t * MegabytesPerMinute;
                Console.WriteLine($"| {t,20:F2} | {sizeMb,20:F2} |");
            }

            Console.WriteLine("+----------------------+----------------------+");
        }
        // Пункт 3: Таблиця з двома входами та підсумками (Рівень А + Рівень Б)
        static void ShowTwoDimensionalTable()
        {
            Console.WriteLine("=== ЗВЕДЕНА ТАБЛИЦЯ ПРОСЛУХОВУВАНЬ (ЗА ДВА ВХОДИ) ===");
            Console.WriteLine("Моделювання розподілу кількості прослуховувань треків за жанрами та днями тижня.\n");

            Console.Write("Введіть кількість категорій жанрів (рядків, від 1 до 10): ");
            string rowsInput = Console.ReadLine();
            bool rowsOk = int.TryParse(rowsInput, out int rowCount);

            Console.Write("Введіть кількість періодів/днів (стовпців, від 1 до 7): ");
            string colsInput = Console.ReadLine();
            bool colsOk = int.TryParse(colsInput, out int colCount);

            // Перевірка коректності введення користувача
            if (!rowsOk || !colsOk || rowCount <= 0 || colCount <= 0 || rowCount > 10 || colCount > 7)
            {
                Console.WriteLine("\nПомилка: введено некоректні межі таблиці (мають бути додатні цілі числа у розумних межах).");
                return;
            }

            Console.WriteLine();

            // Виведення шапки таблиці
            Console.Write($"{"Жанр \\ День",-15}");
            for (int col = 1; col <= colCount; col++)
            {
                Console.Write($"{"День " + col,10}");
            }
            Console.WriteLine($"{"Підсумок",12}");

            // Розділювальна лінія
            PrintSeparator(15 + colCount * 10 + 12);

            int grandTotal = 0;

            // Зовнішній цикл — рядки
            for (int row = 1; row <= rowCount; row++)
            {
                int rowSum = 0;
                Console.Write($"{"Жанр #" + row,-15}");

                // Внутрішній цикл — стовпці
                for (int col = 1; col <= colCount; col++)
                {
                    // Детермінована формула для навчальної імітації значень прослуховувань
                    int value = (row * 17 + col * 29) % 150 + 20;
                    rowSum += value;
                    Console.Write($"{value,10}");
                }

                // Виведення підсумку рядка
                Console.WriteLine($"{rowSum,12}");
                grandTotal += rowSum;
            }

            // Розділювальна лінія перед підсумковим рядком
            PrintSeparator(15 + colCount * 10 + 12);

            // Рівень Б: обчислення та виведення підсумків по кожному стовпцю
            Console.Write($"{"Підсумок дня",-15}");

            for (int col = 1; col <= colCount; col++)
            {
                int colSum = 0;
                // Підсумовуємо всі рядки для поточного стовпця
                for (int row = 1; row <= rowCount; row++)
                {
                    int value = (row * 17 + col * 29) % 150 + 20;
                    colSum += value;
                }
                Console.Write($"{colSum,10}");
            }

            // Загальний підсумок у правому нижньому кутку
            Console.WriteLine($"{grandTotal,12}");
            PrintSeparator(15 + colCount * 10 + 12);
        }

        static void PrintSeparator(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}