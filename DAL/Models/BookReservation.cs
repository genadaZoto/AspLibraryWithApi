using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Infra;

namespace DAL.Models
{
    public partial class BookReservation: IEntity<CompositeKey<int, int>>
    {
        private int _idBookCopy;
        private int _idReader;
        private DateTime _reservationDate;

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

        public Reader Reader { get; set; }
        public BookCopy BookCopy { get; set; }

        public CompositeKey<int, int> Id
        {
            get
            {
                return new CompositeKey<int, int>() { PK1 = IdReader, PK2 = IdBookCopy };
            }
        }
    }
}
