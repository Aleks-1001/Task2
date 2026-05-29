using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Программа сортировки фамилий ===\n");

            // Создаем список и добавляем 5 фамилий
            SurnameList surnameList = new SurnameList();

            // Добавляем фамилии
            surnameList.AddSurname("Иванов");
            surnameList.AddSurname("Петров");
            surnameList.AddSurname("Сидоров");
            surnameList.AddSurname("Алексеев");
            surnameList.AddSurname("Кузнецов");

            // Подписываемся на событие сортировки
            surnameList.SortCompleted += OnSortCompleted;

            // Показываем начальный список
            surnameList.DisplaySurnames();

            bool continueSorting = true;

            while (continueSorting)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Сортировка А-Я");
                Console.WriteLine("2 - Сортировка Я-А");
                Console.WriteLine("3 - Выход");
                Console.Write("Ваш выбор: ");

                try
                {
                    string input = Console.ReadLine();

                    // Проверяем ввод с помощью нашего исключения
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new InvalidInputException("Ошибка: Ввод не может быть пустым!");
                    }

                    if (!int.TryParse(input, out int choice))
                    {
                        throw new InvalidInputException("Ошибка: Необходимо ввести число 1, 2 или 3!");
                    }

                    switch (choice)
                    {
                        case 1:
                            surnameList.SortAscending();
                            break;
                        case 2:
                            surnameList.SortDescending();
                            break;
                        case 3:
                            continueSorting = false;
                            Console.WriteLine("Программа завершена.");
                            break;
                        default:
                            throw new InvalidInputException("Ошибка: Неверный выбор! Введите 1, 2 или 3.");
                    }
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"\nОшибка ввода: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nНепредвиденная ошибка: {ex.Message}");
                }
                finally
                {
                    if (continueSorting && (surnameList != null))
                    {
                        Console.WriteLine("\n--- Блок finally выполнен ---");
                        surnameList.DisplaySurnames();
                    }
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Обработчик события сортировки
        static void OnSortCompleted(string[] surnames)
        {
            Console.WriteLine("\nРезультат сортировки:");
            for (int i = 0; i < surnames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {surnames[i]}");
            }
        }
    }
}
      