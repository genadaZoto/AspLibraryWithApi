using Library.ModelTools;
using Library.ModelTools.Filters;
using System;
using System.Collections.Generic;
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
    }
}