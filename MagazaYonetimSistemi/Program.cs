using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaYonetimSistemi
{
    public class Program
    {
        static List<Urun> urunler = new List<Urun>();
        static int urunIdSayaci = 1;   //otomatik ıd
        static void Main(string[] args)
        {
            // Örnek ürünler ekle
            urunler.Add(new Urun { Id = urunIdSayaci++, Ad = "Laptop", Fiyat = 5000.0m, StokMiktari = 10 });
            urunler.Add(new Urun { Id = urunIdSayaci++, Ad = "Telefon", Fiyat = 3000.0m, StokMiktari = 25 });
            urunler.Add(new Urun { Id = urunIdSayaci++, Ad = "Kulaklık", Fiyat = 200.0m, StokMiktari = 50 });

            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Mağaza Envanter Yönetim Sistemi ====");
                Console.WriteLine("1. Tüm Ürünleri Görüntüle");
                Console.WriteLine("2. Yeni Ürün Ekle");
                Console.WriteLine("3. Ürün Güncelle");
                Console.WriteLine("4. Ürün Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        TumUrunleriGoruntule();
                        break;
                    case "2":
                        YeniUrunEkle();
                        break;
                    case "3":
                        UrunGuncelle();
                        break;
                    case "4":
                        UrunSil();
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

        static void TumUrunleriGoruntule()
        {
            Console.Clear();
            Console.WriteLine("==== Tüm Ürünler ====");
            foreach (var urun in urunler)
            {
                Console.WriteLine($"ID: {urun.Id}, Ürün Adı: {urun.Ad}, Fiyat: {urun.Fiyat} TL, Stok: {urun.StokMiktari}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void YeniUrunEkle()
        {
            Console.Clear();
            Console.WriteLine("==== Yeni Ürün Ekle ====");
            Console.Write("Ürün adı: ");
            string ad = Console.ReadLine();
            Console.Write("Ürün fiyatı: ");
            decimal fiyat = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Stok miktarı: ");
            int stok = Convert.ToInt32(Console.ReadLine());

            urunler.Add(new Urun { Id = urunIdSayaci++, Ad = ad, Fiyat = fiyat, StokMiktari = stok });
            Console.WriteLine("Yeni ürün başarıyla eklendi!");

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void UrunGuncelle()
        {
            Console.Clear();
            Console.WriteLine("==== Ürün Güncelle ====");
            TumUrunleriGoruntule();

            Console.Write("Güncellemek istediğiniz ürünün ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var urun = urunler.Find(u => u.Id == id);
                if (urun != null)
                {
                    Console.Write("Yeni ürün adı: ");
                    urun.Ad = Console.ReadLine();
                    Console.Write("Yeni fiyat: ");
                    urun.Fiyat = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Yeni stok miktarı: ");
                    urun.StokMiktari = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ürün başarıyla güncellendi!");
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

        static void UrunSil()
        {
            Console.Clear();
            Console.WriteLine("==== Ürün Sil ====");
            TumUrunleriGoruntule();

            Console.Write("Silmek istediğiniz ürünün ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var urun = urunler.Find(u => u.Id == id);
                if (urun != null)
                {
                    urunler.Remove(urun);
                    Console.WriteLine("Ürün başarıyla silindi!");
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
    }
}