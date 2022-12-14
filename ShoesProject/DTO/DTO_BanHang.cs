using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DTO
{
    public class DTO_BanHang
    {
        private string ID;
        private string Name;
        private string Genres;
        private int Quantity;
        private long Price;

        public DTO_BanHang(string iD, string name, string genres, int quantity, long price)
        {
            ID = iD;
            Name = name;
            Genres = genres;
            Quantity = quantity;
            Price = price;
            
        }

        public DTO_BanHang()
        {
            ID = "";
            Name = "";
            Genres = "";
            Quantity = 0;
            Price = 0;

        }

        public string ID1 { get => ID; set => ID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Genres1 { get => Genres; set => Genres = value; }
        public int Quantity1 { get => Quantity; set => Quantity = value; }
        public long Price1 { get => Price; set => Price = value; }
    }
}
