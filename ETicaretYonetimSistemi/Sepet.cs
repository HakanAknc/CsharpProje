using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretYonetimSistemi
{
    public class Sepet
    {
        public List<Urun> Urunler { get; set; } = new List<Urun>();
        public decimal ToplamFiyat { get; set; }
    }
}
