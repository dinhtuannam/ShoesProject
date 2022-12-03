using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoesProject.DAO
{
    public class DAO_Product
    {
        private static DAO_Product instance;

        public static DAO_Product Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Product();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Product() { }

        public DataTable getAllProduct()
        {
            string query = "Select * from sanpham where trangthai = 'active' ";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable searchProduct(String data, String action)
        {
            string query = "";
            if (action == "Name")
                query = "Select * from sanpham where tenSP like '%" + data + "%' and trangthai = 'active'";
            else if (action == "ID")
                query = "Select * from sanpham where idSP like '%" + data + "%' and trangthai = 'active'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool insertProduct(DTO_Product data)
        {
            int result = 0;
            string id = GenerateID();
            string query = "insert into Sanpham(idSP,tenSP,hinhanh,gia,mota,idTL,trangthai,soluong) values( @idUser , @tenSP , @hinhanh , @gia , @mota , @idTL , @trangthai , @soluong )";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, data.Name, data.Img, data.Price, data.Des, data.Genres, data.Status, data.Quantity });
            return result > 0;
        }

        private string GenerateID()
        {
            Random rnd = new Random();
            string str = "S" + Convert.ToString(rnd.Next(1, 9999));
            return str;
        }

        public bool updateProduct(DTO_Product data)
        {
            int result = 0;
            string query = "update Sanpham set tenSP = @tensp , hinhanh = @hinhand , gia = @gia , mota = @mota , idTL = @idTL , trangthai = @trangthai , soluong = @soluong where idSP = @idSP ";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { data.Name, data.Img, data.Price, data.Des, data.Genres, data.Status, data.Quantity, data.Id });
            return result > 0;
        }

        public bool deleteProduct(String id)
        {
            int result = 0;
            string query = "update Sanpham set trangthai = 'unactive' where idSP = @idSP ";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}
