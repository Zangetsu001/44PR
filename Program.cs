using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Введите количество товаров: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некорректное количество. Завершение программы.");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВведите данные для товара #{i + 1}:");

                Console.Write("Наименование: ");
                string name = Console.ReadLine();

                Console.Write("Изготовитель: ");
                string manufacturer = Console.ReadLine();

                Console.Write("Количество: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                {
                    Console.WriteLine("Некорректное количество. Попробуйте заново.");
                    i--;
                    continue;
                }

                Console.Write("Цена: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
                {
                    Console.WriteLine("Некорректная цена. Попробуйте заново.");
                    i--;
                    continue;
                }

                Console.Write("Год выпуска: ");
                if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
                {
                    Console.WriteLine("Некорректный год выпуска. Попробуйте заново.");
                    i--;
                    continue;
                }

                products.Add(new Product
                {
                    Name = name,
                    Manufacturer = manufacturer,
                    Quantity = quantity,
                    Price = price,
                    Year = year
                });
            }

            int currentYear = DateTime.Now.Year;


            var productsCurrentYear = products.Where(p => p.Year == currentYear).ToList();

            decimal totalCostCurrentYear = productsCurrentYear.Sum(p => p.TotalCost);

            Console.WriteLine($"\nОбщая стоимость товаров, выпущенных в {currentYear}: {totalCostCurrentYear}");

            Console.WriteLine("Сведения о товарах, выпущенных в текущем году:");
            foreach (var p in productsCurrentYear)
            {
                Console.WriteLine($"Наименование: {p.Name}, Изготовитель: {p.Manufacturer}, Кол-во: {p.Quantity}, Цена: {p.Price}, Год: {p.Year}, Общая стоимость: {p.TotalCost}");
            }


            if (products.Count > 0)
            {
                decimal maxTotalCost = products.Max(p => p.TotalCost);
                decimal minTotalCost = products.Min(p => p.TotalCost);

                var maxCostProducts = products.Where(p => p.TotalCost == maxTotalCost);
                var minCostProducts = products.Where(p => p.TotalCost == minTotalCost);

                Console.WriteLine("\nТовары с максимальной общей стоимостью:");
                foreach (var p in maxCostProducts)
                {
                    Console.WriteLine($"{p.Name} - Общая стоимость: {p.TotalCost}");
                }

                Console.WriteLine("\nТовары с минимальной общей стоимостью:");
                foreach (var p in minCostProducts)
                {
                    Console.WriteLine($"{p.Name} - Общая стоимость: {p.TotalCost}");
                }
            }
            else
            {
                Console.WriteLine("Список товаров пуст.");
            }
            Console.Read();
        }
        
        
    }
}
