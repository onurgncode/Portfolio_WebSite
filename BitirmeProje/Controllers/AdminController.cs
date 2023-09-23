using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult BlogDuzen(int id)
        {
            
            if (Session["uyem"] != null)
            {
                var listele = db.BLOGLAR.ToList().FirstOrDefault(x =>x.BLOGID == id);
                ViewBag.yazi = "<br><p>buy</p>azar";
                return View(listele);
            }
            else
            {
                return View("Error");
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult BlogDuzen(int BLOGID,string BLOGAD, string BLOGIMG_1,string BLOGIMG_2,string BLOGIMG_3,string BLOGLOGO,string BLOGYAZI,string BLOGKUCUKYAZI,DateTime BLOGDATE)
        {
            
            var bul = db.BLOGLAR.FirstOrDefault(x => x.BLOGID == BLOGID);
            bul.BLOGAD = BLOGAD;
            bul.BLOGIMG_1 = BLOGIMG_1;
            bul.BLOGIMG_2 = BLOGIMG_2;
            bul.BLOGIMG_3 = BLOGIMG_3;
            bul.BLOGLOGO = BLOGLOGO;
            bul.BLOGYAZI = BLOGYAZI;
            bul.BLOGKUCUKYAZI = BLOGKUCUKYAZI;
            bul.BLOGDATE = BLOGDATE;
            
            db.SaveChanges();
            
            return View();
        }
        public ActionResult Blogsil(int? id)
        {
            if(id == null)
            {
                ViewBag.err = "İd yok hocam";
                return View();
            }
            else
            {
                var listele = db.BLOGLAR.FirstOrDefault(x=> x.BLOGID == id);
                return View(listele);
            }
        }


        [HttpPost]
        public ActionResult Blogsil(int id)
        {
            Session["uyem"] = 1;
            if (Session["uyem"] != null)
            {
                
                BLOGLAR listele = db.BLOGLAR.ToList().Find(x => x.BLOGID == id);
                db.BLOGLAR.Remove(listele);     
                db.SaveChanges();
                return RedirectToAction("BlogListele");
            }
            else
            {
                ViewBag.err = "Silinemedi Hocam";
                return View();
            }
        }
        public ActionResult Olustur()
        {
            
            BLOGLAR oldu = new BLOGLAR();
            return View(oldu);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Olustur(string BLOGAD, string BLOGIMG_1, string BLOGIMG_2, string BLOGIMG_3, string BLOGYAZI, string BLOGKUCUKYAZI, HttpPostedFileBase BLOGLOGO,int KATEID,int UYEID)
        {
             
            BLOGLAR oldu = new BLOGLAR();
            oldu.BLOGAD = BLOGAD;
            oldu.BLOGIMG_1 = BLOGIMG_1;
            oldu.BLOGIMG_2 = BLOGIMG_2;
            oldu.BLOGIMG_3 = BLOGIMG_3;
            if (ModelState.IsValid)
            {
                string logo = Path.GetFileName(BLOGLOGO.FileName);
                string tam_yol = Server.MapPath("~/images/" + logo);
                BLOGLOGO.SaveAs(tam_yol);
                oldu.BLOGLOGO = logo;
            }

            oldu.UYEID = UYEID;
            oldu.KATEID = KATEID;
            oldu.BLOGYAZI = BLOGYAZI;
            oldu.BLOGKUCUKYAZI = BLOGKUCUKYAZI;
            oldu.BLOGDATE = DateTime.Now;
            db.BLOGLAR.Add(oldu);
            db.SaveChanges();
            if(oldu != null)
            {
                ViewBag.olsutumu = "Oluştur";
            }
            var listem = db.BLOGLAR.ToList();
            return View("BlogListele",listem);
        }


        public ActionResult Mesajlar()
        {
            if (Session["uyem"] !=null)
            {
                var bak = db.MESAJLAR.ToList();
                return PartialView(bak);
            }
            else return PartialView("error");
        }
        public ActionResult MesajSil(int? id)
        {
            if (Session["uyem"] != null)
            {
                var listele = db.MESAJLAR.FirstOrDefault(x => x.CONID == id);
                return View(listele);
            }
            else return View("login");
        }
        [HttpPost]
        public ActionResult MesajSil(int id)
        {
            
            if (Session["uyem"] != null)
            {

                MESAJLAR listele = db.MESAJLAR.ToList().Find(x => x.CONID == id);
                db.MESAJLAR.Remove(listele);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.err = "Silinemedi Hocam";
                return View();
            }
        }


    }
}