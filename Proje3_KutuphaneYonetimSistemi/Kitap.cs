using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3_KutuphaneYonetimSistemi
{
    class Kitap
    {
        public class Kitap
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public string Yazar { get; set; }
            public int Durum { get; set; }
        }

        // Kitap listesi
        static List<Kitap> kitaplar = new List<Kitap>();
        static int kitapIdSayaci = 1; // Otomatik ID için sayaç

    }
}
