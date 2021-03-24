using System;
using static ConsoleApp1.Menu;
using static ConsoleApp1.InputClass;
using static ConsoleApp1.DBConnect;
using static ConsoleApp1.AccountModel;
using System.IO;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пункт меню - ");
            int number;
            do {
                PrintMenu();
                number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1://
                    {
                        Console.Clear();
                        var res = InputAccount();
                        DBConnect dbEnterAccount = new DBConnect();
                        AccountModel accountModel = dbEnterAccount.EnterAccount(res.login, res.password);
                        if (Convert.ToInt32(accountModel.Id) > 0)
                        {
                            Console.WriteLine("Вход выполнен");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Проверьте корректность логина или пароля");
                        }
                    }
                        break;
                    case 2: //Регистрация
                    {
                        Console.Clear();
                        DBConnect dbCountRow = new DBConnect();
                        int countRow = dbCountRow.CountRow();
                        var resUsers = InputUser();
                        var resAccount = InputAccount();
                        DBConnect CheckLogin = new DBConnect();
                        if (CheckLogin.CheckLogin(resAccount.login))
                        {
                            DBConnect dbRegistrationAccount = new DBConnect();
                            DBConnect dbRegistrationUser = new DBConnect();
                            if (dbRegistrationAccount.RegistrationAccount(resAccount.login, resAccount.password) &&
                                dbRegistrationUser.RegistrationUser(resUsers.name, resUsers.email, resUsers.phone,
                                    resUsers.dateBirth, countRow + 1))
                                Console.WriteLine("Пользователь зарегистрирован");
                            else Console.WriteLine("Пользователь НЕ зарегистрирован");
                        }
                        else
                        {
                            Console.WriteLine("Пользователь уже зарегистрирован");
                        }
                    }
                        break;
                    case 3: //Восстановление пароля
                    {
                        Console.Clear();
                        var login =InputLogin();//ввод логина
                        Random rnd = new Random();
                        int value = rnd.Next(1000, 9999);
                        StreamWriter file = new StreamWriter("D:\\Programing\\UserAuthorization\\Random.txt");
                        file.Write(value);
                        file.Close();
                        int num = InputRandValue();//ввод числа
                        if (num == value)
                        {
                            var password = InputNewPassword();//ввод нового пароля
                            DBConnect dbChangePassword = new DBConnect();
                            dbChangePassword.NewPassword(login, password);
                        }
                        else
                        {
                            Console.WriteLine("Введенный код не верный");
                        }
                    }
                        break;
                }
            } while (number != 0);
        }
    }
}