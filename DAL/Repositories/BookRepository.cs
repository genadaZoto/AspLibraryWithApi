using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ToolBox.Database;
using WebApiSampleConsume.Tools;
using WebApiSampleConsume.Tools.Models;

namespace DAL.Repositories
{
    public class BookRepository: BaseRepository<Book, int>
    {

        public BookRepository (string Cnstr): base(Cnstr)
        {
            SelectAllCommand = "SELECT * FROM Book";
            SelectOneCommand = "SELECT * FROM Book WHERE IdBook=@IdBook ";
            InsertCommand = "INSERT INTO Book(Title, Author, Category, Description, Image, ReleaseYear) OUTPUT inserted.IdBook VALUES (@Title, @Author, @Category, @Description, @Image, @ReleaseYear)";
            UpdateCommand = "UPDATE Book SET Title=@Title,Author=@Author,Category=@Category,Description=@Description,Image=@Image,ReleaseYear=@ReleaseYear WHERE IdBook=@IdBook";
            DeleteCommand = "DELETE FROM  Book WHERE IdBook=@IdBook";

        }

        public Book getBookFromApi()
        {
            OpenLibraryRequester ORequester = new OpenLibraryRequester();

            bookModel bm = ORequester.GetInfos("0781441900");

            if (bm != null)
            {
                Book b = new Book();
                foreach (var item in bm.authors)
                {
                    b.Author = b.Author + item.name + " ";
                }

                b.Title = bm.title;
                foreach (var item in bm.subjects)
                {
                    b.Category = b.Category + item.name + ",";
                }
                b.Description = bm.notes;
                b.Image = bm.cover.large;
                //b.ReleaseYear = int.Parse(bm.publish_date);
               
                Insert(b);
                return (b);

            }

            return null;

        }

        public override IEnumerable<Book> GetAll()
        {
            return base.getAll(Map);
        }

        //methode pour chercher les livre de l'utilisateur
        public IEnumerable<ReaderBooks> GetAllReaderBooks(Func<SqlDataReader, ReaderBooks> MapToMemberBooks, Dictionary<string, object> QueryParameters)
        {
            Command cmd = new Command(SelectAllCommand);
            if (QueryParameters != null)
            {
                foreach (KeyValuePair<string, object> item in QueryParameters)
                {
                    cmd.AddParameter(item.Key, item.Value);
                }
            }
            return base._oconn.ExecuteReader<ReaderBooks>(cmd, MapToMemberBooks);
        }

        public IEnumerable<Book> GetFromSearch(string search)
        {
            search = '%' + search + '%';
            SelectAllCommand = "SELECT * FROM Book WHERE title like @search or author like @search";
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("search", search);
            return base.getAll(Map, QueryParameters);


            //Command cmd = new Command($"SELECT * FROM Book WHERE title like '%{search}%' or author like '%{search}%'");
            //return base._oconn.ExecuteReader<Book>(cmd, Map);
        }


        public int getNbBooks()
        {
            Command cmd= new Command("SELECT count(*) FROM Book");
            return(int)base._oconn.ExecuteScalar(cmd);
        }


        public IEnumerable<Book> Paginate (int page, int nb = 8)
        {
            int toSkip = (page - 1) * nb;
            //Command cmd = new Command("SELECT * FROM Book ORDER BY IdBook ASC OFFSET @toSkip ROWS FETCH NEXT @nb ROWS ONLY");
            SelectAllCommand= "SELECT   * FROM Book order by IdBook  OFFSET @toSkip ROWS FETCH NEXT @nb  ROWS ONLY";
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("toSkip", toSkip);
            QueryParameters.Add("nb", nb);

            return base.getAll(Map, QueryParameters);
        }





        public override Book GetOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdBook", id);
            return base.getOne(Map, Parameters);
        }

        public override Book Insert(Book toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdBook = id;
            return toInsert;
        }

        public override bool Update(Book toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdBook", id);
            return base.Delete(Parameters);
        }

        public IEnumerable<ReaderBooks> GetBooksFromReader(int idReader)
        {
            SelectAllCommand = @"SELECT Book.*, ReservationDate FROM BookReservation 
                                INNER JOIN BookCopy ON BookCopy.IdBookCopy = BookReservation.IdBookCopy
                                INNER JOIN Book ON Book.IdBook = BookCopy.IdBook 
                                WHERE IdReader = @idReader";
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("IdReader", idReader);
            return GetAllReaderBooks(MapToMemberBooks, QueryParameters);
        }

        private Dictionary<string, object> MapToDico(Book toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["IdBook"] = toInsert.IdBook;
            p["Title"] = toInsert.Title;
            p["Author"] = toInsert.Author;
            p["Category"] = toInsert.Category;
            p["Description"] = toInsert.Description;
            p["Image"] = toInsert.Image;
            p["ReleaseYear"] = toInsert.ReleaseYear;
            return p;
        }

        private Book Map(SqlDataReader p)
        {
            return new Book()
            {
                IdBook = (int)p["IdBook"],
                Title = p["Title"].ToString(),
                Author = p["Author"].ToString(),
                Category = p["Category"].ToString(),
                Description = p["Description"].ToString(),
                Image = p["Image"].ToString(),
                ReleaseYear = (int)p["ReleaseYear"],
            };
        }

        private ReaderBooks MapToMemberBooks(SqlDataReader p)
        {
            return new ReaderBooks()
            {
                IdBook = (int)p["IdBook"],
                Title = p["Title"].ToString(),
                Author = p["Author"].ToString(),
                Category = p["Category"].ToString(),
                Description = p["Description"].ToString(),
                Image = p["Image"].ToString(),
                ReleaseYear = (int)p["ReleaseYear"],
                ReservationDate = (DateTime)p["ReservationDate"]
            };
        }

    }
}
