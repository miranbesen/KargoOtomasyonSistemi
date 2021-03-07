using DenemeBaglanti.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DenemeBaglanti.Models.Kargo
{
    public class KargoAddViewModel
    {
       
        public List<SelectListItem> KuryeSelectList { get; set;}
        

        public List<SelectListItem> MusteriSelectList { get; set; }
        
       

    }
}