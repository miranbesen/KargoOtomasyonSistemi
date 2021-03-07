using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DenemeBaglanti.Models.Entity;

namespace DenemeBaglanti.Models.Kurye
{
    public class KuryeModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Adınızı giriniz lutfen....!")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyadınızı giriniz lutfen....!")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Telefon No'nuzu giriniz lutfen....!")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Kargo durumunuzu belirtiniz lutfen....!")]
        public string Durum { get; set; }


    }
}