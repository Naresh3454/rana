using BussinessLogicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiRouting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult AddNewPost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPost(AdvertiseCarEntity model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                //Redirect to business logic
            }
            return View();
        }
    }
}