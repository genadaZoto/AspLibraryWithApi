using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReaderRepository : BaseRepository<Reader, int>
    {
        public ReaderRepository(string Cnstr) : base(Cnstr)
        {
            SelectOneCommand = "Select * from Reader where idReader=@idReader";
            SelectAllCommand = "Select * from Reader";
            InsertCommand = @"INSERT INTO  Reader (Name, Surname, Email, Adress, Password)
                            OUTPUT inserted.idReader VALUES(@Name, @Surname, @Email, @Adress,@Password)";
            UpdateCommand = @"UPDATE  Reader
                           SET Name = @Name,  Surname = @Surname,  Email= @Email, Adress = @Adress,  Password = @Password
                         WHERE IdReader = @IdReader ;";
            DeleteCommand = @"Delete from  Reader   WHERE IdReader  = @IdReader ;";
        }
        public Reader VerifLogin(Reader reader)
        {
            SelectOneCommand = "Select * from Reader where Email=@Email and Password=@Password";
            return base.getOne(Map, MapToDico(reader));
        }

        public override IEnumerable<Reader> GetAll()
        {
            return base.getAll(Map);
        }

        public override Reader GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idReader", id);
            return base.getOne(Map, QueryParameters);
        }

        public override Reader Insert(Reader toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdReader = id;
            return toInsert;
        }

        public override bool Update(Reader toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@IdReader", id);
            return base.Delete(QueryParameters);
        }

        private Dictionary<string, object> MapToDico(Reader toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idReader"] = toInsert.Id;
            p["Name"] = toInsert.Name;
            p["Surname"] = toInsert.Surname;
            p["Adress"] = toInsert.Adress;
            p["Email"] = toInsert.Email;
            p["Password"] = toInsert.HashMDP;
            return p;
        }

        private Reader Map(SqlDataReader arg)
        {
            return new Reader()
            {
                IdReader = (int)arg["idReader"],
                Name = arg["Name"].ToString(),
                Surname= arg["Surname"].ToString(),
                Email= arg["Email"].ToString(),
                Adress = arg["Adress"].ToString()
                //WE CAN'T STORE PASSWORD FROM DB
                // Password= arg["Password"].ToString()
            };
        }


    }
}
