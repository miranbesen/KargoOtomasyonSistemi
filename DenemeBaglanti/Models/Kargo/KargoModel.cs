using DenemeBaglanti.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DenemeBaglanti.Models.Kargo
{
    public class KargoModel
    {
        public int Id { get; set; }
        
       
        public string KuryeAdiSoyadi { get; set; }
        
        
        public string MusteriAdiSoyadi { get; set; }
        
        
        public int Kurye_Id { get; set; }

     
        public int Musteri_Id { get; set; }


        public string Tur { get; set; }
       
        public decimal Boyut { get; set; }
       
        public decimal Agirlik { get; set; }
  
        public decimal Fiyat { get; set; }


    }
}