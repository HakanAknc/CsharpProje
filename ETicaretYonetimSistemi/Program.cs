using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretYonetimSistemi
{
    public class Program
    {

        // Kullanıcı ve admin için sınıflar
        static List<Urun> urunler = new List<Urun>();
        static Sepet sepet = new Sepet();

        static void Main(string[] args)
        {
            // Örnek ürünler ekle
            urunler.Add(new Urun { Id = 1, Ad = "Laptop", Fiyat = 2500.0m, Aciklama = "Güçlü işlemci ve geniş ekran." });
            urunler.Add(new Urun { Id = 2, Ad = "Telefon", Fiyat = 1500.0m, Aciklama = "Yeni model akıllı telefon." });
            urunler.Add(new Urun { Id = 3, Ad = "Tablet", Fiyat = 800.0m, Aciklama = "Ekran büyüklüğü ile dikkat çekiyor." });

            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Mini E-Ticaret Uygulaması ====");
                Console.WriteLine("1. Ürünleri Görüntüle");
                Console.WriteLine("2. Sepetimi Görüntüle");
                Console.WriteLine("3. Sepete Ürün Ekle");
                Console.WriteLine("4. Satın Al");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        UrunleriGoruntule();
                        break;
                    case "2":
                        SepetimiGoruntule();
                        break;
                    case "3":
                        SepeteUrunEkle();
                        break;
                    case "4":
                        SatinAl();
                        break;
                    case "5":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void UrunleriGoruntule()
        {
            Console.Clear();
            Console.WriteLine("==== Ürünler ====");
            foreach (var urun in urunler)
            {
                Console.WriteLine($"ID: {urun.Id}, Ürün: {urun.Ad}, Fiyat: {urun.Fiyat} TL, Açıklama: {urun.Aciklama}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void SepetimiGoruntule()
        {
            Console.Clear();
            if (sepet.Urunler.Count == 0)
            {
                Console.WriteLine("Sepetiniz boş.");
            }
            else
            {
                Console.WriteLine("==== Sepetiniz ====");
                foreach (var urun in sepet.Urunler)
                {
                    Console.WriteLine($"Ürün: {urun.Ad}, Fiyat: {urun.Fiyat} TL");
                }
                Console.WriteLine($"Toplam Fiyat: {sepet.ToplamFiyat} TL");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void SepeteUrunEkle()
        {
            Console.Clear();
            Console.WriteLine("==== Ürün Ekle ====");
            Console.WriteLine("Mevcut Ürünler:");

            foreach (var urun in urunler)
            {
                Console.WriteLine($"ID: {urun.Id}, Ürün: {urun.Ad}, Fiyat: {urun.Fiyat} TL");
            }

            Console.Write("Sepete eklemek istediğiniz ürünün ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var secilenUrun = urunler.FirstOrDefault(u => u.Id == id);
                if (secilenUrun != null)
                {
                    sepet.Urunler.Add(secilenUrun);
                    Console.WriteLine("Ürün sepete eklendi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün ID'si.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş.");
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void SatinAl()
        {
            Console.Clear();
            if (sepet.Urunler.Count == 0)
            {
                Console.WriteLine("Sepetiniz boş. Satın alma işlemi yapılmaz.");
            }
            else
            {
                Console.WriteLine("==== Satın Alma ====");
                Console.WriteLine($"Toplam Fiyat: {sepet.ToplamFiyat} TL");
                Console.Write("Ödeme yapmak için 'Evet' yazın: ");
                string onay = Console.ReadLine();
                if (onay.ToLower() == "evet")
                {
                    Console.WriteLine("Ödeme başarıyla tamamlandı. Teşekkür ederiz.");
                    sepet.Urunler.Clear(); // Sepeti temizle
                }
                else
                {
                    Console.WriteLine("Ödeme işlemi iptal edildi.");
                }
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
