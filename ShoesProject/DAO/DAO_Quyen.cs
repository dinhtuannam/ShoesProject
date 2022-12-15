using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoesProject.DAO
{
    public class DAO_Quyen
    {
        private static DAO_Quyen instance;

        public static DAO_Quyen Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Quyen();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Quyen(){ }

        public DataTable getAllQuyen()
        {
            string query = "Select * from Quyen";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getQuyenByID(string id)
        {
            string query = "Select * from quyen where idquyen = @id ";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }
        public int addQuyen(string id,string name)
        {
            string query = "insert into quyen values( @id , @name )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name });
        }
        public bool isQuyenIDExist(string id)
        {
            string query = "Select * from quyen where idquyen= @id ";
            object temp = DataProvider.Instance.ExecuteScalar(query, new object[] { id });
            return temp != null;
        }
        public int updateQuyen(string id,string name)
        {
            string query = "update quyen set tenquyen = @name where idquyen = @id ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, id });
        }
       public bool remove(string id)
        {
            string query = "select * from taikhoan where idquyen = @id ";
            string query1 = "Select * from ctq where idquyen = @id ";
            string query2 = "delete from quyen where idquyen = @id ";
            

            if (DataProvider.Instance.ExecuteScalar(query, new object[] { id }) != null || DataProvider.Instance.ExecuteScalar(query1, new object[] { id }) != null)
            {
                return false;
            }
            DataProvider.Instance.ExecuteNonQuery(query2, new object[] { id });
            return true;
        }
    }
}
