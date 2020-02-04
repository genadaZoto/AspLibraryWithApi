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


namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id=1)
        {
            ViewBag.CurrentPage = id;
            BookRepository BR = new BookRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            //List<BookModel> Lbm = BR.GetAll().Select(b => MapToDbModels.BookToBookModel(b)).ToList();
            int nb = BR.getNbBooks();

            //Book book = BR.getBookFromApi();
            List<BookModel> Lbm = BR.Paginate(id, 8).Select(b => MapToDbModels.BookToBookModel(b)).ToList();
            
            ViewBag.MaxPages = Math.Round((double)BR.getNbBooks() / 8);

            return View(Lbm);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (SessionUtils.IsConnected)
            {
                return RedirectToAction("Index", new { controller = "Home", area = "Member" });
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            ReaderRepository Rr = new ReaderRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            ProfileModel Mmodel = MapToDbModels.ReaderToProfile(Rr.VerifLogin(MapToDbModels.LoginToReader(m)));
            if (Mmodel != null)
            {
                SessionUtils.ConnectedUser = Mmodel;
                SessionUtils.IsConnected = true;
                return RedirectToAction("Index", new { controller = "Home", area = "Member" });
            }
            else
            {
                ViewBag.ErrorLoginMessage = "Erreur Login/ Password";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Register(RegisterModel Rm, HttpPostedFileBase ProfilePicture)
        {
            List<string> matchContentType = new List<string>() { "image/jpeg", "image/png", "image/gif" };
            if(!matchContentType.Contains(ProfilePicture.ContentType)|| ProfilePicture.ContentLength > 80000)
            {
                ViewBag.ErrorMessage = "You can upload a file with the following exctentions(png, jpg, gif)";
                return View();
            }
            if (!ModelState.IsValid)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br>";
                    }
                }
            }
            else
            {
                // insert the new reader
                ReaderRepository Rr = new ReaderRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
                Reader R = Rr.Insert(MapToDbModels.RegisterToReader(Rm));
                if (R!= null)
                {
                    //saving the picture
                    string[] splitFileName = ProfilePicture.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    string ext = splitFileName[splitFileName.Length - 1];
                    string newFileName = R.Id + "." + ext;
                    string folderpath = Server.MapPath("~/Photos/");
                    string FileNameToSave = folderpath + "/" + newFileName;

                    try
                    {
                        ProfilePicture.SaveAs(FileNameToSave);
                    }
                    catch (Exception)
                    {
                        ViewBag.ErrorMessage = "The image couldn't be saved";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Error during Insertion";
                }

            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Index();
            return View("Index");
        }

        public ActionResult Search(string txtSearch)
        {
            BookRepository BR = new BookRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            List<BookModel> Lbm = BR.GetFromSearch(txtSearch).Select(b => MapToDbModels.BookToBookModel(b)).ToList();
            if(Lbm == null)
            {
                ViewBag.ErrorMessage = "Sorry we couldn't find the book you entered!";
                return View();
            }
           
            return View(Lbm);

        }


    }
}