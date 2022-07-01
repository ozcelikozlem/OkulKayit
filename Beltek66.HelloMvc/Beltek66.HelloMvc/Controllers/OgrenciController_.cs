using Beltek66.HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Beltek66.HelloMvc.Controllers
{
    public class OgrenciController_ : Controller
    {
        public ViewResult Index()
        {
            //string isim = "Ahmet";
            //ViewData["name"]=isim;
            //ViewData["name1"] = "Ali";
            //ViewData["surname"] = "Mehmet";
            //ViewData["surname1"] = "Veli";
            //ViewData["age"] = 25;
            //ViewData["age1"] = 24;

            //ViewBag.name = "Ali";
            //ViewBag.surname = "Veli";
            //ViewBag.age = "28";


            //string isim = "Ahmet";
            //var name = "Ali";
            //dynamic _name = "Osman";//runtime sırasında karar verilecek type
            //object _age = "25";

            //var ogr = new Ogrenci();
            //ogr.Ad = "Ahmet";
            //ogr.Soyad = "Mehmet";
            //ogr.Yas = 25;
            //ViewData["ogrenci"] = ogr;
            //ViewBag.student= ogr;//viewdata ile aynı isim olmaz verirsen son veri kullanılır

            //dynamic st = new Ogrenci();//st.Ad görmez runtime sırasında
            //var st1=new Ogrenci();
            //st1.Ad = "ali";

            

            return View();
        }

        [HttpGet] // yazmasanda olur ama post yamak zorundasın 
        public ViewResult OgrenciEkle()
        {
            return View();
        }

       [HttpPost]
        public ViewResult OgrenciEkle(Ogrenci ogrenci )//Model Binding
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Add(ogrenci);
                ctx.SaveChanges();
            }




            return View();
        }


        public ViewResult OgrenciListesi()
        {
            //    var ogrenciler = new List<Ogrenci>();//Generic List
            //    ogrenciler.Add(new Ogrenci { Ad = "Ali", Soyad = "Veli", Yas = 24 });
            //    ogrenciler.Add(new Ogrenci { Ad = "Veli", Soyad = "Ali", Yas = 29 });
            //    ogrenciler.Add(new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Yas = 30 });
            //    ViewData["lst"] = ogrenciler;
            //    ViewBag.lts1 = ogrenciler;

            //    //var ogretmenler = new List<Ogretmen>();
            //    //ogretmenler.Add(new Ogretmen { Ad = "ali", Soyad = "veli", Bolum = "Endüstri" });
            //    //ogretmenler.Add(new Ogretmen { Ad = "ahmet", Soyad = "mehmet", Bolum = "Bilgisayar" });


            //    var lst = new ListViewModel();
            //  //  lst.Ogretmenler = ogretmenler;
            //    lst.Ogrenciler = ogrenciler;

            List<Ogrenci> lst = null;
            using (var ctx = new OkulDbContext())
            {

                lst = ctx.Ogrenciler.ToList();
            }


                return View(lst);
        }





        //public string OgrenciDetay(int id)
        //{
        //    string ogr;
        //    if (id == 1)
        //    {
        //        ogr = "Ali";
        //    }
        //    else if (id == 2)
        //    {
        //        ogr = "Veli";
        //    }
        //    else
        //    {
        //        ogr = "Bu id ile kayıtlı öğrenci yok";
        //    }
        //    return ogr;
        //}
       

        public IActionResult OgrenciSil(int id) //IActionResult: wiev result,RedirectToAction interface ; view result yok listeden tık diye silinmeli
        {
            using(var ctx=new OkulDbContext())
            {
                var ogr= ctx.Ogrenciler.Find(id);
                ctx.Ogrenciler.Remove(ogr);
                ctx.SaveChanges();
                
            }

            return RedirectToAction("OgrenciListesi");
        }


        public IActionResult OgrenciDetay(int id)
        {
            using (var ctx=new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                return View(ogr);
            }
        }

        [HttpPost]
        public IActionResult OgrenciDetay(Ogrenci ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("OgrenciListesi");
            }
        }

    }
}

//IIS(Internet Information Services)
//ViewData:Controllerdan view lere veri taşımak için kullanılır.bir yöntemi object 
//view-controller ctrl m+g
//Key-Value Pair
//Dictionary Yapısı
//Collection->Dizilerin eleman sayısı belirlemeden kullanılabilen hali
//ViewBag arka planda ViewData koleksiyonunu kullanır.Aynı key den olmaz
//ViewBag dynamic bir yapıdır.runtime sırasında karar verilecek type
