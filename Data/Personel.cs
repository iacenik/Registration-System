using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelKayıtSistemi.Data
{
    public class Personel
    {   
        [Key]     
        public int PersonelId { get; set; }
        public string? Ad  { get; set; }
        public string? Soyad { get; set; }
        public string AdSoyad {
            get{
                return this.Ad+""+this.Soyad;
            }
        }
        public string? Adres { get; set; }
        public decimal Maas { get; set; }
        public string? Resim { get; set; }
        public ICollection<PersonelKayıt> PersonelKayıtları {get ; set;}= new List<PersonelKayıt>();

        
    }
}