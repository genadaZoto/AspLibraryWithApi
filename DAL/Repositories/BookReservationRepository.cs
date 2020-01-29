using DAL.Infra;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookReservationRepository : BaseRepository<BookReservation, CompositeKey<int, int>>
    {
        public BookReservationRepository(string Cnstr) : base(Cnstr)
        {
            SelectAllCommand = "SELECT * FROM BookReservation";
            SelectOneCommand = "SELECT * FROM BookReservation WHERE IdBookCopy=@IdBookCopy AND IdReader=@IdReader ";
            InsertCommand = "INSERT INTO BookReservation(IdBookCopy,IdReader,ReservationDate) VALUES (@IdBookCopy,@IdReader,@ReservationDate)";
            UpdateCommand = "UPDATE BookReservation SET IdBookCopy=@IdBookCopy, IdReader=@IdReader,ReservationDate=@ReservationDate WHERE IdBookCopy=@IdBookCopy AND IdReader=@IdReader";
            DeleteCommand = "DELETE FROM  BookReservation WHERE IdBookCopy=@IdBookCopy AND IdReader=@IdReader";
        }


        public override IEnumerable<BookReservation> GetAll()
        {
            return base.getAll(Map);
        }


        public override BookReservation GetOne(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdBookCopy", id.PK1);
            Parameters.Add("IdReader", id.PK2);
            return base.getOne(Map, Parameters);
        }

        public override BookReservation Insert(BookReservation toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            base.Insert(Parameters);
            return toInsert;
        }
        public  int InsertWithBook(int IdReader, int IdBook, DateTime ReservationDate)
        {
            InsertCommand = "Exec InsertBookOfReader  @IdBook, @IdReader, @ReservationDate";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdReader", IdReader);
            Parameters.Add("IdBook", IdBook);
            Parameters.Add("ReservationDate", ReservationDate);
            return base.Insert(Parameters);
        }

        public override bool Update(BookReservation toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdBookCopy", id.PK1);
            Parameters.Add("IdReader", id.PK2);
            return base.Delete(Parameters);
        }

       

        private Dictionary<string, object> MapToDico(BookReservation toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["_idReader"] = toInsert.IdReader;
            p["IdBookCopy"] = toInsert.IdBookCopy;
            p["ReservationDate"] = toInsert.ReservationDate;
            return p;
        }

        private BookReservation Map(SqlDataReader p)
        {
            return new BookReservation()
            {

                IdReader = (int)p["IdReader"],
                IdBookCopy = (int)p["IdBookCopy"],
                ReservationDate = (DateTime)p["ReservationDate"]

            };
        }

    }
}
