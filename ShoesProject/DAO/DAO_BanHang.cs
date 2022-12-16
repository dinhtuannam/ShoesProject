using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml.Linq;


namespace ShoesProject.DAO
{
    public class DAO_BanHang 
    {
        private static DAO_BanHang instance;

        public static DAO_BanHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_BanHang();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_BanHang() { }

        public DataTable getAllSanPham()
        {
            string query = "Select idSP, tenSP, idTL, gia, soluong from sanpham theloai where trangthai = 'active' ";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable searchSanPham(String data, String action)
        {
            string query = "";
            if (action == "Name")
                query = "Select idSP, tenSP, idTL, gia, soluong from sanpham where tenSP like '%" + data + "%' and trangthai = 'active'";
            else if (action == "ID")
                query = "Select idSP, tenSP, idTL, gia, soluong from sanpham where idSP like '%" + data + "%' and trangthai = 'active'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool Buy(List<DTO_BanHang> list, long total)
        {
            int result;
            string IDHD = GenerateID();
            for (int i = 0; i < list.Count; i++)
            {
                if (!DAO_Bill.Instance.IsEnough(list[i].ID1, IDHD, list[i].Quantity1))
                {
                    return false;
                }
            }
            string date = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            object IDEmp = DBNull.Value;
            string query = "insert into HOADON(idHD,idNV,idKH,ngaydat,tongtien,trangthai) values( @idHD , @idNV , 'BOT' , @ngaydat , @tongtien , 'unconfirmed' )";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IDHD, IDEmp, date, total });
            for (int i = 0; i < list.Count; i++)
            {
                string query2 = "insert into CTHD(idHD,idSP,soluong,tongtien) values( @idHD , @idSP , @soluong , @tongtien ) ";
                result += DataProvider.Instance.ExecuteNonQuery(query2, new object[] { IDHD, list[i].ID1, list[i].Quantity1, list[i].Price1 });
            }
            return result > 1;
        }

        private string GenerateID()
        {
            Random rnd = new Random();
            string str = "HD" + Convert.ToString(rnd.Next(1, 9999));
            return str;
        }
    }
}
