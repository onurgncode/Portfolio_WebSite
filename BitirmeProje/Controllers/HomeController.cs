using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProje.Models;
using PagedList;


namespace BitirmeProje.Controllers
{
    public class HomeController : Controller
    {
        DbWebSiteEntities db = new DbWebSiteEntities();
        
        public ActionResult Index(int page = 1 , int  pageSize = 5)
        {
            //veritabanından products tablosunu çekiyoruz.
            List<BLOGLAR> bloglar = db.BLOGLAR.ToList();
            //Burada ise PageList tipinde bir Product model oluşturuyoruz ve özelliklerini veriyoruz. Sayfa sayısı ve sayfada kaç tane kayıt gösterilecek gibi..
            PagedList<BLOGLAR> model = new PagedList<BLOGLAR>(bloglar, page, pageSize);
            
            return View(model);
        }
       public ActionResult BlogKontrol(int page = 1, int pageSize = 5)
        {
            List<BLOGLAR> bloglari = db.BLOGLAR.ToList();
            PagedList<BLOGLAR> model = new PagedList<BLOGLAR>(bloglari, page, pageSize);
            return View(model);
        }
        public ActionResult BlogIzle(int? id)
        {
            if(id == null)
            {
                ViewBag.err = "<h1>Böyle Bir Blog bulunamadı</h1>";
                return View();
            }
            else
            {
                var bulucu = db.BLOGLAR.FirstOrDefault(x => x.BLOGID == id);
                var kate = db.KATEGORILER.FirstOrDefault(x => x.KATEID == bulucu.KATEID);
                var yazar = db.UYELER.FirstOrDefault(x => x.ID == bulucu.UYEID);
                ViewBag.yazial = bulucu.BLOGYAZI;
                if(ViewBag.kate != null)
                {
                    ViewBag.kate = kate.KATEAD;
                }
                else if (ViewBag.yazar != null)
                {
                    ViewBag.yazar = yazar.UYEAD;
                }
                
                
                return View(bulucu);
            }
        }
        public ActionResult Mesaj()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Mesaj(string mail, string ad, string icerik)
        {
            MESAJLAR item = new MESAJLAR();
            item.CONMAIL = mail;
            item.CONADSOYAD = ad;
            item.CONICERIK = icerik;
            db.MESAJLAR.Add(item);
            db.SaveChanges();
            return PartialView("Index");
            
        }


    }
}