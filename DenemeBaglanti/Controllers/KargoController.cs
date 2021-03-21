using DenemeBaglanti.Models.Entity;
using DenemeBaglanti.Models.Kargo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace DenemeBaglanti.Controllers
{
    public class KargoController : Controller
    {
        KargoOtomasyonSistemiEntities db = new KargoOtomasyonSistemiEntities();

        // GET: Kargo
        
        [HttpGet, Authorize]
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            var kargoList = db.Kargo.ToList();
            List<KargoModel> resultModel = new List<KargoModel>();
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

            PagedList<KargoModel> pagedKargoModel = new PagedList<KargoModel>(resultModel, page, pageSize);



            return View(pagedKargoModel);

        }

        [HttpGet, Authorize]
        public ActionResult KargoEkle()
        {
            var model = new KargoAddViewModel();
        

            List<SelectListItem> kuryedeger = (from kurye in db.Kurye.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = kurye.Ad + " " + kurye.Soyad,
                                                   Value = kurye.Id.ToString()
                                               }).ToList();           
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
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("KargoEkle");
            //}


            //var kargo = new Kargo();
            //kargo.Kurye_Id = kargoModel.KargoModel.Kurye_Id;
            //kargo.Musteri_Id = kargoModel.KargoModel.Musteri_Id;
            //kargo.Tur = kargoModel.KargoModel.Tur;
            //kargo.Agirlik = kargoModel.KargoModel.Agirlik;
            //kargo.Boyut = kargoModel.KargoModel.Boyut;
            //kargo.Fiyat = kargoModel.KargoModel.Fiyat;


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
        public ActionResult KargoGuncelle(Kargo guncelKargo)
        {
            var kargo = db.Kargo.Find(guncelKargo.Id);
            kargo.Kurye_Id = guncelKargo.Kurye_Id;
            kargo.Musteri_Id = guncelKargo.Musteri_Id;
            kargo.Agirlik = guncelKargo.Agirlik;
            kargo.Boyut = guncelKargo.Boyut;
            kargo.Tur = guncelKargo.Tur;
            kargo.Fiyat = guncelKargo.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}