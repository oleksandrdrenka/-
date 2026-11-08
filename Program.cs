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