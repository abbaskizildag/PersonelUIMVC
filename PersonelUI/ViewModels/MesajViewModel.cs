using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelUI.ViewModels
{
    public class MesajViewModel
    {
        public bool Status { get; set; } //true ise başarılı false ise başarısız
        public string Mesaj { get; set; }
        public string Url { get; set; }
        public string LinkText { get; set; }


    }
}