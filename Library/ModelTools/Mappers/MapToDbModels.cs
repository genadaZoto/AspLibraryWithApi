using DAL.Models;
using Library.Areas.Member.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.ModelTools.Mappers
{
    public static class MapToDbModels
    {
        public static BookModel BookToBookModel (Book b)
        {
            return new BookModel()
            {
                IdBook = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category,
                Description = b.Description,
                Image = b.Image,
                ReleaseYear = b.ReleaseYear
            };
        }
        public static BookMemberModel BookToBookMemberModel(ReaderBooks b)
        {
            return new BookMemberModel()
            {
                IdBook = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category,
                Description = b.Description,
                ReleaseYear = b.ReleaseYear,
                ReservationDate = b.ReservationDate
            };
        }

        internal static ProfileModel ReaderToProfile(Reader rmodel)
        {
            if (rmodel == null) return null;

            return new ProfileModel()
            {
                IdReader = rmodel.Id,
                Name = rmodel.Name,
                Surname = rmodel.Surname,
                Email = rmodel.Email,
                Adress = rmodel.Adress
            };
        }

   
        internal static Reader EditReader (EditProfile pm)
        {
            
            return new Reader()
            {
                IdReader = pm.Id,
                Name = pm.Name,
                Surname = pm.Surname,
                Email = pm.Email,
                Adress = pm.Adress,
                Password=pm.Password
            };
        }


        internal static Reader LoginToReader(LoginModel lm)
        {
            return new Reader()
            {
                Email = lm.Email,
                Password = lm.Password,
            };
        }

        internal static Reader RegisterToReader(RegisterModel rm)
        {
            return new Reader()
            {
                Name = rm.Name,
                Surname = rm.Surname,
                Email = rm.Email,
                Adress = rm.Adress,
                Password = rm.Password
            };
        }
    }
}