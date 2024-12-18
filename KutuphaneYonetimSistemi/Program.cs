using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneYonetimSistemi
{
    public class Program
    {
        static List<Kitap> kitaplar = new List<Kitap>();
        static int kitapIdSayaci = 1;
        static void Main(string[] args)
        {
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Sözler", Yazar = "Bediüzzaman Said Nursi", Durum = true});
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Lemalar", Yazar = "Bediüzzaman Said Nursi", Durum = true});
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Şualar", Yazar = "Bediüzzaman Said Nursi", Durum = true});
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Mesnevi", Yazar = "Bediüzzaman Said Nursi", Durum = false});
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Mektubat", Yazar = "Bediüzzaman Said Nursi", Durum = true});
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Küçük Sözler", Yazar = "Bediüzzaman Said Nursi", Durum = false });
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Ayetül Kübra", Yazar = "Bediüzzaman Said Nursi", Durum = true });
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Gençlik Rehberi", Yazar = "Bediüzzaman Said Nursi", Durum = true });
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Hanımlar Rehberi", Yazar = "Bediüzzaman Said Nursi", Durum = true });
            kitaplar.Add(new Kitap { Id = kitapIdSayaci++, Ad = "Haşir", Yazar = "Bediüzzaman Said Nursi", Durum = true });

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

        private static void TumKitaplariGoruntule()
        {
            Console.Clear();
            Console.WriteLine("=== Tüm Kitap Listesi ===");

            foreach (var kitap in kitaplar) 
            {
                Console.WriteLine($"Id: {kitap.Id} Ad: {kitap.Ad} Yazar: {kitap.Yazar} Durum: {kitap.Durum}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        private static void YeniKitapEkle()
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

        private static void KitapOduncAl()
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

        private static void KitapIadeEt()
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
