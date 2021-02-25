using DenemeBaglanti.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenemeBaglanti.Models.Musteri
{
    public class MusteriModel
    {
        public int Id { get; set; }
        public string TC_Kimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon_No { get; set; }
        public string Adres { get; set; }

    }
}