using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.DAO
{
    public class DAO_TKSP
    {
        private static DAO_TKSP instance;

        public static DAO_TKSP Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_TKSP();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_TKSP() { }

        public DataTable getChart()
        {
            string query = "SELECT sum(CTHD.soluong)as TongSoLuong , sum(CTHD.tongtien)as TongTien  , SANPHAM.tenSP as TenSanPham FROM CTHD,HOADON,SANPHAM,THELOAI WHERE sanpham.idTL=theloai.idTL and CTHD.idSP=sanpham.idSP and CTHD.idHD=HOADON.idHD GROUP by sanpham.tenSP";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable filterDate(string month1, string month2, string year1, string year2)
        {
            string date = string.Format(" and HOADON.ngaydat between '{0}-{1}-1 00:00:00' and '{2}-{3}-30 23:59:59' ", year1, month1, year2, month2);
            string query = "SELECT  sum(CTHD.soluong)as TongSoLuong , sum(CTHD.tongtien)as TongTien  , SANPHAM.tenSP as TenSanPham FROM CTHD,HOADON,SANPHAM,THELOAI WHERE sanpham.idTL=theloai.idTL and CTHD.idSP=sanpham.idSP and CTHD.idHD=HOADON.idHD " + date + " GROUP by sanpham.tenSP";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
