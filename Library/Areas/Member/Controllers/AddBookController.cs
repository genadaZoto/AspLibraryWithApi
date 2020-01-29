using DAL.Models;
using DAL.Repositories;
using Library.Areas.Member.Models;
using Library.Models;
using Library.ModelTools;
using Library.ModelTools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Areas.Member.Controllers
{
    public class AddBookController : Controller
    {
        // GET: Member/AddBook
        public ActionResult Index(int IdBook)
        {
            DateTime today = DateTime.Today;
            BookReservationRepository BR = new BookReservationRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int IdBookCopyReserved = BR.InsertWithBook(SessionUtils.ConnectedUser.IdReader, IdBook, today);
            if(IdBookCopyReserved == 0)
            {
                ViewBag.ErrorLoginMessage = "We couldn't save this book to you! No copy of this book available for the moment.";
                return View();
            }

            else
            {
                BookRepository br = new BookRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
                Book B = br.GetOne(IdBook);
                BookModel Bm = MapToDbModels.BookToBookModel(B);
                return View(Bm);
            }

        }
    }
}