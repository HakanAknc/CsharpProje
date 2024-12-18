using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletRezervasyonSistemi
{
    public class Bilet
    {
        public int Id { get; set; }
        public string UcusAdi { get; set; }
        public string Tarih { get; set; }
        public decimal Fiyat { get; set; }
        public bool RezervasyonDurumu { get; set; }
    }
}
