using DAL.Infra;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;

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

        //Methode qui n'existe pas dans baserepository, il faut la créer ici parce que j'ai besoin que dans cette model
        public int getTotal(Func<SqlDataReader, BookCopy> callBack,
            Dictionary<string, object> QueryParameters = null)
        {
            Command cmd = new Command(SelectAllCommand);
            if (QueryParameters != null)
            {
                foreach (KeyValuePair<string, object> item in QueryParameters)
                {
                    cmd.AddParameter(item.Key, item.Value);
                }
            }
            return (int)_oconn.ExecuteScalar(cmd);
        }
        public int getNbBookCopy(int idBook)
        {
            SelectAllCommand = "SELECT COUNT(*) from bookcopy where bookcopy.Available= 1 and BookCopy.IdBook = @idBook";
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idBook", idBook);
            return getTotal(Map, QueryParameters);

            //Command cmd = new Command("SELECT COUNT(*) from bookcopy where bookcopy.Available= 1 and BookCopy.IdBook = idBook");
            //return (int)base._oconn.ExecuteScalar(cmd);
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


