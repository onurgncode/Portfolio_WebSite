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
       
        
    }
}