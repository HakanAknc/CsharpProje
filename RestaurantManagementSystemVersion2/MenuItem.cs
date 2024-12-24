using System.Collections.Generic;

namespace Restorant
{
    public class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string AnaYemek { get; set; }
        public string Tatli { get; set; }
        public string Icecek { get; set; }


        public List<MenuItem> SubMenu { get; set; }

        public MenuItem(string name, int price, string description, string anayemek, string tatli, string icecek)
        {
            Name = name;
            Price = price;
            Description = description;
            AnaYemek = anayemek;
            Tatli = tatli;
            Icecek = icecek;
            SubMenu = new List<MenuItem>();

        }
    }
}
