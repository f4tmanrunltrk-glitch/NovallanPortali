using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovallanPortali.Models;

namespace NovallanPortali.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Veritabanı tablolarımızı buraya tanımlıyoruz
        public DbSet<Ilan> Ilanlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Eğer veritabanı oluşurken özel ayarlar yapmak istersen burayı kullanabiliriz
            // Şu an için standart ayarlar yeterli.
        }
    }
}