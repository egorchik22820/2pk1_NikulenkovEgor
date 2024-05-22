using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikulenkovLibrary
{
    public class Users : IComparable<Users>
    {
        public string _name;
        public string _surname;
        public string _email;
        public string _password;
        public DateTime CreationTime { get; private set; } = DateTime.Now;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// для корректной десиреализации обязательно
        /// должен присутствовать конструктор без параметров
        /// </summary>
        public Users() { }
        public Users(string name, string surname, string email, string password)
        {
            CreationTime = DateTime.Now;
            this._name = name;
            this._surname = surname;
            this._email = email;
            this._password = password;
        }
        public Users(string email, string password)
        {
            this._email = email;
            this._password = password;
        }
        public override string ToString()
        {
            return $"{_name} : {_surname} : {_email} : {_password}";
        }

        public int CompareTo(Users other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Name.CompareTo(other.Name);
        }
    }
}