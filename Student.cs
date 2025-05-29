using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    struct Student
    {
        public string FullName;
        public string Group;
        public List<int> Informatics;
        public List<int> Physics;
        public List<int> History;

        public double GetSubjectAverage(List<int> grades)
        {
            if (grades == null || grades.Count == 0) return 0;
            return grades.Average();
        }

        public double GetOverallAverage()
        {
            List<int> all = new List<int>();
            if (Informatics != null) all.AddRange(Informatics);
            if (Physics != null) all.AddRange(Physics);
            if (History != null) all.AddRange(History);

            return all.Count > 0 ? all.Average() : 0;
        }

        public void Print()
        {
            Console.WriteLine("\nИнформация о студенте:");
            Console.WriteLine($"ФИО: {FullName}");
            Console.WriteLine($"Группа: {Group}");
            Console.WriteLine($"Оценки по информатике: {Stringify(Informatics)} (средний: {GetSubjectAverage(Informatics):F2})");
            Console.WriteLine($"Оценки по физике: {Stringify(Physics)} (средний: {GetSubjectAverage(Physics):F2})");
            Console.WriteLine($"Оценки по истории: {Stringify(History)} (средний: {GetSubjectAverage(History):F2})");
            Console.WriteLine($"Общий средний балл: {GetOverallAverage():F2}");
        }

        private string Stringify(List<int> list)
        {
            return list != null && list.Count > 0 ? string.Join(", ", list) : "нет данных";
        }
    }
}
    