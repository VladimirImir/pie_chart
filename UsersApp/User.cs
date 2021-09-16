using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class User
    {
        public int id { get; set; }
        private string _login, _password, _email;

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public User()
        {

        }
        public User(string login, string password, string email)
        {
            this._login = login;
            this._password = password;
            this._email = email;
        }

        /*public override string ToString()
        {
            return $"Пользователь: {Login} Email: {Email} ";
            //return "Пользователь: " + Login + "Email: " + Email;
        }*/
    }
}
