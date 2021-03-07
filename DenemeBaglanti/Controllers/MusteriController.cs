using DenemeBaglanti.Models.Entity;
using DenemeBaglanti.Models.Musteri;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace DenemeBaglanti.Controllers
{
    public class MusteriController : Controller
    {
        KargoOtomasyonSistemiEntities db = new KargoOtomasyonSistemiEntities();

        // GET: Musteri
        [HttpGet]
        public ActionResult Index()
        {
            var musteriList = db.Musteri.ToList();
            var resultModel = new List<MusteriModel>();
            var musteriModel = new MusteriModel();
            foreach (var item in musteriList)
            {
                musteriModel = new MusteriModel()
                {
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    TC_Kimlik = item.TC_Kimlik,
                    Adres = item.Adres,
                    Telefon_No = item.Telefon_No,
                    Id = item.Id
                };
                resultModel.Add(musteriModel);
            }
            return View(resultModel);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(MusteriModel musteri)
        {
            if(!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }

            var dbMusteri = new Musteri();
            dbMusteri.Ad = musteri.Ad;
            dbMusteri.Soyad = musteri.Soyad;
            dbMusteri.Telefon_No = musteri.Telefon_No;
            dbMusteri.TC_Kimlik = musteri.TC_Kimlik;
            dbMusteri.Adres = musteri.Adres;

            db.Musteri.Add(dbMusteri);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }


        public ActionResult MusteriSil(int id)
        {
            var musteri = db.Musteri.Find(id);
            db.Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.Musteri.Find(id);
            return View("MusteriGuncelle", musteri);
        }

        [HttpPost]
        public ActionResult MusteriGuncelle(Musteri p1)
        {
            var mstr = db.Musteri.Find(p1.Id);
            mstr.Ad = p1.Ad;
            mstr.Soyad = p1.Soyad;
            mstr.TC_Kimlik = p1.TC_Kimlik;
            mstr.Telefon_No = p1.Telefon_No;
            mstr.Adres = p1.Adres;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}