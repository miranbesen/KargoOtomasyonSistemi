using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DenemeBaglanti.Models.Entity;

namespace DenemeBaglanti.Models.Kurye
{
    public class KuryeModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Durum { get; set; }


    }
}