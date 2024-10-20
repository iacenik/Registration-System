using System.ComponentModel.DataAnnotations;

namespace PersonelKayıtSistemi.Data{
    public class PersonelKayıt{
        [Key]
        public int KayitId {get ; set;}
        public int PersonelId {get; set;}
        public Personel Personel {get; set;}= null!;
        public DateTime KayitTarihi {get;set;}

    }
}