using System;

namespace ConsoleApp1
{
    public class AccountModel
    {
        private string id;
        private string login;
        private string password;
        public AccountModel() { }
        public AccountModel(string id, string login, string password)
        {
            this.id=id;
            this.login=login;
            this.password=password;
        }
        public string Id
        {
            get
            {
                return id;
            }
        }
    }
}