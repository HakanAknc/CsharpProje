﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamSistemi
{
    public class Program
    {
        static List<Arac> araclar = new List<Arac>();
        static void Main(string[] args)
        {
            araclar.Add(new Arac { Id = 1, Marka = "Toyota", Model = "Corolla", Yil = 2020, Kirada = false });
            araclar.Add(new Arac { Id = 2, Marka = "Honda", Model = "Civic", Yil = 2021, Kirada = false });
            araclar.Add(new Arac { Id = 3, Marka = "Ford", Model = "Focus", Yil = 2019, Kirada = true });

            //Menu
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Araç Kiralam Sistemi ===");
                Console.WriteLine("1. Araçları Listele");
                Console.WriteLine("2. Araç Kirala");
                Console.WriteLine("3. Araç Ekle");
                Console.WriteLine("4. Araç İade Et");
                Console.WriteLine("5. Kiradaki Araçlar");
                Console.WriteLine("6. Çıkş");
                Console.WriteLine("Seçim yapınız: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        AraclariListele();
                        break;
                    case "2":
                        AracKirala();
                        break;
                    case "3":
                        AracEkle();
                        break;
                    case "4":
                        AracIadeEt();
                        break;
                    case "5":
                        KiradakiAraclar();
                        break;
                    case "6":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }
            }
        }

        public static void KiradakiAraclar()
        {
            Console.Clear();
            Console.WriteLine("=== Kirada ki Araçlar ===");

            AraclariListele();

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();

        }

        public static void AraclariListele()
        {
            Console.Clear();
            Console.WriteLine("=== Mevcut Araçlar ===");

            foreach (var arac in araclar)
            {
                string durum = arac.Kirada ? "Kirada" : "Müsait";
                Console.WriteLine($"ID: {arac.Id}, Marka: {arac.Marka}, Model: {arac.Model}, Yıl: {arac.Yil}, Durum: {durum}");
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        public static void AracKirala()
        {
            Console.Clear();
            Console.WriteLine("==== Araç Kirala ====");
            AraclariListele();

            Console.Write("Kiralamak istediğiniz aracın ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var arac = araclar.Find(a => a.Id == id);
                if (arac != null && !arac.Kirada)
                {
                    arac.Kirada = true;
                    Console.WriteLine($"{arac.Marka} {arac.Model} başarıyla kiralandı.");
                }
                else
                {
                    Console.WriteLine("Bu araç zaten kirada veya bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz ID girdiniz.");
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        public static void AracEkle()
        {
            Console.Clear();
            Console.WriteLine("==== Araç Ekle ====");
            Console.Write("Marka: ");
            string marka = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Yıl: ");
            if (int.TryParse(Console.ReadLine(), out int yil))
            {
                int id = araclar.Count + 1;
                araclar.Add(new Arac { Id = id, Marka = marka, Model = model, Yil = yil, Kirada = false });
                Console.WriteLine("Araç başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz yıl girdiniz.");
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        public static void AracIadeEt()
        {
            Console.Clear();
            Console.WriteLine("==== Araç İade Et ====");
            foreach (var arac in araclar)
            {
                if (arac.Kirada)
                {
                    Console.WriteLine($"ID: {arac.Id}, Marka: {arac.Marka}, Model: {arac.Model}, Yıl: {arac.Yil}");
                }
            }

            Console.Write("İade etmek istediğiniz aracın ID'sini girin: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var arac = araclar.Find(a => a.Id == id);
                if (arac != null && arac.Kirada)
                {
                    arac.Kirada = false;
                    Console.WriteLine($"{arac.Marka} {arac.Model} başarıyla iade edildi.");
                }
                else
                {
                    Console.WriteLine("Bu araç zaten müsait veya bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz ID girdiniz.");
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
