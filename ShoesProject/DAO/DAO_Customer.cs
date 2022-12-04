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
    public class DAO_Customer
    {
        string condition = "TAIKHOAN.trangthai != 'unactive' ";
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

        public bool banAccount(string id)
        {
            int result = 0;
            string query = "update TAIKHOAN set trangthai = 'banned' where idUser = @id";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

        public bool deleteAccount(string id)
        {
            int result = 0;
            string query = "update TAIKHOAN set trangthai = 'unactive' where idUser = @id";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

        public bool insertAccount(DTO_Customer item)
        {
            int result = 0;
            string id = GenerateID();
            string query1 = "insert into TAIKHOAN(idUser,tenTK,matkhau,trangthai,idQuyen) values( @id , @username , @pass , @status , @role )";
            result = DataProvider.Instance.ExecuteNonQuery(query1, new object[] { id , item.Username , item.Password , item.Status , item.Role });
            string query2 = "insert into KHACHHANG(idKH,tenkhachhang,soDT,email,diaChi) values( @id , @fullname , @phone , @email , @address )";
            result = result + DataProvider.Instance.ExecuteNonQuery(query2, new object[] { id, item.Fullname , item.Phone, item.Email, item.Address });
            return result == 2;
        }

        private string GenerateID()
        {
            Random rnd = new Random();
            string str = "U" + Convert.ToString(rnd.Next(1, 999));
            return str;
        }

        public bool updateAccount(DTO_Customer item)
        {
            int result = 0;
            string query1 = "update TAIKHOAN set tenTK = @username , matkhau = @pass , trangthai = @status , idQuyen = @role where idUser = @id ";
            result = DataProvider.Instance.ExecuteNonQuery(query1, new object[] { item.Username, item.Password, item.Status, item.Role , item.Id });
            string query2 = "update KHACHHANG set tenkhachhang = @fullname , soDT = @phone , email = @email , diaChi = @address where idKH = @id ";
            result = result + DataProvider.Instance.ExecuteNonQuery(query2, new object[] { item.Fullname, item.Phone, item.Email, item.Address , item.Id });
            return result == 2;
        }

        public DataTable searchAccount(String data, String action)
        {
            string query = "";
            if (action == "Name")
                query = selectRow + " where tenTK like '%" + data + "%' and TAIKHOAN.idUser = KHACHHANG.idKH and " + condition;
            else if (action == "ID")
                query = selectRow + " where idUser like '%" + data + "%' and TAIKHOAN.idUser = KHACHHANG.idKH and " + condition;
            else if (action == "STATUS")
                query = selectRow + " where trangthai like '%" + data + "%' and TAIKHOAN.idUser = KHACHHANG.idKH and " + condition;
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
