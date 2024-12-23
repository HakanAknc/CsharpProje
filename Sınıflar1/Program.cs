using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sınıflar1
{
    class Program
    {
        static void Main(string[] args)
        {
            Araba araba1 = new Araba();
            Araba araba2 = new Araba();

            araba1.renk = "Kırmızı";
            araba1.fiyat = 10000;
            araba1.model = "BMW G63";
            araba1.vites = "Otomatik";
            araba1.plaka = "07KNY256";


            araba2.renk = "Sarı";
            araba2.fiyat = 20000;
            araba2.model = "Audi A15";
            araba2.vites = "Otomatik";
            araba2.plaka = "07ANY26";

            Console.WriteLine($"Araba 1 : Renk: {araba1.renk} - Fiyat: {araba1.fiyat} - Model: {araba1.model} - Vites: {araba1.vites} - Plaka: {araba1.plaka}");
            Console.WriteLine();
            Console.WriteLine($"Araba 2 : Renk: {araba2.renk} - Fiyat: {araba2.fiyat} - Model: {araba2.model} - Vites: {araba2.vites} - Plaka: {araba2.plaka}");

            araba1.renk = "Turuncu";
            Console.WriteLine($"Araba 1 : Renk: {araba1.renk} - Fiyat: {araba1.fiyat} - Model: {araba1.model} - Vites: {araba1.vites} - Plaka: {araba1.plaka}");

            Console.Read();
        }
    }
}
