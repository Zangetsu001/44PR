using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество студентов: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некорректное количество студентов.");
                return;
            }

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВвод данных для студента #{i + 1}:");
                Student student = new Student();

                Console.Write("Введите ФИО студента: ");
                student.FullName = Console.ReadLine();

                Console.Write("Введите группу: ");
                student.Group = Console.ReadLine();

                student.Informatics = ReadGrades("информатике");
                student.Physics = ReadGrades("физике");
                student.History = ReadGrades("истории");

                students.Add(student);
            }

            Console.WriteLine("\nВведённые данные студентов:");
            foreach (var student in students)
            {
                student.Print();
                Console.WriteLine();
            }

            Console.Read();
        }

            static List<int> ReadGrades(string subject)
        {
            Console.WriteLine($"Введите оценки по {subject} через пробел (например: 5 4 3), или оставьте пустым:");
            string input = Console.ReadLine();
            List<int> grades = new List<int>();

            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts)
                {
                    if (int.TryParse(part, out int grade))
                        grades.Add(grade);
                }
            }

            return grades;
        }

    }
}
