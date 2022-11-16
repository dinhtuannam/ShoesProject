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
    }
}
