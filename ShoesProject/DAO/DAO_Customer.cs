using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.DAO
{
    public class DAO_Customer
    {
        string condition = "TAIKHOAN.trangthai = 'active' or TAIKHOAN.trangthai = 'banned' ";
        string selectRow = "Select idKH , tenTK , matkhau , tenkhachhang , soDT , diachi , email , trangthai from TAIKHOAN , KHACHHANG ";
        
        private static DAO_Customer instance;

        public static DAO_Customer Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Customer();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Customer() { }

        public DataTable getAllCustomer()
        {
            string query =  selectRow + "where TAIKHOAN.idUser = KHACHHANG.idKH and "+ condition;
            return DataProvider.Instance.ExecuteQuery(query);   
        }
    }
}
