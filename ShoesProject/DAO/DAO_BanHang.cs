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
                query = "Select * from sanpham where tenSP like '%" + data + "%' and trangthai = 'active'";
            else if (action == "ID")
                query = "Select * from sanpham where idSP like '%" + data + "%' and trangthai = 'active'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
