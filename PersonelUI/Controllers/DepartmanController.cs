using PersonelUI.Models.EntitiyFramework;
using PersonelUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelUI.Controllers
{
    [Authorize(Roles = "A,U")]
    public class DepartmanController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();


  
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult DepartmanForm()
        {
            
            return View(new Departman());
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid) //geçerli değilse diyoruz
            {
                return View("DepartmanForm");
            }

            MesajViewModel model = new MesajViewModel(); //viewmeesaj'ı tanımladık

            if (departman.Id ==0)
            {

                db.Departman.Add(departman);
                model.Mesaj = departman.Ad + " Başarıyla Eklendi"; //mesaj için bu kodu ekledim
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if (guncellenecekDepartman==null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.Ad = departman.Ad;
                model.Mesaj = departman.Ad + " Başarıyla Güncellendi"; //mesaj için bu kodu ekledim
            }
            db.SaveChanges();
            //return RedirectToAction("index","departman");
            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";
            return View("_Mesaj",model); //modeli'ide gönderdik.
        }
        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id); //id'i olanı bul
            if (model == null) //yani kişi elle sıfırlarsa.
                return HttpNotFound();
            return View("DepartmanForm",model);
        }
        public ActionResult Sil (int id)
        {
            var silinecekDb = db.Departman.Find(id);
            if (silinecekDb == null)
                return HttpNotFound();
            db.Departman.Remove(silinecekDb);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}