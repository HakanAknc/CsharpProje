using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletRezervasyonSistemi
{
    public class Program
    {
        static List<Bilet> biletler = new List<Bilet>();
        static int biletIdSayaci = 1;
        static void Main(string[] args)
        {
            // Örnek uçuş biletleri ekle
            biletler.Add(new Bilet { Id = biletIdSayaci++, UcusAdi = "İstanbul - Ankara", Tarih = "2024-12-20", Fiyat = 250.0m, RezervasyonDurumu = false });
            biletler.Add(new Bilet { Id = biletIdSayaci++, UcusAdi = "İstanbul - İzmir", Tarih = "2024-12-22", Fiyat = 300.0m, RezervasyonDurumu = false });
            biletler.Add(new Bilet { Id = biletIdSayaci++, UcusAdi = "Ankara - Antalya", Tarih = "2024-12-25", Fiyat = 400.0m, RezervasyonDurumu = false });

            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Bilet Rezervasyon Sistemi ====");
                Console.WriteLine("1. Mevcut Biletleri Görüntüle");
                Console.WriteLine("2. Bilet Rezervasyonu Yap");
                Console.WriteLine("3. Rezervasyonu İptal Et");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        TumBiletleriGoruntule();
                        break;
                    case "2":
                        BiletRezervasyonuYap();
                        break;
                    case "3":
                        RezervasyonIptalEt();
                        break;
                    case "4":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void TumBiletleriGoruntule()
        {
            Console.Clear();
            Console.WriteLine("==== Mevcut Biletler ====");
            foreach (var bilet in biletler)
            {
                string rezervasyonDurumu = bilet.RezervasyonDurumu ? "Rezerve Edildi" : "Boş";
                Console.WriteLine($"ID: {bilet.Id}, Uçuş: {bilet.UcusAdi}, Tarih: {bilet.Tarih}, Fiyat: {bilet.Fiyat} TL, Durum: {rezervasyonDurumu}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void BiletRezervasyonuYap()
        {
            Console.Clear();
            Console.WriteLine("=== Bilet Rezarvasyonu ===");
            TumBiletleriGoruntule();

            Console.Write("Rezarvasyon yapmak istediğiniz biletin ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var bilet = biletler.Find(b => b.Id == id);
                if (bilet != null)
                {
                    if (bilet.RezervasyonDurumu)
                    {
                        Console.WriteLine("Bu bilet zaten rezerve edilmiş.");
                    }
                    else
                    {
                        bilet.RezervasyonDurumu = true;
                        Console.WriteLine("Bilet başarıyla rezerve edildi.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz bilet ID'si.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş.");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        private static void RezervasyonIptalEt()
        {
            Console.Clear();
            Console.WriteLine("==== Rezervasyon İptali ====");
            TumBiletleriGoruntule();

            Console.Write("İptal etmek istediğiniz biletin ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var bilet = biletler.Find(b => b.Id == id);
                if (bilet != null)
                {
                    if (!bilet.RezervasyonDurumu)
                    {
                        Console.WriteLine("Bu bilet zaten rezerve edilmemiş.");
                    }
                    else
                    {
                        bilet.RezervasyonDurumu = false;
                        Console.WriteLine("Bilet rezervasyonu başarıyla iptal edildi!");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz bilet ID'si.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş.");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
