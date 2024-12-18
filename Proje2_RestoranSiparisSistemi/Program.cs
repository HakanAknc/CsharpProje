using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2_RestoranSiparisSistemi
{
    class Program
    {
        //Menüdeki yemekel için
        public class Yemek
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public decimal Fiyat { get; set; }
        }

        public class Siparis
        {
            public int YemekId { get; set; }
            public int Adet { get; set; }
        }

        static List<Yemek> menu = new List<Yemek>();
        static List<Siparis> siparisler = new List<Siparis>();

        static void Main(string[] args)
        {
            // Menüye örnek yemekler ekle
            menu.Add(new Yemek { Id = 1, Ad = "Adana Kebap", Fiyat = 75.00m });
            menu.Add(new Yemek { Id = 2, Ad = "Lahmacun", Fiyat = 25.00m });
            menu.Add(new Yemek { Id = 3, Ad = "İskender", Fiyat = 90.00m });
            menu.Add(new Yemek { Id = 4, Ad = "Çorba", Fiyat = 30.00m });
            menu.Add(new Yemek { Id = 5, Ad = "Tatlı", Fiyat = 40.00m });

            //Ana menü
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Restoran Sipariş Sistemi ====");
                Console.WriteLine("1. Menüyü Görüntüle");
                Console.WriteLine("2. Sipariş Ver");
                Console.WriteLine("3. Sipariş Detayları");
                Console.WriteLine("4. Toplam Tutar");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        MenuyuGoruntule();
                        break;
                    case "2":
                        SiparisVer();
                        break;
                    case "3":
                        SiparisDetaylari();
                        break;
                    case "4":
                        ToplamTutar();
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
        static void MenuyuGoruntule()
        {
            Console.Clear();
            Console.WriteLine("==== Menü ====");
            foreach (var yemek in menu)
            {
                Console.WriteLine($"ID: {yemek.Id}, Yemek: {yemek.Ad}, Fiyat: {yemek.Fiyat:C}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void SiparisVer()
        {
            Console.Clear();
            MenuyuGoruntule();

            Console.Write("Sipariş vermek istediğiniz yemeğin ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int yemekId))
            {
                var yemek = menu.Find(y => y.Id == yemekId);
                if (yemek != null)
                {
                    Console.Write("Kaç adet almak istiyorsunuz?: ");
                    if (int.TryParse(Console.ReadLine(), out int adet) && adet > 0)
                    {
                        siparisler.Add(new Siparis { YemekId = yemekId, Adet = adet });
                        Console.WriteLine($"{adet} adet {yemek.Ad} başarıyla sipariş edildi.");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz adet girdiniz.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz yemek ID'si.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş.");
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void SiparisDetaylari()
        {
            Console.Clear();
            Console.WriteLine("==== Sipariş Detayları ====");
            if (siparisler.Count == 0)
            {
                Console.WriteLine("Henüz sipariş vermediniz.");
            }
            else
            {
                foreach (var siparis in siparisler)
                {
                    var yemek = menu.Find(y => y.Id == siparis.YemekId);
                    Console.WriteLine($"Yemek: {yemek.Ad}, Adet: {siparis.Adet}, Fiyat: {yemek.Fiyat:C}, Toplam: {(yemek.Fiyat * siparis.Adet):C}");
                }
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void ToplamTutar()
        {
            Console.Clear();
            Console.WriteLine("==== Toplam Tutar ====");
            decimal toplamTutar = 0;

            foreach (var siparis in siparisler)
            {
                var yemek = menu.Find(y => y.Id == siparis.YemekId);
                toplamTutar += yemek.Fiyat * siparis.Adet;
            }

            Console.WriteLine($"Toplam Tutar: {toplamTutar:C}");
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}


