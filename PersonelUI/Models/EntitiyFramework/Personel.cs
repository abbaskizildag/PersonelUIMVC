//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelUI.Models.EntitiyFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personel
    {
        public int Id { get; set; }
        [Display(Name = "Departman Ad�")]
        [Required(ErrorMessage = "L�tfen bir departman ad� se�iniz.")]

        public Nullable<int> DepartmanId { get; set; }
        [Required(ErrorMessage = "L�tfen isim alan�n� doldururuz.")]

        public string Ad { get; set; }
        [Required(ErrorMessage = "L�tfen soyad alan�n� doldurunuz.")]
        public string Soyad { get; set; }

        [Display(Name = "Maa�")]
        [Required(ErrorMessage ="L�tfeb maa� giriniz")]
        [Range(1399, 8000, ErrorMessage = "L�tfen 1399-8000 aras�nda de�er girilmeli")]
        public Nullable<short> Maas { get; set; }

        [Display(Name = "Do�um Tarihi")]
        [Required(ErrorMessage = "L�tfen tarih se�iniz")]

        public Nullable<System.DateTime> DogumTarihi { get; set; }

        [Display(Name = "L�tfen cinsiyetinizi se�iniz")]

        public Nullable<bool> Cinsiyet { get; set; }
        public bool EvliMi { get; set; }
    
        public virtual Departman Departman { get; set; }
    }
}
