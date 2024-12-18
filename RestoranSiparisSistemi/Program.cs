using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSiparisSistemi
{
    public class Program
    {
        static List<Yemek> menu = new List<Yemek>();
        static List<Siparis> siparisler = new List<Siparis>();
        static void Main(string[] args)
        {
            menu.Add(new Yemek { Id = 1, Ad = "Adana Kebap", Fiyat = 300});
            menu.Add(new Yemek { Id = 2, Ad = "Lahmacun", Fiyat = 200 });
            menu.Add(new Yemek { Id = 3, Ad = "Pide", Fiyat = 100 });

            //menu
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*****  Restorant Sipariş Sistemi  ******");
                Console.WriteLine("1. Menüyü Göster");
                Console.WriteLine("2. Sipariş Ver");
                Console.WriteLine("3. Siparis Detayları");
                Console.WriteLine("4. Toplam Tutar");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçim yapınız : ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        MenuyuGoruntule();
                        break;
                    case "2":
                        SiparsVer();
                        break;
                    case "3":
                        SiparisDetayları();
                        break;
                    case "4":
                        ToplamTutar();
                        break;
                    case "5":
                        Console.WriteLine("Çıkş yapılıyor");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        private static void MenuyuGoruntule()
        {
            Console.Clear();
            Console.WriteLine(" ===  Menü  ====");
            foreach (var yemek in menu)
            {
                Console.WriteLine($"ID: {yemek.Id}, Yemek: {yemek.Ad}, Fiyat: {yemek.Fiyat:C}");
            }
            Console.WriteLine("/nDevam etmek için");
            Console.ReadKey();
        }

        private static void SiparsVer()
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

        private static void SiparisDetayları()
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


        private static void ToplamTutar()
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
