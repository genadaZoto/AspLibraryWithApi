using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Models 
{
    public partial class Reader : IEntity<int>
    {
        private int _idReader;
        private string _name;
        private string _surname;
        private string _email;
        private string _adress;
        private string _password;

        public int IdReader
        {
            get
            {
                return _idReader;
            }

            set
            {
                _idReader = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name= value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = value;
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
        public string Adress
        {
            get
            {
                return _adress;
            }

            set
            {
                _adress= value;
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
        public int Id
        {
            get
            {
                return _idReader;
            }
        }

        public string HashMDP
        {
            get
            {
                if (_password == null) throw new InvalidOperationException("The password is empty");
                using (SHA512 sha512Hash = SHA512.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(_password);
                    byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                    return hash;
                }
            }
           
        }

    }
}
