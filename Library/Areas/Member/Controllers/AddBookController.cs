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
            int IdReader = SessionUtils.ConnectedUser.IdReader; 

            DateTime today = DateTime.Today;
            BookReservationRepository BR = new BookReservationRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
           
            BookCopyRepository Bcr = new BookCopyRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int nbBookAvailable = Bcr.getNbBookCopy(IdBook);
            if (nbBookAvailable == 0)
            {
                SessionUtils.ErrorReservation = "We couldn't save this book to you! No copy of this book available for the moment.";
                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }

            else
            {
                int IdBookCopyReserved = BR.InsertWithBook(SessionUtils.ConnectedUser.IdReader, IdBook, today);
                BookRepository br = new BookRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
                Book B = br.GetOne(IdBook);
                BookModel Bm = MapToDbModels.BookToBookModel(B);
                return View(Bm);
            }

        }
    }
}