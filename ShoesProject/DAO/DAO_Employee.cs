using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShoesProject.DAO
{
    public class DAO_Employee
    {
        string condition = "TAIKHOAN.trangthai != 'unactive' ";
        string selectRow = "Select idNV , tenNV , matkhau , tennhanvien , soDT , diachi , email , trangthai from TAIKHOAN , NHANVIEN ";
        private static DAO_Employee instance;

        public static DAO_Employee Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Employee();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Employee() { }

        public DataTable getAllEmployee()
        {
            string query = selectRow + "where TAIKHOAN.idUser = NHANVIEN.idNV and " + condition;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool deleteAccount(string id)
        {
            int result = 0;
            string query = "update TAIKHOAN set trangthai = 'unactive' where idUser = @id";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

        public bool insertAccount(DTO_Employee item)
        {
            int result = 0;
            string id = GenerateID();
            string query1 = "insert into TAIKHOAN(idUser,tenTK,matkhau,trangthai,idQuyen) values( @id , @username , @pass , @status , @permission )";
            result = DataProvider.Instance.ExecuteNonQuery(query1, new object[] { id, item.Username, item.Password, item.Status, item.Permission });
            string query2 = "insert into NHANVIEN(idNV,tennhanvien,soDT,email,diaChi) values( @id , @fullname , @phone , @email , @address )";
            result = result + DataProvider.Instance.ExecuteNonQuery(query2, new object[] { id, item.Fullname, item.Phone, item.Email, item.Address });
            return result == 2;
        }

        public DataTable Login(string name,string password)
        {
            string query = "Select * from TaiKhoan where tenTK = @tenTK and matkhau = @matkhau ";
            return DataProvider.Instance.ExecuteQuery(query,new object[] {name,password});
        }

        public bool isUserNameExist(string username)
        {
            string query = "Select * from TaiKhoan where tenTK = @tenTK ";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            return dt.Rows.Count > 0;
        }

        public bool Register(DTO_Employee em)
        {   
            int result = 0;
            string id = GenerateID();
            string query = "insert into TaiKhoan(idUser,tenTK,matkhau,trangthai,idQuyen) values( @idUser , @tenTK , @matkhau , 'active' , 'AD' )";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id,em.Username,em.Password });
            string query2 = "insert into NhanVien(idNV,tenNV,soDT,diachi,email) values( @idNV , @tenNV , @soDT , @diachi , @email )";
            result = result + DataProvider.Instance.ExecuteNonQuery(query2, new object[] { id, em.Fullname, em.Phone, em.Address , em.Email });
            return result == 2;
        }

        private string GenerateID()
        {
            Random rnd = new Random();
            string str = "U" + Convert.ToString(rnd.Next(1, 999));
            return str;
        }

        public bool updateAccount(DTO_Employee item)
        {
            int result = 0;
            string query1 = "update TAIKHOAN set tenTK = @username , matkhau = @pass , trangthai = @status , idQuyen = @permission where idUser = @id ";
            result = DataProvider.Instance.ExecuteNonQuery(query1, new object[] { item.Username, item.Password, item.Status, item.Permission, item.Id });
            string query2 = "update NHANVIEN set tennhanvien = @fullname , soDT = @phone , email = @email , diaChi = @address where idNV = @id ";
            result = result + DataProvider.Instance.ExecuteNonQuery(query2, new object[] { item.Fullname, item.Phone, item.Email, item.Address, item.Id });
            return result == 2;
        }

        public DataTable searchAccount(String data, String action)
        {
            string query = "";
            if (action == "Name")
                query = selectRow + " where tenTK like '%" + data + "%' and TAIKHOAN.idUser = NHANVIEN.idNV and " + condition;
            else if (action == "ID")
                query = selectRow + " where idUser like '%" + data + "%' and TAIKHOAN.idUser = NHANVIEN.idNV and " + condition;
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
