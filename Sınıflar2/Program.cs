using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sınıflar2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.ADI = "Hakan";
            ogr.SOYADI = "Akıncı";
            ogr.ALANI = "Yazılım";
            ogr.YASI = 25;

            Console.WriteLine("Adı: " + ogr.ADI);
            Console.WriteLine("Soyadı: " + ogr.SOYADI);
            Console.WriteLine("Yaşı: " + ogr.YASI);
            Console.WriteLine("Alanı: " + ogr.ALANI);

            Console.Read();
        }
    }
}
