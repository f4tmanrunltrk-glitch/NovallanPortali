using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovallanPortali.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori adı zorunludur")]
        public string Ad { get; set; }
        public ICollection<Ilan>? Ilanlar { get; set; }
    }
}