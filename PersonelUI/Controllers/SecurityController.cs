using PersonelUI.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelUI.Controllers
{
    public class SecurityController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Security

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre==kullanici.Sifre);
            if (kullaniciDb!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciDb.Ad,false); //
                return RedirectToAction("Index","Departman");
            }
            else
            {
                ViewBag.Mesaj = "geçersiz kullanıcı veya şifre";
                return View();
            }
          
        }

        public ActionResult Loginout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Security");
        }
    }
}