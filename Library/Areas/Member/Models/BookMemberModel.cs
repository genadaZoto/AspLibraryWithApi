using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Library.Areas.Member.Models
{
    public class BookMemberModel
    {
        private int _idBook;
        private string _title;
        private string _author;
        private string _category;
        private string _description;
        private DateTime _reservationDate;
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
        public DateTime ReservationDate
        {
            get
            {
                return _reservationDate;
            }

            set
            {
                _reservationDate = value;
            }
        }

    }
}

