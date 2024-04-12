using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task3
{
    public class User
    {     

        private string name;
        private string subName;
        private string midName;
        private DateTime date;

        public string Name 
        { 
            get 
            { 
                return name; 
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value)) 
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Ошибка в имени");
                }
            }

        }
        public string SubName
        {
            get
            {
                return subName;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    subName = value;
                }
                else
                {
                    throw new ArgumentException("Ошибка в фамилии");
                }
            }
        }
        public string MidName
        {
            get
            {
                return midName;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    midName = value;
                }
                else
                {
                    throw new ArgumentException("Ошибка в отчестве");
                }
            }
        }
        public DateTime Date { get { return date; } }

        public int Age
        {
            get
            {

                DateTime currentDate = DateTime.Now;
                int age = currentDate.Year - date.Year;

                // Проверка, был ли уже день рождения в текущем году
                if (date.Month > currentDate.Month || (date.Month == currentDate.Month && date.Day > currentDate.Day))
                {
                    age--;
                }

                return age;

            }
        }
        /// <summary>
        /// Конструктор для создания объекта класса User
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subName"></param>
        /// <param name="midName"></param>
        /// <param name="date"></param>
        /// <param name="age"></param>
        public User(string name, string subName, string midName, DateTime date)
        {

            Name = name;
            SubName = subName;
            MidName = midName;
            this.date = date;
           
            if ((DateTime.Now.Year - date.Year) > 101)
            {
                throw new ArgumentException("Слишком старый пользователь");
            }

        }

        public override string ToString()
        {
            return $"Имя пользователя: {Name}\n" +
                   $"Фамилия пользователя: {SubName}\n" +
                   $"Отчество пользователя: {MidName}\n" +
                   $"Дата Рождения: {Date.ToString("dd.MM.yyyy")}\n" +
                   $"Полных лет: {Age}\n";
        }

        public static User Changing(User sourseUser, string name)
        {
            User user = new User(name, sourseUser.SubName, sourseUser.MidName, sourseUser.Date);

            Console.WriteLine(user);

            return user;
        }

        public static User NameChanging(User sourceUser, string name)
        {
            sourceUser.Name = name;
            return sourceUser;
        }

    }
}
