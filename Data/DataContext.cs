using Microsoft.EntityFrameworkCore;

namespace PersonelKayıtSistemi.Data{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options){}
        public  DbSet<Personel> Personeller=>Set<Personel>();
        public DbSet<User> Users => Set<User>();
        public DbSet<PersonelKayıt> PersonelKayıtları => Set<PersonelKayıt>();
    }
}