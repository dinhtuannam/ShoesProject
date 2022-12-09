using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DAO
{
    public class DAO_Genres
    {
        private static DAO_Genres instance;

        public static DAO_Genres Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Genres();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Genres() { }

        public DataTable getAllGenres()
        {
            string query = "Select * from theloai";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool isGenresIDExist(string id)
        {
            string query = "select * from theloai where idtl = @idtl ";
            object temp = DataProvider.Instance.ExecuteScalar(query, new object[] { id });
            if (temp == null)
            {
                return false;
            }
            return true;
        }
        public int addQLTL(string id, string name, string trangthai)
        {
            string query = "insert into theloai values( @idtheloai , @tentheloai , @trangthai )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, trangthai });
        }

        public int updateQLTL(string id, string name, string trangthai)
        {
            string query = "update theloai set tentl= @name , trangthai = @trangthai where idtl = @idtl ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, trangthai, id });

        }
        public int removeQLTL(string id)
        {
            string query = "delete from theloai where idtl= @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
        public DataTable GetQLTLById(string id)
        {
            string query = "Select * from theloai where idTL = @id ";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });

        }
    }
}
