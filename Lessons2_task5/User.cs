using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lessons2_task3;

namespace Lessons2_task5
{

    internal class Employee : User // Наследуем User для использования его свойств и методов
    {
        public string Position { get; set; } // Должность
        public int Experience
        {
            get
            {
                int years = DateTime.Now.Year - _dateEmployment.Year;
                if (DateTime.Now.Month < _dateEmployment.Month || (DateTime.Now.Month == _dateEmployment.Month && DateTime.Now.Day < _dateEmployment.Day))
                {
                    years--;
                }
                return years;
            }
        }

        private DateTime _dateEmployment;

        /// <summary>
        /// Конструктор для создания объекта класса Employee
        /// </summary>
        public Employee(string name, string subName, string midName, DateTime date, string position, DateTime dateEmployment)
               : base(name, subName, midName, date)
        {
            Position = position;
            _dateEmployment = dateEmployment;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"Должность: {Position}\n" +
                   $"Стаж работы (в годах): {Experience}\n";
        }

    }
}
