using PersonelUI.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelUI.ViewModels;

namespace PersonelUI.Controllers
{
    [Authorize(Roles = "A,U")]
    public class PersonelController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Personel
        public ActionResult Index()
        {
           var model= db.Personel.Include(x => x.Departman).ToList(); //join yapıyoruz.
            return View(model);
        }


        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel{
                Departmanlar = db.Departman.ToList(),
                Personel=new Personel()
            };
            return View("PersonelForm",model); //bu forma yönlendirdim.
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return RedirectToAction("PersonelForm",model);
            }
            if (personel.Id==0)
            {
                db.Personel.Add(personel);
            }
            else //güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified; //bu kod tek satırda halletmemizi sağlıyor
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle (int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekPersonel = db.Personel.Find(id);
            if (silinecekPersonel==null)
            {
                return HttpNotFound();
            }
                db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}