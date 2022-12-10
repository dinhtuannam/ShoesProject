using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string query = "update quyen set namequyen = @name where idquyen = @id ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, id });
        }
    }
}
