using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Models
{
    public partial class BookCopy : IEntity<int>
    {
        private int _idBookCopy;
        private bool _available;
        private int _idBook;

        public int IdBookCopy
        {
            get
            {
                return _idBookCopy;
            }

            set
            {
                _idBookCopy = value;
            }
        }
        public bool Available
        {
            get
            {
                return _available;
            }

            set
            {
                _available = value;
            }
        }

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

        public Book Book { get; set; }

        public int Id
        {
            get
            {
                return IdBookCopy;
            }
        }

    }
}
