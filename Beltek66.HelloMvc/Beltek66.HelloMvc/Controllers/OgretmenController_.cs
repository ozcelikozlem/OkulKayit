using Beltek66.HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace Beltek66.HelloMvc.Controllers
{
    public class OgretmenController_ : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public ViewResult OgretmenListesi()
        {
 

            List<Ogretmen> lst = null;
            using (var ctx = new OkulDbContext())
            {

                lst = ctx.Ogretmenler.ToList();
            }


            return View(lst);
        }


        [HttpGet] 
        public ViewResult OgretmenEkle()
        {
            return View();
        }

        [HttpPost]
        public ViewResult OgretmenEkle(Ogretmen ogrt)//Model Binding
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogrt);
                ctx.SaveChanges();
            }


            return View();
        }


        public IActionResult OgretmenSil(int id) //IActionResult: view result yok listeden tık diye silinmeli
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrt = ctx.Ogretmenler.Find(id);
                ctx.Ogretmenler.Remove(ogrt);
                ctx.SaveChanges();

            }

            return RedirectToAction("OgretmenListesi");
        }


        public IActionResult OgretmenDetay(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrt = ctx.Ogretmenler.Find(id);
                return View(ogrt);
            }
        }

        [HttpPost]
        public IActionResult OgretmenDetay(Ogretmen ogrt)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogrt).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("OgretmenListesi");
            }
        }



    }
}
