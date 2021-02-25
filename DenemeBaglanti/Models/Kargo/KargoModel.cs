using DenemeBaglanti.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenemeBaglanti.Models.Kargo
{
    public class KargoModel
    {
        public int Id { get; set; }
        public string KuryeAdiSoyadi { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        public Nullable<int> Kurye_Id { get; set; }
        public string Tur { get; set; }
        public Nullable<decimal> Boyut { get; set; }
        public Nullable<decimal> Agirlik { get; set; }
        public Nullable<decimal> Fiyat { get; set; }

    }
}