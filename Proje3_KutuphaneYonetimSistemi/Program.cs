using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3_KutuphaneYonetimSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Örnek kitaplar ekle
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Savaş ve Barış", Yazar = "Lev Tolstoy", Durum = true });
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "1984", Yazar = "George Orwell", Durum = true });
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Beyaz Zambaklar Ülkesi", Yazar = "Grigory Petrov", Durum = true });

            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Kütüphane Yönetim Sistemi ====");
                Console.WriteLine("1. Tüm Kitapları Görüntüle");
                Console.WriteLine("2. Yeni Kitap Ekle");
                Console.WriteLine("3. Kitap Ödünç Al");
                Console.WriteLine("4. Kitap İade Et");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        TumKitaplariGoruntule();
                        break;
                    case "2":
                        YeniKitapEkle();
                        break;
                    case "3":
                        KitapOduncAl();
                        break;
                    case "4":
                        KitapIadeEt();
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

        static void TumKitaplariGoruntule()
        {
            Console.Clear();
            Console.WriteLine("==== Tüm Kitaplar ====");
            foreach (var kitap in kitaplar)
            {
                string durum = kitap.Durum ? "Müsait" : "Ödünç Alındı";
                Console.WriteLine($"ID: {kitap.Id}, Kitap: {kitap.Ad}, Yazar: {kitap.Yazar}, Durum: {durum}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void YeniKitapEkle()
        {
            Console.Clear();
            Console.WriteLine("==== Yeni Kitap Ekle ====");
            Console.Write("Kitap adı: ");
            string ad = Console.ReadLine();
            Console.Write("Yazar: ");
            string yazar = Console.ReadLine();

            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = ad, Yazar = yazar, Durum = true });
            Console.WriteLine("Yeni kitap başarıyla eklendi!");

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void KitapOduncAl()
        {
            Console.Clear();
            Console.WriteLine("==== Kitap Ödünç Al ====");
            TumKitaplariGoruntule();

            Console.Write("Ödünç almak istediğiniz kitabın ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var kitap = kitaplar.Find(k => k.Id == id);
                if (kitap != null)
                {
                    if (kitap.Durum)
                    {
                        kitap.Durum = false;
                        Console.WriteLine($"{kitap.Ad} başarıyla ödünç alındı!");
                    }
                    else
                    {
                        Console.WriteLine("Bu kitap zaten ödünç alınmış.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz kitap ID'si.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş.");
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void KitapIadeEt()
        {
            Console.Clear();
            Console.WriteLine("==== Kitap İade Et ====");
            TumKitaplariGoruntule();

            Console.Write("İade etmek istediğiniz kitabın ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var kitap = kitaplar.Find(k => k.Id == id);
                if (kitap != null)
                {
                    if (!kitap.Durum)
                    {
                        kitap.Durum = true;
                        Console.WriteLine($"{kitap.Ad} başarıyla iade edildi!");
                    }
                    else
                    {
                        Console.WriteLine("Bu kitap zaten müsait.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz kitap ID'si.");
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
