using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVC.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int x = 0, int y=0 )
        {
            int sonuc = x + y;
            ViewBag.snc = sonuc;
            return View();
        }

    }
}