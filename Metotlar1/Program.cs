 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metotlar1
{
    internal class Program
    {
        //private static void veriler()
        //{
        //    Console.WriteLine("Müdür: Hakan Akıncı");
        //    Console.WriteLine("Öğretmen: Yusuf Özbek");
        //    Console.WriteLine("Okul: Necmettin Erbakan");
        //    Console.WriteLine("Şehir: KONYA");
        //}

        //private static void yazdir(string bilgi)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(bilgi);
        //    }
        //}

        private static int Topla(int s1, int s2)
        {
            return s1 + s2;
        }

        private static string Kimlik(string name, string surname, int age)
        {
            return name + surname + age;
        }

        static void Main(string[] args)
        {
            //veriler();
            //veriler();
            //Console.Read();

            //Console.Write("Metin Girin: ");
            //string blg = Console.ReadLine();
            //yazdir(blg);

            //int t = Topla(1, 2);
            //Console.WriteLine("Toplam = " + t);

            string hakan = Kimlik("Hakan", "Akıncı", 20);
            Console.WriteLine(hakan);
             








            Console.Read();
        }
    }
}
