using System;
using MySql.Data.MySqlClient;
using static ConsoleApp1.AccountModel;


namespace ConsoleApp1
{
    public class DBConnect
    {
        string conn_str = "Server=mysql60.hostland.ru;Database=host1323541_itstep37;Uid=host1323541_itstep;Pwd=269f43dc;";
        private MySqlConnection connection;
        public DBConnect()
        {
            //подключение к БД
            connection = new MySqlConnection(conn_str);
            connection.Open();
        }
        public int CountRow()
        {
            var sql = $"SELECT COUNT(*) FROM table_users;"; 
            var command = new MySqlCommand 
            {
                Connection = connection, CommandText = sql
            }; 
            var result = command.ExecuteReader();
            int countRow = 0;
            while (result.Read())
            {
                countRow = Convert.ToInt32(result.GetValue(0));
            }
            connection.Close();
            return countRow;
        }
        public bool RegistrationAccount(string login,string password)
        {
            var sql = $"INSERT INTO host1323541_itstep37.table_account (login, password) VALUES ('{login}', '{password}');";
            var commandAccount = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var resultAccount = commandAccount.ExecuteNonQuery();
            if (resultAccount == 0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }
        public bool RegistrationUser(string name,string email,string phone,string date_birth,int account_id)
        {
            var sql =
                $"INSERT INTO host1323541_itstep37.table_users (name, email, phone, date_birth, account_id)" +
                $" VALUES ('{name}', '{email}', '{phone}', '{date_birth}', {account_id});";
            var commandUser = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var resultUser = commandUser.ExecuteNonQuery();
            if (resultUser==0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }

        public bool CheckLogin(string login)
        {
            var sql = $"SELECT id FROM table_account WHERE login = '{login}';";
            var command = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var result = command.ExecuteReader();
            int id = 0;
            while (result.Read())
            {
                id= Convert.ToInt32(result.GetString("id"));
            }
            connection.Close();
            if (id > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public AccountModel EnterAccount(string login, string password)
        {
            var sql = $"SELECT id, login, password FROM host1323541_itstep37.table_account WHERE login = '{login}' AND password = '{password}';";
            AccountModel accountModel = new AccountModel();
            var command = new MySqlCommand
            {
                Connection = connection, CommandText = sql
            };
            var result = command.ExecuteReader();
            while (result.Read())
            {
                var tempId= result.GetString("id");
                var tempLogin = result.GetString("login");
                var tempPassword = result.GetString("password");
                accountModel = new AccountModel (tempId, tempLogin, tempPassword);
            }
            connection.Close();
            return accountModel;
        }

        public bool NewPassword(string login, string password)
        {
            var sql = $"UPDATE host1323541_itstep37.table_account t SET t.password = '{password}' WHERE t.login = '{login}'";
            var command = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var result = command.ExecuteNonQuery();
            if (result==0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }

    }
}