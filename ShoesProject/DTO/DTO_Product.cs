using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace ShoesProject.DTO
{
    public class DTO_Product
    {
        String id;
        String name;
        String img;
        long price;
        String des;
        String genres;
        String status;
        int quantity;

        public DTO_Product(string id_, string name_, string img_, long price_, string des_, string genres_, string status_, int quantity_)
        {
            id = id_;
            name = name_;
            img = img_;
            price = price_;
            des = des_;
            genres = genres_;
            status = status_;
            quantity = quantity_;
        }

        public DTO_Product()
        {
            id = "";
            name = "";
            img = "";
            price = 0;
            des = "";
            genres = "";
            status = "";
            quantity = 0;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Img { get => img; set => img = value; }
        public long Price { get => price; set => price = value; }
        public string Des { get => des; set => des = value; }
        public string Genres { get => genres; set => genres = value; }
        public string Status { get => status; set => status = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
