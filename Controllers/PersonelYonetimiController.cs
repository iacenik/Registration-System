using Microsoft.AspNetCore.Mvc;
using PersonelKayıtSistemi.Data;
using Microsoft.EntityFrameworkCore;

namespace PersonelKayıtSistemi.Controllers
{
    public class PersonelYonetimiController : Controller
    {
        private readonly ILogger<PersonelYonetimiController> _logger;
        private readonly DataContext _context;
        
        public PersonelYonetimiController(ILogger<PersonelYonetimiController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index() // Personelleri Sıralıyoruz
        {
            var personeller = await _context.Personeller.ToListAsync(); // Asenkron veritabanı çağrısı
            return View(personeller);
        }

        [HttpGet]
        public IActionResult Ekle()  // Ekleme formuna yönlendirecek
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Personel yeniPersonel)  // Formdan gelen personeli ekleyecek
        {
            if (!ModelState.IsValid)
            {
                return View(yeniPersonel);
            }

            await _context.Personeller.AddAsync(yeniPersonel); // Asenkron ekleme işlemi
            await _context.SaveChangesAsync(); // Değişiklikleri asenkron kaydet
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detaylar(int id)  // Detayları gösteriyor
        {
            var personel = await _context.Personeller.SingleOrDefaultAsync(p => p.PersonelId == id); // Asenkron sorgu
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle(int id)  // Düzenleme formunu açıyor
        {
            var personel = await _context.Personeller.SingleOrDefaultAsync(p => p.PersonelId == id); // Asenkron sorgu
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(Personel duzenlenmisPersonel)  // Düzenlenmiş personeli kaydediyor
        {
            if (!ModelState.IsValid)
            {
                return View(duzenlenmisPersonel);
            }

            var personel = await _context.Personeller.SingleOrDefaultAsync(p => p.PersonelId == duzenlenmisPersonel.PersonelId); // Asenkron sorgu
            if (personel == null)
            {
                return NotFound();
            }

            personel.Ad = duzenlenmisPersonel.Ad;
            personel.Soyad = duzenlenmisPersonel.Soyad;
            personel.Adres = duzenlenmisPersonel.Adres;
            personel.Maas = duzenlenmisPersonel.Maas;

            await _context.SaveChangesAsync(); // Değişiklikleri asenkron kaydet
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Sil(int id)  // Personeli siliyor
        {
            var personel = await _context.Personeller.SingleOrDefaultAsync(p => p.PersonelId == id); // Asenkron sorgu
            if (personel == null)
            {
                return NotFound();
            }

            _context.Personeller.Remove(personel);
            await _context.SaveChangesAsync(); // Değişiklikleri asenkron kaydet
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
