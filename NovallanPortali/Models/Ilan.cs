using System.ComponentModel.DataAnnotations;

namespace NovallanPortali.Models
{
    public class Ilan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur")]
        public string Baslik { get; set; }

        public string? Aciklama { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        public decimal Fiyat { get; set; }

        public string? ResimYolu { get; set; }

        // Konum Bilgileri
        [Required(ErrorMessage = "Şehir seçimi zorunludur")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "İlçe seçimi zorunludur")]
        public string Ilce { get; set; }

        // İlişkiler
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }

        public string? KullaniciId { get; set; }
    }
}