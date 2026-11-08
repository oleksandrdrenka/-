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