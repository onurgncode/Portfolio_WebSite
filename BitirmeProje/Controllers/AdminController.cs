using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProje.Models;
namespace BitirmeProje.Controllers
{
    public class AdminController : Controller
    {
        DbWebSiteEntities db = new DbWebSiteEntities();
        // GET: Admin
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string kadi,string sifre)
        {
            Session["uyem"] = db.UYELER.ToList().Find(x => x.KADI == kadi && x.SIFRE == sifre);
            if (Session["uyem"] != null)
            {
                ViewBag.ekle = "ok";
                return View("index");
            }
            else
            {
                ViewBag.ekle = "no";
                return View();
            }
            

        }
        public ActionResult index()
        {
            if (Session["uyem"] != null)
            { 
            return View();
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult BlogListele()
        {
            if (Session["uyem"] != null)
            {
                var listele = db.BLOGLAR.ToList();
                return View(listele);
            }
            else
            {
                return View("Error");
            }
        }
    }
}