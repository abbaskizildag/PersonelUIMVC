using PersonelUI.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelUI.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> Departmanlar { get; set; }
        public Personel Personel { get; set; }
    }
}