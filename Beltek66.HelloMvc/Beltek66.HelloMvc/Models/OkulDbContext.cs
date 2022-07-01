using Microsoft.EntityFrameworkCore;

namespace Beltek66.HelloMvc.Models
{
    public class OkulDbContext:DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<Sinif> Siniflar { get; set; }

        public DbSet<Ogretmen> Ogretmenler { get; set; }

        public DbSet<Bolum> Bolumler { get; set; }

        public DbSet<Ders> Dersler { get; set; }

        public DbSet<OgretmenDers> OgretmenDers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object p = optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(ogr => ogr.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(ogr => ogr.Soyad).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Ogretmen>().ToTable("tblOgretmenler");
            modelBuilder.Entity<Ogretmen>().Property(ogrt => ogrt.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(ogrt => ogrt.Soyad).HasColumnType("varchar").HasMaxLength(50).IsRequired();
                 

            modelBuilder.Entity<OgretmenDers>().HasKey(od => od.OgretmenDersId);
            modelBuilder.Entity<OgretmenDers>().HasOne(od => od.Ogretmen).WithMany(o => o.OgretmenDers).HasForeignKey(od => od.OgretmenId);
            modelBuilder.Entity<OgretmenDers>().HasOne(od => od.Ders).WithMany(d => d.OgretmenDers).HasForeignKey(od => od.DersId);

            modelBuilder.Entity<Bolum>().HasData(

                new Bolum
                {
                    BolumId = 1,
                    BolumAd= "Bilgisayar Mühendisliği"


                },
                new Bolum
                {
                    BolumId = 2,
                    BolumAd = "Elektrik ve Elektronik Mühendisliği"


                }

                );
          
            





        }

       
       


    }
}
