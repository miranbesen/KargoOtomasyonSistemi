using DenemeBaglanti.Models.Entity;
using DenemeBaglanti.Models.Kurye;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace DenemeBaglanti.Controllers
{
    public class KuryeController : Controller
    {
        KargoOtomasyonSistemiEntities db = new KargoOtomasyonSistemiEntities();

        // GET: Kurye
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            var KuryeList = db.Kurye.ToList();
            List<KuryeModel> resultModel = new List<KuryeModel>();
            var KuryeModel = new KuryeModel();
            foreach (var item in KuryeList)
            {
                KuryeModel = new KuryeModel()
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    Telefon = item.Telefon,
                    Durum = item.Durum

                };
                resultModel.Add(KuryeModel);
            }
            PagedList<KuryeModel> pagedKuryeModel = new PagedList<KuryeModel>(resultModel, page, pageSize);


            return View(pagedKuryeModel);
        }

        [HttpGet]
        public ActionResult KuryeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KuryeEkle(KuryeModel p1)
        {
            if (!ModelState.IsValid)
            {
                return View("KuryeEkle");
            }
            var kurye = new Kurye();
            kurye.Ad = p1.Ad;
            kurye.Soyad = p1.Soyad;
            kurye.Telefon = p1.Telefon;
            kurye.Durum = p1.Durum;

            db.Kurye.Add(kurye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KuryeSil(int id)
        {
            var kurye = db.Kurye.Find(id);
            db.Kurye.Remove(kurye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KuryeGuncelle(int id)
        {
            var kurye = db.Kurye.Find(id);
            return View("KuryeGuncelle", kurye);

        }
        [HttpPost]
        public ActionResult KuryeGuncelle(Kurye guncelKurye)
        {
            var kurye = db.Kurye.Find(guncelKurye.Id);
            kurye.Ad = guncelKurye.Ad;
            kurye.Soyad = guncelKurye.Soyad;
            kurye.Telefon = guncelKurye.Telefon;
            kurye.Durum = guncelKurye.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}