using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Library.Areas.Member.Models
{
    public class ProfileModel
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
                _name = value;
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
        public string Photo
        {
            get
            {
                return GetPhoto();
            }

        }
        private string GetPhoto()
        {
            string folderpath = System.Web.Hosting.HostingEnvironment.MapPath("~/Photos/");
            string[] PicturesFiles = Directory.GetFiles(folderpath, IdReader + ".*");

            if (PicturesFiles.Count()>0)
            {
                FileInfo i = new FileInfo(PicturesFiles[0]);

                return "/Photos/" + i.Name;
            }
            else
            {
                return "";
            }
        }
        
    }
}
