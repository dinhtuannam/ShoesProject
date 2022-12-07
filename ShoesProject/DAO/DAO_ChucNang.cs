using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DAO
{
    public class DAO_ChucNang
    {
        private static DAO_ChucNang instance;

        public static DAO_ChucNang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_ChucNang();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_ChucNang() { }

        public DataTable getChucNang()
        {
            string query = "Select * from CHUCNANG";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
