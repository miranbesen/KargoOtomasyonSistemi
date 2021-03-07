using DenemeBaglanti.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DenemeBaglanti.Models.Musteri
{
    public class MusteriModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "TC'yi lutfen bos birakmayiniz...!")]
        [StringLength(11, ErrorMessage = "En fazla 11 karakterlik TC giriniz.")]
        public string TC_Kimlik { get; set; }
        
        [Required(ErrorMessage = "Ad kismini lutfen bos birakmayiniz...!")]
        public string Ad { get; set; }
        
        [Required(ErrorMessage = "Soyad kismini lutfen bos birakmayiniz...!")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Telefon no'yu lutfen bos birakmayiniz...!")]
        [StringLength(11,ErrorMessage ="En fazla 11 karakterlik bir telefon no giriniz.")]
        public string Telefon_No { get; set; }
       
        [Required(ErrorMessage = "Adres'i lutfen bos birakmayiniz...!")]
        public string Adres { get; set; }

    }
}