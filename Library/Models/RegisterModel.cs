using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class RegisterModel
    {
  
        private string _name;
        private string _surname;
        private string _email;
        private string _adress;
        private string _password;
        private string _confirmPassword;


        [Required(ErrorMessage = "Please enter your name!")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        [Required]
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

        [Required]
        [DataType(DataType.EmailAddress)]
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
        [Required]
        public string Adress
        {
            get
            {
                return _adress;
            }

            set
            {
                _adress = value;
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

        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
            }
        }

    }
}

  