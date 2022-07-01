using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beltek66.EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ogr = new Ogrenci();
            //ogr.Ad = "Ali";
            //ogr.Soyad = "Veli";
            //ogr.Numara = 256;

            ////var ctx = new OkulDb1Context();
            ////ctx.Ogrenciler.Add(ogr);
            ////ctx.SaveChanges();
            ////ctx.Dispose(); //bellekten atmak için

            //var ogr = new Ogrenci { Ad = "Ali", Soyad = "Velii", Numara = 582 };

            //using (var ctx = new OkulDb1Context())//Dispose olacak metodlar için using
            //{
            //    ctx.Ogrenciler.Add(ogr);//DbSet Ogrenciler bellekte bekliyor
            //    ctx.SaveChanges();//EntityState -->insert yapacak
            //}
            //-------- Güncelleme-------------
            //using (var ctx = new OkulDb1Context())
            //{
            //    var ogr = ctx.Ogrenciler.Find(2);
            //    ogr.Numara = 789;
            //    ctx.Entry(ogr).State = EntityState.Modified;
            //    ctx.SaveChanges();

            //}

            //using (var ctx = new OkulDb1Context())
            //{
            //    var ogrenci = ctx.Ogrenciler.Find(1);
            //    ogrenci.Numara = 742;
            //    ctx.Entry(ogrenci).State = EntityState.Modified;//Entity state Modified yaptık
            //    if (ctx.SaveChanges() > 0)
            //    {

            //        Console.WriteLine("İşlem Başarılı");


            //    }

            //}

            // --------- Delete-------------


            //using (var ctx = new OkulDb1Context())
            //{
            //    var ogr = ctx.Ogrenciler.Find(6);
            //    ctx.Ogrenciler.Remove(ogr);
            //    ctx.SaveChanges();

            //}


            using (var ctx = new OkulDb1Context())
            {

                List<Ogrenci> lst = ctx.Ogrenciler.ToList();//DbSet ten generic liste oluşturdu List<Ogrenci> yerine var da yazarsn

                foreach (var item in lst)
                {
                    Console.WriteLine($"Ad :{item.Ad} , Soyad:{item.Soyad}");
                }


            }


        }
    }

    class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }

    }

    class OkulDb1Context : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            object p = optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            //Fluent Api:EF Code First yöntemi,EF'nin oluşturduğu alanların ve tabloların özelliklerini belirlemede kullanılır
        //o referans için kullanılıyor başka isim olur
        //IsRequired null olmasın

        }

    }

}
