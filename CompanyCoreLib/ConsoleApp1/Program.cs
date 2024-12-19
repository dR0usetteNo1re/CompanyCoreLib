
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCoreLib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) // Пример работы созданной библиотеки
        {
            var analytics = new Analytics();

            var srcDates = new List<DateTime>()
            {
                /* 
                На вход подаю несколько дат для более наглядного примера: 
                Самым популярным будет ноябрь (11)
                На втором месте по популярности будет август (8)
                И декабрь (12) на последнем по популярности месте 
                */

                new DateTime(2023, 8, 12, 0, 0, 0),
                new DateTime(2023, 8, 11, 0, 0, 0),
                new DateTime(2023, 12, 10, 0, 0, 0),
                new DateTime(2023, 11, 11, 0, 0, 0),
                new DateTime(2023, 11, 11, 0, 0, 0),
                new DateTime(2023, 11, 7, 0, 0, 0),
            };

            var outDates = analytics.PopularMonths(srcDates);

            foreach (var date in outDates)
            {
                Console.WriteLine(date.ToString());
            }
            Console.ReadLine();
        }
    }
}
