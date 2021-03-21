using DenemeBaglanti.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DenemeBaglanti.Controllers
{
    public class GirisYapController : Controller
    {

        KargoOtomasyonSistemiEntities db = new KargoOtomasyonSistemiEntities();
        // GET: GirisYap
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KullaniciGirisi userInfoCont)
        {
            var kulBilgikontrol = db.KullaniciGirisi.FirstOrDefault(m => m.Name == userInfoCont.Name &&
              m.Password == userInfoCont.Password);
            if (kulBilgikontrol != null)
            {
                FormsAuthentication.SetAuthCookie(kulBilgikontrol.Name, false);
                Session["Name"] = kulBilgikontrol.Name.ToString();
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                return View();
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }

        [HttpPost]
        public ActionResult KayitEkle(KullaniciGirisi Kullanici)
        {
            db.KullaniciGirisi.Add(Kullanici);
            db.SaveChanges();
            return RedirectToAction("Login", "GirisYap");

        }

    }
}