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
            string query = "Select * from sanpham";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public DataTable searchProduct(String data,String action)
        {
            string query = "";
            if(action == "Name")
                query = "Select * from sanpham where tenSP like '%"+data+"%' ";
            else if(action == "ID")
                query = "Select * from sanpham where idSP like '%"+data+"%' ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
