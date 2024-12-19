using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCoreLib
{
    public class Analytics
    {
        class DateTimeWithCounter
        {
            public DateTime DateTimeProp;
            public int Counter = 0;

            public DateTimeWithCounter(DateTime date) //Создание конструктора
            {
                DateTimeProp = date;
                Counter = 1;
            }
        }

        public List<DateTime> PopularMonths(List<DateTime> dates)
        {
            var DateTimeWithCounterList = new List<Tuple<DateTime, int>>(); //Временный список объектов "ДатаСоСчётчиком"

            int PreviousYear = DateTime.Now.Year - 1;
            foreach (DateTime IterDate in dates)
            {
                if (IterDate.Year == PreviousYear)
                {
                    // Вычисление начала месяца для текущей даты
                    var DateMonthStart = new DateTime(
                        IterDate.Year, // Год
                        IterDate.Month, // Месяц
                        1, 0, 0, 0); // День

                    // Ищем такую дату во временном списке
                    var index = DateTimeWithCounterList.FindIndex(item => item.Item1 == DateMonthStart);

                    if (index == -1)
                    {
                        DateTimeWithCounterList.Add(new Tuple<DateTime, int>(DateMonthStart, 1));
                    }
                    else
                    {
                        DateTimeWithCounterList[index] = Tuple.Create(DateTimeWithCounterList[index].Item1,
                        DateTimeWithCounterList[index].Item2 + 1);
                    }
                }


            }

            return DateTimeWithCounterList
                .OrderByDescending(item => item.Item2) // Сорт по убыванию
                .ThenBy(item => item.Item1) // Сорт по следующему параметру
                .Select(item => item.Item1) // Выбор нужного
                .ToList(); // Список

        }
    }


}
