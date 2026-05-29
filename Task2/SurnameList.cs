using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    // Класс, который управляет списком фамилий
    class SurnameList
    {
        private List<string> surnames;

        // Объявляем событие для сортировки
        public event Action<string[]> SortCompleted;

        public SurnameList()
        {
            surnames = new List<string>();
        }

        // Добавление фамилий
        public void AddSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException("Фамилия не может быть пустой");

            surnames.Add(surname);
        }

        // Метод для сортировки по возрастанию (А-Я)
        public void SortAscending()
        {
            surnames.Sort();
            OnSortCompleted("Сортировка А-Я выполнена");
        }

        // Метод для сортировки по убыванию (Я-А)
        public void SortDescending()
        {
            surnames.Sort();
            surnames.Reverse();
            OnSortCompleted("Сортировка Я-А выполнена");
        }

        // Вызов события
        protected virtual void OnSortCompleted(string message)
        {
            string[] surnamesArray = surnames.ToArray();
            SortCompleted?.Invoke(surnamesArray);
            Console.WriteLine($"\n{message}");
        }

        // Вывод списка фамилий
        public void DisplaySurnames()
        {
            Console.WriteLine("\nТекущий список фамилий:");
            for (int i = 0; i < surnames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {surnames[i]}");
            }
        }
    }
}
