using DenemeBaglanti.Models.Entity;
using DenemeBaglanti.Models.Kargo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DenemeBaglanti.Controllers
{
    public class KargoController : Controller
    {
        KargoOtomasyonSistemiEntities db = new KargoOtomasyonSistemiEntities();

        // GET: Kargo
        [HttpGet]
        public ActionResult Index()
        {
            var kargoList = db.Kargo.ToList();
            var resultModel = new List<KargoModel>();
            var kargoModel = new KargoModel();
            foreach (var item in kargoList)
            {
                kargoModel = new KargoModel()
                {
                    MusteriAdiSoyadi = item.Musteri.Ad + " " + item.Musteri.Soyad,
                    KuryeAdiSoyadi = item.Kurye.Ad + " " + item.Kurye.Soyad,
                    Agirlik = item.Agirlik,
                    Boyut = item.Boyut,
                    Fiyat = item.Fiyat,
                    Tur = item.Tur,
                    Kurye_Id = item.Kurye_Id,
                    Id = item.Id
                };
                resultModel.Add(kargoModel);
            }
            return View(resultModel);

        }

        [HttpGet]
        public ActionResult KargoEkle()
        {
            List<SelectListItem> kuryedeger = (from kurye in db.Kurye.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = kurye.Ad + " " + kurye.Soyad,
                                                   Value = kurye.Id.ToString()
                                               }).ToList();

            var model = new KargoAddViewModel();
            model.KuryeSelectList = kuryedeger;
            model.MusteriSelectList = db.Musteri.Select(musteri => new SelectListItem()
            {
                Text = musteri.Ad + " " + musteri.Soyad,
                Value = musteri.Id.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult KargoEkle(Kargo kargo)
        {
            db.Kargo.Add(kargo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KargoSil(int id)
        {
            var kargo = db.Kargo.Find(id);
            db.Kargo.Remove(kargo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KargoGuncelle(int id)
        {
            List<SelectListItem> MusteriDeger = (from item in db.Musteri.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = item.Ad + " " + item.Soyad,
                                                     Value = item.Id.ToString()
                                                 }).ToList();
            ViewBag.MusteriAdSoyad = MusteriDeger;

            List<SelectListItem> Kuryedeger = (from item in db.Kurye.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = item.Ad + " " + item.Soyad,
                                                   Value = item.Id.ToString()
                                               }).ToList();
            ViewBag.KuryeAdSoyad = Kuryedeger;
            var kargo = db.Kargo.Find(id);
            return View("kargoGuncelle", kargo);
        }

        [HttpPost]
        public ActionResult KargoGuncelle(Kargo GuncelKargo)
        {
            var kargo = db.Kargo.Find(GuncelKargo.Id);
            kargo.Kurye_Id = GuncelKargo.Kurye_Id;
            kargo.Musteri_Id = GuncelKargo.Musteri_Id;
            kargo.Agirlik = GuncelKargo.Agirlik;
            kargo.Boyut = GuncelKargo.Boyut;
            kargo.Tur = GuncelKargo.Tur;
            kargo.Fiyat = GuncelKargo.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}