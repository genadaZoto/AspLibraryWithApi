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
    public class BookController : Controller
    {
        // GET: Member/Book
        public ActionResult Index()
        {
            ViewBag.Current = "Books";
            BookRepository BR = new BookRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            List<BookMemberModel> Bm = BR.GetBooksFromReader(SessionUtils.ConnectedUser.IdReader).Select(b => MapToDbModels.BookToBookMemberModel(b)).ToList();
            if(Bm.Count() == 0)
            {
                ViewBag.NoBooks = "There are no books in your account!";
                return View();
            }
            return View(Bm);
        }
    }
}