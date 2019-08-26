using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegImob_API.Business;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using System.Web.Http;

namespace SegImob_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
