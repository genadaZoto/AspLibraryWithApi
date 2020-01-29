using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Models
{
    public partial class Book: IEntity<int>
    {
        private int _idBook;
        private string _title;
        private string _author;
        private string _category;
        private string _description;
        private string _image;
        private int _releaseYear;

      

        public int IdBook
        {
            get
            {
                return _idBook;
            }

            set
            {
                _idBook = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = value;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
            }
        }
        public int ReleaseYear
        {
            get
            {
                return _releaseYear;
            }

            set
            {
                _releaseYear = value;
            }
        }

        public int Id
        {
            get
            {
                return IdBook;
            }
        }
    }
}
