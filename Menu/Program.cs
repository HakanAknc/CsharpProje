using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menüyü tanımlıyoruz
            var menu = new Dictionary<string, Dictionary<string, decimal>>
        {
            { "Başlangıç", new Dictionary<string, decimal>
                {
                    { "Humus", 75.00m },
                    { "Haydari", 80.00m }
                }
            },
            { "Ana Yemek", new Dictionary<string, decimal>
                {
                    { "Güveç", 20.00m },
                    { "Tas Kebabı", 70.00m }
                }
            },
            { "Ara Sıcaklar", new Dictionary<string, decimal>
                {
                    { "Kaşarlı Mantar", 15.00m },
                    { "Avcı Böreği", 25.00m }
                }
            },
            { "İçecekler", new Dictionary<string, decimal>
                {
                    { "Çay", 15.00m },
                    { "Kahve", 20.00m }
                }
            }
        };

            Console.WriteLine("Yemek Menüsü:");

            // Menüyü ekrana yazdırıyoruz
            foreach (var kategori in menu)
            {
                Console.WriteLine($"\n{kategori.Key}");
                foreach (var yemek in kategori.Value)
                {
                    Console.WriteLine($"{yemek.Key}: {yemek.Value} TL");
                }
            }

            // Kullanıcıdan seçim alıyoruz
            Console.WriteLine("\nLütfen bir yemek seçin (örneğin: 'Humus', 'Güveç', 'Çay' vb.):");
            string secim = Console.ReadLine();

            // Seçilen yemeği buluyoruz ve fiyatını ekrana yazdırıyoruz
            bool found = false;
            foreach (var kategori in menu)
            {
                if (kategori.Value.ContainsKey(secim))
                {
                    Console.WriteLine($"\nSeçtiğiniz yemek: {secim}, Fiyat: {kategori.Value[secim]} TL");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Geçersiz yemek seçimi.");
            }
        }
    }
}
