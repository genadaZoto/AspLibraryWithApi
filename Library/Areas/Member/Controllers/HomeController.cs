using DAL.Models;
using DAL.Repositories;
using Library.Areas.Member.Models;
using Library.ModelTools;
using Library.ModelTools.Filters;
using Library.ModelTools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Areas.Member.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        // GET: Member/Home
        public ActionResult Index()
        {
            ViewBag.Nom = SessionUtils.ConnectedUser.Name;
            ViewBag.Current = "Profil";

            return View(SessionUtils.ConnectedUser);
        }

        public ActionResult Edit(int id)
        {
            ReaderRepository Rr = new ReaderRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            Reader R = Rr.GetOne(id);
            ProfileModel Pm = MapToDbModels.ReaderToProfile(R);
           
            return View(Pm);
        }

        [HttpPost]
        public ActionResult Edit(EditProfile Ep)
        {
            ReaderRepository Rr = new ReaderRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            Reader R = MapToDbModels.EditReader(Ep);
            if (Rr.Update(R))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}