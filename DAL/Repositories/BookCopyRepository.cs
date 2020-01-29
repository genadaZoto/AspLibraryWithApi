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
    public class BookCopyRepository : BaseRepository<BookCopy, int>
    {
        public BookCopyRepository(string Cnstr) : base(Cnstr)
        {
            SelectAllCommand = "SELECT * FROM BookCopy";
            SelectOneCommand = "SELECT * FROM BookCopy WHERE IdBookCopy=@IdBookCopy ";
            InsertCommand = "INSERT INTO BookCopy(Available, IdBook) OUTPUT inserted.IdBookCopy VALUES (@Available, @IdBook)";
            UpdateCommand = "UPDATE BookCopy SET Available=@Available,IdBook=@IdBook WHERE IdBookCopy=@IdBookCopy";
            DeleteCommand = "DELETE FROM  BookCopy WHERE IdBookCopy=@IdBookCopy";
        }

        public override IEnumerable<BookCopy> GetAll()
        {
            return base.getAll(Map);
        }

        public override BookCopy GetOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdBookCopy", id);
            return base.getOne(Map, Parameters);
        }

        public override BookCopy Insert(BookCopy toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdBookCopy = id;
            return toInsert;
        }

        public override bool Update(BookCopy toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdBookCopy", id);
            return base.Delete(Parameters);
        }



        private Dictionary<string, object> MapToDico(BookCopy toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["IdBookCopy"] = toInsert.IdBookCopy;
            p["Available"] = toInsert.Available;
            p["IdBook"] = toInsert.IdBook;
            return p;
        }

        private BookCopy Map(SqlDataReader p)
        {
            return new BookCopy()
            {
                IdBookCopy = (int)p["IdBookCopy"],
                Available =(bool) p["Available"],
                IdBook = (int)p["IdBook"]
            };
        }

    }
}


