using System;

namespace ConsoleApp1
{
    public class InputClass
    {
        public static (string login, string password) InputAccount()
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            return (login, password);
        }
        public static (string name, string dateBirth, string email, string phone) InputUser()
        {
            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            string dateBirth = Console.ReadLine();
            Console.WriteLine("Введите электронную почту");
            string email = Console.ReadLine();
            Console.WriteLine("Введите номер телефона (необязательно)");
            string phone = Console.ReadLine();
            return (name, dateBirth, email, phone);
        }

        public static string InputLogin()
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            return login;
        }
    }
}