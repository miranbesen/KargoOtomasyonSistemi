using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DenemeBaglanti.Models.Entity;
using PagedList;

namespace DenemeBaglanti.Models.Kurye
{
    public class KuryeModelAndPagedKuryeModel
    {
        public  ICollection<KuryeModel> NormalKuryeModel { get; set; }
        public PagedList.IPagedList<KuryeModel> PagedKuryeModel { get; set; }
    }
}