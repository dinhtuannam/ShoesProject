using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
