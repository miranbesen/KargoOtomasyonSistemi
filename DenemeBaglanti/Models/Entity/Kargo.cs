//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DenemeBaglanti.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kargo
    {
        public int Id { get; set; }
        public int Musteri_Id { get; set; }
        public int Kurye_Id { get; set; }
        public string Tur { get; set; }
        public decimal Boyut { get; set; }
        public decimal Agirlik { get; set; }
        public decimal Fiyat { get; set; }
    
        public virtual Kurye Kurye { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}